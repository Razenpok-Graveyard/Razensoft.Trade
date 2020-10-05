using Razensoft.Trade.Pine.Parsing;

namespace Razensoft.Trade.Pine.Statements
{
    public class VariableAssignmentStatement : PineScriptStatement
    {
        private readonly string _name;
        private readonly PineScriptStatement _value;

        public VariableAssignmentStatement(string name, PineScriptStatement value)
        {
            _name = name;
            _value = value;
        }

        public override object Execute(PineScriptExecutionContext context)
        {
            var value = _value.Execute(context);
            context.AssignVariable(_name, value);
            return value;
        }
    }
}