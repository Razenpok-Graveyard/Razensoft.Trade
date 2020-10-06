using NUnit.Framework;

namespace Razensoft.Trade.Pine.Parsing.Tests
{
    public class MainTest
    {
        [Test]
        public void Test1()
        {
            var script = PineScript.FromFile("example.pine");
            var executionContext = new RootPineScriptExecutionContext(new DefaultBuiltinProvider());
            script.Execute(executionContext);
        }
    }
}