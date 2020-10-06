using System;

namespace Razensoft.Trade.Pine.Parsing
{
    public abstract class BuiltinFunctionProvider
    {
        public virtual void strategy(
            string title, string shorttitle, bool overlay, string format, int precision, int scale, int pyramiding,
            bool calc_on_order_fills, bool calc_on_every_tick, int max_bars_back, int backtest_fill_limits_assumption,
            string default_qty_type, float default_qty_value, float initial_capital, string currency, int slippage,
            string commission_type, float commission_value, bool process_orders_on_close, string close_entries_rule)
        {
            throw new NotImplementedException();
        }

        public virtual void strategy__entry(
            string id, bool @long, float qty, float limit, float stop, string oca_name, string oca_type, string comment,
            bool when, string alert_message)
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

        public virtual PineSeries<float> atr(int length)
        {
            throw new NotImplementedException();
        }

        public virtual void barcolor(PineColor color, int offset, bool editable, int show_last, string title)
        {
            throw new NotImplementedException();
        }

        public virtual PineSeries<int> barssince(PineSeries<bool> condition)
        {
            throw new NotImplementedException();
        }

        public virtual void fill(object plot1, object plot2, PineColor color, int transp, string title, bool editable,
            int show_last)
        {
            throw new NotImplementedException();
        }

        public virtual object plot(
            PineSeries<float> series, string title, PineColor color, int linewidth, int style, bool trackprice,
            int transp, float histbase, int offset, bool join, bool editable, int show_last, int display)
        {
            throw new NotImplementedException();
        }

        public virtual bool na(object x)
        {
            throw new NotImplementedException();
        }

        public virtual object nz(object x, object y)
        {
            throw new NotImplementedException();
        }

        public virtual void plotshape(
            PineSeries<float> series, string title, string style, string location, PineColor color, int transp,
            int offset, string text, PineColor textcolor, bool editable, string size, int show_last, int display)
        {
            throw new NotImplementedException();
        }

        public virtual PineSeries<int> timestamp(int year, int month, int day, int hour, int minute, int second)
        {
            throw new NotImplementedException();
        }
    }
}