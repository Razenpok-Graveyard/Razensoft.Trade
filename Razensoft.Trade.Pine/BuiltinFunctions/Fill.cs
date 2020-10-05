using System;
using System.Collections.Generic;

namespace Razensoft.Trade.Pine.Parsing.BuiltinFunctions
{
    public class Fill : BuiltinFunction
    {
        public Fill() : base("fill", Parameters)
        {
        }

        private static IEnumerable<(string name, object defaultValue)> Parameters
            => new (string name, object defaultValue)[]
            {
                ("plot1", null),
                ("plot2", null),
                ("color", null),
                ("transp", null),
                ("title", null),
                ("editable", null),
                ("show_last", null),
            };

        protected override object Execute(PineScriptExecutionContext parentContext, Dictionary<string, object> args)
        {
            Console.WriteLine("Fill");
            return null;
        }
    }
}