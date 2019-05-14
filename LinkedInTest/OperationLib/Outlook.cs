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
            // 父类如何返回子类的类型
        }

        //private new CommonOperation<OutlookFlag> AddAuthor()
        //{
        //    // 在父类中，如何判断调用类型
        //    throw new Exception("Outlook don't have this function, please change code");
        //}
    }
}
