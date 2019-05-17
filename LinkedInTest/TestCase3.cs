using System.Reflection;
using LinkedInTest.OperationLib;
using LinkedInTest.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LinkedInTest
{
    [TestClass]
    public class TestCase3
    {
        private static void CommonPart<T1, T2, T3, T4>(Func<CommonOperation<T1>> changeapp, MethodBase method, Func<CommonOperation<T2>> checkapp1, Func<CommonOperation<T3>> checkapp2, Func<CommonOperation<T4>> checkapp3)
        {
            var g = new ImageNameGenerator(method);
            var e = changeapp();
            var k1 = checkapp1();
            var k2 = checkapp2();
            var k3 = checkapp3();
            void ShotE() => e.GetSession().ShotScreen(g.Gen());
            void ShotK1() => k1.GetSession().ShotScreen(g.Gen());
            void ShotK2() => k1.GetSession().ShotScreen(g.Gen());
            void ShotK3() => k1.GetSession().ShotScreen(g.Gen());
            //enable
            e.OpenFileTab().ViewOption().CheckedLinkedInOption().ExecuteExternalAction(ShotE).ClickOkButton();
            k1.OpenFileTab().ViewOption().ExecuteExternalAction(ShotK1).ClickCancelButton();
            k2.OpenFileTab().ViewOption().ExecuteExternalAction(ShotK2).ClickCancelButton();
            k2.OpenFileTab().ViewOption().ExecuteExternalAction(ShotK3).ClickCancelButton();
            //disable
            e.OpenFileTab().ViewOption().UncheckedLinkedInOption().ExecuteExternalAction(ShotE).ClickOkButton();
            k1.OpenFileTab().ViewOption().ExecuteExternalAction(ShotK1).ClickCancelButton();
            k2.OpenFileTab().ViewOption().ExecuteExternalAction(ShotK2).ClickCancelButton();
            k2.OpenFileTab().ViewOption().ExecuteExternalAction(ShotK3).ClickCancelButton();
            // changeapp enable
            e.OpenFileTab().ViewOption().UncheckedLinkedInOption().ClickOkButton();
        }

        [TestMethod]
        public void WordPart()
        {
            CommonPart(Word.Open, MethodBase.GetCurrentMethod(), Excel.Open, PowerPoint.Open, Outlook.Open);
        }

        [TestMethod]
        public void ExcelPart()
        {
            CommonPart(Excel.Open, MethodBase.GetCurrentMethod(), Word.Open, PowerPoint.Open, Outlook.Open);
        }

        [TestMethod]
        public void PowerpointPart()
        {
            CommonPart(PowerPoint.Open, MethodBase.GetCurrentMethod(), Outlook.Open, Word.Open, Excel.Open);
        }

        [TestMethod]
        public void OutlookPart()
        {
            CommonPart(Outlook.Open, MethodBase.GetCurrentMethod(), Word.Open, Excel.Open, PowerPoint.Open);
        }


    }

}