namespace Razensoft.Trade.Pine.Statements
{
    public class TernaryExpression : PineScriptStatement
    {
        private readonly PineScriptStatement _condition;
        private readonly PineScriptStatement _truthyExpression;
        private readonly PineScriptStatement _falsyExpression;

        public TernaryExpression(
            PineScriptStatement condition,
            PineScriptStatement truthyExpression,
            PineScriptStatement falsyExpression)
        {
            _condition = condition;
            _truthyExpression = truthyExpression;
            _falsyExpression = falsyExpression;
        }

        public override object Execute(PineScriptExecutionContext context)
        {
            var conditionObject = _condition.Execute(context);
            bool condition;
            if (conditionObject is PineSeries<bool> series)
            {
                condition = (bool) PineTypeSystem.Convert(series[0], typeof(bool));
            }
            else
            {
                condition = (bool) PineTypeSystem.Convert(conditionObject, typeof(bool));
            }
            var executingExpression = condition ? _truthyExpression : _falsyExpression;
            return executingExpression.Execute(context);
        }
    }
}