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
            if (typeof(T) == typeof(float))
            {
                return new CombinationSeries(left, right, (arg1, arg2) => (float) arg1 + (float) arg2);
            }
            throw new NotSupportedException($"Series of type {typeof(T)} cannot be combined");
        }

        public static PineSeries<T> operator /(PineSeries<T> left, int right)
        {
            if (typeof(T) == typeof(int))
            {
                return new TransformationSeries(left, value => (int) value + right);
            }
            if (typeof(T) == typeof(float))
            {
                return new TransformationSeries(left, value => (float) value + right);
            }
            throw new NotSupportedException($"Series of type {typeof(T)} cannot be combined");
        }
        
        private class TransformationSeries : PineSeries<T>
        {
            private readonly PineSeries<T> _series;
            private readonly Func<object, object> _transformer;

            public TransformationSeries(PineSeries<T> series, Func<object, object> transformer)
            {
                _series = series;
                _transformer = transformer;
            }

            public override object this[int index] => _transformer(_series[index]);
        }

        private class CombinationSeries : PineSeries<T>
        {
            private readonly PineSeries<T> _left;
            private readonly PineSeries<T> _right;
            private readonly Func<object, object, object> _combinator;

            public CombinationSeries(PineSeries<T> left, PineSeries<T> right, Func<object, object, object> combinator)
            {
                _left = left;
                _right = right;
                _combinator = combinator;
            }

            public override object this[int index] => _combinator(_left[index], _right[index]);
        }
    }
}