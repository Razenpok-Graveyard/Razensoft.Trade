using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime;
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

    public class StatementBlockAstNode : PineScriptAstNode
    {
        public StatementBlockAstNode(IEnumerable<PineScriptAstNode> nodes)
        {
            Nodes = nodes;
        }

        public IEnumerable<PineScriptAstNode> Nodes { get; }
    }

    public class VariableDeclarationAstNode : PineScriptAstNode
    {
        public VariableDeclarationAstNode(VariableNameAstNode name, PineScriptAstNode value)
        {
            Name = name;
            Value = value;
        }

        public VariableNameAstNode Name { get; }

        public PineScriptAstNode Value { get; }
    }

    public class VariableAssignmentAstNode : PineScriptAstNode
    {
        public VariableAssignmentAstNode(VariableNameAstNode name, PineScriptAstNode value)
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

    public class FunctionDeclarationAstNode : PineScriptAstNode
    {
        public FunctionDeclarationAstNode(
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

    public class FunctionCallAstNode : PineScriptAstNode
    {
        public FunctionCallAstNode(
            FunctionNameAstNode name,
            List<PineScriptAstNode> positionalArgs,
            List<VariableDeclarationAstNode> namedArgs)
        {
            Name = name;
            PositionalArgs = positionalArgs;
            NamedArgs = namedArgs;
        }

        public FunctionNameAstNode Name { get; }

        public List<PineScriptAstNode> PositionalArgs { get; }

        public List<VariableDeclarationAstNode> NamedArgs { get; }
    }

    public class FunctionNameAstNode : PineScriptAstNode
    {
        public FunctionNameAstNode(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }

    public class ConditionalAstNode : PineScriptAstNode
    {
        public ConditionalAstNode(
            PineScriptAstNode condition,
            PineScriptAstNode thenBlock,
            PineScriptAstNode elseBlock)
        {
            Condition = condition;
            ThenBlock = thenBlock;
            ElseBlock = elseBlock;
        }

        public PineScriptAstNode Condition { get; }

        public PineScriptAstNode ThenBlock { get; }

        public PineScriptAstNode ElseBlock { get; }
    }

    public class LoopAstNode : PineScriptAstNode
    {
        public LoopAstNode(
            PineScriptAstNode counterDeclaration,
            PineScriptAstNode endValue,
            PineScriptAstNode body,
            int step = 1
        )
        {
        }
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
            var sequence = new StatementBlockAstNode(statements);
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
            return new VariableDeclarationAstNode(name, value);
        }

        public override PineScriptAstNode VisitVariableAssignment(PineScriptParser.VariableAssignmentContext context)
        {
            var name = new VariableNameAstNode(context.ID().GetText());
            var value = context.variableValue().Accept(this);
            return new VariableAssignmentAstNode(name, value);
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
            return new FunctionDeclarationAstNode(name, parameters, body);
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
                .Cast<VariableDeclarationAstNode>()
                .ToList();
            return new FunctionCallAstNode(name, positionalArgs, namedArgs);
        }

        public override PineScriptAstNode VisitConditional(PineScriptParser.ConditionalContext context)
        {
            var condition = context.condition.Accept(this);
            var thenBlock = context.then.Accept(this);
            var elseBlock = context.@else?.GetChild(0).Accept(this);
            return new ConditionalAstNode(condition, thenBlock, elseBlock);
        }

        /*public override PineScriptAstNode VisitLoop(PineScriptParser.LoopContext context)
        {
            var counterDeclaration = context.variableDeclaration().Accept(this);
            var endValue = context.expression().Accept(this);
            var body = context.expression().Accept(this);
            var step = context.step != null ? int.Parse(context.step.Text) : 1;
            return new LoopStatement(counterDeclaration, endValue, body, step);
        }

        /*public override PineScriptAstNode VisitBlock(PineScriptParser.BlockContext context)
        {
            var statements = context.statement()
                .Select(statement => statement.Accept(this))
                .ToArray();
            return new StatementBlock(statements);
        }*/
    }
}