using System;

namespace Razensoft.Trade.Pine
{
    public partial class PineSeries<T>
    {
        public static PineSeries<int> Add(PineSeries<int> left, PineSeries<int> right)
        {
            return new CombinationSeries<int, int, int>(left, right, (l, r) => l + r);
        }

        public static PineSeries<int> operator +(PineSeries<int> left, PineSeries<int> right)
        {
            return new CombinationSeries<int, int, int>(left, right, (l, r) => l + r);
        }

        public static PineSeries<float> Add(PineSeries<int> left, PineSeries<float> right)
        {
            return new CombinationSeries<int, float, float>(left, right, (l, r) => l + r);
        }

        public static PineSeries<float> operator +(PineSeries<int> left, PineSeries<float> right)
        {
            return new CombinationSeries<int, float, float>(left, right, (l, r) => l + r);
        }

        public static PineSeries<float> Add(PineSeries<float> left, PineSeries<float> right)
        {
            return new CombinationSeries<float, float, float>(left, right, (l, r) => l + r);
        }

        public static PineSeries<float> operator +(PineSeries<float> left, PineSeries<float> right)
        {
            return new CombinationSeries<float, float, float>(left, right, (l, r) => l + r);
        }

        public static PineSeries<float> Add(PineSeries<float> left, PineSeries<int> right)
        {
            return new CombinationSeries<float, int, float>(left, right, (l, r) => l + r);
        }

        public static PineSeries<float> operator +(PineSeries<float> left, PineSeries<int> right)
        {
            return new CombinationSeries<float, int, float>(left, right, (l, r) => l + r);
        }

        public static PineSeries<int> Add(PineSeries<int> left, int right)
        {
            return new TransformationSeries<int, int>(left, v => v + right);
        }

        public static PineSeries<int> operator +(PineSeries<int> left, int right)
        {
            return new TransformationSeries<int, int>(left, v => v + right);
        }

        public static PineSeries<float> Add(PineSeries<int> left, float right)
        {
            return new TransformationSeries<int, float>(left, v => v + right);
        }

        public static PineSeries<float> operator +(PineSeries<int> left, float right)
        {
            return new TransformationSeries<int, float>(left, v => v + right);
        }

        public static PineSeries<float> Add(PineSeries<float> left, float right)
        {
            return new TransformationSeries<float, float>(left, v => v + right);
        }

        public static PineSeries<float> operator +(PineSeries<float> left, float right)
        {
            return new TransformationSeries<float, float>(left, v => v + right);
        }

        public static PineSeries<float> Add(PineSeries<float> left, int right)
        {
            return new TransformationSeries<float, float>(left, v => v + right);
        }

        public static PineSeries<float> operator +(PineSeries<float> left, int right)
        {
            return new TransformationSeries<float, float>(left, v => v + right);
        }

        public static PineSeries<int> Subtract(PineSeries<int> left, PineSeries<int> right)
        {
            return new CombinationSeries<int, int, int>(left, right, (l, r) => l - r);
        }

        public static PineSeries<int> operator -(PineSeries<int> left, PineSeries<int> right)
        {
            return new CombinationSeries<int, int, int>(left, right, (l, r) => l - r);
        }

        public static PineSeries<float> Subtract(PineSeries<int> left, PineSeries<float> right)
        {
            return new CombinationSeries<int, float, float>(left, right, (l, r) => l - r);
        }

        public static PineSeries<float> operator -(PineSeries<int> left, PineSeries<float> right)
        {
            return new CombinationSeries<int, float, float>(left, right, (l, r) => l - r);
        }

        public static PineSeries<float> Subtract(PineSeries<float> left, PineSeries<float> right)
        {
            return new CombinationSeries<float, float, float>(left, right, (l, r) => l - r);
        }

        public static PineSeries<float> operator -(PineSeries<float> left, PineSeries<float> right)
        {
            return new CombinationSeries<float, float, float>(left, right, (l, r) => l - r);
        }

        public static PineSeries<float> Subtract(PineSeries<float> left, PineSeries<int> right)
        {
            return new CombinationSeries<float, int, float>(left, right, (l, r) => l - r);
        }

        public static PineSeries<float> operator -(PineSeries<float> left, PineSeries<int> right)
        {
            return new CombinationSeries<float, int, float>(left, right, (l, r) => l - r);
        }

        public static PineSeries<int> Subtract(PineSeries<int> left, int right)
        {
            return new TransformationSeries<int, int>(left, v => v - right);
        }

        public static PineSeries<int> operator -(PineSeries<int> left, int right)
        {
            return new TransformationSeries<int, int>(left, v => v - right);
        }

        public static PineSeries<float> Subtract(PineSeries<int> left, float right)
        {
            return new TransformationSeries<int, float>(left, v => v - right);
        }

        public static PineSeries<float> operator -(PineSeries<int> left, float right)
        {
            return new TransformationSeries<int, float>(left, v => v - right);
        }

        public static PineSeries<float> Subtract(PineSeries<float> left, float right)
        {
            return new TransformationSeries<float, float>(left, v => v - right);
        }

        public static PineSeries<float> operator -(PineSeries<float> left, float right)
        {
            return new TransformationSeries<float, float>(left, v => v - right);
        }

        public static PineSeries<float> Subtract(PineSeries<float> left, int right)
        {
            return new TransformationSeries<float, float>(left, v => v - right);
        }

        public static PineSeries<float> operator -(PineSeries<float> left, int right)
        {
            return new TransformationSeries<float, float>(left, v => v - right);
        }

        public static PineSeries<int> Multiply(PineSeries<int> left, PineSeries<int> right)
        {
            return new CombinationSeries<int, int, int>(left, right, (l, r) => l * r);
        }

        public static PineSeries<int> operator *(PineSeries<int> left, PineSeries<int> right)
        {
            return new CombinationSeries<int, int, int>(left, right, (l, r) => l * r);
        }

        public static PineSeries<float> Multiply(PineSeries<int> left, PineSeries<float> right)
        {
            return new CombinationSeries<int, float, float>(left, right, (l, r) => l * r);
        }

        public static PineSeries<float> operator *(PineSeries<int> left, PineSeries<float> right)
        {
            return new CombinationSeries<int, float, float>(left, right, (l, r) => l * r);
        }

        public static PineSeries<float> Multiply(PineSeries<float> left, PineSeries<float> right)
        {
            return new CombinationSeries<float, float, float>(left, right, (l, r) => l * r);
        }

        public static PineSeries<float> operator *(PineSeries<float> left, PineSeries<float> right)
        {
            return new CombinationSeries<float, float, float>(left, right, (l, r) => l * r);
        }

        public static PineSeries<float> Multiply(PineSeries<float> left, PineSeries<int> right)
        {
            return new CombinationSeries<float, int, float>(left, right, (l, r) => l * r);
        }

        public static PineSeries<float> operator *(PineSeries<float> left, PineSeries<int> right)
        {
            return new CombinationSeries<float, int, float>(left, right, (l, r) => l * r);
        }

        public static PineSeries<int> Multiply(PineSeries<int> left, int right)
        {
            return new TransformationSeries<int, int>(left, v => v * right);
        }

        public static PineSeries<int> operator *(PineSeries<int> left, int right)
        {
            return new TransformationSeries<int, int>(left, v => v * right);
        }

        public static PineSeries<float> Multiply(PineSeries<int> left, float right)
        {
            return new TransformationSeries<int, float>(left, v => v * right);
        }

        public static PineSeries<float> operator *(PineSeries<int> left, float right)
        {
            return new TransformationSeries<int, float>(left, v => v * right);
        }

        public static PineSeries<float> Multiply(PineSeries<float> left, float right)
        {
            return new TransformationSeries<float, float>(left, v => v * right);
        }

        public static PineSeries<float> operator *(PineSeries<float> left, float right)
        {
            return new TransformationSeries<float, float>(left, v => v * right);
        }

        public static PineSeries<float> Multiply(PineSeries<float> left, int right)
        {
            return new TransformationSeries<float, float>(left, v => v * right);
        }

        public static PineSeries<float> operator *(PineSeries<float> left, int right)
        {
            return new TransformationSeries<float, float>(left, v => v * right);
        }

        public static PineSeries<float> Divide(PineSeries<int> left, PineSeries<int> right)
        {
            return new CombinationSeries<int, int, float>(left, right, (l, r) => l / r);
        }

        public static PineSeries<float> operator /(PineSeries<int> left, PineSeries<int> right)
        {
            return new CombinationSeries<int, int, float>(left, right, (l, r) => l / r);
        }

        public static PineSeries<float> Divide(PineSeries<int> left, PineSeries<float> right)
        {
            return new CombinationSeries<int, float, float>(left, right, (l, r) => l / r);
        }

        public static PineSeries<float> operator /(PineSeries<int> left, PineSeries<float> right)
        {
            return new CombinationSeries<int, float, float>(left, right, (l, r) => l / r);
        }

        public static PineSeries<float> Divide(PineSeries<float> left, PineSeries<float> right)
        {
            return new CombinationSeries<float, float, float>(left, right, (l, r) => l / r);
        }

        public static PineSeries<float> operator /(PineSeries<float> left, PineSeries<float> right)
        {
            return new CombinationSeries<float, float, float>(left, right, (l, r) => l / r);
        }

        public static PineSeries<float> Divide(PineSeries<float> left, PineSeries<int> right)
        {
            return new CombinationSeries<float, int, float>(left, right, (l, r) => l / r);
        }

        public static PineSeries<float> operator /(PineSeries<float> left, PineSeries<int> right)
        {
            return new CombinationSeries<float, int, float>(left, right, (l, r) => l / r);
        }

        public static PineSeries<float> Divide(PineSeries<int> left, int right)
        {
            return new TransformationSeries<int, float>(left, v => v / right);
        }

        public static PineSeries<float> operator /(PineSeries<int> left, int right)
        {
            return new TransformationSeries<int, float>(left, v => v / right);
        }

        public static PineSeries<float> Divide(PineSeries<int> left, float right)
        {
            return new TransformationSeries<int, float>(left, v => v / right);
        }

        public static PineSeries<float> operator /(PineSeries<int> left, float right)
        {
            return new TransformationSeries<int, float>(left, v => v / right);
        }

        public static PineSeries<float> Divide(PineSeries<float> left, float right)
        {
            return new TransformationSeries<float, float>(left, v => v / right);
        }

        public static PineSeries<float> operator /(PineSeries<float> left, float right)
        {
            return new TransformationSeries<float, float>(left, v => v / right);
        }

        public static PineSeries<float> Divide(PineSeries<float> left, int right)
        {
            return new TransformationSeries<float, float>(left, v => v / right);
        }

        public static PineSeries<float> operator /(PineSeries<float> left, int right)
        {
            return new TransformationSeries<float, float>(left, v => v / right);
        }

        public static PineSeries<bool> GreaterThan(PineSeries<int> left, PineSeries<int> right)
        {
            return new CombinationSeries<int, int, bool>(left, right, (l, r) => l > r);
        }

        public static PineSeries<bool> operator >(PineSeries<int> left, PineSeries<int> right)
        {
            return new CombinationSeries<int, int, bool>(left, right, (l, r) => l > r);
        }

        public static PineSeries<bool> GreaterThan(PineSeries<int> left, PineSeries<float> right)
        {
            return new CombinationSeries<int, float, bool>(left, right, (l, r) => l > r);
        }

        public static PineSeries<bool> operator >(PineSeries<int> left, PineSeries<float> right)
        {
            return new CombinationSeries<int, float, bool>(left, right, (l, r) => l > r);
        }

        public static PineSeries<bool> GreaterThan(PineSeries<float> left, PineSeries<float> right)
        {
            return new CombinationSeries<float, float, bool>(left, right, (l, r) => l > r);
        }

        public static PineSeries<bool> operator >(PineSeries<float> left, PineSeries<float> right)
        {
            return new CombinationSeries<float, float, bool>(left, right, (l, r) => l > r);
        }

        public static PineSeries<bool> GreaterThan(PineSeries<float> left, PineSeries<int> right)
        {
            return new CombinationSeries<float, int, bool>(left, right, (l, r) => l > r);
        }

        public static PineSeries<bool> operator >(PineSeries<float> left, PineSeries<int> right)
        {
            return new CombinationSeries<float, int, bool>(left, right, (l, r) => l > r);
        }

        public static PineSeries<bool> GreaterThan(PineSeries<int> left, int right)
        {
            return new TransformationSeries<int, bool>(left, v => v > right);
        }

        public static PineSeries<bool> operator >(PineSeries<int> left, int right)
        {
            return new TransformationSeries<int, bool>(left, v => v > right);
        }

        public static PineSeries<bool> GreaterThan(PineSeries<int> left, float right)
        {
            return new TransformationSeries<int, bool>(left, v => v > right);
        }

        public static PineSeries<bool> operator >(PineSeries<int> left, float right)
        {
            return new TransformationSeries<int, bool>(left, v => v > right);
        }

        public static PineSeries<bool> GreaterThan(PineSeries<float> left, float right)
        {
            return new TransformationSeries<float, bool>(left, v => v > right);
        }

        public static PineSeries<bool> operator >(PineSeries<float> left, float right)
        {
            return new TransformationSeries<float, bool>(left, v => v > right);
        }

        public static PineSeries<bool> GreaterThan(PineSeries<float> left, int right)
        {
            return new TransformationSeries<float, bool>(left, v => v > right);
        }

        public static PineSeries<bool> operator >(PineSeries<float> left, int right)
        {
            return new TransformationSeries<float, bool>(left, v => v > right);
        }

        public static PineSeries<bool> GreaterThanOrEquals(PineSeries<int> left, PineSeries<int> right)
        {
            return new CombinationSeries<int, int, bool>(left, right, (l, r) => l >= r);
        }

        public static PineSeries<bool> operator >=(PineSeries<int> left, PineSeries<int> right)
        {
            return new CombinationSeries<int, int, bool>(left, right, (l, r) => l >= r);
        }

        public static PineSeries<bool> GreaterThanOrEquals(PineSeries<int> left, PineSeries<float> right)
        {
            return new CombinationSeries<int, float, bool>(left, right, (l, r) => l >= r);
        }

        public static PineSeries<bool> operator >=(PineSeries<int> left, PineSeries<float> right)
        {
            return new CombinationSeries<int, float, bool>(left, right, (l, r) => l >= r);
        }

        public static PineSeries<bool> GreaterThanOrEquals(PineSeries<float> left, PineSeries<float> right)
        {
            return new CombinationSeries<float, float, bool>(left, right, (l, r) => l >= r);
        }

        public static PineSeries<bool> operator >=(PineSeries<float> left, PineSeries<float> right)
        {
            return new CombinationSeries<float, float, bool>(left, right, (l, r) => l >= r);
        }

        public static PineSeries<bool> GreaterThanOrEquals(PineSeries<float> left, PineSeries<int> right)
        {
            return new CombinationSeries<float, int, bool>(left, right, (l, r) => l >= r);
        }

        public static PineSeries<bool> operator >=(PineSeries<float> left, PineSeries<int> right)
        {
            return new CombinationSeries<float, int, bool>(left, right, (l, r) => l >= r);
        }

        public static PineSeries<bool> GreaterThanOrEquals(PineSeries<int> left, int right)
        {
            return new TransformationSeries<int, bool>(left, v => v >= right);
        }

        public static PineSeries<bool> operator >=(PineSeries<int> left, int right)
        {
            return new TransformationSeries<int, bool>(left, v => v >= right);
        }

        public static PineSeries<bool> GreaterThanOrEquals(PineSeries<int> left, float right)
        {
            return new TransformationSeries<int, bool>(left, v => v >= right);
        }

        public static PineSeries<bool> operator >=(PineSeries<int> left, float right)
        {
            return new TransformationSeries<int, bool>(left, v => v >= right);
        }

        public static PineSeries<bool> GreaterThanOrEquals(PineSeries<float> left, float right)
        {
            return new TransformationSeries<float, bool>(left, v => v >= right);
        }

        public static PineSeries<bool> operator >=(PineSeries<float> left, float right)
        {
            return new TransformationSeries<float, bool>(left, v => v >= right);
        }

        public static PineSeries<bool> GreaterThanOrEquals(PineSeries<float> left, int right)
        {
            return new TransformationSeries<float, bool>(left, v => v >= right);
        }

        public static PineSeries<bool> operator >=(PineSeries<float> left, int right)
        {
            return new TransformationSeries<float, bool>(left, v => v >= right);
        }

        public static PineSeries<bool> LowerThan(PineSeries<int> left, PineSeries<int> right)
        {
            return new CombinationSeries<int, int, bool>(left, right, (l, r) => l < r);
        }

        public static PineSeries<bool> operator <(PineSeries<int> left, PineSeries<int> right)
        {
            return new CombinationSeries<int, int, bool>(left, right, (l, r) => l < r);
        }

        public static PineSeries<bool> LowerThan(PineSeries<int> left, PineSeries<float> right)
        {
            return new CombinationSeries<int, float, bool>(left, right, (l, r) => l < r);
        }

        public static PineSeries<bool> operator <(PineSeries<int> left, PineSeries<float> right)
        {
            return new CombinationSeries<int, float, bool>(left, right, (l, r) => l < r);
        }

        public static PineSeries<bool> LowerThan(PineSeries<float> left, PineSeries<float> right)
        {
            return new CombinationSeries<float, float, bool>(left, right, (l, r) => l < r);
        }

        public static PineSeries<bool> operator <(PineSeries<float> left, PineSeries<float> right)
        {
            return new CombinationSeries<float, float, bool>(left, right, (l, r) => l < r);
        }

        public static PineSeries<bool> LowerThan(PineSeries<float> left, PineSeries<int> right)
        {
            return new CombinationSeries<float, int, bool>(left, right, (l, r) => l < r);
        }

        public static PineSeries<bool> operator <(PineSeries<float> left, PineSeries<int> right)
        {
            return new CombinationSeries<float, int, bool>(left, right, (l, r) => l < r);
        }

        public static PineSeries<bool> LowerThan(PineSeries<int> left, int right)
        {
            return new TransformationSeries<int, bool>(left, v => v < right);
        }

        public static PineSeries<bool> operator <(PineSeries<int> left, int right)
        {
            return new TransformationSeries<int, bool>(left, v => v < right);
        }

        public static PineSeries<bool> LowerThan(PineSeries<int> left, float right)
        {
            return new TransformationSeries<int, bool>(left, v => v < right);
        }

        public static PineSeries<bool> operator <(PineSeries<int> left, float right)
        {
            return new TransformationSeries<int, bool>(left, v => v < right);
        }

        public static PineSeries<bool> LowerThan(PineSeries<float> left, float right)
        {
            return new TransformationSeries<float, bool>(left, v => v < right);
        }

        public static PineSeries<bool> operator <(PineSeries<float> left, float right)
        {
            return new TransformationSeries<float, bool>(left, v => v < right);
        }

        public static PineSeries<bool> LowerThan(PineSeries<float> left, int right)
        {
            return new TransformationSeries<float, bool>(left, v => v < right);
        }

        public static PineSeries<bool> operator <(PineSeries<float> left, int right)
        {
            return new TransformationSeries<float, bool>(left, v => v < right);
        }

        public static PineSeries<bool> LowerThanOrEquals(PineSeries<int> left, PineSeries<int> right)
        {
            return new CombinationSeries<int, int, bool>(left, right, (l, r) => l <= r);
        }

        public static PineSeries<bool> operator <=(PineSeries<int> left, PineSeries<int> right)
        {
            return new CombinationSeries<int, int, bool>(left, right, (l, r) => l <= r);
        }

        public static PineSeries<bool> LowerThanOrEquals(PineSeries<int> left, PineSeries<float> right)
        {
            return new CombinationSeries<int, float, bool>(left, right, (l, r) => l <= r);
        }

        public static PineSeries<bool> operator <=(PineSeries<int> left, PineSeries<float> right)
        {
            return new CombinationSeries<int, float, bool>(left, right, (l, r) => l <= r);
        }

        public static PineSeries<bool> LowerThanOrEquals(PineSeries<float> left, PineSeries<float> right)
        {
            return new CombinationSeries<float, float, bool>(left, right, (l, r) => l <= r);
        }

        public static PineSeries<bool> operator <=(PineSeries<float> left, PineSeries<float> right)
        {
            return new CombinationSeries<float, float, bool>(left, right, (l, r) => l <= r);
        }

        public static PineSeries<bool> LowerThanOrEquals(PineSeries<float> left, PineSeries<int> right)
        {
            return new CombinationSeries<float, int, bool>(left, right, (l, r) => l <= r);
        }

        public static PineSeries<bool> operator <=(PineSeries<float> left, PineSeries<int> right)
        {
            return new CombinationSeries<float, int, bool>(left, right, (l, r) => l <= r);
        }

        public static PineSeries<bool> LowerThanOrEquals(PineSeries<int> left, int right)
        {
            return new TransformationSeries<int, bool>(left, v => v <= right);
        }

        public static PineSeries<bool> operator <=(PineSeries<int> left, int right)
        {
            return new TransformationSeries<int, bool>(left, v => v <= right);
        }

        public static PineSeries<bool> LowerThanOrEquals(PineSeries<int> left, float right)
        {
            return new TransformationSeries<int, bool>(left, v => v <= right);
        }

        public static PineSeries<bool> operator <=(PineSeries<int> left, float right)
        {
            return new TransformationSeries<int, bool>(left, v => v <= right);
        }

        public static PineSeries<bool> LowerThanOrEquals(PineSeries<float> left, float right)
        {
            return new TransformationSeries<float, bool>(left, v => v <= right);
        }

        public static PineSeries<bool> operator <=(PineSeries<float> left, float right)
        {
            return new TransformationSeries<float, bool>(left, v => v <= right);
        }

        public static PineSeries<bool> LowerThanOrEquals(PineSeries<float> left, int right)
        {
            return new TransformationSeries<float, bool>(left, v => v <= right);
        }

        public static PineSeries<bool> operator <=(PineSeries<float> left, int right)
        {
            return new TransformationSeries<float, bool>(left, v => v <= right);
        }

        public static PineSeries<bool> Equals(PineSeries<int> left, PineSeries<int> right)
        {
            return new CombinationSeries<int, int, bool>(left, right, (l, r) => l == r);
        }

        public static PineSeries<bool> operator ==(PineSeries<int> left, PineSeries<int> right)
        {
            return new CombinationSeries<int, int, bool>(left, right, (l, r) => l == r);
        }

        public static PineSeries<bool> Equals(PineSeries<int> left, PineSeries<float> right)
        {
            return new CombinationSeries<int, float, bool>(left, right, (l, r) => l == r);
        }

        public static PineSeries<bool> operator ==(PineSeries<int> left, PineSeries<float> right)
        {
            return new CombinationSeries<int, float, bool>(left, right, (l, r) => l == r);
        }

        public static PineSeries<bool> Equals(PineSeries<float> left, PineSeries<float> right)
        {
            return new CombinationSeries<float, float, bool>(left, right, (l, r) => l == r);
        }

        public static PineSeries<bool> operator ==(PineSeries<float> left, PineSeries<float> right)
        {
            return new CombinationSeries<float, float, bool>(left, right, (l, r) => l == r);
        }

        public static PineSeries<bool> Equals(PineSeries<float> left, PineSeries<int> right)
        {
            return new CombinationSeries<float, int, bool>(left, right, (l, r) => l == r);
        }

        public static PineSeries<bool> operator ==(PineSeries<float> left, PineSeries<int> right)
        {
            return new CombinationSeries<float, int, bool>(left, right, (l, r) => l == r);
        }

        public static PineSeries<bool> Equals(PineSeries<int> left, int right)
        {
            return new TransformationSeries<int, bool>(left, v => v == right);
        }

        public static PineSeries<bool> operator ==(PineSeries<int> left, int right)
        {
            return new TransformationSeries<int, bool>(left, v => v == right);
        }

        public static PineSeries<bool> Equals(PineSeries<int> left, float right)
        {
            return new TransformationSeries<int, bool>(left, v => v == right);
        }

        public static PineSeries<bool> operator ==(PineSeries<int> left, float right)
        {
            return new TransformationSeries<int, bool>(left, v => v == right);
        }

        public static PineSeries<bool> Equals(PineSeries<float> left, float right)
        {
            return new TransformationSeries<float, bool>(left, v => v == right);
        }

        public static PineSeries<bool> operator ==(PineSeries<float> left, float right)
        {
            return new TransformationSeries<float, bool>(left, v => v == right);
        }

        public static PineSeries<bool> Equals(PineSeries<float> left, int right)
        {
            return new TransformationSeries<float, bool>(left, v => v == right);
        }

        public static PineSeries<bool> operator ==(PineSeries<float> left, int right)
        {
            return new TransformationSeries<float, bool>(left, v => v == right);
        }

        public static PineSeries<bool> NotEquals(PineSeries<int> left, PineSeries<int> right)
        {
            return new CombinationSeries<int, int, bool>(left, right, (l, r) => l != r);
        }

        public static PineSeries<bool> operator !=(PineSeries<int> left, PineSeries<int> right)
        {
            return new CombinationSeries<int, int, bool>(left, right, (l, r) => l != r);
        }

        public static PineSeries<bool> NotEquals(PineSeries<int> left, PineSeries<float> right)
        {
            return new CombinationSeries<int, float, bool>(left, right, (l, r) => l != r);
        }

        public static PineSeries<bool> operator !=(PineSeries<int> left, PineSeries<float> right)
        {
            return new CombinationSeries<int, float, bool>(left, right, (l, r) => l != r);
        }

        public static PineSeries<bool> NotEquals(PineSeries<float> left, PineSeries<float> right)
        {
            return new CombinationSeries<float, float, bool>(left, right, (l, r) => l != r);
        }

        public static PineSeries<bool> operator !=(PineSeries<float> left, PineSeries<float> right)
        {
            return new CombinationSeries<float, float, bool>(left, right, (l, r) => l != r);
        }

        public static PineSeries<bool> NotEquals(PineSeries<float> left, PineSeries<int> right)
        {
            return new CombinationSeries<float, int, bool>(left, right, (l, r) => l != r);
        }

        public static PineSeries<bool> operator !=(PineSeries<float> left, PineSeries<int> right)
        {
            return new CombinationSeries<float, int, bool>(left, right, (l, r) => l != r);
        }

        public static PineSeries<bool> NotEquals(PineSeries<int> left, int right)
        {
            return new TransformationSeries<int, bool>(left, v => v != right);
        }

        public static PineSeries<bool> operator !=(PineSeries<int> left, int right)
        {
            return new TransformationSeries<int, bool>(left, v => v != right);
        }

        public static PineSeries<bool> NotEquals(PineSeries<int> left, float right)
        {
            return new TransformationSeries<int, bool>(left, v => v != right);
        }

        public static PineSeries<bool> operator !=(PineSeries<int> left, float right)
        {
            return new TransformationSeries<int, bool>(left, v => v != right);
        }

        public static PineSeries<bool> NotEquals(PineSeries<float> left, float right)
        {
            return new TransformationSeries<float, bool>(left, v => v != right);
        }

        public static PineSeries<bool> operator !=(PineSeries<float> left, float right)
        {
            return new TransformationSeries<float, bool>(left, v => v != right);
        }

        public static PineSeries<bool> NotEquals(PineSeries<float> left, int right)
        {
            return new TransformationSeries<float, bool>(left, v => v != right);
        }

        public static PineSeries<bool> operator !=(PineSeries<float> left, int right)
        {
            return new TransformationSeries<float, bool>(left, v => v != right);
        }

        public static PineSeries<bool> And(PineSeries<bool> left, PineSeries<bool> right)
        {
            return new CombinationSeries<bool, bool, bool>(left, right, (l, r) => l && r);
        }

        public static PineSeries<bool> And(PineSeries<bool> left, bool right)
        {
            return new TransformationSeries<bool, bool>(left, v => v && right);
        }

        public static PineSeries<bool> Or(PineSeries<bool> left, PineSeries<bool> right)
        {
            return new CombinationSeries<bool, bool, bool>(left, right, (l, r) => l || r);
        }

        public static PineSeries<bool> Or(PineSeries<bool> left, bool right)
        {
            return new TransformationSeries<bool, bool>(left, v => v || right);
        }

    }
}
