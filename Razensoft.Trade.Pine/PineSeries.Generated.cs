using System;

namespace Razensoft.Trade.Pine
{
    public partial class PineSeries
    {
        public static PineSeries<long> Add(PineSeries<long> left, PineSeries<long> right)
        {
            return PineSeries<long>.Combine(left, right, (l, r) => l + r);
        }

        public static PineSeries<float> Add(PineSeries<long> left, PineSeries<float> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l + r);
        }

        public static PineSeries<float> Add(PineSeries<float> left, PineSeries<float> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l + r);
        }

        public static PineSeries<float> Add(PineSeries<float> left, PineSeries<long> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l + r);
        }

        public static PineSeries<long> Add(PineSeries<long> left, long right)
        {
            return PineSeries<long>.Transform(left, v => v + right);
        }

        public static PineSeries<float> Add(PineSeries<long> left, float right)
        {
            return PineSeries<float>.Transform(left, v => v + right);
        }

        public static PineSeries<float> Add(PineSeries<float> left, float right)
        {
            return PineSeries<float>.Transform(left, v => v + right);
        }

        public static PineSeries<float> Add(PineSeries<float> left, long right)
        {
            return PineSeries<float>.Transform(left, v => v + right);
        }

        public static PineSeries<long> Subtract(PineSeries<long> left, PineSeries<long> right)
        {
            return PineSeries<long>.Combine(left, right, (l, r) => l - r);
        }

        public static PineSeries<float> Subtract(PineSeries<long> left, PineSeries<float> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l - r);
        }

        public static PineSeries<float> Subtract(PineSeries<float> left, PineSeries<float> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l - r);
        }

        public static PineSeries<float> Subtract(PineSeries<float> left, PineSeries<long> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l - r);
        }

        public static PineSeries<long> Subtract(PineSeries<long> left, long right)
        {
            return PineSeries<long>.Transform(left, v => v - right);
        }

        public static PineSeries<float> Subtract(PineSeries<long> left, float right)
        {
            return PineSeries<float>.Transform(left, v => v - right);
        }

        public static PineSeries<float> Subtract(PineSeries<float> left, float right)
        {
            return PineSeries<float>.Transform(left, v => v - right);
        }

        public static PineSeries<float> Subtract(PineSeries<float> left, long right)
        {
            return PineSeries<float>.Transform(left, v => v - right);
        }

        public static PineSeries<long> Multiply(PineSeries<long> left, PineSeries<long> right)
        {
            return PineSeries<long>.Combine(left, right, (l, r) => l * r);
        }

        public static PineSeries<float> Multiply(PineSeries<long> left, PineSeries<float> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l * r);
        }

        public static PineSeries<float> Multiply(PineSeries<float> left, PineSeries<float> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l * r);
        }

        public static PineSeries<float> Multiply(PineSeries<float> left, PineSeries<long> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l * r);
        }

        public static PineSeries<long> Multiply(PineSeries<long> left, long right)
        {
            return PineSeries<long>.Transform(left, v => v * right);
        }

        public static PineSeries<float> Multiply(PineSeries<long> left, float right)
        {
            return PineSeries<float>.Transform(left, v => v * right);
        }

        public static PineSeries<float> Multiply(PineSeries<float> left, float right)
        {
            return PineSeries<float>.Transform(left, v => v * right);
        }

        public static PineSeries<float> Multiply(PineSeries<float> left, long right)
        {
            return PineSeries<float>.Transform(left, v => v * right);
        }

        public static PineSeries<long> Divide(PineSeries<long> left, PineSeries<long> right)
        {
            return PineSeries<long>.Combine(left, right, (l, r) => l / r);
        }

        public static PineSeries<float> Divide(PineSeries<long> left, PineSeries<float> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l / r);
        }

        public static PineSeries<float> Divide(PineSeries<float> left, PineSeries<float> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l / r);
        }

        public static PineSeries<float> Divide(PineSeries<float> left, PineSeries<long> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l / r);
        }

        public static PineSeries<long> Divide(PineSeries<long> left, long right)
        {
            return PineSeries<long>.Transform(left, v => v / right);
        }

        public static PineSeries<float> Divide(PineSeries<long> left, float right)
        {
            return PineSeries<float>.Transform(left, v => v / right);
        }

        public static PineSeries<float> Divide(PineSeries<float> left, float right)
        {
            return PineSeries<float>.Transform(left, v => v / right);
        }

        public static PineSeries<float> Divide(PineSeries<float> left, long right)
        {
            return PineSeries<float>.Transform(left, v => v / right);
        }

        public static PineSeries<long> Modulo(PineSeries<long> left, PineSeries<long> right)
        {
            return PineSeries<long>.Combine(left, right, (l, r) => l % r);
        }

        public static PineSeries<float> Modulo(PineSeries<long> left, PineSeries<float> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l % r);
        }

        public static PineSeries<float> Modulo(PineSeries<float> left, PineSeries<float> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l % r);
        }

        public static PineSeries<float> Modulo(PineSeries<float> left, PineSeries<long> right)
        {
            return PineSeries<float>.Combine(left, right, (l, r) => l % r);
        }

        public static PineSeries<long> Modulo(PineSeries<long> left, long right)
        {
            return PineSeries<long>.Transform(left, v => v % right);
        }

        public static PineSeries<float> Modulo(PineSeries<long> left, float right)
        {
            return PineSeries<float>.Transform(left, v => v % right);
        }

        public static PineSeries<float> Modulo(PineSeries<float> left, float right)
        {
            return PineSeries<float>.Transform(left, v => v % right);
        }

        public static PineSeries<float> Modulo(PineSeries<float> left, long right)
        {
            return PineSeries<float>.Transform(left, v => v % right);
        }

        public static PineSeries<bool> GreaterThan(PineSeries<long> left, PineSeries<long> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l > r);
        }

        public static PineSeries<bool> GreaterThan(PineSeries<long> left, PineSeries<float> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l > r);
        }

        public static PineSeries<bool> GreaterThan(PineSeries<float> left, PineSeries<float> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l > r);
        }

        public static PineSeries<bool> GreaterThan(PineSeries<float> left, PineSeries<long> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l > r);
        }

        public static PineSeries<bool> GreaterThan(PineSeries<long> left, long right)
        {
            return PineSeries<bool>.Transform(left, v => v > right);
        }

        public static PineSeries<bool> GreaterThan(PineSeries<long> left, float right)
        {
            return PineSeries<bool>.Transform(left, v => v > right);
        }

        public static PineSeries<bool> GreaterThan(PineSeries<float> left, float right)
        {
            return PineSeries<bool>.Transform(left, v => v > right);
        }

        public static PineSeries<bool> GreaterThan(PineSeries<float> left, long right)
        {
            return PineSeries<bool>.Transform(left, v => v > right);
        }

        public static PineSeries<bool> GreaterThanOrEquals(PineSeries<long> left, PineSeries<long> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l >= r);
        }

        public static PineSeries<bool> GreaterThanOrEquals(PineSeries<long> left, PineSeries<float> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l >= r);
        }

        public static PineSeries<bool> GreaterThanOrEquals(PineSeries<float> left, PineSeries<float> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l >= r);
        }

        public static PineSeries<bool> GreaterThanOrEquals(PineSeries<float> left, PineSeries<long> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l >= r);
        }

        public static PineSeries<bool> GreaterThanOrEquals(PineSeries<long> left, long right)
        {
            return PineSeries<bool>.Transform(left, v => v >= right);
        }

        public static PineSeries<bool> GreaterThanOrEquals(PineSeries<long> left, float right)
        {
            return PineSeries<bool>.Transform(left, v => v >= right);
        }

        public static PineSeries<bool> GreaterThanOrEquals(PineSeries<float> left, float right)
        {
            return PineSeries<bool>.Transform(left, v => v >= right);
        }

        public static PineSeries<bool> GreaterThanOrEquals(PineSeries<float> left, long right)
        {
            return PineSeries<bool>.Transform(left, v => v >= right);
        }

        public static PineSeries<bool> LowerThan(PineSeries<long> left, PineSeries<long> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l < r);
        }

        public static PineSeries<bool> LowerThan(PineSeries<long> left, PineSeries<float> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l < r);
        }

        public static PineSeries<bool> LowerThan(PineSeries<float> left, PineSeries<float> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l < r);
        }

        public static PineSeries<bool> LowerThan(PineSeries<float> left, PineSeries<long> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l < r);
        }

        public static PineSeries<bool> LowerThan(PineSeries<long> left, long right)
        {
            return PineSeries<bool>.Transform(left, v => v < right);
        }

        public static PineSeries<bool> LowerThan(PineSeries<long> left, float right)
        {
            return PineSeries<bool>.Transform(left, v => v < right);
        }

        public static PineSeries<bool> LowerThan(PineSeries<float> left, float right)
        {
            return PineSeries<bool>.Transform(left, v => v < right);
        }

        public static PineSeries<bool> LowerThan(PineSeries<float> left, long right)
        {
            return PineSeries<bool>.Transform(left, v => v < right);
        }

        public static PineSeries<bool> LowerThanOrEquals(PineSeries<long> left, PineSeries<long> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l <= r);
        }

        public static PineSeries<bool> LowerThanOrEquals(PineSeries<long> left, PineSeries<float> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l <= r);
        }

        public static PineSeries<bool> LowerThanOrEquals(PineSeries<float> left, PineSeries<float> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l <= r);
        }

        public static PineSeries<bool> LowerThanOrEquals(PineSeries<float> left, PineSeries<long> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l <= r);
        }

        public static PineSeries<bool> LowerThanOrEquals(PineSeries<long> left, long right)
        {
            return PineSeries<bool>.Transform(left, v => v <= right);
        }

        public static PineSeries<bool> LowerThanOrEquals(PineSeries<long> left, float right)
        {
            return PineSeries<bool>.Transform(left, v => v <= right);
        }

        public static PineSeries<bool> LowerThanOrEquals(PineSeries<float> left, float right)
        {
            return PineSeries<bool>.Transform(left, v => v <= right);
        }

        public static PineSeries<bool> LowerThanOrEquals(PineSeries<float> left, long right)
        {
            return PineSeries<bool>.Transform(left, v => v <= right);
        }

        public static PineSeries<bool> Equals(PineSeries<long> left, PineSeries<long> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l == r);
        }

        public static PineSeries<bool> Equals(PineSeries<long> left, PineSeries<float> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l == r);
        }

        public static PineSeries<bool> Equals(PineSeries<float> left, PineSeries<float> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l == r);
        }

        public static PineSeries<bool> Equals(PineSeries<float> left, PineSeries<long> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l == r);
        }

        public static PineSeries<bool> Equals(PineSeries<long> left, long right)
        {
            return PineSeries<bool>.Transform(left, v => v == right);
        }

        public static PineSeries<bool> Equals(PineSeries<long> left, float right)
        {
            return PineSeries<bool>.Transform(left, v => v == right);
        }

        public static PineSeries<bool> Equals(PineSeries<float> left, float right)
        {
            return PineSeries<bool>.Transform(left, v => v == right);
        }

        public static PineSeries<bool> Equals(PineSeries<float> left, long right)
        {
            return PineSeries<bool>.Transform(left, v => v == right);
        }

        public static PineSeries<bool> NotEquals(PineSeries<long> left, PineSeries<long> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l != r);
        }

        public static PineSeries<bool> NotEquals(PineSeries<long> left, PineSeries<float> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l != r);
        }

        public static PineSeries<bool> NotEquals(PineSeries<float> left, PineSeries<float> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l != r);
        }

        public static PineSeries<bool> NotEquals(PineSeries<float> left, PineSeries<long> right)
        {
            return PineSeries<bool>.Combine(left, right, (l, r) => l != r);
        }

        public static PineSeries<bool> NotEquals(PineSeries<long> left, long right)
        {
            return PineSeries<bool>.Transform(left, v => v != right);
        }

        public static PineSeries<bool> NotEquals(PineSeries<long> left, float right)
        {
            return PineSeries<bool>.Transform(left, v => v != right);
        }

        public static PineSeries<bool> NotEquals(PineSeries<float> left, float right)
        {
            return PineSeries<bool>.Transform(left, v => v != right);
        }

        public static PineSeries<bool> NotEquals(PineSeries<float> left, long right)
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
