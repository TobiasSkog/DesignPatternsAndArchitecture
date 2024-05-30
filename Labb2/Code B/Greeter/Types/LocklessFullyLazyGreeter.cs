using Greeter.Types.Common;

namespace Greeter.Types
{

    public class LocklessFullyLazyGreeter : BaseGreeter
    {
        private LocklessFullyLazyGreeter()
        {
        }

        public static LocklessFullyLazyGreeter Instance
        {
            get
            {
                return Nested.Instance;
            }
        }

        private class Nested
        {

            internal static readonly LocklessFullyLazyGreeter Instance = new LocklessFullyLazyGreeter();

            static Nested()
            {
            }
        }
    }
}
