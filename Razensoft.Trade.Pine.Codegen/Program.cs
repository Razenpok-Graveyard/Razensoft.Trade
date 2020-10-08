using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HtmlAgilityPack;

namespace Razensoft.Trade.Pine.Codegen
{
    internal static partial class Program
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
}