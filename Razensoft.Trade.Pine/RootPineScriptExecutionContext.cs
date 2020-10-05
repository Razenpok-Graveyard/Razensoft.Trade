using System;
using System.Reflection;
using Razensoft.Trade.Pine.Parsing.BuiltinFunctions;

namespace Razensoft.Trade.Pine.Parsing
{
    public class RootPineScriptExecutionContext : PineScriptExecutionContext
    {
        public RootPineScriptExecutionContext(BuiltinProvider builtinProvider)
        {
            var methods = builtinProvider.GetType()
                .GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
            foreach (var method in methods)
            {
                DeclareFunction(new BuiltinFunction2(method, builtinProvider));
            }

            DeclareFunction(new AverageTrueRange());
            DeclareFunction(new NonZero());
            DeclareFunction(new NATest());
            DeclareFunction(new Plot());
            DeclareFunction(new PlotShape());
            DeclareFunction(new Fill());
            DeclareFunction(new Timestamp());
            DeclareFunction(new Barssince());
            DeclareFunction(new Barcolor());

            DeclareVariable("input.integer", "int");
            DeclareVariable("input.float", "float");
            DeclareVariable("input.bool", "bool");

            var open = new PineSeries<float>();
            var close = new PineSeries<float>();
            var high = new PineSeries<float>();
            var low = new PineSeries<float>();

            DeclareVariable("open", open);
            DeclareVariable("close", close);
            DeclareVariable("high", high);
            DeclareVariable("low", low);
            DeclareVariable("hl2", (high + low) / 2);
            DeclareVariable("ohlc4", (open + high + low + close) / 4);
            DeclareVariable("tr", builtinProvider.tr(false));

            DeclareVariable("plot.style_linebr", 0);
            DeclareVariable("plot.style_circles", 0);

            DeclareVariable("location.absolute", string.Empty);

            DeclareVariable("shape.circle", string.Empty);
            DeclareVariable("shape.labelup", string.Empty);
            DeclareVariable("shape.labeldown", string.Empty);

            DeclareVariable("size.tiny", string.Empty);

            DeclareVariable("color.green", new PineColor());
            DeclareVariable("color.white", new PineColor());
            DeclareVariable("color.red", new PineColor());

            DeclareVariable("na", PineNA.NA);
        }
    }

    public abstract class BuiltinProvider
    {
        public virtual void strategy(
            string title, string shorttitle, bool overlay, string format, int precision, int scale, int pyramiding,
            bool calc_on_order_fills, bool calc_on_every_tick, int max_bars_back, int backtest_fill_limits_assumption,
            string default_qty_type, float default_qty_value, float initial_capital, string currency, int slippage,
            string commission_type, float commission_value, bool process_orders_on_close, string close_entries_rule)
        {
            throw new NotImplementedException();
        }

        public virtual bool input(bool defval, string title, string type, bool confirm)
        {
            throw new NotImplementedException();
        }

        public virtual PineColor input(PineColor defval, string title, string type, bool confirm)
        {
            throw new NotImplementedException();
        }

        public virtual int input(int defval, string title, string type, int minval, int maxval, bool confirm, int step)
        {
            throw new NotImplementedException();
        }

        public virtual float input(float defval, string title, string type, float minval, float maxval, bool confirm,
            float step)
        {
            throw new NotImplementedException();
        }

        public virtual PineSeries<float> tr(bool handle_na)
        {
            throw new NotImplementedException();
        }

        public virtual PineSeries<float> sma(PineSeries<int> source, int length)
        {
            throw new NotImplementedException();
        }

        public virtual PineSeries<float> sma(PineSeries<float> source, int length)
        {
            throw new NotImplementedException();
        }
    }

    public class DefaultBuiltinProvider : BuiltinProvider
    {
        public override void strategy(
            string title, string shorttitle, bool overlay, string format, int precision, int scale, int pyramiding,
            bool calc_on_order_fills, bool calc_on_every_tick, int max_bars_back, int backtest_fill_limits_assumption,
            string default_qty_type, float default_qty_value, float initial_capital, string currency, int slippage,
            string commission_type, float commission_value, bool process_orders_on_close, string close_entries_rule)
        {
            Console.WriteLine($"Strategy {title}");
        }

        public override bool input(bool defval, string title, string type, bool confirm)
        {
            Console.WriteLine($"Input bool {title}");
            return defval;
        }

        public override int input(int defval, string title, string type, int minval, int maxval, bool confirm, int step)
        {
            Console.WriteLine($"Input int {title}");
            return defval;
        }

        public override float input(float defval, string title, string type, float minval, float maxval, bool confirm,
            float step)
        {
            Console.WriteLine($"Input float {title}");
            return defval;
        }

        public override PineSeries<float> tr(bool handle_na)
        {
            Console.WriteLine("tr");
            return new PineSeries<float>();
        }

        public override PineSeries<float> sma(PineSeries<int> source, int length)
        {
            Console.WriteLine($"sma int for {length}");
            return new PineSeries<float>();
        }

        public override PineSeries<float> sma(PineSeries<float> source, int length)
        {
            Console.WriteLine($"sma float for {length}");
            return new PineSeries<float>();
        }
    }
}