namespace Razensoft.Trade.Pine
{
    public interface IHistoricalDataProvider
    {
        public PineSeries<float> Open { get; }
        public PineSeries<float> Close { get; }
        public PineSeries<float> Low { get; }
        public PineSeries<float> High { get; }
    }
}