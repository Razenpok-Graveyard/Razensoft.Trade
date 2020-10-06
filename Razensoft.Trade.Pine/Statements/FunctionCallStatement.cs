using System.Linq;

namespace Razensoft.Trade.Pine.Statements
{
    public class FunctionCallStatement : PineScriptStatement
    {
        private readonly string _name;
        private readonly PineScriptStatement[] _args;

        public FunctionCallStatement(string name, PineScriptStatement[] args)
        {
            _name = name;
            _args = args;
        }

        public override object Execute(PineScriptExecutionContext context)
        {
            var positionalArgs = _args
                .TakeWhile(arg => arg is ExpressionStatement || arg is TernaryExpression)
                .Select(arg => arg.Execute(context))
                .ToArray();
            var namedArgs = _args
                .Skip(positionalArgs.Length)
                .Cast<VariableDeclarationStatement>()
                .ToDictionary(
                    s => s.Name,
                    s => s.Value.Execute(context));
            return context.CallFunction(_name, positionalArgs, namedArgs);
        }
    }
}