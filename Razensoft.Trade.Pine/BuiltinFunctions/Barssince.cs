using System;
using System.Collections.Generic;

namespace Razensoft.Trade.Pine.Parsing.BuiltinFunctions
{
    public class Barssince : BuiltinFunction
    {
        public Barssince() : base("barssince", Parameters)
        {
        }

        private static IEnumerable<(string name, object defaultValue)> Parameters
            => new (string name, object defaultValue)[]
            {
                ("condition", null)
            };

        protected override object Execute(PineScriptExecutionContext parentContext, Dictionary<string, object> args)
        {
            Console.WriteLine("Barssince");
            return new PineSeries<int>();
        }
    }
}