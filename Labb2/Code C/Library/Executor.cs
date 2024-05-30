using DesignPatternsLibrary.PatternExecutors;
using Library.ShippingExample;
using Library.SortingExample;

namespace Library
{
    public class Executor : PatternExecutor
    {
        public override string Name => "???";

        public override void Execute()
        {
            ShippingExecutor.Execute();
            SortingExecutor.Execute();
        }
    }
}
