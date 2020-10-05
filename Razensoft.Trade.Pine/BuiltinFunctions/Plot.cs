using System;
using System.Collections.Generic;

namespace Razensoft.Trade.Pine.Parsing.BuiltinFunctions
{
    public class Plot : BuiltinFunction
    {
        public Plot() : base("plot", Parameters)
        {
        }

        private static IEnumerable<(string name, object defaultValue)> Parameters
            => new (string name, object defaultValue)[]
            {
                ("series", null),
                ("title", null),
                ("color", null),
                ("linewidth", null),
                ("style", null),
                ("trackprice", null),
                ("transp", null),
                ("histbase", null),
                ("offset", null),
                ("join", null),
                ("editable", null),
                ("show_last", null),
                ("display", null)
            };

        protected override object Execute(PineScriptExecutionContext parentContext, Dictionary<string, object> args)
        {
            Console.WriteLine("Plot");
            return null;
        }
    }
}