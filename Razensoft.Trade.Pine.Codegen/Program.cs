using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HtmlAgilityPack;

namespace Razensoft.Trade.Pine.Codegen
{
    class Program
    {
        private const string htmlPath = "reference.html";
        
        static void Main(string[] args)
        {
            var html = LoadHtml();
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var variablesNode = doc.DocumentNode
                .Descendants("h2")
                .ToList()[1];
            var variables = ProcessVariables(variablesNode.NextSibling);
        }

        private static List<VariableDefinition> ProcessVariables(HtmlNode node)
        {
            return node.ChildNodes
                .Select(child => ProcessVariable(child.FirstChild))
                .ToList();
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
            return new VariableDefinition(name, description, type);
        }

        private static string LoadHtml()
        {
            return File.ReadAllText(htmlPath);
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