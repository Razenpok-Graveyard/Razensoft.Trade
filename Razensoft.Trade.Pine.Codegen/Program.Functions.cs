using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace Razensoft.Trade.Pine.Codegen
{
    internal static partial class Program
    {
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
    }
}