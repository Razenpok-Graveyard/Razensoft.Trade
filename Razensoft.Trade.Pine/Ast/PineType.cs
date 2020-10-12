using System;
using System.Collections.Generic;

namespace Razensoft.Trade.Pine.Ast
{
    public class PineType
    {
        private readonly Dictionary<PineType, Func<object, object>> _casts
            = new Dictionary<PineType, Func<object, object>>();

        private PineType(PineDataType dataType, PineTypeForm form)
        {
            DataType = dataType;
            Form = form;
        }

        public PineDataType DataType { get; }

        public PineTypeForm Form { get; }

        public bool IsConvertibleTo(PineType type)
        {
            return _casts.ContainsKey(type);
        }

        public object Convert(object value, PineType type)
        {
            if (!_casts.TryGetValue(type, out var cast))
            {
                throw new Exception($"Type \"{this}\" is not convertible to type \"{type}\"");
            }

            return cast(value);
        }

        public override string ToString()
        {
            return $"{Form.ToString().ToLower()} {DataType.ToString().ToLower()}";
        }

        public static PineType SimpleNA { get; } = new PineType(PineDataType.NA, PineTypeForm.Simple);
        public static PineType SeriesNA { get; } = new PineType(PineDataType.NA, PineTypeForm.Series);

        public static PineType LiteralInt { get; } = new PineType(PineDataType.Int, PineTypeForm.Literal);
        public static PineType ConstInt { get; } = new PineType(PineDataType.Int, PineTypeForm.Const);
        public static PineType InputInt { get; } = new PineType(PineDataType.Int, PineTypeForm.Input);
        public static PineType SimpleInt { get; } = new PineType(PineDataType.Int, PineTypeForm.Simple);
        public static PineType SeriesInt { get; } = new PineType(PineDataType.Int, PineTypeForm.Series);

        public static PineType LiteralFloat { get; } = new PineType(PineDataType.Float, PineTypeForm.Literal);
        public static PineType ConstFloat { get; } = new PineType(PineDataType.Float, PineTypeForm.Const);
        public static PineType InputFloat { get; } = new PineType(PineDataType.Float, PineTypeForm.Input);
        public static PineType SimpleFloat { get; } = new PineType(PineDataType.Float, PineTypeForm.Simple);
        public static PineType SeriesFloat { get; } = new PineType(PineDataType.Float, PineTypeForm.Series);

        public static PineType LiteralBool { get; } = new PineType(PineDataType.Bool, PineTypeForm.Literal);
        public static PineType ConstBool { get; } = new PineType(PineDataType.Bool, PineTypeForm.Const);
        public static PineType InputBool { get; } = new PineType(PineDataType.Bool, PineTypeForm.Input);
        public static PineType SimpleBool { get; } = new PineType(PineDataType.Bool, PineTypeForm.Simple);
        public static PineType SeriesBool { get; } = new PineType(PineDataType.Bool, PineTypeForm.Series);

        public static PineType LiteralColor { get; } = new PineType(PineDataType.Color, PineTypeForm.Literal);
        public static PineType ConstColor { get; } = new PineType(PineDataType.Color, PineTypeForm.Const);
        public static PineType InputColor { get; } = new PineType(PineDataType.Color, PineTypeForm.Input);
        public static PineType SimpleColor { get; } = new PineType(PineDataType.Color, PineTypeForm.Simple);
        public static PineType SeriesColor { get; } = new PineType(PineDataType.Color, PineTypeForm.Series);

        public static PineType LiteralString { get; } = new PineType(PineDataType.String, PineTypeForm.Literal);
        public static PineType ConstString { get; } = new PineType(PineDataType.String, PineTypeForm.Const);
        public static PineType InputString { get; } = new PineType(PineDataType.String, PineTypeForm.Input);
        public static PineType SimpleString { get; } = new PineType(PineDataType.String, PineTypeForm.Simple);
        public static PineType SeriesString { get; } = new PineType(PineDataType.String, PineTypeForm.Series);

        public static PineType SeriesLine { get; } = new PineType(PineDataType.Line, PineTypeForm.Series);
        public static PineType SeriesLabel { get; } = new PineType(PineDataType.Label, PineTypeForm.Series);
        public static PineType SeriesPlot { get; } = new PineType(PineDataType.Plot, PineTypeForm.Series);
        public static PineType SeriesHline { get; } = new PineType(PineDataType.Hline, PineTypeForm.Series);

        static PineType()
        {
            static void AddTypeCast(PineType from, PineType to, Func<object, object> cast)
            {
                from._casts.Add(to, cast);
            }

            static void AddDirectTypeCast(PineType from, PineType to)
            {
                from._casts.Add(to, value => value);
            }

            // SimpleNA

            AddDirectTypeCast(SimpleNA, SeriesNA);

            AddTypeCast(SimpleNA, SimpleInt, value => (long) 0);
            AddTypeCast(SimpleNA, SeriesInt, value => new PineSeries<long>());

            AddTypeCast(SimpleNA, SimpleFloat, value => (float) 0);
            AddTypeCast(SimpleNA, SeriesFloat, value => new PineSeries<float>());

            AddTypeCast(SimpleNA, SimpleBool, value => false);
            AddTypeCast(SimpleNA, SeriesBool, value => new PineSeries<bool>());

            AddTypeCast(SimpleNA, SimpleString, value => string.Empty);
            AddTypeCast(SimpleNA, SeriesString, value => new PineSeries<string>());

            AddTypeCast(SimpleNA, SimpleColor, value => new PineColor());
            AddTypeCast(SimpleNA, SeriesColor, value => new PineSeries<PineColor>());

            // SeriesNA

            AddTypeCast(SeriesNA, SeriesInt, value => new PineSeries<long>());
            
            AddTypeCast(SeriesNA, SeriesFloat, value => new PineSeries<float>());
            
            AddTypeCast(SeriesNA, SeriesBool, value => new PineSeries<bool>());
            
            AddTypeCast(SeriesNA, SeriesString, value => new PineSeries<string>());
            
            AddTypeCast(SeriesNA, SeriesColor, value => new PineSeries<PineColor>());

            static object IntFloatConverter(object value) => (float) (long) value;
            static object IntBoolConverter(object value) => (long) value > 0;
            
            // LiteralInt

            AddDirectTypeCast(LiteralInt, ConstInt);
            AddDirectTypeCast(LiteralInt, InputInt);
            AddDirectTypeCast(LiteralInt, SimpleInt);
            AddTypeCast(LiteralInt, SeriesInt, value => new PineSeries<long>());

            AddTypeCast(LiteralInt, ConstFloat, IntFloatConverter);
            AddTypeCast(LiteralInt, InputFloat, IntFloatConverter);
            AddTypeCast(LiteralInt, SimpleFloat, IntFloatConverter);
            AddTypeCast(LiteralInt, SeriesFloat, value => new PineSeries<float>());

            AddTypeCast(LiteralInt, ConstBool, IntBoolConverter);
            AddTypeCast(LiteralInt, InputBool, IntBoolConverter);
            AddTypeCast(LiteralInt, SimpleBool, IntBoolConverter);
            AddTypeCast(LiteralInt, SeriesBool, value => new PineSeries<bool>());
            
            // ConstInt

            AddDirectTypeCast(ConstInt, InputInt);
            AddDirectTypeCast(ConstInt, SimpleInt);
            AddTypeCast(ConstInt, SeriesInt, value => new PineSeries<long>());

            AddTypeCast(ConstInt, ConstFloat, IntFloatConverter);
            AddTypeCast(ConstInt, InputFloat, IntFloatConverter);
            AddTypeCast(ConstInt, SimpleFloat, IntFloatConverter);
            AddTypeCast(ConstInt, SeriesFloat, value => new PineSeries<float>());

            AddTypeCast(ConstInt, ConstBool, IntBoolConverter);
            AddTypeCast(ConstInt, InputBool, IntBoolConverter);
            AddTypeCast(ConstInt, SimpleBool, IntBoolConverter);
            AddTypeCast(ConstInt, SeriesBool, value => new PineSeries<bool>());
            
            // InputInt

            AddDirectTypeCast(InputInt, SimpleInt);
            AddTypeCast(InputInt, SeriesInt, value => new PineSeries<long>());

            AddTypeCast(InputInt, InputFloat, IntFloatConverter);
            AddTypeCast(InputInt, SimpleFloat, IntFloatConverter);
            AddTypeCast(InputInt, SeriesFloat, value => new PineSeries<float>());

            AddTypeCast(InputInt, InputBool, IntBoolConverter);
            AddTypeCast(InputInt, SimpleBool, IntBoolConverter);
            AddTypeCast(InputInt, SeriesBool, value => new PineSeries<bool>());
            
            // SimpleInt

            AddTypeCast(SimpleInt, SeriesInt, value => new PineSeries<long>());

            AddTypeCast(SimpleInt, SimpleFloat, IntFloatConverter);
            AddTypeCast(SimpleInt, SeriesFloat, value => new PineSeries<float>());

            AddTypeCast(SimpleInt, SimpleBool, IntBoolConverter);
            AddTypeCast(SimpleInt, SeriesBool, value => new PineSeries<bool>());
            
            // SeriesInt

            AddTypeCast(SeriesInt, SeriesFloat, value => new PineSeries<float>());

            AddTypeCast(SeriesInt, SeriesBool, value => new PineSeries<bool>());

            static object FloatBoolConverter(object value) => (float) value > 0;

            // LiteralFloat

            AddDirectTypeCast(LiteralFloat, ConstFloat);
            AddDirectTypeCast(LiteralFloat, InputFloat);
            AddDirectTypeCast(LiteralFloat, SimpleFloat);
            AddTypeCast(LiteralFloat, SeriesFloat, value => new PineSeries<float>());

            AddTypeCast(LiteralFloat, ConstBool, FloatBoolConverter);
            AddTypeCast(LiteralFloat, InputBool, FloatBoolConverter);
            AddTypeCast(LiteralFloat, SimpleBool, FloatBoolConverter);
            AddTypeCast(LiteralFloat, SeriesBool, value => new PineSeries<bool>());

            // ConstFloat

            AddDirectTypeCast(ConstFloat, InputFloat);
            AddDirectTypeCast(ConstFloat, SimpleFloat);
            AddTypeCast(ConstFloat, SeriesFloat, value => new PineSeries<float>());

            AddTypeCast(ConstFloat, ConstBool, FloatBoolConverter);
            AddTypeCast(ConstFloat, InputBool, FloatBoolConverter);
            AddTypeCast(ConstFloat, SimpleBool, FloatBoolConverter);
            AddTypeCast(ConstFloat, SeriesBool, value => new PineSeries<bool>());

            // InputFloat

            AddDirectTypeCast(InputFloat, SimpleFloat);
            AddTypeCast(InputFloat, SeriesFloat, value => new PineSeries<float>());

            AddTypeCast(InputFloat, InputBool, FloatBoolConverter);
            AddTypeCast(InputFloat, SimpleBool, FloatBoolConverter);
            AddTypeCast(InputFloat, SeriesBool, value => new PineSeries<bool>());

            // SimpleFloat

            AddTypeCast(SimpleFloat, SeriesFloat, value => new PineSeries<float>());

            AddTypeCast(SimpleFloat, SimpleBool, FloatBoolConverter);
            AddTypeCast(SimpleFloat, SeriesBool, value => new PineSeries<bool>());

            // SeriesFloat

            AddTypeCast(SeriesFloat, SeriesBool, value => new PineSeries<bool>());

            // LiteralBool

            AddDirectTypeCast(LiteralBool, ConstBool);
            AddDirectTypeCast(LiteralBool, InputBool);
            AddDirectTypeCast(LiteralBool, SimpleBool);
            AddTypeCast(LiteralBool, SeriesBool, value => new PineSeries<bool>());

            // ConstBool

            AddDirectTypeCast(ConstBool, InputBool);
            AddDirectTypeCast(ConstBool, SimpleBool);
            AddTypeCast(ConstBool, SeriesBool, value => new PineSeries<bool>());

            // InputBool

            AddDirectTypeCast(InputBool, SimpleBool);
            AddTypeCast(InputBool, SeriesBool, value => new PineSeries<bool>());

            // SimpleBool

            AddTypeCast(SimpleBool, SeriesBool, value => new PineSeries<bool>());

            // LiteralColor

            AddDirectTypeCast(LiteralColor, ConstColor);
            AddDirectTypeCast(LiteralColor, InputColor);
            AddDirectTypeCast(LiteralColor, SimpleColor);
            AddTypeCast(LiteralColor, SeriesColor, value => new PineSeries<PineColor>());

            // ConstColor

            AddDirectTypeCast(ConstColor, InputColor);
            AddDirectTypeCast(ConstColor, SimpleColor);
            AddTypeCast(ConstColor, SeriesColor, value => new PineSeries<PineColor>());

            // InputColor

            AddDirectTypeCast(InputColor, SimpleColor);
            AddTypeCast(InputColor, SeriesColor, value => new PineSeries<PineColor>());

            // SimpleColor

            AddTypeCast(SimpleColor, SeriesColor, value => new PineSeries<PineColor>());

            // LiteralColor

            AddDirectTypeCast(LiteralString, ConstString);
            AddDirectTypeCast(LiteralString, InputString);
            AddDirectTypeCast(LiteralString, SimpleString);
            AddTypeCast(LiteralString, SeriesString, value => new PineSeries<string>());

            // ConstString

            AddDirectTypeCast(ConstString, InputString);
            AddDirectTypeCast(ConstString, SimpleString);
            AddTypeCast(ConstString, SeriesString, value => new PineSeries<string>());

            // InputString

            AddDirectTypeCast(InputString, SimpleString);
            AddTypeCast(InputString, SeriesString, value => new PineSeries<string>());

            // SimpleString

            AddTypeCast(SimpleString, SeriesString, value => new PineSeries<string>());
        }
    }
}