namespace Razensoft.Trade.Pine.Statements
{
    public class IdentifierExpression : ExpressionStatement
    {
        private readonly string _name;

        public IdentifierExpression(string name)
        {
            _name = name;
        }

        public override object Execute(PineScriptExecutionContext context)
        {
            return context.GetVariableValue(_name);
        }
    }
}