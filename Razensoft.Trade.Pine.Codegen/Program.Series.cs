using System.IO;
using System.Text;

namespace Razensoft.Trade.Pine.Codegen
{
    internal static partial class Program
    {
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
    }
}