using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;

namespace LinkedInTest.OperationLib
{
    internal struct ControlType
    {
        public const string Button = "ControlType.Button";
        public const string ListItem = "ControlType.ListItem";
        public const string CheckBox = "ControlType.CheckBox";
        public const string Group = "ControlType.Group";
        public const string Edit = "ControlType.Edit";
        public const string TabItem = "ControlType.TabItem";
        public const string Window = "ControlType.Window";
    }

    public abstract class CommonOperation<T>
    {
        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        public static WindowsDriver<WindowsElement> Session { get; set; }

        public WindowsDriver<WindowsElement> GetSession()
        {
            return Session;
        }
        
        //case1,2,3
        public CommonOperation<T> ResumeAssistant()
        {
            FindSpecificTypeElementByName(Session, ControlType.Button, "CV Assistant").Click();
            return this;
        }

        public CommonOperation<T> Close()
        {
            FindSpecificTypeElementByName(Session, ControlType.Button, "Close").Click();
            return this;
        }


        public CommonOperation<T> NewBluegreyResume()
        {
            FindSpecificTypeElementByName(Session, ControlType.ListItem, "New").Click();
            Thread.Sleep(1000);
            FindSpecificTypeElementByName(Session, ControlType.ListItem, "Blue grey resume").Click();
            Thread.Sleep(1000);
            FindSpecificTypeElementByName(Session, ControlType.Button, "Create").Click();
            Thread.Sleep(3000);
            FindSpecificTypeElementByName(Session, ControlType.TabItem, "Review").Click();
            return this;
        }

        public CommonOperation<T> OpenFileTab()
        {
            FindSpecificTypeElementByName(Session, ControlType.Button, "File Tab").Click();
            Thread.Sleep(3000);
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
            Session.FindElementByName(
                "Use LinkedIn features in Office to stay connected with your professional network and keep up to date in your industry.");
            return this;
        }

        public CommonOperation<T> CheckTip()
        {
            var position = Session.FindElementByName("Enable LinkedIn features in my Office applications");
            Session.Mouse.MouseMove(position.Coordinates);
            Thread.Sleep(1500);
            Session.FindElementByName(
                "Turn off this option to disable LinkedIn features in Word, Excel, PowerPoint and Outlook on this computer.");
            return this;
        }

        public CommonOperation<T> CheckLink1()
        {
            Session.FindElementByName("About LinkedIn Features").Click();
            // TODO wait to complete
            return this;
        }

        public CommonOperation<T> CheckLink2()
        {
            Session.FindElementByName("Manage LinkedIn account associations").Click();
            // TODO wait to complete
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
            FindSpecificTypeElementByName(Session, ControlType.Edit, "Add an author").Click();
            Session.Keyboard.SendKeys("v-yifan@microsoft.com");
            FindSpecificTypeElementByName(Session, ControlType.Group, "Info").Click();
            //Session.Keyboard.PressKey(Keys.Enter);

            var position = FindSpecificTypeElementByName(Session, ControlType.Group, "Author").FindElementsByXPath("/Group/*")[2].Coordinates;
            Session.Mouse.DoubleClick(position);
            Thread.Sleep(2000);

            FindSpecificTypeElementByName(DesktopSession(), ControlType.Button, "LinkedIn profile");
            return this;
        }

        public CommonOperation<T> ViewContact()
        {
            FindSpecificTypeElementByName(Session, ControlType.Button, "People").Click();
            Thread.Sleep(1500);
            FindSpecificTypeElementByName(Session, ControlType.Group, "Contact List")
                .FindElementsByXPath("/Group/*")[2] // fixed to 2
                .Click();
            return this;
        }

        public CommonOperation<T> ChangeChannel()
        {
            throw new NotImplementedException("wait to complete");
        }

        public CommonOperation<T> ExecuteExternalAction(Action action)
        {
            action(); // like screen shot
            return this;
        }

        protected CommonOperation() { }

        ~CommonOperation()
        {
            // 1. 手动触发析构
            // 2. 实现 IDispose
            // 3. Finalize 是什么鬼？
            Dispose();
        }

        public void Dispose()
        {
            if (Session != null)
            {
                FindSpecificTypeElementByName(Session, ControlType.Button, "Close").Click();
                Session.Quit();
                Session = null;
            }
        }

        public static WindowsElement FindSpecificTypeElementByName(WindowsDriver<WindowsElement> session, string type, string name)
        {
            var r = session.FindElementByName(name);
            //if (r.TagName == type)
            //{
            return r;
            //}

            //throw new ArgumentException("Can't find the element which meet the requirement, please recheck args");


            //var res = new List<WindowsElement>();

            //foreach (var e in session.FindElementsByName(name))
            //{
            //    if (e.TagName == type)
            //    {
            //        res.Add(e);
            //    }
            //}

            //if (res.Count == 0)
            //{
            //    throw new ArgumentException("Can't find the element which meet the requirement, please recheck args");
            //}
            //else if (res.Count != 1)
            //{
            //    throw new ArgumentException("Element which meet the requirement is not unique, please recheck args");
            //}
            //else
            //{
            //    return res[0];
            //}
        }

        protected static void OpenHelper(string appId, Func<WindowsElement> findHomePage)
        {
            var appCapability = new DesiredCapabilities();
            appCapability.SetCapability("app", appId);
            appCapability.SetCapability("deviceName", "WindowsPC");
            var startupPageSession = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapability);
            Assert.IsNotNull(startupPageSession);
            //Session.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            Thread.Sleep(9000);

            //var home = DesktopSession().FindElementByName("Excel");
            var home = findHomePage();
            Session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), MakeCapabilities(home));
            Session.Manage().Window.Maximize();
        }

        protected static WindowsDriver<WindowsElement> DesktopSession()
        {
            var desktopCapabilities = new DesiredCapabilities();
            desktopCapabilities.SetCapability("app", "Root");
            
            return new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), desktopCapabilities);
        }

        protected static DesiredCapabilities MakeCapabilities(WindowsElement appElement)
        {
            var handle = appElement.GetAttribute("NativeWindowHandle");
            handle = (int.Parse(handle)).ToString("x"); // Convert to Hex
            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability("appTopLevelWindow", handle);

            return capabilities;
        }

        // TODO 封装一些像 Mita 里面那样的子孙函数来用
    }
}
