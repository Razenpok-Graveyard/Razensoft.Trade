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

        private static void WriteVariables(IEnumerable<VariableDefinition> variables)
        {
            var sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine();
            sb.AppendLine("namespace Razensoft.Trade.Pine.Parsing");
            sb.AppendLine("{");
            sb.AppendLine("    public abstract class BuiltinVariableProvider");
            sb.AppendLine("    {");

            foreach (var variable in variables)
            {
                var indent = "        ";
                var type = variable.Type switch
                {
                    "na" => "PineNA",
                    "const integer" => "int",
                    "const float" => "float",
                    "const bool" => "bool",
                    "const string" => "string",
                    "const color" => "PineColor",
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
                };
                var name = variable.Name.Replace(".", "__");
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
}