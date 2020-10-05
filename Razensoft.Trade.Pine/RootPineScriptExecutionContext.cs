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

            DeclareVariable("input.integer", typeof(int));
            DeclareVariable("input.float", typeof(float));
            DeclareVariable("input.bool", typeof(bool));

            var high = new PineScriptSeries();
            var low = new PineScriptSeries();

            DeclareVariable("high", high);
            DeclareVariable("low", low);
            DeclareVariable("hl2", (high + low) / 2);

            // TODO
            DeclareVariable("tr", new PineScriptSeries());
        }
    }
}