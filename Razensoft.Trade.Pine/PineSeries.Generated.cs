using System;

namespace Razensoft.Trade.Pine
{
    public partial class PineSeries
    {
        public static PineSeries<int> Add(PineSeries<int> left, PineSeries<int> right)
        {
            return PineSeries<int>.Combine(left, right, (l, r) => l + r);
        }

        public static PineSeries<float> Add(PineSeries<int> left, PineSeries<float> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l + r);
        }

        public static PineSeries<float> Add(PineSeries<float> left, PineSeries<float> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l + r);
        }

        public static PineSeries<float> Add(PineSeries<float> left, PineSeries<int> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l + r);
        }

        public static PineSeries<int> Add(PineSeries<int> left, int right)
        {
            return PineSeries<int>.Transform(left, v => v + right);
        }

        public static PineSeries<float> Add(PineSeries<int> left, float right)
        {
            return PineSeries<float>.Transform(left, v => v + right);
        }

        public static PineSeries<float> Add(PineSeries<float> left, float right)
        {
            return PineSeries<float>.Transform(left, v => v + right);
        }

        public static PineSeries<float> Add(PineSeries<float> left, int right)
        {
            return PineSeries<float>.Transform(left, v => v + right);
        }

        public static PineSeries<int> Subtract(PineSeries<int> left, PineSeries<int> right)
        {
            return PineSeries<int>.Combine(left, right, (l, r) => l - r);
        }

        public static PineSeries<float> Subtract(PineSeries<int> left, PineSeries<float> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l - r);
        }

        public static PineSeries<float> Subtract(PineSeries<float> left, PineSeries<float> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l - r);
        }

        public static PineSeries<float> Subtract(PineSeries<float> left, PineSeries<int> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l - r);
        }

        public static PineSeries<int> Subtract(PineSeries<int> left, int right)
        {
            return PineSeries<int>.Transform(left, v => v - right);
        }

        public static PineSeries<float> Subtract(PineSeries<int> left, float right)
        {
            return PineSeries<float>.Transform(left, v => v - right);
        }

        public static PineSeries<float> Subtract(PineSeries<float> left, float right)
        {
            return PineSeries<float>.Transform(left, v => v - right);
        }

        public static PineSeries<float> Subtract(PineSeries<float> left, int right)
        {
            return PineSeries<float>.Transform(left, v => v - right);
        }

        public static PineSeries<int> Multiply(PineSeries<int> left, PineSeries<int> right)
        {
            return PineSeries<int>.Combine(left, right, (l, r) => l * r);
        }

        public static PineSeries<float> Multiply(PineSeries<int> left, PineSeries<float> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l * r);
        }

        public static PineSeries<float> Multiply(PineSeries<float> left, PineSeries<float> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l * r);
        }

        public static PineSeries<float> Multiply(PineSeries<float> left, PineSeries<int> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l * r);
        }

        public static PineSeries<int> Multiply(PineSeries<int> left, int right)
        {
            return PineSeries<int>.Transform(left, v => v * right);
        }

        public static PineSeries<float> Multiply(PineSeries<int> left, float right)
        {
            return PineSeries<float>.Transform(left, v => v * right);
        }

        public static PineSeries<float> Multiply(PineSeries<float> left, float right)
        {
            return PineSeries<float>.Transform(left, v => v * right);
        }

        public static PineSeries<float> Multiply(PineSeries<float> left, int right)
        {
            return PineSeries<float>.Transform(left, v => v * right);
        }

        public static PineSeries<int> Divide(PineSeries<int> left, PineSeries<int> right)
        {
            return PineSeries<int>.Combine(left, right, (l, r) => l / r);
        }

        public static PineSeries<float> Divide(PineSeries<int> left, PineSeries<float> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l / r);
        }

        public static PineSeries<float> Divide(PineSeries<float> left, PineSeries<float> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l / r);
        }

        public static PineSeries<float> Divide(PineSeries<float> left, PineSeries<int> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l / r);
        }

        public static PineSeries<int> Divide(PineSeries<int> left, int right)
        {
            return PineSeries<int>.Transform(left, v => v / right);
        }

        public static PineSeries<float> Divide(PineSeries<int> left, float right)
        {
            return PineSeries<float>.Transform(left, v => v / right);
        }

        public static PineSeries<float> Divide(PineSeries<float> left, float right)
        {
            return PineSeries<float>.Transform(left, v => v / right);
        }

        public static PineSeries<float> Divide(PineSeries<float> left, int right)
        {
            return PineSeries<float>.Transform(left, v => v / right);
        }

        public static PineSeries<int> Modulo(PineSeries<int> left, PineSeries<int> right)
        {
            return PineSeries<int>.Combine(left, right, (l, r) => l % r);
        }

        public static PineSeries<float> Modulo(PineSeries<int> left, PineSeries<float> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l % r);
        }

        public static PineSeries<float> Modulo(PineSeries<float> left, PineSeries<float> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l % r);
        }

        public static PineSeries<float> Modulo(PineSeries<float> left, PineSeries<int> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l % r);
        }

        public static PineSeries<int> Modulo(PineSeries<int> left, int right)
        {
            return PineSeries<int>.Transform(left, v => v % right);
        }

        public static PineSeries<float> Modulo(PineSeries<int> left, float right)
        {
            return PineSeries<float>.Transform(left, v => v % right);
        }

        public static PineSeries<float> Modulo(PineSeries<float> left, float right)
        {
            return PineSeries<float>.Transform(left, v => v % right);
        }

        public static PineSeries<float> Modulo(PineSeries<float> left, int right)
        {
            return PineSeries<float>.Transform(left, v => v % right);
        }

        public static PineSeries<bool> GreaterThan(PineSeries<int> left, PineSeries<int> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l > r);
        }

        public static PineSeries<bool> GreaterThan(PineSeries<int> left, PineSeries<float> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l > r);
        }

        public static PineSeries<bool> GreaterThan(PineSeries<float> left, PineSeries<float> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l > r);
        }

        public static PineSeries<bool> GreaterThan(PineSeries<float> left, PineSeries<int> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l > r);
        }

        public static PineSeries<bool> GreaterThan(PineSeries<int> left, int right)
        {
            return PineSeries<bool>.Transform(left, v => v > right);
        }

        public static PineSeries<bool> GreaterThan(PineSeries<int> left, float right)
        {
            return PineSeries<bool>.Transform(left, v => v > right);
        }

        public static PineSeries<bool> GreaterThan(PineSeries<float> left, float right)
        {
            return PineSeries<bool>.Transform(left, v => v > right);
        }

        public static PineSeries<bool> GreaterThan(PineSeries<float> left, int right)
        {
            return PineSeries<bool>.Transform(left, v => v > right);
        }

        public static PineSeries<bool> GreaterThanOrEquals(PineSeries<int> left, PineSeries<int> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l >= r);
        }

        public static PineSeries<bool> GreaterThanOrEquals(PineSeries<int> left, PineSeries<float> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l >= r);
        }

        public static PineSeries<bool> GreaterThanOrEquals(PineSeries<float> left, PineSeries<float> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l >= r);
        }

        public static PineSeries<bool> GreaterThanOrEquals(PineSeries<float> left, PineSeries<int> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l >= r);
        }

        public static PineSeries<bool> GreaterThanOrEquals(PineSeries<int> left, int right)
        {
            return PineSeries<bool>.Transform(left, v => v >= right);
        }

        public static PineSeries<bool> GreaterThanOrEquals(PineSeries<int> left, float right)
        {
            return PineSeries<bool>.Transform(left, v => v >= right);
        }

        public static PineSeries<bool> GreaterThanOrEquals(PineSeries<float> left, float right)
        {
            return PineSeries<bool>.Transform(left, v => v >= right);
        }

        public static PineSeries<bool> GreaterThanOrEquals(PineSeries<float> left, int right)
        {
            return PineSeries<bool>.Transform(left, v => v >= right);
        }

        public static PineSeries<bool> LowerThan(PineSeries<int> left, PineSeries<int> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l < r);
        }

        public static PineSeries<bool> LowerThan(PineSeries<int> left, PineSeries<float> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l < r);
        }

        public static PineSeries<bool> LowerThan(PineSeries<float> left, PineSeries<float> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l < r);
        }

        public static PineSeries<bool> LowerThan(PineSeries<float> left, PineSeries<int> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l < r);
        }

        public static PineSeries<bool> LowerThan(PineSeries<int> left, int right)
        {
            return PineSeries<bool>.Transform(left, v => v < right);
        }

        public static PineSeries<bool> LowerThan(PineSeries<int> left, float right)
        {
            return PineSeries<bool>.Transform(left, v => v < right);
        }

        public static PineSeries<bool> LowerThan(PineSeries<float> left, float right)
        {
            return PineSeries<bool>.Transform(left, v => v < right);
        }

        public static PineSeries<bool> LowerThan(PineSeries<float> left, int right)
        {
            return PineSeries<bool>.Transform(left, v => v < right);
        }

        public static PineSeries<bool> LowerThanOrEquals(PineSeries<int> left, PineSeries<int> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l <= r);
        }

        public static PineSeries<bool> LowerThanOrEquals(PineSeries<int> left, PineSeries<float> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l <= r);
        }

        public static PineSeries<bool> LowerThanOrEquals(PineSeries<float> left, PineSeries<float> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l <= r);
        }

        public static PineSeries<bool> LowerThanOrEquals(PineSeries<float> left, PineSeries<int> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l <= r);
        }

        public static PineSeries<bool> LowerThanOrEquals(PineSeries<int> left, int right)
        {
            return PineSeries<bool>.Transform(left, v => v <= right);
        }

        public static PineSeries<bool> LowerThanOrEquals(PineSeries<int> left, float right)
        {
            return PineSeries<bool>.Transform(left, v => v <= right);
        }

        public static PineSeries<bool> LowerThanOrEquals(PineSeries<float> left, float right)
        {
            return PineSeries<bool>.Transform(left, v => v <= right);
        }

        public static PineSeries<bool> LowerThanOrEquals(PineSeries<float> left, int right)
        {
            return PineSeries<bool>.Transform(left, v => v <= right);
        }

        public static PineSeries<bool> Equals(PineSeries<int> left, PineSeries<int> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l == r);
        }

        public static PineSeries<bool> Equals(PineSeries<int> left, PineSeries<float> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l == r);
        }

        public static PineSeries<bool> Equals(PineSeries<float> left, PineSeries<float> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l == r);
        }

        public static PineSeries<bool> Equals(PineSeries<float> left, PineSeries<int> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l == r);
        }

        public static PineSeries<bool> Equals(PineSeries<int> left, int right)
        {
            return PineSeries<bool>.Transform(left, v => v == right);
        }

        public static PineSeries<bool> Equals(PineSeries<int> left, float right)
        {
            return PineSeries<bool>.Transform(left, v => v == right);
        }

        public static PineSeries<bool> Equals(PineSeries<float> left, float right)
        {
            return PineSeries<bool>.Transform(left, v => v == right);
        }

        public static PineSeries<bool> Equals(PineSeries<float> left, int right)
        {
            return PineSeries<bool>.Transform(left, v => v == right);
        }

        public static PineSeries<bool> NotEquals(PineSeries<int> left, PineSeries<int> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l != r);
        }

        public static PineSeries<bool> NotEquals(PineSeries<int> left, PineSeries<float> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l != r);
        }

        public static PineSeries<bool> NotEquals(PineSeries<float> left, PineSeries<float> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l != r);
        }

        public static PineSeries<bool> NotEquals(PineSeries<float> left, PineSeries<int> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l != r);
        }

        public static PineSeries<bool> NotEquals(PineSeries<int> left, int right)
        {
            return PineSeries<bool>.Transform(left, v => v != right);
        }

        public static PineSeries<bool> NotEquals(PineSeries<int> left, float right)
        {
            return PineSeries<bool>.Transform(left, v => v != right);
        }

        public static PineSeries<bool> NotEquals(PineSeries<float> left, float right)
        {
            return PineSeries<bool>.Transform(left, v => v != right);
        }

        public static PineSeries<bool> NotEquals(PineSeries<float> left, int right)
        {
            return PineSeries<bool>.Transform(left, v => v != right);
        }

        public static PineSeries<bool> And(PineSeries<bool> left, PineSeries<bool> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l && r);
        }

        public static PineSeries<bool> And(PineSeries<bool> left, bool right)
        {
            return PineSeries<bool>.Transform(left, v => v && right);
        }

        public static PineSeries<bool> Or(PineSeries<bool> left, PineSeries<bool> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l || r);
        }

        public static PineSeries<bool> Or(PineSeries<bool> left, bool right)
        {
            return PineSeries<bool>.Transform(left, v => v || right);
        }

    }
    public partial class PineSeries<T>
    {
        public static PineSeries<T> operator +(PineSeries<T> left, PineSeries<T> right)
        {
            return PineSeries<T>.Combine(left, right, (l, r) => (dynamic) l + (dynamic) r);
        }

        public static PineSeries<T> operator +(PineSeries<T> left, T right)
        {
            return PineSeries<T>.Transform(left, v => (dynamic) v + (dynamic) right);
        }

        public static PineSeries<T> operator -(PineSeries<T> left, PineSeries<T> right)
        {
            return PineSeries<T>.Combine(left, right, (l, r) => (dynamic) l - (dynamic) r);
        }

        public static PineSeries<T> operator -(PineSeries<T> left, T right)
        {
            return PineSeries<T>.Transform(left, v => (dynamic) v - (dynamic) right);
        }

        public static PineSeries<T> operator *(PineSeries<T> left, PineSeries<T> right)
        {
            return PineSeries<T>.Combine(left, right, (l, r) => (dynamic) l * (dynamic) r);
        }

        public static PineSeries<T> operator *(PineSeries<T> left, T right)
        {
            return PineSeries<T>.Transform(left, v => (dynamic) v * (dynamic) right);
        }

        public static PineSeries<T> operator /(PineSeries<T> left, PineSeries<T> right)
        {
            return PineSeries<T>.Combine(left, right, (l, r) => (dynamic) l / (dynamic) r);
        }

        public static PineSeries<T> operator /(PineSeries<T> left, T right)
        {
            return PineSeries<T>.Transform(left, v => (dynamic) v / (dynamic) right);
        }

        public static PineSeries<T> operator %(PineSeries<T> left, PineSeries<T> right)
        {
            return PineSeries<T>.Combine(left, right, (l, r) => (dynamic) l % (dynamic) r);
        }

        public static PineSeries<T> operator %(PineSeries<T> left, T right)
        {
            return PineSeries<T>.Transform(left, v => (dynamic) v % (dynamic) right);
        }

        public static PineSeries<T> operator >(PineSeries<T> left, PineSeries<T> right)
        {
            return PineSeries<T>.Combine(left, right, (l, r) => (dynamic) l > (dynamic) r);
        }

        public static PineSeries<T> operator >(PineSeries<T> left, T right)
        {
            return PineSeries<T>.Transform(left, v => (dynamic) v > (dynamic) right);
        }

        public static PineSeries<T> operator >=(PineSeries<T> left, PineSeries<T> right)
        {
            return PineSeries<T>.Combine(left, right, (l, r) => (dynamic) l >= (dynamic) r);
        }

        public static PineSeries<T> operator >=(PineSeries<T> left, T right)
        {
            return PineSeries<T>.Transform(left, v => (dynamic) v >= (dynamic) right);
        }

        public static PineSeries<T> operator <(PineSeries<T> left, PineSeries<T> right)
        {
            return PineSeries<T>.Combine(left, right, (l, r) => (dynamic) l < (dynamic) r);
        }

        public static PineSeries<T> operator <(PineSeries<T> left, T right)
        {
            return PineSeries<T>.Transform(left, v => (dynamic) v < (dynamic) right);
        }

        public static PineSeries<T> operator <=(PineSeries<T> left, PineSeries<T> right)
        {
            return PineSeries<T>.Combine(left, right, (l, r) => (dynamic) l <= (dynamic) r);
        }

        public static PineSeries<T> operator <=(PineSeries<T> left, T right)
        {
            return PineSeries<T>.Transform(left, v => (dynamic) v <= (dynamic) right);
        }

        public static PineSeries<T> operator ==(PineSeries<T> left, PineSeries<T> right)
        {
            return PineSeries<T>.Combine(left, right, (l, r) => (dynamic) l == (dynamic) r);
        }

        public static PineSeries<T> operator ==(PineSeries<T> left, T right)
        {
            return PineSeries<T>.Transform(left, v => (dynamic) v == (dynamic) right);
        }

        public static PineSeries<T> operator !=(PineSeries<T> left, PineSeries<T> right)
        {
            return PineSeries<T>.Combine(left, right, (l, r) => (dynamic) l != (dynamic) r);
        }

        public static PineSeries<T> operator !=(PineSeries<T> left, T right)
        {
            return PineSeries<T>.Transform(left, v => (dynamic) v != (dynamic) right);
        }

    }
}
