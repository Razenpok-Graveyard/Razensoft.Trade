using System;

namespace Razensoft.Trade.Pine.Parsing
{
    public abstract class BuiltinVariableProvider
    {
        public virtual PineNA na => throw new NotImplementedException();

        public virtual string input__integer => throw new NotImplementedException();
        public virtual string input__float => throw new NotImplementedException();
        public virtual string input__bool => throw new NotImplementedException();

        public virtual int plot__style_linebr => throw new NotImplementedException();
        public virtual int plot__style_circles => throw new NotImplementedException();

        public virtual string location__absolute => throw new NotImplementedException();

        public virtual string shape__circle => throw new NotImplementedException();
        public virtual string shape__labelup => throw new NotImplementedException();
        public virtual string shape__labeldown => throw new NotImplementedException();

        public virtual string size__tiny => throw new NotImplementedException();

        public virtual PineColor color__green => throw new NotImplementedException();
        public virtual PineColor color__white => throw new NotImplementedException();
        public virtual PineColor color__red => throw new NotImplementedException();

        public virtual PineSeries<float> open => throw new NotImplementedException();
        public virtual PineSeries<float> close => throw new NotImplementedException();
        public virtual PineSeries<float> high => throw new NotImplementedException();
        public virtual PineSeries<float> low => throw new NotImplementedException();
        public virtual PineSeries<float> hl2 => throw new NotImplementedException();
        public virtual PineSeries<float> ohlc4 => throw new NotImplementedException();
        public virtual PineSeries<float> tr => throw new NotImplementedException();
    }
}