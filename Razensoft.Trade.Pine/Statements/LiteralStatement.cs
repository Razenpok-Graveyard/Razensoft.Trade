namespace Razensoft.Trade.Pine.Statements
{
    public class LiteralStatement : ExpressionStatement
    {
        private readonly object _value;

        public LiteralStatement(object value)
        {
            _value = value;
        }

        public override object Execute(PineScriptExecutionContext context)
        {
            return _value;
        }
    }
}