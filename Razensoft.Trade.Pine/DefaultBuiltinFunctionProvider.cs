using System;

namespace Razensoft.Trade.Pine
{
    public class DefaultBuiltinFunctionProvider : BuiltinFunctionProvider
    {
        public override object nz(object x, object y)
        {
            return x is PineNA ? y : x;
        }

        public override float max(float x1, float x2)
        {
            return Math.Max(x1, x2);
        }

        public override long max(long x1, long x2)
        {
            return Math.Max(x1, x2);
        }
    }
}