using System;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Razensoft.Trade.Pine.Parsing.Tests.Tests
{
    public class SuperTrendTests
    {
        private PineScript _script;

        [SetUp]
        public void Setup()
        {
            _script = PineScript.FromFile("files/SuperTrend STRATEGY/script.pine");
        }

        [Test]
        public void Should_not_call_entry_when_not_appropriate()
        {
            var data = HistoricalData.FromFile("files/SuperTrend STRATEGY/SELL.json");
            for (var i = 0; i < data.Length; i++)
            {
                data.Position = i;
                var functionProvider = new StubBuiltinFunctionProvider();
                var variableProvider = new DefaultBuiltinVariableProvider(data);
                var executionContext = new RootPineScriptExecutionContext(variableProvider, functionProvider);
                _script.Execute(executionContext);
                functionProvider.EntryId.Should().Be(null);
            }
        }

        private class StubBuiltinFunctionProvider : DefaultBuiltinFunctionProvider
        {
            public string EntryId { get; private set; }

            public override long timestamp(object year, object month, object day, object hour, object minute,
                object second)
            {
                var dateTimeOffset = new DateTimeOffset(
                    year == null ? 0 : (int) (long) year,
                    month == null ? 0 : (int) (long) month,
                    day == null ? 0 : (int) (long) day,
                    hour == null ? 0 : (int) (long) hour,
                    minute == null ? 0 : (int) (long) minute,
                    second == null ? 0 : (int) (long) second,
                    TimeSpan.Zero);
                return dateTimeOffset.ToUnixTimeMilliseconds();
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

            public override PineSeries<float> rma(object source, object length)
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

            public override void strategy__entry(object id, object @long, object qty, object limit, object stop,
                object oca_name, object oca_type,
                object comment, object when, object alert_message)
            {
                if (EntryId != null)
                {
                    Assert.Fail();
                }

                EntryId = (string) id;
            }

            public override void strategy(
                object title, object shorttitle, object overlay, object format, object precision, object scale,
                object pyramiding, object calc_on_order_fills, object calc_on_every_tick, object max_bars_back,
                object backtest_fill_limits_assumption, object default_qty_type, object default_qty_value,
                object initial_capital, object currency, object slippage, object commission_type,
                object commission_value, object process_orders_on_close, object close_entries_rule) { }

            public override object plot(
                object series, object title, object color, object linewidth, object style, object trackprice,
                object transp, object histbase, object offset, object @join, object editable, object show_last,
                object display)
            {
                return new object();
            }

            public override void plotshape(
                object series, object title, object style, object location, object color, object transp, object offset,
                object text, object textcolor, object editable, object size, object show_last, object display) { }

            public override void fill(object plot1, object plot2, object color, object transp, object title,
                object editable, object show_last) { }

            public override void barcolor(object color, object offset, object editable, object show_last,
                object title) { }

            public override PineSeries<long> barssince(object condition)
            {
                return new PineSeries<long>();
            }
        }

        private class HistoricalData : IHistoricalDataProvider
        {
            private readonly List<float> _open;
            private readonly List<float> _close;
            private readonly List<float> _low;
            private readonly List<float> _high;
            private int _position;

            public HistoricalData(List<float> open, List<float> close, List<float> low, List<float> high)
            {
                _open = open;
                _close = close;
                _low = low;
                _high = high;
                Length = open.Count;
                Position = 0;
            }

            public int Length { get; }

            public PineSeries<float> Open { get; private set; }
            public PineSeries<float> Close { get; private set; }
            public PineSeries<float> Low { get; private set; }
            public PineSeries<float> High { get; private set; }

            public int Position
            {
                get => _position;
                set
                {
                    _position = value;
                    Open = new PineSeries<float>(_open, Position);
                    Close = new PineSeries<float>(_close, Position);
                    Low = new PineSeries<float>(_low, Position);
                    High = new PineSeries<float>(_high, Position);
                }
            }

            public static HistoricalData FromFile(string path)
            {
                var json = File.ReadAllText(path);
                var jArray = JArray.Parse(json);
                var open = new List<float>();
                var close = new List<float>();
                var high = new List<float>();
                var low = new List<float>();
                foreach (var jToken in jArray)
                {
                    var candleArray = (JArray) jToken;
                    open.Add(float.Parse(candleArray[1].ToString()));
                    high.Add(float.Parse(candleArray[2].ToString()));
                    low.Add(float.Parse(candleArray[3].ToString()));
                    close.Add(float.Parse(candleArray[4].ToString()));
                }

                return new HistoricalData(open, close, high, low);
            }
        }
    }
}