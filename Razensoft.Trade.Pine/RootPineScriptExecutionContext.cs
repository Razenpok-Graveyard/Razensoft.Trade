using System;
using System.Linq;
using System.Reflection;

namespace Razensoft.Trade.Pine
{
    public class RootPineScriptExecutionContext : PineScriptExecutionContext
    {
        public RootPineScriptExecutionContext(BuiltinVariableProvider builtinVariableProvider, BuiltinFunctionProvider builtinFunctionProvider)
        {
            builtinFunctionProvider.VariableProvider = builtinVariableProvider;
            builtinVariableProvider.FunctionProvider = builtinFunctionProvider;
            DeclareFunctions(builtinFunctionProvider.GetType(), builtinFunctionProvider);
            DeclareVariables(builtinVariableProvider.GetType(), builtinVariableProvider);
        }

        private void DeclareFunctions(Type providerType, object provider)
        {
            var functions = providerType
                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .Where(v => v.DeclaringType != typeof(object) && v.DeclaringType != typeof(BuiltinFunctionProvider));
            foreach (var function in functions)
            {
                DeclareFunction(new BuiltinFunction(function, provider));
            }
        }

        private void DeclareVariables(Type providerType, object provider)
        {
            var variables = providerType
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(v => v.DeclaringType != typeof(object) && v.DeclaringType != typeof(BuiltinVariableProvider));
            foreach (var variable in variables)
            {
                DeclareVariable(variable.Name.Replace("__", "."), variable.GetValue(provider));
            }
        }
    }
}