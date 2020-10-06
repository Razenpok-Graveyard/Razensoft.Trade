using System;
using System.Collections.Generic;
using System.Linq;

namespace Razensoft.Trade.Pine.Parsing
{
    public abstract class BuiltinFunction : PineScriptFunction
    {
        private readonly PineScriptFunctionParameter[] _parameters;

        protected BuiltinFunction(string name, IEnumerable<(string name, object defaultValue)> parameters) : base(name)
        {
            _parameters = parameters
                .Select(param => new PineScriptFunctionParameter(param.name, param.defaultValue))
                .ToArray();
        }

        public override bool CanAcceptAsIs(object[] positionalArgs, Dictionary<string, object> namedArgs)
        {
            return true;
        }

        public override bool CanAccept(object[] positionalArgs, Dictionary<string, object> namedArgs)
        {
            return true;
        }

        public override object Execute(
            PineScriptExecutionContext parentContext,
            object[] positionalArgs,
            Dictionary<string, object> namedArgs)
        {
            var args = new Dictionary<string, object>();
            var implicitArgs = _parameters.ToList();
            for (int i = 0; i < positionalArgs.Length; i++)
            {
                var arg = _parameters[i];
                var value = positionalArgs[i];
                args.Add(arg.Name, value);
                implicitArgs.Remove(arg);
            }

            foreach (var (name, value) in namedArgs)
            {
                var arg = implicitArgs.Find(a => a.Name == name);
                if (arg == null)
                {
                    throw new Exception($"Unknown function argument \"{name}\" in function \"{Name}\"");
                }
                args.Add(name, value);
                implicitArgs.Remove(arg);
            }

            foreach (var arg in implicitArgs)
            {
                args.Add(arg.Name, arg.DefaultValue);
            }

            return Execute(parentContext, args);
        }

        protected abstract object Execute(PineScriptExecutionContext parentContext, Dictionary<string, object> args);
    }
}