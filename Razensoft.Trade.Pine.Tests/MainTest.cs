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
            public override void strategy(
                object title, object shorttitle, object overlay, object format, object precision, object scale,
                object pyramiding, object calc_on_order_fills, object calc_on_every_tick, object max_bars_back,
                object backtest_fill_limits_assumption, object default_qty_type, object default_qty_value,
                object initial_capital, object currency, object slippage, object commission_type,
                object commission_value, object process_orders_on_close, object close_entries_rule)
            {
            }

            public override object input(
                object defval, object title, object type, object minval,
                object maxval, object confirm, object step, object options)
            {
                return defval;
            }
        }

        private class StubBuiltinVariableProvider : BuiltinVariableProvider
        {
            public override PineSeries<float> open => new PineSeries<float>(new float[]
            {
                1000
            });

            public override PineSeries<float> close => new PineSeries<float>(new float[]
            {
                1200
            });

            public override PineSeries<float> high => new PineSeries<float>(new float[]
            {
                1500
            });

            public override PineSeries<float> low => new PineSeries<float>(new float[]
            {
                800
            });

            public override PineSeries<float> hl2 => (high + low) / 2;

            public override PineSeries<float> ohlc4 => (open + high + low + close) / 4;

            public override string input__integer => "integer";
        }
    }
}