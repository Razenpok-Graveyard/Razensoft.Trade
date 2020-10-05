using System;
using System.Collections.Generic;

namespace Razensoft.Trade.Pine.Parsing.BuiltinFunctions
{
    public class SimpleMovingAverage : BuiltinFunction
    {
        public SimpleMovingAverage() : base("sma", Parameters)
        {
        }

        private static IEnumerable<(string name, object defaultValue)> Parameters
            => new (string name, object defaultValue)[]
            {
                ("source", null),
                ("length", null)
            };

        protected override object Execute(PineScriptExecutionContext parentContext, Dictionary<string, object> args)
        {
            var source = args["source"];
            var length = args["length"];
            Console.WriteLine($"Simple Moving Average source {source} length {length}");
            return new PineScriptSeries();
        }
    }
}