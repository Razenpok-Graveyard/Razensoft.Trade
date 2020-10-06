namespace Razensoft.Trade.Pine.Parsing
{
    public class DefaultBuiltinVariableProvider : BuiltinVariableProvider
    {
        private readonly BuiltinFunctionProvider _functionProvider;
        private readonly IHistoricalDataProvider _historicalDataProvider;

        public DefaultBuiltinVariableProvider(
            BuiltinFunctionProvider functionProvider,
            IHistoricalDataProvider historicalDataProvider)
        {
            _functionProvider = functionProvider;
            _historicalDataProvider = historicalDataProvider;
        }

        public override PineNA na => PineNA.NA;

        public override string input__integer => string.Empty;
        public override string input__float => string.Empty;
        public override string input__bool => string.Empty;

        public override int plot__style_linebr => 0;
        public override int plot__style_circles => 0;

        public override string location__absolute => string.Empty;

        public override string shape__circle => string.Empty;
        public override string shape__labelup => string.Empty;
        public override string shape__labeldown => string.Empty;

        public override string size__tiny => string.Empty;

        public override PineColor color__green => new PineColor();
        public override PineColor color__white => new PineColor();
        public override PineColor color__red => new PineColor();

        public override PineSeries<float> open => _historicalDataProvider.Open;
        public override PineSeries<float> close => _historicalDataProvider.Close;
        public override PineSeries<float> high => _historicalDataProvider.High;
        public override PineSeries<float> low => _historicalDataProvider.Low;
        public override PineSeries<float> hl2 => (high + low) / 2;
        public override PineSeries<float> ohlc4 => (open + high + low + close) / 4;
        public override PineSeries<float> tr => _functionProvider.tr(false);
    }
}