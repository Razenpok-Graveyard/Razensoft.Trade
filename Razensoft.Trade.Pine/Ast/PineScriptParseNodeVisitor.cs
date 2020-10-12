using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Tree;

namespace Razensoft.Trade.Pine.Ast
{
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
            var name = context.Identifier().GetText();
            var parameters = new List<string>();
            if (context.functionParameters() != null)
            {
                parameters = context.functionParameters()
                    .Identifier()
                    .Select(id => id.GetText())
                    .ToList();
            }

            _symbolTable.DeclareFunction(name, parameters, context.functionBody());
            return new NoopAstNode();
        }

        public override PineScriptAstNode VisitFunctionCallStatement(
            PineScriptParser.FunctionCallStatementContext context)
        {
            var name = context.Identifier().GetText();
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