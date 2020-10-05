using System;
using System.Collections.Generic;

namespace Razensoft.Trade.Pine.Parsing.BuiltinFunctions
{
    public class AverageTrueRange : BuiltinFunction
    {
        public AverageTrueRange() : base("atr", Parameters)
        {
        }

        private static IEnumerable<(string name, object defaultValue)> Parameters
            => new (string name, object defaultValue)[]
            {
                ("length", null)
            };

        protected override object Execute(PineScriptExecutionContext parentContext, Dictionary<string, object> args)
        {
            Console.WriteLine($"Average True Range length {args["length"]}");
            return new PineScriptSeries();
        }
    }
}