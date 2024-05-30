using System;
using Greeter.Types.Common;

namespace Greeter.Types
{
    public class SimpleGreeter : BaseGreeter
    {
        private static SimpleGreeter _instance;

        private SimpleGreeter()
        {
            Console.WriteLine("Simple singleton instantiated for the first and only time!");
        }

        public static SimpleGreeter Instance
        {
            get
            {
                Console.WriteLine("Simple singleton being requested...");

                if (_instance == null)
                {
                    _instance = new SimpleGreeter();
                }

                Console.WriteLine("Simple singleton returned");
                return _instance;
            }
        }
    }
}
