using LinkedInTest.OperationLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace LinkedInTest
{
    [TestClass]
    public class TestCase5
    {
        private static readonly Func<CommonOperation<ExcelFlag>> OpenExcelForCheck = Excel.Open;
        private static readonly Func<MethodBase> CatchCurrentMethod = MethodBase.GetCurrentMethod;

        [TestMethod]
        public void WordPart()
        {
            WordExcelPptCommon.WordPart(OpenExcelForCheck, CatchCurrentMethod());
        }

        [TestMethod]
        public void ExcelPart()
        {
            WordExcelPptCommon.ExcelPart(OpenExcelForCheck, CatchCurrentMethod());
        }

        [TestMethod]
        public void PowerPointPart()
        {
            WordExcelPptCommon.PowerPointPart(OpenExcelForCheck, CatchCurrentMethod());
        }

        [TestMethod]
        public void OutlookPart()
        {
            WordExcelPptCommon.OutlookPart(OpenExcelForCheck, CatchCurrentMethod());
        }

        [TestMethod]
        public void PolicyPart()
        {
            // TODO wait to complete
        }
    }
}
