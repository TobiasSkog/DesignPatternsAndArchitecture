using Greeter.Types.Common;

namespace Greeter.Types
{

    public class SimpleThreadSafetyGreeter : BaseGreeter
    {
        private static readonly object Padlock = new object();

        private static SimpleThreadSafetyGreeter _instance;

        private SimpleThreadSafetyGreeter()
        {
        }

        public static SimpleThreadSafetyGreeter Instance
        {
            get
            {
                lock (Padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new SimpleThreadSafetyGreeter();
                    }

                    return _instance;
                }
            }
        }
    }
}
