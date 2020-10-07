using FluentAssertions;
using NUnit.Framework;

namespace Razensoft.Trade.Pine.Parsing.Tests.Tests
{
    public class SuperTrendTests
    {
        private PineScript _script;

        [SetUp]
        public void Setup()
        {
            _script = PineScript.FromFile("files/SuperTrend STRATEGY.pine");
        }
        
        [Test]
        public void Should_not_call_entry_when_not_appropriate()
        {
            var functionProvider = new StubBuiltinFunctionProvider();
            var variableProvider = new StubBuiltinVariableProvider(functionProvider);
            var executionContext = new RootPineScriptExecutionContext(variableProvider, functionProvider);
            _script.Execute(executionContext);
            functionProvider.EntryId.Should().Be(null);
        }

        private class StubBuiltinFunctionProvider : DefaultBuiltinFunctionProvider
        {
            public string EntryId { get; private set; }
            
            public override int timestamp(object year, object month, object day, object hour, object minute, object second)
            {
                return 0;
            }

            public override PineSeries<int> barssince(object condition)
            {
                return new PineSeries<int>();
            }

            public override object input(
                object defval, object title, object type, object minval,
                object maxval, object confirm, object step, object options)
            {
                return defval;
            }

            public override PineSeries<float> atr(object length)
            {
                return new PineSeries<float>();
            }

            public override PineSeries<float> sma(object source, object length)
            {
                return new PineSeries<float>();
            }

            public override PineSeries<float> tr(object handle_na)
            {
                return new PineSeries<float>();
            }

            public override void strategy__entry(object id, object @long, object qty, object limit, object stop, object oca_name, object oca_type,
                object comment, object when, object alert_message)
            {
                EntryId = (string) id;
            }

            public override void strategy(
                object title, object shorttitle, object overlay, object format, object precision, object scale,
                object pyramiding, object calc_on_order_fills, object calc_on_every_tick, object max_bars_back,
                object backtest_fill_limits_assumption, object default_qty_type, object default_qty_value,
                object initial_capital, object currency, object slippage, object commission_type,
                object commission_value, object process_orders_on_close, object close_entries_rule)
            {
            }

            public override object plot(
                object series, object title, object color, object linewidth, object style, object trackprice,
                object transp, object histbase, object offset, object @join, object editable, object show_last,
                object display)
            {
                return new object();
            }

            public override void plotshape(
                object series, object title, object style, object location, object color, object transp, object offset,
                object text, object textcolor, object editable, object size, object show_last, object display)
            {
            }

            public override void fill(object plot1, object plot2, object color, object transp, object title, object editable, object show_last)
            {
            }

            public override void barcolor(object color, object offset, object editable, object show_last, object title)
            {
            }
        }

        private class StubBuiltinVariableProvider : DefaultBuiltinVariableProvider
        {
            public StubBuiltinVariableProvider(BuiltinFunctionProvider functionProvider)
                : base(functionProvider, null) { }
            
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
        }
    }
}