using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Razensoft.Trade.Pine.Statements;

namespace Razensoft.Trade.Pine.Parsing
{
    public class PineScriptExecutionContext
    {
        private readonly PineScriptExecutionContext _parent;
        private readonly Dictionary<string, object> _variables
            = new Dictionary<string, object>();
        private readonly Dictionary<string, List<PineScriptFunction>> _functions
            = new Dictionary<string, List<PineScriptFunction>>();

        public PineScriptExecutionContext() : this(null) { }

        public PineScriptExecutionContext(PineScriptExecutionContext parent)
        {
            _parent = parent;
        }

        public void DeclareVariable(string name, object value)
        {
            if (!_variables.ContainsKey(name))
            {
                _variables.Add(name, value);
                return;
            }

            throw new Exception($"Variable {name} is already declared.");
        }

        public void AssignVariable(string name, object value)
        {
            if (_variables.ContainsKey(name))
            {
                var currentValue = _variables[name];
                if (currentValue.GetType() != value.GetType())
                {
                    if (!PineTypeSystem.IsConvertible(value.GetType(), currentValue.GetType()))
                    {
                        throw new InvalidCastException($"Cannot cast {value.GetType()}, to {currentValue.GetType()}");
                    }

                    value = PineTypeSystem.Convert(value, currentValue.GetType());
                }
                _variables[name] = value;
                return;
            }

            if (_parent != null)
            {
                _parent.AssignVariable(name, value);
                return;
            }

            throw new Exception($"Variable {name} is not declared.");
        }

        public object GetVariableValue(string name)
        {
            if (_variables.ContainsKey(name))
            {
                return _variables[name];
            }

            if (_parent != null)
            {
                return _parent.GetVariableValue(name);
            }

            throw new Exception($"Variable {name} is not declared.");
        }

        public void DeclareFunction(PineScriptFunction function)
        {
            if (!_functions.TryGetValue(function.Name, out var list))
            {
                list = new List<PineScriptFunction>();
                _functions.Add(function.Name, list);
            }

            if (!list.Contains(function))
            {
                list.Add(function);
                return;
            }

            throw new Exception($"Function {function.Name} is already declared.");
        }

        public object CallFunction(string name, object[] positionalArgs, Dictionary<string, object> namedArgs)
        {
            if (_functions.TryGetValue(name, out var list))
            {
                foreach (var function in list)
                {
                    if (function.CanAccept(positionalArgs, namedArgs))
                    {
                        return function.Execute(this, positionalArgs, namedArgs);
                    }
                }

                var arguments = positionalArgs
                    .Select(arg => arg.GetType().Name)
                    .ToList();
                arguments.AddRange(namedArgs
                    .Select(kvp => $"{kvp.Key}={kvp.Value.GetType().Name}"));

                throw new Exception($"Cannot call \"{name}\" with arguments ({string.Join(", ", arguments)})");
            }

            if (_parent != null)
            {
                return _parent.CallFunction(name, positionalArgs, namedArgs);
            }

            throw new Exception($"Function {name} is not declared.");
        }
    }
}