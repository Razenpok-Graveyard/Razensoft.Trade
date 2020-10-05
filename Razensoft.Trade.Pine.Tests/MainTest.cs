using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Antlr4.Runtime;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Razensoft.Trade.Pine.Parsing.Tests
{
    public class MainTest
    {
        [Test]
        public void Test1()
        {
            var scriptSource = File.ReadAllText("example - Processed.pine");
            //var strategy = PineStrategy.FromScript(scriptSource);
            //var preprocessed2 = PineScriptPreprocessor.Preprocess(scriptSource);
            //Console.WriteLine(preprocessed2);
            //return;
            var preprocessed = scriptSource
                .Replace("\r\n", "\n");
            var inputStream = new AntlrInputStream(preprocessed);
            var lexer = new PineScriptLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new PineScriptParser(tokens);

            var classVisitor = new PineScriptVisitor();
            var statements = classVisitor.VisitScript(parser.script()).ToList();
            var script = new PineScript(statements);

            var executionContext = new RootPineScriptExecutionContext();
            script.Execute(executionContext);
        }
    }
}