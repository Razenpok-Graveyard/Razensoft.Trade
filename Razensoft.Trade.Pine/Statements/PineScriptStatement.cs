using Razensoft.Trade.Pine.Parsing;

namespace Razensoft.Trade.Pine.Statements
{
    public abstract class PineScriptStatement
    {
        public abstract object Execute(PineScriptExecutionContext context);
    }
}