using System;
using System.Collections.Generic;

namespace Razensoft.Trade.Pine.Statements
{
    public class BinaryExpression : ExpressionStatement
    {
        private readonly PineScriptStatement _left;
        private readonly PineScriptStatement _right;
        private readonly BinaryOperation _binaryOperation;

        private BinaryExpression(
            PineScriptStatement left,
            PineScriptStatement right,
            BinaryOperation binaryOperation)
        {
            _left = left;
            _right = right;
            _binaryOperation = binaryOperation;
        }

        public override object Execute(PineScriptExecutionContext context)
        {
            var left = _left.Execute(context);
            var right = _right.Execute(context);
            return _binaryOperation.Execute(left, right);
        }

        public static BinaryExpression Or(PineScriptStatement left, PineScriptStatement right)
            => new BinaryExpression(left, right, BinaryOperation.Or);

        public static BinaryExpression And(PineScriptStatement left, PineScriptStatement right)
            => new BinaryExpression(left, right, BinaryOperation.And);

        public static BinaryExpression Equals(PineScriptStatement left, PineScriptStatement right)
            => new BinaryExpression(left, right, BinaryOperation.Equals);

        public static BinaryExpression NotEquals(PineScriptStatement left, PineScriptStatement right)
            => new BinaryExpression(left, right, BinaryOperation.NotEquals);

        public static BinaryExpression GreaterThan(PineScriptStatement left, PineScriptStatement right)
            => new BinaryExpression(left, right, BinaryOperation.GreaterThan);

        public static BinaryExpression GreaterThanOrEquals(PineScriptStatement left, PineScriptStatement right)
            => new BinaryExpression(left, right, BinaryOperation.GreaterThanOrEquals);

        public static BinaryExpression LowerThan(PineScriptStatement left, PineScriptStatement right)
            => new BinaryExpression(left, right, BinaryOperation.LowerThan);

        public static BinaryExpression LowerThanOrEquals(PineScriptStatement left, PineScriptStatement right)
            => new BinaryExpression(left, right, BinaryOperation.LowerThanOrEquals);

        public static BinaryExpression Add(PineScriptStatement left, PineScriptStatement right)
            => new BinaryExpression(left, right, BinaryOperation.Add);

        public static BinaryExpression Subtract(PineScriptStatement left, PineScriptStatement right)
            => new BinaryExpression(left, right, BinaryOperation.Subtract);

        public static BinaryExpression Multiply(PineScriptStatement left, PineScriptStatement right)
            => new BinaryExpression(left, right, BinaryOperation.Multiply);

        public static BinaryExpression Divide(PineScriptStatement left, PineScriptStatement right)
            => new BinaryExpression(left, right, BinaryOperation.Divide);

        public static BinaryExpression Modulo(PineScriptStatement left, PineScriptStatement right)
            => new BinaryExpression(left, right, BinaryOperation.Modulo);

        private abstract class BinaryOperation
        {
            private Dictionary<Type, Func<object, object, object>> _typeOperations
                = new Dictionary<Type, Func<object, object, object>>();

            protected BinaryOperation()
            {
                _typeOperations.Add(typeof(int), (left, right) => Execute((int) left, (int) right));
                _typeOperations.Add(typeof(float), (left, right) => Execute((float) left, (float) right));
                _typeOperations.Add(typeof(bool), (left, right) => Execute((bool) left, (bool) right));
                _typeOperations.Add(typeof(string), (left, right) => Execute((string) left, (string) right));
                _typeOperations.Add(typeof(PineColor), (left, right) => Execute((PineColor) left, (PineColor) right));
                _typeOperations.Add(typeof(PineSeries<int>), (left, right) => Execute((PineSeries<int>) left, (PineSeries<int>) right));
                _typeOperations.Add(typeof(PineSeries<float>), (left, right) => Execute((PineSeries<float>) left, (PineSeries<float>) right));
                _typeOperations.Add(typeof(PineSeries<bool>), (left, right) => Execute((PineSeries<bool>) left, (PineSeries<bool>) right));
                _typeOperations.Add(typeof(PineSeries<string>), (left, right) => Execute((PineSeries<string>) left, (PineSeries<string>) right));
                _typeOperations.Add(typeof(PineSeries<PineColor>), (left, right) => Execute((PineSeries<PineColor>) left, (PineSeries<PineColor>) right));
            }
            
            public virtual object Execute(object left, object right)
            {
                if (left is PineNA)
                {
                    return left;
                }

                if (right is PineNA)
                {
                    return right;
                }
                var leftType = left.GetType();
                var rightType = right.GetType();
                var targetType = leftType;
                if (leftType != rightType)
                {
                    if (PineTypeSystem.IsConvertible(leftType, rightType))
                    {
                        targetType = rightType;
                        left = PineTypeSystem.Convert(left, rightType);
                    }
                    else if (PineTypeSystem.IsConvertible(rightType, leftType))
                    {
                        right = PineTypeSystem.Convert(right, leftType);
                    }
                    else
                    {
                        throw new Exception($"Types {leftType} and {rightType} are not compatible");
                    }
                }

                if (!_typeOperations.TryGetValue(targetType, out var typeOperation))
                {
                    throw new Exception($"Unknown value type {leftType}");
                }

                return typeOperation.Invoke(left, right);
            }

            protected virtual object Execute(int left, int right)
            {
                throw new NotSupportedException();
            }

            protected virtual object Execute(float left, float right)
            {
                throw new NotSupportedException();
            }

            protected virtual object Execute(bool left, bool right)
            {
                throw new NotSupportedException();
            }

            protected virtual object Execute(string left, string right)
            {
                throw new NotSupportedException();
            }

            protected virtual object Execute(PineColor left, PineColor right)
            {
                throw new NotSupportedException();
            }

            protected virtual object Execute(PineSeries<int> left, PineSeries<int> right)
            {
                throw new NotSupportedException();
            }

            protected virtual object Execute(PineSeries<float> left, PineSeries<float> right)
            {
                throw new NotSupportedException();
            }

            protected virtual object Execute(PineSeries<bool> left, PineSeries<bool> right)
            {
                throw new NotSupportedException();
            }

            protected virtual object Execute(PineSeries<string> left, PineSeries<string> right)
            {
                throw new NotSupportedException();
            }

            protected virtual object Execute(PineSeries<PineColor> left, PineSeries<PineColor> right)
            {
                throw new NotSupportedException();
            }
            
            public static BinaryOperation Or { get; } = new OrOperation();

            private class OrOperation : BinaryOperation
            {
                protected override object Execute(bool left, bool right)
                {
                    return left || right;
                }

                protected override object Execute(PineSeries<bool> left, PineSeries<bool> right)
                {
                    return PineSeries.Or(left, right);
                }
            }
            
            public static BinaryOperation And { get; } = new AndOperation();

            private class AndOperation : BinaryOperation
            {
                protected override object Execute(bool left, bool right)
                {
                    return left && right;
                }

                protected override object Execute(PineSeries<bool> left, PineSeries<bool> right)
                {
                    return PineSeries.And(left, right);
                }
            }
            
            public static BinaryOperation Equals { get; } = new EqualsOperation();

            private class EqualsOperation : BinaryOperation
            {
                protected override object Execute(int left, int right)
                {
                    return left == right;
                }

                protected override object Execute(float left, float right)
                {
                    return left == right;
                }

                protected override object Execute(bool left, bool right)
                {
                    return left == right;
                }

                protected override object Execute(string left, string right)
                {
                    return left == right;
                }

                protected override object Execute(PineColor left, PineColor right)
                {
                    return left == right;
                }

                protected override object Execute(PineSeries<int> left, PineSeries<int> right)
                {
                    return PineSeries.Equals(left, right);
                }

                protected override object Execute(PineSeries<float> left, PineSeries<float> right)
                {
                    return PineSeries.Equals(left, right);
                }
            }
            
            public static BinaryOperation NotEquals { get; } = new NotEqualsOperation();

            private class NotEqualsOperation : BinaryOperation
            {
                protected override object Execute(int left, int right)
                {
                    return left != right;
                }

                protected override object Execute(float left, float right)
                {
                    return left != right;
                }

                protected override object Execute(bool left, bool right)
                {
                    return left != right;
                }

                protected override object Execute(string left, string right)
                {
                    return left != right;
                }

                protected override object Execute(PineColor left, PineColor right)
                {
                    return left != right;
                }

                protected override object Execute(PineSeries<int> left, PineSeries<int> right)
                {
                    return PineSeries.NotEquals(left, right);
                }

                protected override object Execute(PineSeries<float> left, PineSeries<float> right)
                {
                    return PineSeries.NotEquals(left, right);
                }
            }
            
            public static BinaryOperation GreaterThan { get; } = new GreaterThanOperation();

            private class GreaterThanOperation : BinaryOperation
            {
                protected override object Execute(int left, int right)
                {
                    return left > right;
                }

                protected override object Execute(float left, float right)
                {
                    return left > right;
                }

                protected override object Execute(PineSeries<int> left, PineSeries<int> right)
                {
                    return PineSeries.GreaterThan(left, right);
                }

                protected override object Execute(PineSeries<float> left, PineSeries<float> right)
                {
                    return PineSeries.GreaterThan(left, right);
                }
            }
            
            public static BinaryOperation GreaterThanOrEquals { get; } = new GreaterThanOrEqualsOperation();

            private class GreaterThanOrEqualsOperation : BinaryOperation
            {
                protected override object Execute(int left, int right)
                {
                    return left >= right;
                }

                protected override object Execute(float left, float right)
                {
                    return left >= right;
                }

                protected override object Execute(PineSeries<int> left, PineSeries<int> right)
                {
                    return PineSeries.GreaterThanOrEquals(left, right);
                }

                protected override object Execute(PineSeries<float> left, PineSeries<float> right)
                {
                    return PineSeries.GreaterThanOrEquals(left, right);
                }
            }
            
            public static BinaryOperation LowerThan { get; } = new LowerThanOperation();

            private class LowerThanOperation : BinaryOperation
            {
                protected override object Execute(int left, int right)
                {
                    return left < right;
                }

                protected override object Execute(float left, float right)
                {
                    return left < right;
                }

                protected override object Execute(PineSeries<int> left, PineSeries<int> right)
                {
                    return PineSeries.LowerThan(left, right);
                }

                protected override object Execute(PineSeries<float> left, PineSeries<float> right)
                {
                    return PineSeries.LowerThan(left, right);
                }
            }
            
            public static BinaryOperation LowerThanOrEquals { get; } = new LowerThanOrEqualsOperation();

            private class LowerThanOrEqualsOperation : BinaryOperation
            {
                protected override object Execute(int left, int right)
                {
                    return left <= right;
                }

                protected override object Execute(float left, float right)
                {
                    return left <= right;
                }

                protected override object Execute(PineSeries<int> left, PineSeries<int> right)
                {
                    return PineSeries.LowerThanOrEquals(left, right);
                }

                protected override object Execute(PineSeries<float> left, PineSeries<float> right)
                {
                    return PineSeries.LowerThanOrEquals(left, right);
                }
            }
            
            public static BinaryOperation Add { get; } = new AddOperation();

            private class AddOperation : BinaryOperation
            {
                protected override object Execute(int left, int right)
                {
                    return left + right;
                }

                protected override object Execute(float left, float right)
                {
                    return left + right;
                }

                protected override object Execute(PineSeries<int> left, PineSeries<int> right)
                {
                    return PineSeries.Add(left, right);
                }

                protected override object Execute(PineSeries<float> left, PineSeries<float> right)
                {
                    return PineSeries.Add(left, right);
                }
            }
            
            public static BinaryOperation Subtract { get; } = new SubtractOperation();

            private class SubtractOperation : BinaryOperation
            {
                protected override object Execute(int left, int right)
                {
                    return left - right;
                }

                protected override object Execute(float left, float right)
                {
                    return left - right;
                }

                protected override object Execute(PineSeries<int> left, PineSeries<int> right)
                {
                    return PineSeries.Subtract(left, right);
                }

                protected override object Execute(PineSeries<float> left, PineSeries<float> right)
                {
                    return PineSeries.Subtract(left, right);
                }
            }
            
            public static BinaryOperation Multiply { get; } = new MultiplyOperation();

            private class MultiplyOperation : BinaryOperation
            {
                protected override object Execute(int left, int right)
                {
                    return left * right;
                }

                protected override object Execute(float left, float right)
                {
                    return left * right;
                }

                protected override object Execute(PineSeries<int> left, PineSeries<int> right)
                {
                    return PineSeries.Multiply(left, right);
                }

                protected override object Execute(PineSeries<float> left, PineSeries<float> right)
                {
                    return PineSeries.Multiply(left, right);
                }
            }
            
            public static BinaryOperation Divide { get; } = new DivideOperation();

            private class DivideOperation : BinaryOperation
            {
                protected override object Execute(int left, int right)
                {
                    return left / right;
                }

                protected override object Execute(float left, float right)
                {
                    return left / right;
                }

                protected override object Execute(PineSeries<int> left, PineSeries<int> right)
                {
                    return PineSeries.Divide(left, right);
                }

                protected override object Execute(PineSeries<float> left, PineSeries<float> right)
                {
                    return PineSeries.Divide(left, right);
                }
            }
            
            public static BinaryOperation Modulo { get; } = new ModuloOperation();

            private class ModuloOperation : BinaryOperation
            {
                protected override object Execute(int left, int right)
                {
                    return left % right;
                }

                protected override object Execute(float left, float right)
                {
                    return left % right;
                }

                protected override object Execute(PineSeries<int> left, PineSeries<int> right)
                {
                    return PineSeries.Modulo(left, right);
                }

                protected override object Execute(PineSeries<float> left, PineSeries<float> right)
                {
                    return PineSeries.Modulo(left, right);
                }
            }
        }
    }
}