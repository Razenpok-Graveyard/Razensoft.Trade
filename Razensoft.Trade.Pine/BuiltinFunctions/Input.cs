using System;
using System.Collections.Generic;

namespace Razensoft.Trade.Pine.Parsing.BuiltinFunctions
{
    public class Input : BuiltinFunction
    {
        public Input() : base("input", Parameters)
        {
        }

        private static IEnumerable<(string name, object defaultValue)> Parameters
            => new (string name, object defaultValue)[]
            {
                ("defval", null),
                ("title", null),
                ("type", typeof(object)),
                ("minval", null),
                ("maxval", null),
                ("confirm", null),
                ("step", null),
                ("options", null)
            };

        protected override object Execute(PineScriptExecutionContext parentContext, Dictionary<string, object> args)
        {
            Console.WriteLine($"Input {args["title"]} of type {args["type"]} with default value {args["defval"]}");
            return args["defval"];
        }
    }
}