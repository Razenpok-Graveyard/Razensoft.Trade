using System;
using System.Linq;
using Razensoft.Trade.Pine.Statements;

namespace Razensoft.Trade.Pine
{
    public class PineScriptStatementVisitor : PineScriptBaseVisitor<PineScriptStatement>
    {
        public override PineScriptStatement VisitBlock(PineScriptParser.BlockContext context)
        {
            var statements = context.statementList().statement().Select(Visit).ToArray();
            return new StatementBlock(statements);
        }

        public override PineScriptStatement VisitVariableDeclarationStatement(PineScriptParser.VariableDeclarationStatementContext context)
        {
            var name = context.Identifier().GetText();
            var value = context.variableValue().Accept(this);
            return new VariableDeclarationStatement(name, value);
        }

        public override PineScriptStatement VisitVariableAssignmentStatement(PineScriptParser.VariableAssignmentStatementContext context)
        {
            var name = context.Identifier().GetText();
            var value = context.variableValue().Accept(this);
            return new VariableAssignmentStatement(name, value);
        }

        public override PineScriptStatement VisitFunctionDeclarationStatement(PineScriptParser.FunctionDeclarationStatementContext context)
        {
            var name = context.Identifier().GetText();
            var parameters = new string[0];
            if (context.functionParameters() != null)
            {
                parameters = context.functionParameters()?
                    .Identifier()
                    .Select(id => id.GetText())
                    .ToArray();
            }
            var body = context.functionBody().Accept(this);
            return new FunctionDeclarationStatement(name, parameters, body);
        }

        public override PineScriptStatement VisitFunctionCallStatement(PineScriptParser.FunctionCallStatementContext context)
        {
            var name = context.Identifier().GetText();
            if (context.functionArguments() == null)
            {
                return new FunctionCallStatement(name, new PineScriptStatement[0], new PineScriptStatement[0]);
            }

            var arguments = context.functionArguments();
            var positionalArgs = arguments._positional
                .Select(e => e.Accept(this))
                .ToArray();
            var namedArgs = arguments._named
                .Select(e => new VariableDeclarationStatement(e.Identifier().GetText(), e.expression().Accept(this)))
                .Cast<PineScriptStatement>()
                .ToArray();
            return new FunctionCallStatement(name, positionalArgs, namedArgs);
        }

        public override PineScriptStatement VisitIfStatement(PineScriptParser.IfStatementContext context)
        {
            var condition = context.expression().Accept(this);
            var thenBlock = context.block().Accept(this);
            var elseBlock = context.ifStatementElseBody() != null
                ? context.ifStatementElseBody().Accept(this)
                : null;
            return new ConditionalStatement(condition, thenBlock, elseBlock);
        }

        public override PineScriptStatement VisitForStatement(PineScriptParser.ForStatementContext context)
        {
            var counterDeclaration = context.forStatementCounter().Accept(this);
            var endValue = context.end.Accept(this);
            var body = context.forStatementBody().Accept(this);
            var step = 1;
            if (context.step != null)
            {
                step = int.Parse(context.step.GetText());
            }
            return new LoopStatement(counterDeclaration, endValue, body, step);
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

        public override PineScriptStatement VisitParenthesizedExpression(PineScriptParser.ParenthesizedExpressionContext context)
        {
            return context.expression().Accept(this);
        }

        public override PineScriptStatement VisitIdentifierExpression(PineScriptParser.IdentifierExpressionContext context)
        {
            PineScriptStatement statement;
            var id = context.Identifier();
            if (id != null)
            {
                var name = context.Identifier().GetText();
                statement = new IdentifierExpression(name);
            }
            else
            {
                statement = context.seriesAccess().Accept(this);
            }
            return statement;
        }

        public override PineScriptStatement VisitIntLiteral(PineScriptParser.IntLiteralContext context)
        {
            return new LiteralStatement(long.Parse(context.GetText()));
        }

        public override PineScriptStatement VisitColorLiteral(PineScriptParser.ColorLiteralContext context)
        {
            return new LiteralStatement(new PineColor());
        }

        public override PineScriptStatement VisitStringLiteral(PineScriptParser.StringLiteralContext context)
        {
            return new LiteralStatement(context.GetText().Trim('"'));
        }

        public override PineScriptStatement VisitFloatLiteral(PineScriptParser.FloatLiteralContext context)
        {
            return new LiteralStatement(float.Parse(context.GetText()));
        }

        public override PineScriptStatement VisitBoolLiteral(PineScriptParser.BoolLiteralContext context)
        {
            return new LiteralStatement(bool.Parse(context.GetText()));
        }

        public override PineScriptStatement VisitNALiteral(PineScriptParser.NALiteralContext context)
        {
            return new LiteralStatement(PineNA.NA);
        }

        public override PineScriptStatement VisitSeriesAccess(PineScriptParser.SeriesAccessContext context)
        {
            var name = context.Identifier().GetText();
            var identifierStatement = new IdentifierExpression(name);
            var expression = context.expression().Accept(this);
            return new SeriesAccessExpression(identifierStatement, expression);
        }
    }
}