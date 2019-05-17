using LinkedInTest.OperationLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace LinkedInTest
{
    [TestClass]
    public class TestCase4
    {
        private static readonly Func<CommonOperation<WordFlag>> OpenWordForCheck = Word.Open;
        private static readonly Func<MethodBase> CatchCurrentMethod = MethodBase.GetCurrentMethod;

        [TestMethod]
        public void WordPart()
        {
            WordExcelPptCommon.WordPart(OpenWordForCheck, CatchCurrentMethod());
        }

        [TestMethod]
        public void ExcelPart()
        {
            WordExcelPptCommon.ExcelPart(OpenWordForCheck, CatchCurrentMethod());
        }

        [TestMethod]
        public void PowerPointPart()
        {
            WordExcelPptCommon.PowerPointPart(OpenWordForCheck, CatchCurrentMethod());
        }

        [TestMethod]
        public void OutlookPart()
        {
            WordExcelPptCommon.OutlookPart(OpenWordForCheck, CatchCurrentMethod());
        }

        [TestMethod]
        public void PolicyPart()
        {
            // TODO wait to complete
        }
    }
}
