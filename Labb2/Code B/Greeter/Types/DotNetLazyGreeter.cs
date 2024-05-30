using System;
using Greeter.Types.Common;

namespace Greeter.Types
{

    public class DotNetLazyGreeter : BaseGreeter
    {
        private static readonly Lazy<DotNetLazyGreeter> Lazy = new Lazy<DotNetLazyGreeter>(() => new DotNetLazyGreeter());

        private DotNetLazyGreeter()
        {
        }

        public static DotNetLazyGreeter Instance
        {
            get
            {
                return Lazy.Value;
            }
        }
    }
}
