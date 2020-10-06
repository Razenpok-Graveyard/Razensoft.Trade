using NUnit.Framework;

namespace Razensoft.Trade.Pine.Parsing.Tests
{
    public class MainTest
    {
        [Test]
        public void Test1()
        {
            var script = PineScript.FromFile("example.pine");
            var functionProvider = new DefaultBuiltinFunctionProvider();
            var variableProvider = new DefaultBuiltinVariableProvider(functionProvider);
            var executionContext = new RootPineScriptExecutionContext(variableProvider, functionProvider);
            script.Execute(executionContext);
        }
    }
}