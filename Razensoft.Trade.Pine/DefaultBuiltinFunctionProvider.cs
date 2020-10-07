namespace Razensoft.Trade.Pine
{
    public class DefaultBuiltinFunctionProvider : BuiltinFunctionProvider
    {
        public override object nz(object x, object y)
        {
            return x is PineNA ? y : x;
        }
    }
}