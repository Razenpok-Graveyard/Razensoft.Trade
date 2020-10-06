namespace Razensoft.Trade.Pine.Statements
{
    public class ConditionalStatement : PineScriptStatement
    {
        private readonly PineScriptStatement _condition;
        private readonly PineScriptStatement _thenBlock;
        private readonly PineScriptStatement _elseBlock;

        public ConditionalStatement(
            PineScriptStatement condition,
            PineScriptStatement thenBlock,
            PineScriptStatement elseBlock)
        {
            _condition = condition;
            _thenBlock = thenBlock;
            _elseBlock = elseBlock;
        }

        public override object Execute(PineScriptExecutionContext context)
        {
            var condition = (bool) _condition.Execute(context);
            var executingBlock = condition ? _thenBlock : _elseBlock;
            if (executingBlock == null) return null;
            var blockContext = new PineScriptExecutionContext(context);
            return executingBlock.Execute(blockContext);
        }
    }
}