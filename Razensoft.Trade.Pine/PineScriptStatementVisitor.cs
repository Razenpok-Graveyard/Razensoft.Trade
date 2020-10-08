using System;
using System.Linq;
using Antlr4.Runtime.Tree;
using Razensoft.Trade.Pine.Statements;

namespace Razensoft.Trade.Pine
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
            var value = context.variableValue().Accept(this);
            return new VariableDeclarationStatement(name, value);
        }

        public override PineScriptStatement VisitVariableAssignment(PineScriptParser.VariableAssignmentContext context)
        {
            var name = context.ID().GetText();
            var value = context.variableValue().Accept(this);
            return new VariableAssignmentStatement(name, value);
        }

        public override PineScriptStatement VisitVariableValue(PineScriptParser.VariableValueContext context)
        {
            return context.GetChild(0).Accept(this);
        }

        public override PineScriptStatement VisitFunctionDeclaration(PineScriptParser.FunctionDeclarationContext context)
        {
            var name = context.ID().GetText();
            var parameters = context.functionParameters()
                .ID()
                .Select(id => id.GetText())
                .ToArray();
            var body = context.functionBody().Accept(this);
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

        public override PineScriptStatement VisitIntExpression(PineScriptParser.IntExpressionContext context)
        {
            return new LiteralStatement(long.Parse(context.GetText()));
        }

        public override PineScriptStatement VisitColorExpression(PineScriptParser.ColorExpressionContext context)
        {
            return new LiteralStatement(new PineColor());
        }

        public override PineScriptStatement VisitStringExpression(PineScriptParser.StringExpressionContext context)
        {
            return new LiteralStatement(context.GetText().Trim('"'));
        }

        public override PineScriptStatement VisitFloatExpression(PineScriptParser.FloatExpressionContext context)
        {
            return new LiteralStatement(float.Parse(context.GetText()));
        }

        public override PineScriptStatement VisitBoolExpression(PineScriptParser.BoolExpressionContext context)
        {
            return new LiteralStatement(bool.Parse(context.GetText()));
        }

        public override PineScriptStatement VisitFunctionCallExpression(PineScriptParser.FunctionCallExpressionContext context)
        {
            return context.functionCall().Accept(this);
        }

        public override PineScriptStatement VisitNotExpression(PineScriptParser.NotExpressionContext context)
        {
            var expression = context.expression().Accept(this);
            return UnaryExpression.Not(expression);
        }

        public override PineScriptStatement VisitUnaryMinusExpression(PineScriptParser.UnaryMinusExpressionContext context)
        {
            var expression = context.expression().Accept(this);
            return UnaryExpression.Minus(expression);
        }

        public override PineScriptStatement VisitTernaryExpression(PineScriptParser.TernaryExpressionContext context)
        {
            var condition = context.expression(0).Accept(this);
            var truthyExpression = context.expression(1).Accept(this);
            var falsyExpression = context.expression(2).Accept(this);
            return new TernaryExpression(condition, truthyExpression, falsyExpression);
        }

        public override PineScriptStatement VisitBinaryOperationExpression(PineScriptParser.BinaryOperationExpressionContext context)
        {
            var expressions = context.expression();
            var left = expressions[0].Accept(this);
            var right = expressions[1].Accept(this);
            return context.op.Text switch
            {
                "or" => BinaryExpression.Or(left, right),
                "and" => BinaryExpression.And(left, right),
                "==" => BinaryExpression.Equals(left, right),
                "!=" => BinaryExpression.NotEquals(left, right),
                ">" => BinaryExpression.GreaterThan(left, right),
                ">=" => BinaryExpression.GreaterThanOrEquals(left, right),
                "<" => BinaryExpression.LowerThan(left, right),
                "<=" => BinaryExpression.LowerThanOrEquals(left, right),
                "+" => BinaryExpression.Add(left, right),
                "-" => BinaryExpression.Subtract(left, right),
                "*" => BinaryExpression.Multiply(left, right),
                "/" => BinaryExpression.Divide(left, right),
                "%" => BinaryExpression.Modulo(left, right),
                _ => throw new Exception("Unknown binary operator")
            };
        }

        public override PineScriptStatement VisitGroupExpression(PineScriptParser.GroupExpressionContext context)
        {
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