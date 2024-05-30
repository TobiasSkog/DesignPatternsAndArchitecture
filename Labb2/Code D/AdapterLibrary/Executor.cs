using Library.BillingSystemExample;
using Library.MovieBroadcasterExample;
using DesignPatternsLibrary.PatternExecutors;

namespace Library
{
    public class Executor : PatternExecutor
    {
        public override string Name => "???";

        public override void Execute()
        {
            BillingSystemExecutor.Execute();
            MovieBroadcasterExecutor.Execute();
        }
    }
}
