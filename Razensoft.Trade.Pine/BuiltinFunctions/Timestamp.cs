using System;
using System.Collections.Generic;

namespace Razensoft.Trade.Pine.Parsing.BuiltinFunctions
{
    public class Timestamp : BuiltinFunction
    {
        public Timestamp() : base("timestamp", Parameters)
        {
        }

        private static IEnumerable<(string name, object defaultValue)> Parameters
            => new (string name, object defaultValue)[]
            {
                ("year", null),
                ("month", null),
                ("day", null),
                ("hour", null),
                ("minute", null),
                ("second", null),
            };

        protected override object Execute(PineScriptExecutionContext parentContext, Dictionary<string, object> args)
        {
            Console.WriteLine("Timestamp");
            return null;
        }
    }
}