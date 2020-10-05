using System;
using System.Linq;
using Antlr4.Runtime.Tree;
using Razensoft.Trade.Pine.Statements;

namespace Razensoft.Trade.Pine.Parsing
{
    public class PineScriptStatementVisitor : PineScriptBaseVisitor<PineScriptStatement>
    {
        public override PineScriptStatement VisitStatement(PineScriptParser.StatementContext context)
        {
            context.GetChild(0).Accept(this);
            return base.VisitStatement(context);
        }

        public override PineScriptStatement VisitVariableDeclaration(PineScriptParser.VariableDeclarationContext context)
        {
            var name = context.ID().GetText();
            var value = context.GetChild(2).Accept(this);
            return new VariableDeclarationStatement(name, value);
        }

        public override PineScriptStatement VisitVariableAssignment(PineScriptParser.VariableAssignmentContext context)
        {
            var name = context.ID().GetText();
            var value = context.GetChild(2).Accept(this);
            return new VariableAssignmentStatement(name, value);
        }

        public override PineScriptStatement VisitFunctionDeclaration(PineScriptParser.FunctionDeclarationContext context)
        {
            var name = context.ID().GetText();
            var parametersContext = context.functionParameters();
            var parameters = parametersContext.ID()
                .Select(id => id.GetText())
                .ToArray();
            var body = context.GetChild(5).Accept(this);
            return new FunctionDeclarationStatement(name, parameters, body);
        }

        public override PineScriptStatement VisitFunctionCall(PineScriptParser.FunctionCallContext context)
        {
            var name = context.ID().GetText();
            var functionArguments = context.functionArguments().children
                                    ?? Enumerable.Empty<IParseTree>();
            var args = functionArguments
                .Select(token => token.Accept(this))
                .Where(arg => arg != null)
                .ToArray();
            return new FunctionCallStatement(name, args);
        }

        public override PineScriptStatement VisitTernary(PineScriptParser.TernaryContext context)
        {
            var expressions = context.expression();
            var condition = expressions[0].Accept(this);
            var truthyExpression = expressions[1].Accept(this);
            PineScriptStatement falsyExpression;
            if (expressions.Length == 3)
            {
                falsyExpression = expressions[2].Accept(this);
            }
            else
            {
                falsyExpression = context.ternary().Accept(this);
            }
            return new TernaryExpression(condition, truthyExpression, falsyExpression);
        }

        public override PineScriptStatement VisitConditional(PineScriptParser.ConditionalContext context)
        {
            var condition = context.expression().Accept(this);
            var thenBlock = context.GetChild(2).Accept(this);
            var elseBlock = context.ChildCount > 3
                ? context.GetChild(4).Accept(this)
                : null;
            return new ConditionalStatement(condition, thenBlock, elseBlock);
        }

        public override PineScriptStatement VisitLoop(PineScriptParser.LoopContext context)
        {
            var counterDeclaration = context.variableDeclaration().Accept(this);
            var endValue = context.expression().Accept(this);
            var body = context.variableDeclaration().Accept(this);
            var step = 1;
            var stepToken = context.INT_LITERAL();
            if (stepToken != null)
            {
                step = int.Parse(stepToken.GetText());
            }
            return new LoopStatement(counterDeclaration, endValue, body, step);
        }

        public override PineScriptStatement VisitBlock(PineScriptParser.BlockContext context)
        {
            var statements = context.statement()
                .Select(statement => statement.Accept(this))
                .ToArray();
            return new StatementBlock(statements);
        }

        public override PineScriptStatement VisitLiteralExpression(PineScriptParser.LiteralExpressionContext context)
        {
            static PineScriptStatement ParseLiteral<T>(IParseTree node, Func<string, T> parse)
            {
                return node != null ? new LiteralStatement(parse(node.GetText())) : null;
            }

            return ParseLiteral(context.BOOL_LITERAL(), bool.Parse) ??
                   ParseLiteral(context.STR_LITERAL(), literal => literal.Trim('"')) ??
                   ParseLiteral(context.COLOR_LITERAL(), literal => literal) ??
                   ParseLiteral(context.INT_LITERAL(), literal =>
                   {
                       var value = int.Parse(literal);
                       return context.MINUS() != null ? -value : value;
                   }) ??
                   ParseLiteral(context.FLOAT_LITERAL(), literal =>
                   {
                       var value = float.Parse(literal);
                       return context.MINUS() != null ? -value : value;
                   });
        }

        public override PineScriptStatement VisitCallExpression(PineScriptParser.CallExpressionContext context)
        {
            var functionCall = context.functionCall().Accept(this);
            if (context.NOT() != null) return UnaryExpression.Not(functionCall);
            if (context.MINUS() != null) return UnaryExpression.Minus(functionCall);
            return functionCall;
        }

        public override PineScriptStatement VisitBinaryOperationExpression(PineScriptParser.BinaryOperationExpressionContext context)
        {
            var expressions = context.expression();
            var left = expressions[0].Accept(this);
            var right = expressions[1].Accept(this);
            if (context.OR() != null) return BinaryExpression.Or(left, right);
            if (context.AND() != null) return BinaryExpression.And(left, right);
            if (context.EQ() != null) return BinaryExpression.Equals(left, right);
            if (context.NEQ() != null) return BinaryExpression.NotEquals(left, right);
            if (context.GT() != null) return BinaryExpression.GreaterThan(left, right);
            if (context.GE() != null) return BinaryExpression.GreaterThanOrEquals(left, right);
            if (context.LT() != null) return BinaryExpression.LowerThan(left, right);
            if (context.LE() != null) return BinaryExpression.LowerThanOrEquals(left, right);
            if (context.PLUS() != null) return BinaryExpression.Add(left, right);
            if (context.MINUS() != null) return BinaryExpression.Subtract(left, right);
            if (context.MUL() != null) return BinaryExpression.Multiply(left, right);
            if (context.DIV() != null) return BinaryExpression.Divide(left, right);
            if (context.MOD() != null) return BinaryExpression.Modulo(left, right);
            throw new Exception("Unknown binary operator");
        }

        public override PineScriptStatement VisitGroupExpression(PineScriptParser.GroupExpressionContext context)
        {
            var ternary = context.ternary();
            if (ternary != null)
            {
                return ternary.Accept(this);
            }

            return context.expression().Accept(this);
        }

        public override PineScriptStatement VisitIdentifierExpression(PineScriptParser.IdentifierExpressionContext context)
        {
            PineScriptStatement statement;
            var id = context.ID();
            if (id != null)
            {
                var name = context.ID().GetText();
                statement = new IdentifierExpression(name);
            }
            else
            {
                statement = context.seriesAccess().Accept(this);
            }
            if (context.NOT() != null) return UnaryExpression.Not(statement);
            if (context.MINUS() != null) return UnaryExpression.Minus(statement);
            return statement;
        }

        public override PineScriptStatement VisitSeriesAccess(PineScriptParser.SeriesAccessContext context)
        {
            var name = context.ID().GetText();
            var identifierStatement = new IdentifierExpression(name);
            var expression = context.expression().Accept(this);
            return new SeriesAccessExpression(identifierStatement, expression);
        }
    }
}