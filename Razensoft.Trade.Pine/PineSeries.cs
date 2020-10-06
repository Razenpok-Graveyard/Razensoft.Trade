using System;

namespace Razensoft.Trade.Pine
{
    public class PineSeries
    {
        public virtual object this[int index] => default;
    }

    public class PineSeries<T> : PineSeries
    {
        private readonly T[] _values;

        public PineSeries() : this(new T[] { }) { }

        public PineSeries(T[] values)
        {
            _values = values;
        }

        public override object this[int index]
        {
            get
            {
                if (index < _values.Length)
                {
                    return _values[index];
                }

                if (typeof(T) == typeof(string))
                {
                    return string.Empty;
                }

                if (typeof(T) == typeof(PineColor))
                {
                    return new PineColor();
                }

                return default(T);
            }
        }

        public static PineSeries<T> operator +(PineSeries<T> left, PineSeries<T> right)
        {
            if (typeof(T) == typeof(int))
            {
                return new CombinationSeries(left, right, (arg1, arg2) => (int) arg1 + (int) arg2);
            }

        }

        public static PineSeries<T> operator /(PineSeries<T> left, int right)
            => new PineSeries<T>();

        private class CombinationSeries : PineSeries
        {
            private readonly PineSeries _left;
            private readonly PineSeries _right;
            private readonly Func<object, object, object> _combinator;

            public CombinationSeries(PineSeries left, PineSeries right, Func<object, object, object> combinator)
            {
                _left = left;
                _right = right;
                _combinator = combinator;
            }

            public override object this[int index] => _combinator(_left[index], _right[index]);
        }
    }
}