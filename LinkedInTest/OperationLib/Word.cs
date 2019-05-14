using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedInTest.OperationLib
{
    public struct WordFlag {}
    public class Word : CommonOperation<WordFlag>
    {
        public static Word Open()
        {
            var w = new Word();
            // Open application
            return w;
        }
    }
}
