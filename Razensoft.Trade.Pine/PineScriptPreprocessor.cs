using System;
using System.Linq;

namespace Razensoft.Trade.Pine
{
    public class PineScriptPreprocessor
    {
        private const string EmptyToken = "|EMPTY|";
        private const string BlockBeginToken = "|BEGIN|";
        private const string BlockEndToken = "|END|";

        public static string Preprocess(string script)
        {
            script = script
                .Replace("\r\n", "\n")
                .Replace("\r", "\n");
            var indentLevel = 0;
            return script.Split("\n")
                .Select(RemoveComments)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Aggregate(string.Empty, (line1, line2) =>
                {
                    if (line1 == string.Empty) return line2;

                    if (line2 == EmptyToken)
                    {
                        return line1 + "\n" + line2;
                    }

                    const string indent = "    ";
                    var lineIndentLevel = 0;
                    line2 = line2.Replace("\t", indent);
                    while (line2.StartsWith(indent))
                    {
                        line2 = line2.Substring(indent.Length);
                        lineIndentLevel++;
                    }

                    if (line2.StartsWith(" "))
                    {
                        line2 = line2.TrimStart();
                        return line1 + line2;
                    }

                    if (lineIndentLevel > indentLevel)
                    {
                        indentLevel = lineIndentLevel;
                        return line1 + "\n" + BlockBeginToken + line2;
                    }
                    if (lineIndentLevel < indentLevel)
                    {
                        indentLevel = lineIndentLevel;
                        return line1 + BlockEndToken + "\n" + line2;
                    }

                    return line1 + "\n" + line2;
                });
        }

        private static string RemoveComments(string line)
        {
            var index = line.IndexOf("//", StringComparison.Ordinal);
            return index >= 0 ? line.Substring(0, index) : line;
        }
    }
}