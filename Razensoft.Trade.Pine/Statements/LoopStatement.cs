using System;
using Razensoft.Trade.Pine.Parsing;

namespace Razensoft.Trade.Pine.Statements
{
    public class LoopStatement : PineScriptStatement
    {
        private readonly PineScriptStatement _counterDeclaration;
        private readonly PineScriptStatement _endValue;
        private readonly PineScriptStatement _body;
        private readonly int _step;

        public LoopStatement(
            PineScriptStatement counterDeclaration,
            PineScriptStatement endValue,
            PineScriptStatement body,
            int step = 1
        )
        {
            _counterDeclaration = counterDeclaration;
            _endValue = endValue;
            _body = body;
            _step = step;
        }

        public override object Execute(PineScriptExecutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}