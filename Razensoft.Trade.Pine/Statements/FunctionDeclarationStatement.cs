using System.Linq;
using Razensoft.Trade.Pine.Parsing;

namespace Razensoft.Trade.Pine.Statements
{
    public class FunctionDeclarationStatement : PineScriptStatement
    {
        private readonly string _name;
        private readonly string[] _parameters;
        private readonly PineScriptStatement _body;

        public FunctionDeclarationStatement(string name, string[] parameters, PineScriptStatement body)
        {
            _name = name;
            _parameters = parameters;
            _body = body;
        }

        public override object Execute(PineScriptExecutionContext context)
        {
            var parameters = _parameters
                .Select(param => new PineScriptFunctionParameter(param, null))
                .ToArray();
            var function = new UserDefinedFunction(_name, parameters, _body);
            context.DeclareFunction(function);
            return null;
        }
    }
}