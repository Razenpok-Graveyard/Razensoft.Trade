using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Tree;

namespace Razensoft.Trade.Pine.Ast
{
    public class PineScriptSymbolTable
    {
        private readonly Dictionary<string, VariableInfo> _variables = new Dictionary<string, VariableInfo>();
        private readonly Dictionary<string, FunctionInfo> _functions = new Dictionary<string, FunctionInfo>();
        private readonly Dictionary<string, List<FunctionOverloadInfo>> _overloads = new Dictionary<string, List<FunctionOverloadInfo>>();

        public void DeclareVariable(string name, PineType type)
        {
            if (_variables.ContainsKey(name))
            {
                throw new Exception($"Variable with name \"{name}\" is already declared");
            }

            _variables.Add(name, new VariableInfo(name, type));
        }

        public VariableInfo GetVariableInfo(string name)
        {
            if (!_variables.ContainsKey(name))
            {
                throw new Exception($"Variable with name \"{name}\" is not declared");
            }

            return _variables[name];
        }

        public void DeclareFunction(string name, IReadOnlyList<string> args, IParseTree body)
        {
            if (_functions.ContainsKey(name))
            {
                throw new Exception($"Function with name \"{name}\" is already declared");
            }

            _functions.Add(name, new FunctionInfo(name, args, body));
        }

        public FunctionOverloadInfo GetFunctionOverload(string name, IReadOnlyList<PineType> args)
        {
            if (!_functions.TryGetValue(name, out var function))
            {
                throw new Exception($"Function {name} is not declared.");
            }
            if (!_overloads.TryGetValue(name, out var overloads))
            {
                overloads = new List<FunctionOverloadInfo>();
                _overloads.Add(name, overloads);
            }

            var overload = overloads.FirstOrDefault(o => o.CanAccept(args));
            if (overload == null)
            {
                var visitor = new PineScriptFunctionOverloadVisitor(this);
                overload = function.Body.Accept(visitor);
                overloads.Add(overload);
            }
            return overload;
        } 
    }
}