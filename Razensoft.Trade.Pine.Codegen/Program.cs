using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace Razensoft.Trade.Pine.Codegen
{
    internal static class Program
    {
        private const string htmlPath = "reference.html";

        private static void Main()
        {
            var html = LoadHtml();
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var variablesNode = doc.DocumentNode
                .Descendants("h2")
                .ToList()[1];
            var variables = ProcessVariables(variablesNode.NextSibling);
            WriteVariables(variables);
            var functionsNode = doc.DocumentNode
                .Descendants("h2")
                .ToList()[2];
            var functions = ProcessFunctions(functionsNode.NextSibling);
            WriteFunctions(functions);
        }

        private static IEnumerable<VariableDefinition> ProcessVariables(HtmlNode node)
        {
            return node.ChildNodes.Select(child => ProcessVariable(child.FirstChild));
        }

        private static VariableDefinition ProcessVariable(HtmlNode node)
        {
            var name = node.Descendants("h3").First().InnerText;
            var divs = node.Descendants("div");
            var description = divs.First().InnerText;

            string GetSectionText(string name)
            {
                var nodes = divs
                    .SkipWhile(n => n.InnerText != name)
                    .Skip(1)
                    .TakeWhile(n => !n.HasClass("tv-pine-reference-item__sub-header"))
                    .Select(n => n.InnerText);
                return string.Join(Environment.NewLine, nodes);
            }

            var type = GetSectionText("Type");
            return new VariableDefinition(name, type, description);
        }

        private static IEnumerable<FunctionDefinition> ProcessFunctions(HtmlNode node)
        {
            return node.ChildNodes.SelectMany(child => ProcessFunction(child.FirstChild));
        }

        private static IEnumerable<FunctionDefinition> ProcessFunction(HtmlNode node)
        {
            var name = node.Descendants("h3").First().InnerText;
            var divs = node.Descendants("div");
            var description = divs.First().InnerText;

            string GetSectionText(string name)
            {
                var nodes = divs
                    .SkipWhile(n => n.InnerText != name)
                    .Skip(1)
                    .TakeWhile(n => !n.HasClass("tv-pine-reference-item__sub-header"))
                    .Select(n => n.InnerText);
                return string.Join(Environment.NewLine, nodes);
            }
            var returns = GetSectionText("Returns");

            var syntaxNodes = divs.Where(n => n.HasClass("tv-pine-reference-item__syntax"));
            foreach (var syntaxNode in syntaxNodes)
            {
                var text = syntaxNode.InnerText;
                var parts = text.Split(" → ");
                if (parts.Length < 2)
                {
                    parts = text.Split(" -&gt; ");
                }
                var parameters = parts[0]
                    .TrimStart(name)
                    .TrimStart("(")
                    .TrimEnd(")")
                    .Split(", ")
                    .Where(p => p != "...")
                    .ToList();
                
                var type = parts[1];
                yield return new FunctionDefinition(name, type, description, returns, parameters);
            }
        }

        private static void WriteVariables(IEnumerable<VariableDefinition> variables)
        {
            var sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine();
            sb.AppendLine("namespace Razensoft.Trade.Pine");
            sb.AppendLine("{");
            sb.AppendLine("    public abstract class BuiltinVariableProvider");
            sb.AppendLine("    {");

            foreach (var variable in variables)
            {
                var indent = "        ";
                var name = variable.Name.Replace(".", "__");
                var type = GetTypeName(variable.Type);
                sb.AppendLine(indent + "/// <summary>");
                foreach (var descriptionChunk in WordWrap(variable.Description, 70))
                {
                    sb.AppendLine(indent + $"/// {descriptionChunk}");
                }

                sb.AppendLine(indent + "/// </summary>");
                sb.AppendLine(indent + $"public virtual {type} {name} => throw new NotImplementedException();");
            }

            sb.AppendLine("    }");
            sb.AppendLine("}");

            var solutionDirectory = GetSolutionDirectory();
            var targetPath = Path.Combine(solutionDirectory, "Razensoft.Trade.Pine", "BuiltinVariableProvider.cs");
            File.WriteAllText(targetPath, sb.ToString());
        }

        private static void WriteFunctions(IEnumerable<FunctionDefinition> functions)
        {
            var sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine();
            sb.AppendLine("namespace Razensoft.Trade.Pine");
            sb.AppendLine("{");
            sb.AppendLine("    public abstract class BuiltinFunctionProvider");
            sb.AppendLine("    {");

            var filteredFunctions = functions.GroupBy(f => f.Name)
                .SelectMany(g => g.DistinctBy(f => f.Parameters.Count));
            foreach (var function in filteredFunctions)
            {
                var indent = "        ";
                var name = function.Name.Replace(".", "__");
                if (!IsValidIdentifier(name))
                {
                    name = $"@{name}";
                }
                var type = GetTypeName(function.Type);
                sb.AppendLine(indent + "/// <summary>");
                foreach (var descriptionChunk in WordWrap(function.Description, 70))
                {
                    sb.AppendLine(indent + $"/// {descriptionChunk}");
                }

                sb.AppendLine(indent + "/// </summary>");
                sb.Append(indent + $"public virtual {type} {name}");
                var parametersString = string.Join(", ", function.Parameters.Select(p => $"object {p}"));
                if (function.Parameters.Count <= 3)
                {
                    sb.AppendLine($"({parametersString})");
                }
                else
                {
                    sb.AppendLine("(");
                    var parameterLine = string.Empty;
                    foreach (var parameter in function.Parameters.Take(function.Parameters.Count - 1))
                    {
                        var parameterName = parameter;
                        if (!IsValidIdentifier(parameterName))
                        {
                            parameterName = $"@{parameterName}";
                        }
                        parameterLine += $"object {parameterName},";
                        if (parameterLine.Length >= 60)
                        {
                            sb.AppendLine(indent + "    " + parameterLine);
                            parameterLine = string.Empty;
                        }
                        else
                        {
                            parameterLine += " ";
                        }
                    }
                    parameterLine += $"object {function.Parameters.Last()})";
                    sb.AppendLine(indent + "    " + parameterLine);
                }
                sb.AppendLine(indent + "{");
                sb.AppendLine(indent + "    throw new NotImplementedException();");
                sb.AppendLine(indent + "}");
            }

            sb.AppendLine("    }");
            sb.AppendLine("}");

            var solutionDirectory = GetSolutionDirectory();
            var targetPath = Path.Combine(solutionDirectory, "Razensoft.Trade.Pine", "BuiltinFunctionProvider.cs");
            File.WriteAllText(targetPath, sb.ToString());
        }

        private static string GetTypeName(string type)
        {
            return type switch
            {
                "void" => "void",
                "na" => "PineNA",
                "const integer" => "int",
                "const float" => "float",
                "const bool" => "bool",
                "const string" => "string",
                "const color" => "PineColor",
                "input integer" => "int",
                "input float" => "float",
                "input bool" => "bool",
                "input string" => "string",
                "input color" => "PineColor",
                "integer" => "int",
                "float" => "float",
                "bool" => "bool",
                "string" => "string",
                "color" => "PineColor",
                "series[integer]" => "PineSeries<int>",
                "series[float]" => "PineSeries<float>",
                "series[bool]" => "PineSeries<bool>",
                "series[string]" => "PineSeries<string>",
                "series[color]" => "PineSeries<PineColor>",
                _ => "object"
            };
        }

        private static string LoadHtml()
        {
            return File.ReadAllText(htmlPath);
        }

        private static string GetSolutionDirectory()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            while (Directory.GetParent(currentDirectory).Name != "Razensoft.Trade")
            {
                currentDirectory = Directory.GetParent(currentDirectory).FullName;
            }

            return Directory.GetParent(currentDirectory).FullName;
        }

        public static List<string> WordWrap(string input, int maxCharacters)
        {
            List<string> lines = new List<string>();

            if (!input.Contains(" "))
            {
                int start = 0;
                while (start < input.Length)
                {
                    lines.Add(input.Substring(start, Math.Min(maxCharacters, input.Length - start)));
                    start += maxCharacters;
                }
            }
            else
            {
                string[] words = input.Split(' ');

                string line = "";
                foreach (string word in words)
                {
                    if ((line + word).Length > maxCharacters)
                    {
                        lines.Add(line.Trim());
                        line = "";
                    }

                    line += $"{word} ";
                }

                if (line.Length > 0)
                {
                    lines.Add(line.Trim());
                }
            }

            return lines;
        }
        
        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> items, Func<T, TKey> property)
        {
            return items.GroupBy(property).Select(x => x.First());
        }

        private static bool IsValidIdentifier(string identifier)
        {
            return !new[]
            {
                "bool",
                "string",
                "long"
            }.Contains(identifier);
        }
    }

    public class VariableDefinition
    {
        public VariableDefinition(string name, string type, string description)
        {
            Name = name;
            Type = type;
            Description = description;
        }

        public string Name { get; }

        public string Type { get; }

        public string Description { get; }
    }

    public class FunctionDefinition
    {
        public FunctionDefinition(
            string name,
            string type,
            string description,
            string returns,
            List<string> parameters)
        {
            Name = name;
            Type = type;
            Description = description;
            Returns = returns;
            Parameters = parameters;
        }

        public string Name { get; }

        public string Type { get; }

        public string Description { get; }

        public string Returns { get; }

        public List<string> Parameters { get; }
    }
    internal static class StringExtensions
    {
        public static string TrimStart(this string target, string trimString)
        {
            if (string.IsNullOrEmpty(trimString)) return target;

            var result = target;
            while (result.StartsWith(trimString))
            {
                result = result.Substring(trimString.Length);
            }

            return result;
        }

        public static string TrimEnd(this string target, string trimString)
        {
            if (string.IsNullOrEmpty(trimString)) return target;

            var result = target;
            while (result.EndsWith(trimString))
            {
                result = result.Substring(0, result.Length - trimString.Length);
            }

            return result;
        }
    }
}