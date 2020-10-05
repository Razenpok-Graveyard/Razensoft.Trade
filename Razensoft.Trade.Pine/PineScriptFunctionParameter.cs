namespace Razensoft.Trade.Pine.Parsing
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