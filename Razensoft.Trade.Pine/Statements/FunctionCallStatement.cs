using System.Linq;

namespace Razensoft.Trade.Pine.Statements
{
    public class FunctionCallStatement : PineScriptStatement
    {
        private readonly string _name;
        private readonly PineScriptStatement[] _positionalArgs;
        private readonly PineScriptStatement[] _namedArgs;

        public FunctionCallStatement(string name, PineScriptStatement[] positionalArgs, PineScriptStatement[] namedArgs)
        {
            _name = name;
            _positionalArgs = positionalArgs;
            _namedArgs = namedArgs;
        }

        public override object Execute(PineScriptExecutionContext context)
        {
            var positionalArgs = _positionalArgs
                .Select(arg => arg.Execute(context))
                .ToArray();
            var namedArgs = _namedArgs
                .Cast<VariableDeclarationStatement>()
                .ToDictionary(
                    s => s.Name,
                    s => s.Value.Execute(context));
            return context.CallFunction(_name, positionalArgs, namedArgs);
        }
    }
}