using Razensoft.Trade.Pine.Parsing;

namespace Razensoft.Trade.Pine.Statements
{
    public class VariableDeclarationStatement : PineScriptStatement
    {
        public VariableDeclarationStatement(string name, PineScriptStatement value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }

        public PineScriptStatement Value { get; }

        public override object Execute(PineScriptExecutionContext context)
        {
            var value = Value.Execute(context);
            context.DeclareVariable(Name, value);
            return value;
        }
    }
}