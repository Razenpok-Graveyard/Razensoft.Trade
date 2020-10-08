namespace Razensoft.Trade.Pine.Execution
{
    public class PineScript
    {
        
    }

    public abstract class PineScriptInstruction
    {
        
    }
    

    public abstract class PineScriptVisitor : PineScriptBaseVisitor<PineScript>
    {
    }
    

    public abstract class PineScriptInstructionVisitor : PineScriptBaseVisitor<PineScriptInstructionVisitor>
    {
        public virtual void A()
        {
            
        }
    }
}