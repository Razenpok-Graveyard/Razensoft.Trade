using System;
using System.Collections.Generic;
using System.Linq;
using Razensoft.Trade.Pine.Statements;

namespace Razensoft.Trade.Pine.Parsing
{
    public class UserDefinedFunction : PineScriptFunction
    {
        private readonly PineScriptFunctionParameter[] _parameters;
        private readonly PineScriptStatement _body;

        public UserDefinedFunction(
            string name,
            PineScriptFunctionParameter[] parameters,
            PineScriptStatement body)
            : base(name)
        {
            _parameters = parameters;
            _body = body;
        }

        public override object Execute(
            PineScriptExecutionContext parentContext,
            object[] positionalArgs,
            Dictionary<string, object> namedArgs)
        {
            var context = new PineScriptExecutionContext(parentContext);
            var implicitArgs = _parameters.ToList();
            for (int i = 0; i < positionalArgs.Length; i++)
            {
                var arg = _parameters[i];
                var value = positionalArgs[i];
                context.DeclareVariable(arg.Name, value);
                implicitArgs.Remove(arg);
            }

            foreach (var (name, value) in namedArgs)
            {
                var arg = implicitArgs.Find(a => a.Name == name);
                if (arg == null)
                {
                    throw new Exception($"Unknown function argument \"{name}\" in function \"{Name}\"");
                }
                context.DeclareVariable(name, value);
                implicitArgs.Remove(arg);
            }

            foreach (var arg in implicitArgs)
            {
                context.DeclareVariable(arg.Name, arg.DefaultValue);
            }

            return _body.Execute(context);
        }
    }
}