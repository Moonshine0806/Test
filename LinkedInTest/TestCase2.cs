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
    public class TestCase2
    {
        private static CommonOperation<T> CommonPart<T>(CommonOperation<T> openedApp, MethodBase method)
        {
            var g = new ImageNameGenerator(method);
            void Shot() => Word.Session.ShotScreen(g.Gen());
            void Shot2() => openedApp.GetSession().ShotScreen(g.Gen());
            var res = openedApp.OpenFileTab().ViewOption().UncheckedLinkedInOption().ExecuteExternalAction(Shot2).ClickOkButton();
            Word.Open().OpenFileTab().NewBluegreyResume().ExecuteExternalAction(Shot).ResumeAssistant().ExecuteExternalAction(Shot).Close();
            return res;
        }

        [TestMethod]
        public void WordPart()
        {
            CommonPart(Word.Open(), MethodBase.GetCurrentMethod());
        }

        [TestMethod]
        public void ExcelPart()
        {
            CommonPart(Excel.Open(), MethodBase.GetCurrentMethod());
        }

        [TestMethod]
        public void PowerPointPart()
        {
            CommonPart(PowerPoint.Open(), MethodBase.GetCurrentMethod());
        }

        [TestMethod]
        public void OutlookPart()
        {
            CommonPart(Outlook.Open(), MethodBase.GetCurrentMethod());
        }

    }

}
