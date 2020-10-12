﻿using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Tree;

namespace Razensoft.Trade.Pine.Ast
{
    public class PineScriptProgram
    {
        public PineScriptAst Ast { get; }
    }

    public class PineScriptSymbolTable
    {
        private readonly Dictionary<string, VariableInfo> _variables = new Dictionary<string, VariableInfo>();
        private readonly Dictionary<string, string> _functions = new Dictionary<string, string>();

        public void DeclareVariable(string name, PineType type)
        {
            if (_variables.ContainsKey(name))
            {
                throw new Exception($"Variable with name '{name} is already declared");
            }

            _variables.Add(name, new VariableInfo(name, type));
        }

        public VariableInfo GetVariableInfo(string name)
        {
            if (!_variables.ContainsKey(name))
            {
                throw new Exception($"Variable with name '{name} is not declared");
            }

            return _variables[name];
        }
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

    public class PineScriptAst
    {
        public PineScriptAst(PineScriptAstNode root)
        {
            Root = root;
        }

        public PineScriptAstNode Root { get; }
    }

    public abstract class PineScriptAstNode { }

    public class StatementBlockAstNode : PineScriptAstNode
    {
        public StatementBlockAstNode(IEnumerable<PineScriptAstNode> nodes)
        {
            Nodes = nodes;
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
            List<FunctionArgumentAstNode> args)
        {
            Name = name;
            Args = args;
        }

        public FunctionNameAstNode Name { get; }

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
                });
            var sequence = new StatementBlockAstNode(statements);
            return new PineScriptAst(sequence);
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

    public class PineScriptParseNodeVisitor : PineScriptBaseVisitor<PineScriptAstNode>
    {
        private readonly PineScriptSymbolTable _symbolTable;
        private readonly PineScriptTypeInferringVisitor _typeInferringVisitor;

        public PineScriptParseNodeVisitor(PineScriptSymbolTable symbolTable)
        {
            _symbolTable = symbolTable;
            _typeInferringVisitor = new PineScriptTypeInferringVisitor(_symbolTable);
        }

        public override PineScriptAstNode VisitBlock(PineScriptParser.BlockContext context)
        {
            return context.statementList().Accept(this);
        }

        public override PineScriptAstNode VisitStatementList(PineScriptParser.StatementListContext context)
        {
            var statements = context.statement()
                .Select((statement, _) => statement.Accept(this));
            return new StatementBlockAstNode(statements);
        }

        public override PineScriptAstNode VisitVariableDeclarationStatement(
            PineScriptParser.VariableDeclarationStatementContext context)
        {
            var name = context.Identifier().GetText();
            var valueContext = context.variableValue();
            var type = InferType(valueContext);
            _symbolTable.DeclareVariable(name, type);
            return new VariableAssignmentAstNode(name, valueContext.Accept(this));
        }

        public override PineScriptAstNode VisitVariableAssignmentStatement(
            PineScriptParser.VariableAssignmentStatementContext context)
        {
            var name = context.Identifier().GetText();
            var valueContext = context.variableValue();
            var valueType = InferType(valueContext);
            var variableInfo = _symbolTable.GetVariableInfo(name);
            var variableType = variableInfo.Type;
            if (variableType == valueType)
            {
                return new VariableAssignmentAstNode(name, valueContext.Accept(this));
            }

            if (valueType.IsConvertibleTo(variableType))
            {
                var cast = new ValueCastAstNode(valueType, variableType, valueContext.Accept(this));
                return new VariableAssignmentAstNode(name, cast);
            }

            throw new Exception($"Variable \"{name}\" was declared with \"{variableType}\" type. " +
                                $"Cannot assign it expression of type \"{valueType}\".");
        }

        public override PineScriptAstNode VisitFunctionDeclarationStatement(
            PineScriptParser.FunctionDeclarationStatementContext context)
        {
            var name = new FunctionNameAstNode(context.Identifier().GetText());
            var body = context.functionBody().Accept(this);
            if (context.functionParameters() == null)
            {
                return new FunctionDeclarationAstNode(name, new List<VariableNameAstNode>(), body);
            }

            var parameters = context.functionParameters()
                .Identifier()
                .Select(id => new VariableNameAstNode(id.GetText()))
                .ToList();
            return new FunctionDeclarationAstNode(name, parameters, body);
        }

        public override PineScriptAstNode VisitFunctionCallStatement(
            PineScriptParser.FunctionCallStatementContext context)
        {
            var name = new FunctionNameAstNode(context.Identifier().GetText());
            var args = new List<FunctionArgumentAstNode>();
            if (context.functionArguments() != null)
            {
                var functionArguments = context.functionArguments();
                var positionalArgs = functionArguments
                    ._positional
                    .Select(e => new FunctionArgumentAstNode(e.Accept(this), null));
                args.AddRange(positionalArgs);
                var namedArgs = functionArguments._named
                    .Select(e => e.Accept(this))
                    .Cast<FunctionArgumentAstNode>();
                args.AddRange(namedArgs);
            }

            return new FunctionCallAstNode(name, args);
        }

        public override PineScriptAstNode VisitNamedFunctionArgument(
            PineScriptParser.NamedFunctionArgumentContext context)
        {
            return new FunctionArgumentAstNode(context.expression().Accept(this), context.Identifier().GetText());
        }

        public override PineScriptAstNode VisitIfStatement(PineScriptParser.IfStatementContext context)
        {
            var condition = context.expression().Accept(this);
            var thenBlock = context.block().Accept(this);
            var elseBlock = context.ifStatementElseBody()?.Accept(this);
            return new ConditionalAstNode(condition, thenBlock, elseBlock);
        }

        private PineType InferType(IParseTree context)
        {
            return _typeInferringVisitor.Visit(context);
        }
    }
}