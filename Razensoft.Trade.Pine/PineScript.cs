using System;
using System.Collections.Generic;
using Razensoft.Trade.Pine.Statements;

[assembly: CLSCompliant(false)]
namespace Razensoft.Trade.Pine.Parsing
{
    public class PineScript
    {
        private readonly PineScriptFunction _main;

        public PineScript(IEnumerable<PineScriptStatement> statements)
        {
            var block = new StatementBlock(statements);
            _main = new UserDefinedFunction("Main", new PineScriptFunctionParameter[0], block);
        }

        public void Execute(PineScriptExecutionContext parent = null)
        {
            var context = new PineScriptExecutionContext(parent);
            _main.Execute(context, new object[0], new Dictionary<string, object>());
        }
    }
}