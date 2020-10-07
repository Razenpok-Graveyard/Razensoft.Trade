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
            WritePineSeriesOperators();
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
            var skip = new[]
            {
                "input", "nz", "max"
            };
            if (skip.Contains(name))
            {
                yield break;
            }

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
            sb.AppendLine("    public abstract partial class BuiltinVariableProvider");
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
            var targetPath = Path.Combine(solutionDirectory, "Razensoft.Trade.Pine",
                "BuiltinVariableProvider.Generated.cs");
            File.WriteAllText(targetPath, sb.ToString());
        }

        private static void WriteFunctions(IEnumerable<FunctionDefinition> functions)
        {
            var sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine();
            sb.AppendLine("namespace Razensoft.Trade.Pine");
            sb.AppendLine("{");
            sb.AppendLine("    public abstract partial class BuiltinFunctionProvider");
            sb.AppendLine("    {");

            var filteredFunctions = functions
                .GroupBy(f => f.Name)
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
                var parametersString = string.Join(", ", function.Parameters.Select(p =>
                {
                    var parameterName = p;
                    if (!IsValidIdentifier(parameterName))
                    {
                        parameterName = $"@{parameterName}";
                    }

                    return $"object {parameterName}";
                }));
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
            var targetPath = Path.Combine(solutionDirectory, "Razensoft.Trade.Pine",
                "BuiltinFunctionProvider.Generated.cs");
            File.WriteAllText(targetPath, sb.ToString());
        }

        public static void WritePineSeriesOperators()
        {
            var sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine();
            sb.AppendLine("namespace Razensoft.Trade.Pine");
            sb.AppendLine("{");

            void WriteCombinatorOperator(
                string name, string @operator, params (string left, string right, string @return)[] overloads)
            {
                foreach (var (left, right, @return) in overloads)
                {
                    sb.AppendLine(
                        $"        public static PineSeries<{@return}> {name}(PineSeries<{left}> left, PineSeries<{right}> right)");
                    sb.AppendLine("        {");
                    sb.AppendLine(
                        $"            return PineSeries<{@return}>.Combine(left, right, (l, r) => l {@operator} r);");
                    sb.AppendLine("        }");
                    sb.AppendLine();
                }
            }

            void WriteCombinatorOperatorOverload(string @operator)
            {
                sb.AppendLine(
                    $"        public static PineSeries<T> operator {@operator}(PineSeries<T> left, PineSeries<T> right)");
                sb.AppendLine("        {");
                sb.AppendLine(
                    $"            return PineSeries<T>.Combine(left, right, (l, r) => (dynamic) l {@operator} (dynamic) r);");
                sb.AppendLine("        }");
                sb.AppendLine();
            }

            void WriteTransformationOperator(
                string name, string @operator, params (string left, string right, string @return)[] overloads)
            {
                foreach (var (left, right, @return) in overloads)
                {
                    sb.AppendLine(
                        $"        public static PineSeries<{@return}> {name}(PineSeries<{left}> left, {right} right)");
                    sb.AppendLine("        {");
                    sb.AppendLine(
                        $"            return PineSeries<{@return}>.Transform(left, v => v {@operator} right);");
                    sb.AppendLine("        }");
                    sb.AppendLine();
                }
            }

            void WriteTransformationOperatorOverload(string @operator)
            {
                sb.AppendLine(
                    $"        public static PineSeries<T> operator {@operator}(PineSeries<T> left, T right)");
                sb.AppendLine("        {");
                sb.AppendLine(
                    $"            return PineSeries<T>.Transform(left, v => (dynamic) v {@operator} (dynamic) right);");
                sb.AppendLine("        }");
                sb.AppendLine();
            }

            void WriteOperators(string className, bool operatorOverloads)
            {
                void WriteOperator(
                    string name, string @operator, params (string left, string right, string @return)[] overloads)
                {
                    if (operatorOverloads)
                    {
                        WriteCombinatorOperatorOverload(@operator);
                        WriteTransformationOperatorOverload(@operator);
                    }
                    else
                    {
                        WriteCombinatorOperator(name, @operator, overloads);
                        WriteTransformationOperator(name, @operator, overloads);
                    }
                }

                sb.AppendLine($"    public partial class {className}");
                sb.AppendLine("    {");

                WriteOperator(
                    "Add", "+",
                    ("long", "long", "long"),
                    ("long", "float", "float"),
                    ("float", "float", "float"),
                    ("float", "long", "float")
                );

                WriteOperator(
                    "Subtract", "-",
                    ("long", "long", "long"),
                    ("long", "float", "float"),
                    ("float", "float", "float"),
                    ("float", "long", "float")
                );

                WriteOperator(
                    "Multiply", "*",
                    ("long", "long", "long"),
                    ("long", "float", "float"),
                    ("float", "float", "float"),
                    ("float", "long", "float")
                );

                WriteOperator(
                    "Divide", "/",
                    ("long", "long", "long"),
                    ("long", "float", "float"),
                    ("float", "float", "float"),
                    ("float", "long", "float")
                );

                WriteOperator(
                    "Modulo", "%",
                    ("long", "long", "long"),
                    ("long", "float", "float"),
                    ("float", "float", "float"),
                    ("float", "long", "float")
                );

                WriteOperator(
                    "GreaterThan", ">",
                    ("long", "long", "bool"),
                    ("long", "float", "bool"),
                    ("float", "float", "bool"),
                    ("float", "long", "bool")
                );

                WriteOperator(
                    "GreaterThanOrEquals", ">=",
                    ("long", "long", "bool"),
                    ("long", "float", "bool"),
                    ("float", "float", "bool"),
                    ("float", "long", "bool")
                );

                WriteOperator(
                    "LowerThan", "<",
                    ("long", "long", "bool"),
                    ("long", "float", "bool"),
                    ("float", "float", "bool"),
                    ("float", "long", "bool")
                );

                WriteOperator(
                    "LowerThanOrEquals", "<=",
                    ("long", "long", "bool"),
                    ("long", "float", "bool"),
                    ("float", "float", "bool"),
                    ("float", "long", "bool")
                );

                WriteOperator(
                    "Equals", "==",
                    ("long", "long", "bool"),
                    ("long", "float", "bool"),
                    ("float", "float", "bool"),
                    ("float", "long", "bool")
                );

                WriteOperator(
                    "NotEquals", "!=",
                    ("long", "long", "bool"),
                    ("long", "float", "bool"),
                    ("float", "float", "bool"),
                    ("float", "long", "bool")
                );

                if (!operatorOverloads)
                {
                    WriteOperator(
                        "And", "&&",
                        ("bool", "bool", "bool")
                    );

                    WriteOperator(
                        "Or", "||",
                        ("bool", "bool", "bool")
                    );
                }


                sb.AppendLine("    }");
            }

            WriteOperators("PineSeries", false);
            WriteOperators("PineSeries<T>", true);
            sb.AppendLine("}");

            var solutionDirectory = GetSolutionDirectory();
            var targetPath = Path.Combine(solutionDirectory, "Razensoft.Trade.Pine", "PineSeries.Generated.cs");
            File.WriteAllText(targetPath, sb.ToString());
        }

        private static string GetTypeName(string type)
        {
            return type switch
            {
                "void" => "void",
                "na" => "PineNA",
                "const integer" => "long",
                "const float" => "float",
                "const bool" => "bool",
                "const string" => "string",
                "const color" => "PineColor",
                "input integer" => "long",
                "input float" => "float",
                "input bool" => "bool",
                "input string" => "string",
                "input color" => "PineColor",
                "integer" => "long",
                "float" => "float",
                "bool" => "bool",
                "string" => "string",
                "color" => "PineColor",
                "series[integer]" => "PineSeries<long>",
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
                "int",
                "char",
                "base",
                "float",
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