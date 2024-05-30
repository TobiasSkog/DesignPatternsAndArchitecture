using Greeter.Types.Common;

namespace Greeter.Types
{

    public class LocklessGreeter : BaseGreeter
    {
        private static readonly LocklessGreeter InstanceValue = new LocklessGreeter();

        static LocklessGreeter()
        {
        }

        private LocklessGreeter()
        {
        }

        public static LocklessGreeter Instance
        {
            get
            {
                return InstanceValue;
            }
        }
    }
}
