using System;
using LinkedInTest.OperationLib;
using LinkedInTest.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace LinkedInTest
{
    public class LinkedInProfileCommon // T should inherit from CommonOperation<T>
    {
        private static void CommonPart<T1, T2>(Func<CommonOperation<T1>> openConditionApp, MethodBase method, Func<CommonOperation<T2>> openTestApp)
        {
            var g = new ImageNameGenerator(method);
            var c = openConditionApp();
            var t = openTestApp();
            void CShot() => c.GetSession().ShotScreen(g.Gen()); // should set two shot
            void TShot() => t.GetSession().ShotScreen(g.Gen()); // should set two shot

            c.OpenFileTab().ViewOption().UncheckedLinkedInOption().ExecuteExternalAction(CShot).ClickOkButton().Dispose();
            t.OpenFileTab().AddAuthor().ExecuteExternalAction(TShot).Dispose();
        }

        public void WordPart()
        {
            CommonPart(Word.Open, MethodBase.GetCurrentMethod(), Word.Open);
        }

        public void ExcelPart()
        {
            CommonPart(Excel.Open, MethodBase.GetCurrentMethod(), Word.Open);
        }

        public void PowerPointPart()
        {
            CommonPart(PowerPoint.Open, MethodBase.GetCurrentMethod(), Word.Open);
        }

        public void OutlookPart()
        {
            CommonPart(Outlook.Open, MethodBase.GetCurrentMethod(), Word.Open);
        }
    }
}
