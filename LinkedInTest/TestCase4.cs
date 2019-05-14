using LinkedInTest.OperationLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedInTest
{
    [TestClass]
    public class TestCase4
    {

        [TestMethod]
        public void WordPart()
        {
            Word.Open().OpenFileTab().ViewOption().UncheckedLinkedInOption().ClickOkButton();
            // Screen shot
            Word.Open().OpenFileTab().AddAuthor();

        }

        [TestMethod]
        public void ExcelPart()
        {
            Excel.Open().OpenFileTab().ViewOption().UncheckedLinkedInOption().ClickOkButton();
            // Screen shot
            Excel.Open().OpenFileTab().AddAuthor();
        }

        [TestMethod]
        public void PowerPointPart()
        {
            PowerPoint.Open().OpenFileTab().ViewOption().UncheckedLinkedInOption().ClickOkButton();
            // Screen shot
            PowerPoint.Open().OpenFileTab().AddAuthor();
        }

        [TestMethod]
        public void OutlookPart()
        {
            Outlook.Open().OpenFileTab().ViewOption().UncheckedLinkedInOption().ClickOkButton();
            // Screen shot
            Outlook.Open().OpenFileTab().AddAuthor();
        }


        //[ClassInitialize]
        //public static void Initialize(TestContext context)
        //{
        //}

        //[ClassCleanup]
        //public static void Cleanup()
        //{
        //}
    }
}
