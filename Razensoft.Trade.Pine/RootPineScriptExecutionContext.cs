using System.Reflection;

namespace Razensoft.Trade.Pine.Parsing
{
    public class RootPineScriptExecutionContext : PineScriptExecutionContext
    {
        public RootPineScriptExecutionContext(BuiltinVariableProvider builtinVariableProvider, BuiltinFunctionProvider builtinFunctionProvider)
        {
            var functions = builtinFunctionProvider.GetType()
                .GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
            foreach (var function in functions)
            {
                DeclareFunction(new BuiltinFunction(function, builtinFunctionProvider));
            }

            var variables = builtinVariableProvider.GetType()
                .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
            foreach (var variable in variables)
            {
                DeclareVariable(variable.Name.Replace("__", "."), variable.GetValue(builtinVariableProvider));
            }
        }
    }
}