using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinkedInTest.Util
{
    public class ImageNameGenerator
    {
        private int _num;
        private readonly int _testCaseNum;
        private readonly string _appName;

        public ImageNameGenerator(MethodBase currentMethod, int startNum = 1)
        {
            _num = startNum;
            _testCaseNum = currentMethod.DeclaringType.Name.Last();
            var methodName = currentMethod.Name;
            _appName = methodName.Substring(0, methodName.Length - 4);
        }

        public string Gen()
        {
            // TC: TestCase S: Step
            return new StringBuilder("TC" + _testCaseNum + _appName + "S" + _num++).ToString();
        }
    }
}
