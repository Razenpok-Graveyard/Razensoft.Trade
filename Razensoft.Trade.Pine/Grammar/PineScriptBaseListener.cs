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
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="IPineScriptListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public partial class PineScriptBaseListener : IPineScriptListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="PineScriptParser.script"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterScript([NotNull] PineScriptParser.ScriptContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PineScriptParser.script"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitScript([NotNull] PineScriptParser.ScriptContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PineScriptParser.block"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBlock([NotNull] PineScriptParser.BlockContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PineScriptParser.block"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBlock([NotNull] PineScriptParser.BlockContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PineScriptParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStatement([NotNull] PineScriptParser.StatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PineScriptParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStatement([NotNull] PineScriptParser.StatementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PineScriptParser.variableDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterVariableDeclaration([NotNull] PineScriptParser.VariableDeclarationContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PineScriptParser.variableDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitVariableDeclaration([NotNull] PineScriptParser.VariableDeclarationContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PineScriptParser.variableAssignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterVariableAssignment([NotNull] PineScriptParser.VariableAssignmentContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PineScriptParser.variableAssignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitVariableAssignment([NotNull] PineScriptParser.VariableAssignmentContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PineScriptParser.variableValue"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterVariableValue([NotNull] PineScriptParser.VariableValueContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PineScriptParser.variableValue"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitVariableValue([NotNull] PineScriptParser.VariableValueContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PineScriptParser.functionDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunctionDeclaration([NotNull] PineScriptParser.FunctionDeclarationContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PineScriptParser.functionDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunctionDeclaration([NotNull] PineScriptParser.FunctionDeclarationContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PineScriptParser.functionParameters"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunctionParameters([NotNull] PineScriptParser.FunctionParametersContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PineScriptParser.functionParameters"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunctionParameters([NotNull] PineScriptParser.FunctionParametersContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PineScriptParser.functionBody"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunctionBody([NotNull] PineScriptParser.FunctionBodyContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PineScriptParser.functionBody"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunctionBody([NotNull] PineScriptParser.FunctionBodyContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PineScriptParser.functionCall"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunctionCall([NotNull] PineScriptParser.FunctionCallContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PineScriptParser.functionCall"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunctionCall([NotNull] PineScriptParser.FunctionCallContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PineScriptParser.functionArguments"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunctionArguments([NotNull] PineScriptParser.FunctionArgumentsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PineScriptParser.functionArguments"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunctionArguments([NotNull] PineScriptParser.FunctionArgumentsContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PineScriptParser.conditional"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterConditional([NotNull] PineScriptParser.ConditionalContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PineScriptParser.conditional"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitConditional([NotNull] PineScriptParser.ConditionalContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PineScriptParser.loop"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLoop([NotNull] PineScriptParser.LoopContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PineScriptParser.loop"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLoop([NotNull] PineScriptParser.LoopContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PineScriptParser.loopBody"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLoopBody([NotNull] PineScriptParser.LoopBodyContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PineScriptParser.loopBody"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLoopBody([NotNull] PineScriptParser.LoopBodyContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>TernaryExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterTernaryExpression([NotNull] PineScriptParser.TernaryExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>TernaryExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitTernaryExpression([NotNull] PineScriptParser.TernaryExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>ColorExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterColorExpression([NotNull] PineScriptParser.ColorExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>ColorExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitColorExpression([NotNull] PineScriptParser.ColorExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>UnaryMinusExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterUnaryMinusExpression([NotNull] PineScriptParser.UnaryMinusExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>UnaryMinusExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitUnaryMinusExpression([NotNull] PineScriptParser.UnaryMinusExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>BinaryOperationExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBinaryOperationExpression([NotNull] PineScriptParser.BinaryOperationExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>BinaryOperationExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBinaryOperationExpression([NotNull] PineScriptParser.BinaryOperationExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>IntExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIntExpression([NotNull] PineScriptParser.IntExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>IntExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIntExpression([NotNull] PineScriptParser.IntExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>StringExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStringExpression([NotNull] PineScriptParser.StringExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>StringExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStringExpression([NotNull] PineScriptParser.StringExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>NotExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterNotExpression([NotNull] PineScriptParser.NotExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>NotExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitNotExpression([NotNull] PineScriptParser.NotExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>FloatExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFloatExpression([NotNull] PineScriptParser.FloatExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>FloatExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFloatExpression([NotNull] PineScriptParser.FloatExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>GroupExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterGroupExpression([NotNull] PineScriptParser.GroupExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>GroupExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitGroupExpression([NotNull] PineScriptParser.GroupExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>FunctionCallExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunctionCallExpression([NotNull] PineScriptParser.FunctionCallExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>FunctionCallExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunctionCallExpression([NotNull] PineScriptParser.FunctionCallExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>BoolExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBoolExpression([NotNull] PineScriptParser.BoolExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>BoolExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBoolExpression([NotNull] PineScriptParser.BoolExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>IdentifierExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIdentifierExpression([NotNull] PineScriptParser.IdentifierExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>IdentifierExpression</c>
	/// labeled alternative in <see cref="PineScriptParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIdentifierExpression([NotNull] PineScriptParser.IdentifierExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="PineScriptParser.seriesAccess"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSeriesAccess([NotNull] PineScriptParser.SeriesAccessContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PineScriptParser.seriesAccess"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSeriesAccess([NotNull] PineScriptParser.SeriesAccessContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}
