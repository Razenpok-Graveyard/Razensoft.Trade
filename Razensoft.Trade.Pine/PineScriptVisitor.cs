using System.Collections.Generic;
using System.Linq;
using Razensoft.Trade.Pine.Statements;

namespace Razensoft.Trade.Pine.Parsing
{
    public class PineScriptVisitor : PineScriptBaseVisitor<IEnumerable<PineScriptStatement>>
    {
        public override IEnumerable<PineScriptStatement> VisitScript(PineScriptParser.ScriptContext context)
        {
            return context.statement()
                .Select((statement, _) =>
                {
                    var visitor = new PineScriptStatementVisitor();
                    return statement.Accept(visitor);
                });
        }
    }
}