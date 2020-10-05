using System;

namespace Razensoft.Trade.Pine.Parsing
{
    public class PineScriptSeries
    {
        public object this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public static PineScriptSeries operator +(PineScriptSeries left, PineScriptSeries right)
            => new PineScriptSeries();

        public static PineScriptSeries operator /(PineScriptSeries left, int right)
            => new PineScriptSeries();
    }
}