using LinkedInTest.OperationLib;
using LinkedInTest.Util;
using static LinkedInTest.Util.Log;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LinkedInTest
{
    [TestClass]
    public class TestCase8
    {

        [TestMethod]
        public void WordPart()
        {
            var stepNum = 1;
            void Shot() => Word.Session.ShotScreen(GenerateImageName(MethodBase.GetCurrentMethod(), ref stepNum));

            Word.Open().OpenFileTab().ViewOption().CheckText().ExecuteExternalAction(Shot)
                .CheckTip().ExecuteExternalAction(Shot)
                .CheckLink1().ExecuteExternalAction(Shot)
                .CheckLink2().ExecuteExternalAction(Shot);
        }

        [TestMethod]
        public void ExcelPart()
        {
            var stepNum = 1;
            void Shot() => Excel.Session.ShotScreen(GenerateImageName(MethodBase.GetCurrentMethod(), ref stepNum));

            Excel.Open().OpenFileTab().ViewOption().CheckText().ExecuteExternalAction(Shot)
                .CheckTip().ExecuteExternalAction(Shot)
                .CheckLink1().ExecuteExternalAction(Shot)
                .CheckLink2().ExecuteExternalAction(Shot);
        }

        [TestMethod]
        public void PowerPointPart()
        {
            var stepNum = 1;
            void Shot() => PowerPoint.Session.ShotScreen(GenerateImageName(MethodBase.GetCurrentMethod(), ref stepNum));

            PowerPoint.Open().OpenFileTab().ViewOption().CheckText().ExecuteExternalAction(Shot)
                .CheckTip().ExecuteExternalAction(Shot)
                .CheckLink1().ExecuteExternalAction(Shot)
                .CheckLink2().ExecuteExternalAction(Shot);
        }

        [TestMethod]
        public void OutlookPart()
        {
            var stepNum = 1;
            void Shot() => Outlook.Session.ShotScreen(GenerateImageName(MethodBase.GetCurrentMethod(), ref stepNum));

            Outlook.Open().OpenFileTab().ViewOption().CheckText().ExecuteExternalAction(Shot)
                .CheckTip().ExecuteExternalAction(Shot)
                .CheckLink1().ExecuteExternalAction(Shot)
                .CheckLink2().ExecuteExternalAction(Shot);
        }
    }
}
