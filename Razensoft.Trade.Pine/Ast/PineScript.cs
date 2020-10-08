using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Tree;
using Razensoft.Trade.Pine.Statements;

namespace Razensoft.Trade.Pine.Ast
{
    public class PineScriptAst
    {
        public PineScriptAst(PineScriptAstNode root)
        {
            Root = root;
        }

        public PineScriptAstNode Root { get; }
    }

    public abstract class PineScriptAstNode
    {
    }

    public class StatementSequenceAstNode : PineScriptAstNode
    {
        public StatementSequenceAstNode(IEnumerable<PineScriptAstNode> nodes)
        {
            Nodes = nodes;
        }

        public IEnumerable<PineScriptAstNode> Nodes { get; }
    }

    public class DeclareVariableAstNode : PineScriptAstNode
    {
        public DeclareVariableAstNode(VariableNameAstNode name, PineScriptAstNode value)
        {
            Name = name;
            Value = value;
        }

        public VariableNameAstNode Name { get; }

        public PineScriptAstNode Value { get; }
    }

    public class AssignVariableAstNode : PineScriptAstNode
    {
        public AssignVariableAstNode(VariableNameAstNode name, PineScriptAstNode value)
        {
            Name = name;
            Value = value;
        }

        public VariableNameAstNode Name { get; }

        public PineScriptAstNode Value { get; }
    }

    public class VariableNameAstNode : PineScriptAstNode
    {
        public VariableNameAstNode(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }

    public class DeclareFunctionAstNode : PineScriptAstNode
    {
        public DeclareFunctionAstNode(
            FunctionNameAstNode name,
            List<VariableNameAstNode> parameters,
            PineScriptAstNode body)
        {
            Name = name;
            Parameters = parameters;
            Body = body;
        }

        public FunctionNameAstNode Name { get; }

        public List<VariableNameAstNode> Parameters { get; }

        public PineScriptAstNode Body { get; }
    }

    public class CallFunctionAstNode : PineScriptAstNode
    {
        public CallFunctionAstNode(
            FunctionNameAstNode name,
            List<PineScriptAstNode> positionalArgs,
            List<DeclareVariableAstNode> namedArgs)
        {
            Name = name;
            PositionalArgs = positionalArgs;
            NamedArgs = namedArgs;
        }

        public FunctionNameAstNode Name { get; }

        public List<PineScriptAstNode> PositionalArgs { get; }

        public List<DeclareVariableAstNode> NamedArgs { get; }
    }

    public class FunctionNameAstNode : PineScriptAstNode
    {
        public FunctionNameAstNode(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }


    public class PineScriptParseTreeVisitor : PineScriptBaseVisitor<PineScriptAst>
    {
        public override PineScriptAst VisitScript(PineScriptParser.ScriptContext context)
        {
            var statements = context.statement()
                .Select((statement, _) =>
                {
                    var visitor = new PineScriptParseNodeVisitor();
                    return statement.Accept(visitor);
                });
            var sequence = new StatementSequenceAstNode(statements);
            return new PineScriptAst(sequence);
        }
    }


    public class PineScriptParseNodeVisitor : PineScriptBaseVisitor<PineScriptAstNode>
    {
        public override PineScriptAstNode VisitStatement(PineScriptParser.StatementContext context)
        {
            context.GetChild(0).Accept(this);
            return base.VisitStatement(context);
        }

        public override PineScriptAstNode VisitVariableDeclaration(PineScriptParser.VariableDeclarationContext context)
        {
            var name = new VariableNameAstNode(context.ID().GetText());
            var value = context.variableValue().Accept(this);
            return new DeclareVariableAstNode(name, value);
        }

        public override PineScriptAstNode VisitVariableAssignment(PineScriptParser.VariableAssignmentContext context)
        {
            var name = new VariableNameAstNode(context.ID().GetText());
            var value = context.variableValue().Accept(this);
            return new AssignVariableAstNode(name, value);
        }

        public override PineScriptAstNode VisitVariableValue(PineScriptParser.VariableValueContext context)
        {
            return context.GetChild(0).Accept(this);
        }

        public override PineScriptAstNode VisitFunctionDeclaration(PineScriptParser.FunctionDeclarationContext context)
        {
            var name = new FunctionNameAstNode(context.ID().GetText());
            var parameters = context.functionParameters()
                .ID()
                .Select(id => new VariableNameAstNode(id.GetText()))
                .ToList();
            var body = context.functionBody().Accept(this);
            return new DeclareFunctionAstNode(name, parameters, body);
        }

        public override PineScriptAstNode VisitFunctionCall(PineScriptParser.FunctionCallContext context)
        {
            var name = new FunctionNameAstNode(context.ID().GetText());
            var functionArguments = context.functionArguments();
            var positionalArgs = functionArguments.expression()
                .Select(e => e.Accept(this))
                .ToList();
            var namedArgs = functionArguments.variableDeclaration()
                .Select(e => e.Accept(this))
                .Cast<DeclareVariableAstNode>()
                .ToList();
            return new CallFunctionAstNode(name, positionalArgs, namedArgs);
        }
    }
}