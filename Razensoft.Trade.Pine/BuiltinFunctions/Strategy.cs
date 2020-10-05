
using System;
using System.Collections.Generic;

namespace Razensoft.Trade.Pine.Parsing.BuiltinFunctions
{
    public class Strategy : BuiltinFunction
    {
        public Strategy() : base("strategy", Parameters)
        {
        }

        private static IEnumerable<(string name, object defaultValue)> Parameters
            => new (string name, object defaultValue)[]
            {
                ("title", null),
                ("overlay", false)
            };

        protected override object Execute(PineScriptExecutionContext parentContext, Dictionary<string, object> args)
        {
            Console.WriteLine($"Strategy {args["title"]} with overlay = {args["overlay"]}");
            return null;
        }
    }
}