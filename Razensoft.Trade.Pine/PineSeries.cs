using System;

namespace Razensoft.Trade.Pine.Parsing
{
    public class PineSeries
    {
        public virtual object this[int index]
        {
            get => default;
            set => throw new NotImplementedException();
        }
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
            set => throw new NotImplementedException();
        }

        public static PineSeries<T> operator +(PineSeries<T> left, PineSeries<T> right)
            => new PineSeries<T>();

        public static PineSeries<T> operator /(PineSeries<T> left, int right)
            => new PineSeries<T>();
    }
}