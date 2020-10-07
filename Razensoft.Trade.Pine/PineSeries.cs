using System;
using System.Collections.Generic;

namespace Razensoft.Trade.Pine
{
    public class PineSeries
    {
        public virtual int Length => 0;
        
        public virtual object this[int index] => default;
    }

    public partial class PineSeries<T> : PineSeries
    {
        private readonly IReadOnlyList<T> _values;
        private readonly int _position;

        public PineSeries() : this(new T[] { }, 0) { }

        public PineSeries(IReadOnlyList<T> values, int position)
        {
            _values = values;
            _position = position;
        }

        public override int Length => Math.Min(_position + 1, _values.Count);

        public override object this[int index]
        {
            get
            {
                if (index < Length)
                    return _values[_position - index];
                
                return PineNA.NA;
            }
        }

        private class TransformationSeries<TItem, TResult> : PineSeries<TResult>
        {
            private readonly PineSeries<TItem> _series;
            private readonly Func<TItem, TResult> _transformer;

            public TransformationSeries(PineSeries<TItem> series, Func<TItem, TResult> transformer)
            {
                _series = series;
                _transformer = transformer;
            }

            public override int Length => _series.Length;

            public override object this[int index]
            {
                get
                {
                    if (index < Length)
                    {
                        return _transformer((TItem) _series[index]);
                    }
                
                    return PineNA.NA;
                }
            }
        }

        private class CombinationSeries<TLeft, TRight, TResult> : PineSeries<TResult>
        {
            private readonly PineSeries<TLeft> _left;
            private readonly PineSeries<TRight> _right;
            private readonly Func<TLeft, TRight, TResult> _combinator;

            public CombinationSeries(PineSeries<TLeft> left, PineSeries<TRight> right, Func<TLeft, TRight, TResult> combinator)
            {
                _left = left;
                _right = right;
                _combinator = combinator;
            }

            public override int Length => Math.Min(_left.Length, _right.Length);

            public override object this[int index]
            {
                get
                {
                    if (index < Length)
                    {
                        return _combinator((TLeft) _left[index], (TRight) _right[index]);
                    }
                
                    return PineNA.NA;
                }
            }
        }
    }
}