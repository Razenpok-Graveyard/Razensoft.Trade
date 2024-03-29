﻿namespace Razensoft.Trade.Pine.Statements
{
    public class SeriesAccessExpression : ExpressionStatement
    {
        private readonly PineScriptStatement _expression;
        private readonly PineScriptStatement _index;

        public SeriesAccessExpression(PineScriptStatement expression, PineScriptStatement index)
        {
            _expression = expression;
            _index = index;
        }

        public override object Execute(PineScriptExecutionContext context)
        {
            // TODO
            var maybeSeries = _expression.Execute(context);
            if (!(maybeSeries is PineSeries series))
            {
                return maybeSeries;
            }
            var index = (int) (long) _index.Execute(context);
            return series[index];

        }
    }
}