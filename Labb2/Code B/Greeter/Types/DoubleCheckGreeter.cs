using Greeter.Types.Common;

namespace Greeter.Types
{

    public class DoubleCheckGreeter : BaseGreeter
    {
        private static readonly object Padlock = new object();

        private static DoubleCheckGreeter _instance;

        private DoubleCheckGreeter()
        {
        }

        public static DoubleCheckGreeter Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DoubleCheckGreeter();
                        }
                    }
                }

                return _instance;
            }
        }
    }
}
