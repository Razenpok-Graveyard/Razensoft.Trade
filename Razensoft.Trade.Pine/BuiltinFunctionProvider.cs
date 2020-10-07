using System;

namespace Razensoft.Trade.Pine
{
    public abstract partial class BuiltinFunctionProvider
    {
        public BuiltinVariableProvider VariableProvider { get; set; }

        /// <summary>
        /// Adds an input to your script indicator. User can see and edit inputs
        /// on the Format Object dialog of the script study. Script inputs look
        /// and behave exactly the same as inputs of built-in Technical Analysis
        /// indicators.
        /// </summary>
        public virtual object input(
            object defval, object title, object type, object minval,
            object maxval, object confirm, object step, object options)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Replaces NaN values with zeros (or given value) in a series.
        /// </summary>
        public virtual object nz(object x, object y)
        {
            throw new NotImplementedException();
        }

        public virtual long max(long x1, long x2)
        {
            throw new NotImplementedException();
        }

        public virtual float max(float x1, float x2)
        {
            throw new NotImplementedException();
        }
    }
}