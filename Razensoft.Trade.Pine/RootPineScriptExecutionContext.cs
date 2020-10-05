using Razensoft.Trade.Pine.Parsing.BuiltinFunctions;

namespace Razensoft.Trade.Pine.Parsing
{
    public class RootPineScriptExecutionContext : PineScriptExecutionContext
    {
        public RootPineScriptExecutionContext()
        {
            DeclareFunction(new Strategy());
            DeclareFunction(new Input());
            DeclareFunction(new TrueRange());
            DeclareFunction(new SimpleMovingAverage());
            DeclareFunction(new AverageTrueRange());
            DeclareFunction(new NonZero());
            DeclareFunction(new NATest());
            DeclareFunction(new Plot());
            DeclareFunction(new PlotShape());
            DeclareFunction(new Fill());
            DeclareFunction(new Timestamp());
            DeclareFunction(new Barssince());
            DeclareFunction(new Barcolor());

            DeclareVariable("input.integer", typeof(int));
            DeclareVariable("input.float", typeof(float));
            DeclareVariable("input.bool", typeof(bool));

            var open = new PineSeries<float>();
            var close = new PineSeries<float>();
            var high = new PineSeries<float>();
            var low = new PineSeries<float>();
            var tr = new PineSeries<float>();

            DeclareVariable("open", open);
            DeclareVariable("close", close);
            DeclareVariable("high", high);
            DeclareVariable("low", low);
            DeclareVariable("hl2", (high + low) / 2);
            DeclareVariable("ohlc4", (open + high + low + close) / 4);
            DeclareVariable("tr", tr);

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
}