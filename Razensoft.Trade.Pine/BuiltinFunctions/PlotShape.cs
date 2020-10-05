using System;
using System.Collections.Generic;

namespace Razensoft.Trade.Pine.Parsing.BuiltinFunctions
{
    public class PlotShape : BuiltinFunction
    {
        public PlotShape() : base("plotshape", Parameters)
        {
        }

        private static IEnumerable<(string name, object defaultValue)> Parameters
            => new (string name, object defaultValue)[]
            {
                ("series", null),
                ("title", null),
                ("style", null),
                ("location", null),
                ("color", null),
                ("transp", null),
                ("offset", null),
                ("text", null),
                ("textcolor", null),
                ("editable", null),
                ("size", null),
                ("show_last", null),
                ("display", null),
            };

        protected override object Execute(PineScriptExecutionContext parentContext, Dictionary<string, object> args)
        {
            Console.WriteLine("PlotShape");
            return null;
        }
    }
}