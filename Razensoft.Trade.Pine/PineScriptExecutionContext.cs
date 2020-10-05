using System;
using System.Collections.Generic;
using Razensoft.Trade.Pine.Statements;

namespace Razensoft.Trade.Pine.Parsing
{
    public class PineScriptExecutionContext
    {
        private readonly PineScriptExecutionContext _parent;
        private readonly Dictionary<string, object> _variables
            = new Dictionary<string, object>();
        private readonly Dictionary<string, PineScriptFunction> _functions
            = new Dictionary<string, PineScriptFunction>();

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
            if (!_functions.ContainsKey(function.Name))
            {
                _functions.Add(function.Name, function);
                return;
            }

            throw new Exception($"Function {function.Name} is already declared.");
        }

        public object CallFunction(string name, object[] positionalArgs, Dictionary<string, object> namedArgs)
        {
            if (_functions.ContainsKey(name))
            {
                var function = _functions[name];
                return function.Execute(this, positionalArgs, namedArgs);
            }

            if (_parent != null)
            {
                return _parent.CallFunction(name, positionalArgs, namedArgs);
            }

            throw new Exception($"Function {name} is not declared.");
        }
    }
}