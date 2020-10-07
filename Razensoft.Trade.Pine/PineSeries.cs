using System;
using System.Collections.Generic;

namespace Razensoft.Trade.Pine
{
    public partial class PineSeries
    {
        public virtual int Length => 0;
        
        public virtual object this[int index] => default;
    }

    public partial class PineSeries<T> : PineSeries
    {
        private readonly PineSeriesDataSource _dataSource;

        public PineSeries() : this(new T[] { }, 0) { }

        public PineSeries(IReadOnlyList<T> values, int position) : this(new ListPineSeriesDataSource<T>(values, position))
        {
        }

        public PineSeries(PineSeriesDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public override int Length => _dataSource.Length;

        public override object this[int index] => _dataSource[index];

        public static PineSeries<T> Transform<TItem>(PineSeries<TItem> series, Func<TItem, T> transformer)
        {
            return new PineSeries<T>(new TransformationSeriesDataSource<TItem>(series, transformer));
        }
        
        public static PineSeries<T> Combine<TLeft, TRight>(PineSeries<TLeft> left, PineSeries<TRight> right, Func<TLeft, TRight, T> combinator)
        {
            return new PineSeries<T>(new CombinationSeriesDataSource<TLeft, TRight>(left, right, combinator));
        }

        private class TransformationSeriesDataSource<TItem> : PineSeriesDataSource
        {
            private readonly PineSeries<TItem> _series;
            private readonly Func<TItem, T> _transformer;

            public TransformationSeriesDataSource(PineSeries<TItem> series, Func<TItem, T> transformer)
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

        private class CombinationSeriesDataSource<TLeft, TRight> : PineSeriesDataSource
        {
            private readonly PineSeries<TLeft> _left;
            private readonly PineSeries<TRight> _right;
            private readonly Func<TLeft, TRight, T> _combinator;

            public CombinationSeriesDataSource(PineSeries<TLeft> left, PineSeries<TRight> right, Func<TLeft, TRight, T> combinator)
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

    public abstract class PineSeriesDataSource
    {
        public virtual int Length => 0;
        
        public virtual object this[int index] => default;
    }

    public class ListPineSeriesDataSource<T> : PineSeriesDataSource
    {
        private readonly IReadOnlyList<T> _values;
        private readonly int _position;

        public ListPineSeriesDataSource(IReadOnlyList<T> values, int position)
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
    }
}