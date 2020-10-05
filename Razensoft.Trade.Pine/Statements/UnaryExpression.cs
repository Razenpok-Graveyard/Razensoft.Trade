using System;
using Razensoft.Trade.Pine.Parsing;

namespace Razensoft.Trade.Pine.Statements
{
    public class UnaryExpression : ExpressionStatement
    {
        private readonly PineScriptStatement _expression;
        private readonly Func<object, object> _unaryOperator;

        private UnaryExpression(PineScriptStatement expression, Func<object, object> unaryOperator)
        {
            _expression = expression;
            _unaryOperator = unaryOperator;
        }

        public override object Execute(PineScriptExecutionContext context)
        {
            var value = _expression.Execute(context);
            return _unaryOperator(value);
        }

        public static UnaryExpression Not(PineScriptStatement expression)
            => new UnaryExpression(expression, value => !(bool) value);

        public static UnaryExpression Minus(PineScriptStatement expression)
            => new UnaryExpression(expression, value =>
            {
                if (value is int intValue) return -intValue;
                if (value is float floatValue) return -floatValue;
                throw new Exception("Unknown value type");
            });
    }
}