using BuildingBlocks;

namespace Library.MovieBroadcasterExample
{
    public static class MovieBroadcasterExecutor
    {
        public static void Execute()
        {
            ConsoleExtension.WriteSeparator("Movie broadcaster example");

            MovieRegistry registry = new MovieRegistry();
            IBroadcaster  = new Broadcast(registry);

            .BroadcastToExternalPartners();
        }
    }
}
