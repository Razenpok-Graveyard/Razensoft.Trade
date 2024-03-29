﻿using System.Collections.Generic;

namespace Razensoft.Trade.Pine
{
    public abstract class PineScriptFunction
    {
        protected PineScriptFunction(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public abstract bool CanAcceptAsIs(object[] positionalArgs, Dictionary<string, object> namedArgs);

        public abstract bool CanAccept(object[] positionalArgs, Dictionary<string, object> namedArgs);

        public abstract object Execute(
            PineScriptExecutionContext parentContext,
            object[] positionalArgs,
            Dictionary<string, object> namedArgs);
    }
}