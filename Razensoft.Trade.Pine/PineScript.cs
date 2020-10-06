using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Antlr4.Runtime;
using Razensoft.Trade.Pine.Statements;

[assembly: CLSCompliant(false)]
namespace Razensoft.Trade.Pine
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

        public static PineScript FromFile(string path)
        {
            var scriptSource = File.ReadAllText(path);
            var preprocessed = PineScriptPreprocessor.Preprocess(scriptSource);
            var inputStream = new AntlrInputStream(preprocessed);
            var lexer = new PineScriptLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new PineScriptParser(tokens);
            var classVisitor = new PineScriptVisitor();
            var statements = classVisitor.VisitScript(parser.script()).ToList();
            return new PineScript(statements);
        }
    }
}