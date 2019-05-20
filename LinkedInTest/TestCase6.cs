using LinkedInTest.OperationLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace LinkedInTest
{
    [TestClass]
    public class TestCase6
    {
        private static readonly Func<CommonOperation<PowerPointFlag>> OpenPowerPointForCheck = PowerPoint.Open;
        private static readonly Func<MethodBase> CatchCurrentMethod = MethodBase.GetCurrentMethod;

        [TestMethod]
        public void WordPart()
        {
            WordExcelPptCommon.WordPart(OpenPowerPointForCheck, CatchCurrentMethod());
        }

        [TestMethod]
        public void ExcelPart()
        {
            WordExcelPptCommon.ExcelPart(OpenPowerPointForCheck, CatchCurrentMethod());
        }

        [TestMethod]
        public void PowerPointPart()
        {
            WordExcelPptCommon.PowerPointPart(OpenPowerPointForCheck, CatchCurrentMethod());
        }

        [TestMethod]
        public void OutlookPart()
        {
            WordExcelPptCommon.OutlookPart(OpenPowerPointForCheck, CatchCurrentMethod());
        }

        [TestMethod]
        public void PolicyPart()
        {
            // TODO wait to complete
        }
    }
}
