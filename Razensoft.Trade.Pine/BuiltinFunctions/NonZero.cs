using System;
using System.Collections.Generic;

namespace Razensoft.Trade.Pine.Parsing.BuiltinFunctions
{
    public class NonZero : BuiltinFunction
    {
        public NonZero() : base("nz", Parameters)
        {
        }

        private static IEnumerable<(string name, object defaultValue)> Parameters
            => new (string name, object defaultValue)[]
            {
                ("x", null),
                ("y", null)
            };

        protected override object Execute(PineScriptExecutionContext parentContext, Dictionary<string, object> args)
        {
            var x = args["x"];
            var y = args["y"];
            Console.WriteLine($"Non Zero x {x} y {y}");
            return x is PineNA ? y : x;
        }
    }
}