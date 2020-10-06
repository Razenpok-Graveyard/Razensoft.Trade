using System.Collections.Generic;
using System.Linq;

namespace Razensoft.Trade.Pine.Statements
{
    public class StatementBlock : PineScriptStatement
    {
        private readonly PineScriptStatement[] _statements;

        public StatementBlock(IEnumerable<PineScriptStatement> statements)
        {
            _statements = statements.ToArray();
        }

        public override object Execute(PineScriptExecutionContext context)
        {
            object lastValue = null;
            foreach (var statement in _statements)
            {
                lastValue = statement.Execute(context);
            }

            return lastValue;
        }
    }
}