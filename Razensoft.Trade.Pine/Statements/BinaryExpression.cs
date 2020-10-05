using System;
using Razensoft.Trade.Pine.Parsing;

namespace Razensoft.Trade.Pine.Statements
{
    public class BinaryExpression : ExpressionStatement
    {
        private readonly PineScriptStatement _left;
        private readonly PineScriptStatement _right;
        private readonly Func<object, object, object> _binaryOperator;

        private BinaryExpression(
            PineScriptStatement left,
            PineScriptStatement right,
            Func<object, object, object> binaryOperator)
        {
            _left = left;
            _right = right;
            _binaryOperator = binaryOperator;
        }

        public override object Execute(PineScriptExecutionContext context)
        {
            var left = _left.Execute(context);
            var right = _right.Execute(context);
            return _binaryOperator(left, right);
        }

        public static BinaryExpression Or(PineScriptStatement left, PineScriptStatement right)
            => new BinaryExpression(left, right, (left, right) => (bool) left || (bool) right);

        public static BinaryExpression And(PineScriptStatement left, PineScriptStatement right)
            => new BinaryExpression(left, right, (left, right) => (bool) left && (bool) right);

        public static BinaryExpression Equals(PineScriptStatement left, PineScriptStatement right)
            => new BinaryExpression(left, right, (left, right) => left.Equals(right));

        public static BinaryExpression NotEquals(PineScriptStatement left, PineScriptStatement right)
            => new BinaryExpression(left, right, (left, right) => !left.Equals(right));

        public static BinaryExpression GreaterThan(PineScriptStatement left, PineScriptStatement right)
            => new BinaryExpression(left, right, (left, right) =>
            {
                if (left is float || right is float)
                {
                    return (float) left > (float) right;
                }
                if (left is int && right is int)
                {
                    return (int) left > (int) right;
                }
                throw new Exception("Unknown value types");
            });

        public static BinaryExpression GreaterThanOrEquals(PineScriptStatement left, PineScriptStatement right)
            => new BinaryExpression(left, right, (left, right) =>
            {
                if (left is float || right is float)
                {
                    return (float) left >= (float) right;
                }
                if (left is int && right is int)
                {
                    return (int) left >= (int) right;
                }
                throw new Exception("Unknown value types");
            });

        public static BinaryExpression LowerThan(PineScriptStatement left, PineScriptStatement right)
            => new BinaryExpression(left, right, (left, right) =>
            {
                if (left is float || right is float)
                {
                    return (float) left < (float) right;
                }
                if (left is int && right is int)
                {
                    return (int) left < (int) right;
                }
                throw new Exception("Unknown value types");
            });

        public static BinaryExpression LowerThanOrEquals(PineScriptStatement left, PineScriptStatement right)
            => new BinaryExpression(left, right, (left, right) =>
            {
                if (left is float || right is float)
                {
                    return (float) left <= (float) right;
                }
                if (left is int && right is int)
                {
                    return (int) left <= (int) right;
                }
                throw new Exception("Unknown value types");
            });

        public static BinaryExpression Add(PineScriptStatement left, PineScriptStatement right)
            => new BinaryExpression(left, right, (left, right) =>
            {
                if (left is float || right is float)
                {
                    return (float) left + (float) right;
                }
                if (left is int && right is int)
                {
                    return (int) left + (int) right;
                }
                throw new Exception("Unknown value types");
            });

        public static BinaryExpression Subtract(PineScriptStatement left, PineScriptStatement right)
            => new BinaryExpression(left, right, (left, right) =>
            {
                if (left is float || right is float)
                {
                    return (float) left - (float) right;
                }
                if (left is int && right is int)
                {
                    return (int) left - (int) right;
                }
                throw new Exception("Unknown value types");
            });

        public static BinaryExpression Multiply(PineScriptStatement left, PineScriptStatement right)
            => new BinaryExpression(left, right, (left, right) =>
            {
                if (left is float || right is float)
                {
                    return (float) left * (float) right;
                }
                if (left is int && right is int)
                {
                    return (int) left * (int) right;
                }
                throw new Exception("Unknown value types");
            });

        public static BinaryExpression Divide(PineScriptStatement left, PineScriptStatement right)
            => new BinaryExpression(left, right, (left, right) =>
            {
                if (left is float || right is float)
                {
                    return (float) left / (float) right;
                }
                if (left is int && right is int)
                {
                    return (int) left / (int) right;
                }
                throw new Exception("Unknown value types");
            });

        public static BinaryExpression Modulo(PineScriptStatement left, PineScriptStatement right)
            => new BinaryExpression(left, right, (left, right) =>
            {
                if (left is float || right is float)
                {
                    return (float) left % (float) right;
                }
                if (left is int && right is int)
                {
                    return (int) left % (int) right;
                }
                throw new Exception("Unknown value types");
            });
    }
}