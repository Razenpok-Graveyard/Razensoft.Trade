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
    }
}