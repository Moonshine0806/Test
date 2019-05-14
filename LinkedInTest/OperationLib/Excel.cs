using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedInTest.OperationLib
{
    public struct ExcelFlag {}
    public class Excel : CommonOperation<ExcelFlag>
    {
        public static Excel Open()
        {
            var e = new Excel();
            // Open application
            return e;
        }
    }
}
