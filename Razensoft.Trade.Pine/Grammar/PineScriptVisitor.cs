//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from PineScript.g4 by ANTLR 4.8

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="PineScriptParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public interface IPineScriptVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="PineScriptParser.script"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitScript([NotNull] PineScriptParser.ScriptContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="PineScriptParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBlock([NotNull] PineScriptParser.BlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="PineScriptParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatement([NotNull] PineScriptParser.StatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="PineScriptParser.variableDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariableDeclaration([NotNull] PineScriptParser.VariableDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="PineScriptParser.variableAssignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariableAssignment([NotNull] PineScriptParser.VariableAssignmentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="PineScriptParser.variableValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariableValue([NotNull] PineScriptParser.VariableValueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="PineScriptParser.functionDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionDeclaration([NotNull] PineScriptParser.FunctionDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="PineScriptParser.functionParameters"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionParameters([NotNull] PineScriptParser.FunctionParametersContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="PineScriptParser.functionBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionBody([NotNull] PineScriptParser.FunctionBodyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="PineScriptParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionCall([NotNull] PineScriptParser.FunctionCallContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="PineScriptParser.functionArguments"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionArguments([NotNull] PineScriptParser.FunctionArgumentsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="PineScriptParser.conditional"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConditional([NotNull] PineScriptParser.ConditionalContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="PineScriptParser.conditionalElseBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConditionalElseBody([NotNull] PineScriptParser.ConditionalElseBodyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="PineScriptParser.loop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLoop([NotNull] PineScriptParser.LoopContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="PineScriptParser.loopBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLoopBody([NotNull] PineScriptParser.LoopBodyContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>ParenthesizedExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParenthesizedExpression([NotNull] PineScriptParser.ParenthesizedExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>TernaryExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTernaryExpression([NotNull] PineScriptParser.TernaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>UnaryMinusExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnaryMinusExpression([NotNull] PineScriptParser.UnaryMinusExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>BinaryOperationExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBinaryOperationExpression([NotNull] PineScriptParser.BinaryOperationExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>LiteralExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLiteralExpression([NotNull] PineScriptParser.LiteralExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>NotExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNotExpression([NotNull] PineScriptParser.NotExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>FunctionCallExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionCallExpression([NotNull] PineScriptParser.FunctionCallExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>IdentifierExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdentifierExpression([NotNull] PineScriptParser.IdentifierExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>IntLiteral</c>
	/// labeled alternative in <see cref="PineScriptParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIntLiteral([NotNull] PineScriptParser.IntLiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>FloatLiteral</c>
	/// labeled alternative in <see cref="PineScriptParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFloatLiteral([NotNull] PineScriptParser.FloatLiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>BoolLiteral</c>
	/// labeled alternative in <see cref="PineScriptParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBoolLiteral([NotNull] PineScriptParser.BoolLiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>StringLiteral</c>
	/// labeled alternative in <see cref="PineScriptParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStringLiteral([NotNull] PineScriptParser.StringLiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>ColorLiteral</c>
	/// labeled alternative in <see cref="PineScriptParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitColorLiteral([NotNull] PineScriptParser.ColorLiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>NALiteral</c>
	/// labeled alternative in <see cref="PineScriptParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNALiteral([NotNull] PineScriptParser.NALiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="PineScriptParser.seriesAccess"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSeriesAccess([NotNull] PineScriptParser.SeriesAccessContext context);
}
