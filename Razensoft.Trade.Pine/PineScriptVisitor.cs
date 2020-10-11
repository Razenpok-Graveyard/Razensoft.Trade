using System.Collections.Generic;
using System.Linq;
using Razensoft.Trade.Pine.Statements;

namespace Razensoft.Trade.Pine
{
    public class PineScriptVisitor : PineScriptBaseVisitor<IEnumerable<PineScriptStatement>>
    {
        public override IEnumerable<PineScriptStatement> VisitStatementList(PineScriptParser.StatementListContext context)
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