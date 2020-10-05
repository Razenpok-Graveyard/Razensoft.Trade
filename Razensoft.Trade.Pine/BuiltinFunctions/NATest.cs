using System;
using System.Collections.Generic;

namespace Razensoft.Trade.Pine.Parsing.BuiltinFunctions
{
    public class NATest : BuiltinFunction
    {
        public NATest() : base("na", Parameters)
        {
        }

        private static IEnumerable<(string name, object defaultValue)> Parameters
            => new (string name, object defaultValue)[]
            {
                ("x", null)
            };

        protected override object Execute(PineScriptExecutionContext parentContext, Dictionary<string, object> args)
        {
            var x = args["x"];
            Console.WriteLine($"NA Test x {x}");
            return x is PineNA;
        }
    }
}