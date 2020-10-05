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
            DeclareVariable("tr", tr);

            DeclareVariable("plot.style_linebr", 0);

            DeclareVariable("color.green", new PineColor());

            DeclareVariable("na", new PineNA());
        }
    }
}