using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedInTest.OperationLib
{
    public struct OutlookFlag {}
    public class Outlook : CommonOperation<OutlookFlag>
    {
        public static Outlook Open()
        {
            var o = new Outlook();
            // Open application
            return o;
        }
        private new CommonOperation<OutlookFlag> AddAuthor()
        {
            throw new Exception("Outlook don't have this function, please change code");
        }
    }
}
