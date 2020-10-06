using NUnit.Framework;

namespace Razensoft.Trade.Pine.Parsing.Tests
{
    public class MainTest
    {
        [Test]
        public void Test1()
        {
            var script = PineScript.FromFile("example.pine");
            var functionProvider = new StubBuiltinFunctionProvider();
            var variableProvider = new StubBuiltinVariableProvider();
            var executionContext = new RootPineScriptExecutionContext(variableProvider, functionProvider);
            script.Execute(executionContext);
        }

        private class StubBuiltinFunctionProvider : BuiltinFunctionProvider
        {
            public override void strategy(string title, string shorttitle, bool overlay, string format, int precision, int scale, int pyramiding,
                bool calc_on_order_fills, bool calc_on_every_tick, int max_bars_back, int backtest_fill_limits_assumption,
                string default_qty_type, float default_qty_value, float initial_capital, string currency, int slippage,
                string commission_type, float commission_value, bool process_orders_on_close, string close_entries_rule)
            {
            }
            
            
        }

        private class StubBuiltinVariableProvider : BuiltinVariableProvider
        {
            public override PineSeries<float> close => new PineSeries<float>(new float[]
            {
                1000
            });
        }
    }
}