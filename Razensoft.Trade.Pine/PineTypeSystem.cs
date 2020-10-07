using System;
using System.Collections.Generic;

namespace Razensoft.Trade.Pine
{
    public static class PineTypeSystem
    {
        private static readonly Dictionary<Type, TypeCast> TypeCasts = new Dictionary<Type, TypeCast>();

        static PineTypeSystem()
        {
            AddTypeCast<PineNA, int>(value => 0);
            AddTypeCast<PineNA, float>(value => 0);
            AddTypeCast<PineNA, bool>(value => false);
            AddTypeCast<PineNA, string>(value => string.Empty);
            AddTypeCast<PineNA, PineColor>(value => new PineColor());
            AddTypeCast<PineNA, PineSeries<PineNA>>(value => new PineSeries<PineNA>());
            AddTypeCast<PineNA, PineSeries<int>>(value => new PineSeries<int>());
            AddTypeCast<PineNA, PineSeries<float>>(value => new PineSeries<float>());
            AddTypeCast<PineNA, PineSeries<bool>>(value => new PineSeries<bool>());
            AddTypeCast<PineNA, PineSeries<string>>(value => new PineSeries<string>());
            AddTypeCast<PineNA, PineSeries<PineColor>>(value => new PineSeries<PineColor>());

            AddTypeCast<PineSeries<PineNA>, PineSeries<int>>(value => new PineSeries<int>());
            AddTypeCast<PineSeries<PineNA>, PineSeries<float>>(value => new PineSeries<float>());
            AddTypeCast<PineSeries<PineNA>, PineSeries<bool>>(value => new PineSeries<bool>());
            AddTypeCast<PineSeries<PineNA>, PineSeries<string>>(value => new PineSeries<string>());
            AddTypeCast<PineSeries<PineNA>, PineSeries<PineColor>>(value => new PineSeries<PineColor>());

            AddTypeCast<int, float>(value => (float) value);
            AddTypeCast<int, bool>(value => value > 0);
            AddTypeCast<int, PineSeries<int>>(value => new PineSeries<int>());
            AddTypeCast<int, PineSeries<float>>(value => new PineSeries<float>());
            AddTypeCast<int, PineSeries<bool>>(value => new PineSeries<bool>());

            AddTypeCast<float, bool>(value => value > 0);
            AddTypeCast<float, PineSeries<float>>(value => new PineSeries<float>());
            AddTypeCast<float, PineSeries<bool>>(value => new PineSeries<bool>());

            AddTypeCast<bool, PineSeries<bool>>(value => new PineSeries<bool>());

            AddTypeCast<string, PineSeries<string>>(value => new PineSeries<string>());

            AddTypeCast<string, PineSeries<PineColor>>(value => new PineSeries<PineColor>());

            AddTypeCast<PineSeries<int>, int>(value => (int) value[0]);
            AddTypeCast<PineSeries<float>, float>(value => (float) value[0]);
            AddTypeCast<PineSeries<bool>, bool>(value => (bool) value[0]);
            AddTypeCast<PineSeries<string>, string>(value => (string) value[0]);
            AddTypeCast<PineSeries<PineColor>, PineColor>(value => (PineColor) value[0]);
        }

        private static void AddTypeCast<TFrom, TTo>(Func<TFrom, TTo> cast)
        {
            if (!TypeCasts.TryGetValue(typeof(TFrom), out var typeCast))
            {
                typeCast = new TypeCast();
                TypeCasts.Add(typeof(TFrom), typeCast);
            }

            typeCast.Add(typeof(TTo), value => cast((TFrom) value));
        }

        public static T Convert<T>(object value)
        {
            return (T) Convert(value, typeof(T));
        }

        public static object Convert(object value, Type to)
        {
            if (to.IsInstanceOfType(value))
            {
                return value;
            }
            if (!TypeCasts.TryGetValue(value.GetType(), out var typeCast))
            {
                throw new InvalidCastException($"Type {value.GetType()} can not be cast to {to}");
            }

            return typeCast.Convert(value, to);
        }

        public static bool IsConvertible(Type from, Type to)
        {
            return to.IsAssignableFrom(from) || TypeCasts.TryGetValue(from, out var typeCast) && typeCast.IsConvertible(to);
        }

        private class TypeCast
        {
            private readonly Dictionary<Type, Func<object, object>> _casts
                = new Dictionary<Type, Func<object, object>>();

            public void Add(Type to, Func<object, object> cast)
            {
                _casts.Add(to, cast);
            }

            public object Convert(object value, Type to)
            {
                if (!_casts.TryGetValue(to, out var cast))
                {
                    throw new InvalidCastException($"Type {value.GetType()} can not be cast to {to}");
                }

                return cast(value);
            }

            public bool IsConvertible(Type to) => _casts.ContainsKey(to);
        }
    }
}