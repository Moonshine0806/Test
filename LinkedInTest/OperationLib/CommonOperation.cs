using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium.Support.Extensions;

namespace LinkedInTest.OperationLib
{
    internal struct ControlType
    {
        public const string Button = "ControlType.Button";
        public const string ListItem = "ControlType.ListItem";
        public const string CheckBox = "ControlType.CheckBox";
    }

    public abstract class CommonOperation<T>
    {
        protected static readonly string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        public static WindowsDriver<WindowsElement> Session;

        public CommonOperation<T> OpenFileTab()
        {
            FindSpecificTypeElementByName(Session, ControlType.Button, "File Tab").Click();
            Thread.Sleep(1000);
            return this;
        }

        public CommonOperation<T> ViewAccount()
        {
            FindSpecificTypeElementByName(Session, ControlType.ListItem, "Account").Click();
            Thread.Sleep(1000);
            return this;
        }

        public CommonOperation<T> ViewOption()
        {
            FindSpecificTypeElementByName(Session, ControlType.ListItem, "Options").Click();
            Thread.Sleep(1000);
            return this;
        }

        public CommonOperation<T> CheckText()
        {

            return this;
        }

        public CommonOperation<T> CheckTip()
        {

            return this;
        }

        public CommonOperation<T> CheckLink1()
        {

            return this;
        }

        public CommonOperation<T> CheckLink2()
        {

            return this;
        }

        public CommonOperation<T> CheckedLinkedInOption()
        {
            var checkBox = FindSpecificTypeElementByName(Session, ControlType.CheckBox,
                "Enable LinkedIn features in my Office applications");
            if (!checkBox.Selected) // TODO wait to confirm this Selected work
            {
                checkBox.Click();
            }
            return this;
        }

        public CommonOperation<T> UncheckedLinkedInOption()
        {
            var checkBox = FindSpecificTypeElementByName(Session, ControlType.CheckBox,
                "Enable LinkedIn features in my Office applications");
            if (checkBox.Selected) // TODO wait to confirm this Selected work
            {
                checkBox.Click();
            }
            return this;
        }

        public CommonOperation<T> ClickOkButton()
        {
            FindSpecificTypeElementByName(Session, ControlType.Button, "OK").Click();
            return this;
        }

        public CommonOperation<T> ClickCancelButton()
        {
            FindSpecificTypeElementByName(Session, ControlType.Button, "Cancel").Click();
            return this;
        }

        public CommonOperation<T> AddAuthor()
        {

            return this;
        }

        public CommonOperation<T> ViewContact()
        {
            return this;
        }

        public CommonOperation<T> ChangeChannel()
        {
            throw new NotImplementedException("wait to complete");
            return this;
        }

        public CommonOperation<T> ExecuteExternalAction(Action action)
        {
            action(); // like screen shot
            return this;
        }

        protected CommonOperation<T> OpenHelper(string classNameOfAppWindow, Action openApp)
        {
            openApp();
            // set the Session variable

            return this;
        }

        protected CommonOperation() { }

        ~CommonOperation()
        {
            if (Session != null)
            {
                Session.Quit();
                Session = null;
            }
        }

        public static WindowsElement FindSpecificTypeElementByName(WindowsDriver<WindowsElement> session, string type, string name)
        {
            var res = new List<WindowsElement>();
            
            foreach (var e in session.FindElementsByName(name))
            {
                if (e.TagName == type)
                {
                    res.Add(e);
                }
            }

            if (res.Count == 0)
            {
                throw new ArgumentException("Can't find the element which meet the requirement, please recheck args");
            }
            else if (res.Count != 1)
            {
                throw new ArgumentException("Element which meet the requirement is not unique, please recheck args");
            }
            else
            {
                return res[0];
            }
        }
    }
}
