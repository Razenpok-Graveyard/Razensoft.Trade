using System;
using System.Collections.Generic;

namespace Razensoft.Trade.Pine.Parsing.BuiltinFunctions
{
    public class Barcolor : BuiltinFunction
    {
        public Barcolor() : base("barcolor", Parameters)
        {
        }

        private static IEnumerable<(string name, object defaultValue)> Parameters
            => new (string name, object defaultValue)[]
            {
                ("color", null),
                ("offset", null),
                ("editable", null),
                ("show_last", null),
                ("title", null)
            };

        protected override object Execute(PineScriptExecutionContext parentContext, Dictionary<string, object> args)
        {
            Console.WriteLine("Barcolor");
            return null;
        }
    }
}