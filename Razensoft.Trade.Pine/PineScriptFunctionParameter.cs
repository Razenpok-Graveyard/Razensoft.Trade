namespace Razensoft.Trade.Pine
{
    public class PineScriptFunctionParameter
    {
        public PineScriptFunctionParameter(string name, object defaultValue)
        {
            Name = name;
            DefaultValue = defaultValue;
        }

        public string Name { get; }

        public object DefaultValue { get; }
    }
}