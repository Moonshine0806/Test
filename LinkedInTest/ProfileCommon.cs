using System;
using LinkedInTest.OperationLib;
using LinkedInTest.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace LinkedInTest
{
    // Only for two below classes using
    public static class ProfileCommon
    {
        public static void CommonPartForWordExcelPpt<T1, T2>(Func<CommonOperation<T1>> openConditionApp, Func<CommonOperation<T2>> openNeedCheckApp, MethodBase methodForGenImgName)
        {
            var g = new ImageNameGenerator(methodForGenImgName);

            //var c = openConditionApp();
            //void CShot() => c.GetSession().ShotScreen(g.Gen());
            //// Dispose to solve same app conflict
            //c.OpenFileTab().ViewOption().UncheckedLinkedInOption().ExecuteExternalAction(CShot).ClickOkButton().Dispose();

            var t = openNeedCheckApp();
            void TShot() => t.GetSession().ShotScreen(g.Gen());
            t.OpenFileTab().AddAuthor().ExecuteExternalAction(TShot);
        }

        // Specific for Outlook
        public static void CommonPartForOutlook<T1, T2>(Func<CommonOperation<T1>> openConditionApp, Func<CommonOperation<T2>> openNeedCheckApp, MethodBase methodForGenImgName)
        {
            var g = new ImageNameGenerator(methodForGenImgName);
            var c = openConditionApp();
            var t = openNeedCheckApp();
            void CShot() => c.GetSession().ShotScreen(g.Gen());
            void TShot() => t.GetSession().ShotScreen(g.Gen());

            c.OpenFileTab().ViewOption().UncheckedLinkedInOption().ExecuteExternalAction(CShot).ClickOkButton().Dispose();
            t.ViewContact().ExecuteExternalAction(TShot);
        }
    }

    public static class WordExcelPptCommon
    {
        public static void WordPart<T>(Func<CommonOperation<T>> openNeedCheckApp, MethodBase methodForGenImgName)
        {
            // TODO the get name of template method maybe different from normal method?
            ProfileCommon.CommonPartForWordExcelPpt(Word.Open, openNeedCheckApp, methodForGenImgName);
        }

        public static void ExcelPart<T>(Func<CommonOperation<T>> openNeedCheckApp, MethodBase methodForGenImgName)
        {
            ProfileCommon.CommonPartForWordExcelPpt(Excel.Open, openNeedCheckApp, methodForGenImgName);
        }

        public static void PowerPointPart<T>(Func<CommonOperation<T>> openNeedCheckApp, MethodBase methodForGenImgName)
        {
            ProfileCommon.CommonPartForWordExcelPpt(PowerPoint.Open, openNeedCheckApp, methodForGenImgName);
        }

        public static void OutlookPart<T>(Func<CommonOperation<T>> openNeedCheckApp, MethodBase methodForGenImgName)
        {
            ProfileCommon.CommonPartForWordExcelPpt(Outlook.Open, openNeedCheckApp, methodForGenImgName);
        }
    }

    public static class OutlookCommon
    {
        public static void WordPart<T>(Func<CommonOperation<T>> openNeedCheckApp, MethodBase methodForGenImgName)
        {
            // TODO the get name of template method maybe different from normal method?
            ProfileCommon.CommonPartForOutlook(Word.Open, openNeedCheckApp, methodForGenImgName);
        }

        public static void ExcelPart<T>(Func<CommonOperation<T>> openNeedCheckApp, MethodBase methodForGenImgName)
        {
            ProfileCommon.CommonPartForOutlook(Excel.Open, openNeedCheckApp, methodForGenImgName);
        }

        public static void PowerPointPart<T>(Func<CommonOperation<T>> openNeedCheckApp, MethodBase methodForGenImgName)
        {
            ProfileCommon.CommonPartForOutlook(PowerPoint.Open, openNeedCheckApp, methodForGenImgName);
        }

        public static void OutlookPart<T>(Func<CommonOperation<T>> openNeedCheckApp, MethodBase methodForGenImgName)
        {
            ProfileCommon.CommonPartForOutlook(Outlook.Open, openNeedCheckApp, methodForGenImgName);
        }
    }
}
