using System;

namespace Razensoft.Trade.Pine
{
    public abstract partial class BuiltinFunctionProvider
    {
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
    }
}
