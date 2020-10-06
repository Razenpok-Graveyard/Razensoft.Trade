using System;

namespace Razensoft.Trade.Pine.Parsing
{
    public class DefaultBuiltinFunctionProvider : BuiltinFunctionProvider
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

        public override PineSeries<float> atr(int length)
        {
            Console.WriteLine($"atr for {length}");
            return new PineSeries<float>();
        }

        public override void barcolor(PineColor color, int offset, bool editable, int show_last, string title)
        {
            Console.WriteLine("barcolor");
        }

        public override PineSeries<int> barssince(PineSeries<bool> condition)
        {
            Console.WriteLine("barssince");
            return new PineSeries<int>();
        }

        public override void fill(object plot1, object plot2, PineColor color, int transp, string title, bool editable,
            int show_last)
        {
            Console.WriteLine("fill");
        }

        public override object plot(PineSeries<float> series, string title, PineColor color, int linewidth, int style,
            bool trackprice, int transp,
            float histbase, int offset, bool @join, bool editable, int show_last, int display)
        {
            Console.WriteLine("plot");
            return new object();
        }

        public override bool na(object x)
        {
            return x is PineNA;
        }

        public override object nz(object x, object y)
        {
            return x is PineNA ? y : x;
        }

        public override void plotshape(
            PineSeries<float> series, string title, string style, string location, PineColor color, int transp,
            int offset, string text, PineColor textcolor, bool editable, string size, int show_last, int display)
        {
            Console.WriteLine("plotshape");
        }

        public override PineSeries<int> timestamp(int year, int month, int day, int hour, int minute, int second)
        {
            return new PineSeries<int>();
        }
    }
}