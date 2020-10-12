using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Tree;

namespace Razensoft.Trade.Pine.Ast
{
    public class PineScriptProgram
    {
        public PineScriptAst Ast { get; }
    }

    public class VariableInfo
    {
        public VariableInfo(string name, PineType type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; }

        public PineType Type { get; }
    }

    public class FunctionInfo
    {
        public FunctionInfo(string name, IReadOnlyList<string> parameters, IParseTree body)
        {
            Name = name;
            Parameters = parameters;
            Body = body;
        }
        
        public string Name { get; }
        
        public IReadOnlyList<string> Parameters { get; }
        
        public IParseTree Body { get; }
    }

    public class FunctionOverloadInfo
    {
        public FunctionOverloadInfo(
            FunctionInfo functionInfo,
            PineType returnType,
            IReadOnlyList<FunctionParameterInfo> parameters,
            PineScriptAst body)
        {
            FunctionInfo = functionInfo;
            Parameters = parameters;
            ReturnType = returnType;
            Body = body;
        }
        
        public FunctionInfo FunctionInfo { get; }
        
        public IReadOnlyList<FunctionParameterInfo> Parameters { get; }

        public PineType ReturnType { get; }
        
        public PineScriptAst Body { get; }

        public bool CanAccept(IEnumerable<PineType> args)
        {
            return Parameters.Select(p => p.Type).SequenceEqual(args);
        }
    }

    public class FunctionParameterInfo
    {
        public FunctionParameterInfo(string name, PineType type)
        {
            Name = name;
            Type = type;
        }
        
        public string Name { get; }
        
        public PineType Type { get; }
    }

    public class PineScriptAst
    {
        public PineScriptAst(PineScriptAstNode root)
        {
            Root = root;
        }

        public PineScriptAstNode Root { get; }
    }

    public abstract class PineScriptAstNode { }

    public class NoopAstNode : PineScriptAstNode
    {
        
    }

    public class StatementBlockAstNode : PineScriptAstNode
    {
        public StatementBlockAstNode(IEnumerable<PineScriptAstNode> nodes)
        {
            Nodes = nodes.ToList();
        }

        public IEnumerable<PineScriptAstNode> Nodes { get; }
    }

    public class ValueCastAstNode : PineScriptAstNode
    {
        public ValueCastAstNode(PineType from, PineType to, PineScriptAstNode expression)
        {
            From = from;
            To = to;
            Expression = expression;
        }

        public PineType From { get; }

        public PineType To { get; }
        
        public PineScriptAstNode Expression { get; }
    }

    public class VariableAssignmentAstNode : PineScriptAstNode
    {
        public VariableAssignmentAstNode(string name, PineScriptAstNode value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }

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
            string name,
            List<VariableNameAstNode> parameters,
            PineScriptAstNode body)
        {
            Name = name;
            Parameters = parameters;
            Body = body;
        }

        public string Name { get; }

        public List<VariableNameAstNode> Parameters { get; }

        public PineScriptAstNode Body { get; }
    }

    public class FunctionCallAstNode : PineScriptAstNode
    {
        public FunctionCallAstNode(
            string name,
            List<FunctionArgumentAstNode> args)
        {
            Name = name;
            Args = args;
        }

        public string Name { get; }

        public List<FunctionArgumentAstNode> Args { get; }
    }

    public class FunctionArgumentAstNode : PineScriptAstNode
    {
        public FunctionArgumentAstNode(PineScriptAstNode expression, string name)
        {
            Expression = expression;
            Name = name;
        }

        public PineScriptAstNode Expression { get; }

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

    public class UnaryOperation : PineScriptAstNode { }

    public class BinaryOperation : PineScriptAstNode { }

    public class PineScriptParseTreeVisitor : PineScriptBaseVisitor<PineScriptAst>
    {
        private readonly PineScriptSymbolTable _symbolTable;

        public PineScriptParseTreeVisitor(PineScriptSymbolTable symbolTable)
        {
            _symbolTable = symbolTable;
        }

        public override PineScriptAst VisitScript(PineScriptParser.ScriptContext context)
        {
            var statements = context.statementList()
                .statement()
                .Select((statement, _) =>
                {
                    var visitor = new PineScriptParseNodeVisitor(_symbolTable);
                    return statement.Accept(visitor);
                })
                .Where(s => !(s is NoopAstNode));
            var sequence = new StatementBlockAstNode(statements);
            return new PineScriptAst(sequence);
        }
    }

    public class PineScriptFunctionOverloadVisitor : PineScriptBaseVisitor<FunctionOverloadInfo>
    {
        private readonly PineScriptSymbolTable _symbolTable;

        public PineScriptFunctionOverloadVisitor(PineScriptSymbolTable symbolTable)
        {
            _symbolTable = symbolTable;
        }

        public override FunctionOverloadInfo VisitFunctionBody(PineScriptParser.FunctionBodyContext context)
        {
        }
    }

    public class PineScriptTypeInferringVisitor : PineScriptBaseVisitor<PineType>
    {
        private readonly PineScriptSymbolTable _symbolTable;

        public PineScriptTypeInferringVisitor(PineScriptSymbolTable symbolTable)
        {
            _symbolTable = symbolTable;
        }
    }
}