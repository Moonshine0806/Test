using LinkedInTest.OperationLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace LinkedInTest
{
    [TestClass]
    public class TestCase7
    {
        private static readonly Func<CommonOperation<OutlookFlag>> OpenOutlookForCheck = Outlook.Open;
        private static readonly Func<MethodBase> CatchCurrentMethod = MethodBase.GetCurrentMethod;

        [TestMethod]
        public void WordPart()
        {
            OutlookCommon.WordPart(OpenOutlookForCheck, CatchCurrentMethod());
        }

        [TestMethod]
        public void ExcelPart()
        {
            OutlookCommon.ExcelPart(OpenOutlookForCheck, CatchCurrentMethod());
        }

        [TestMethod]
        public void PowerPointPart()
        {
            OutlookCommon.PowerPointPart(OpenOutlookForCheck, CatchCurrentMethod());
        }

        [TestMethod]
        public void OutlookPart()
        {
            OutlookCommon.OutlookPart(OpenOutlookForCheck, CatchCurrentMethod());
        }

        [TestMethod]
        public void PolicyPart()
        {
            // TODO wait to complete
        }
    }
}
