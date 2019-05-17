using System;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using LinkedInTest.OperationLib;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.Extensions;

namespace LinkedInTest.Util
{
    public static class Log
    {
        private static readonly string Time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        private static readonly string LogFolder = AppDomain.CurrentDomain.BaseDirectory + Time + @"Log\";
        private static readonly StreamWriter StreamWriter;
        private static readonly FileStream FileStream;
        private static readonly ScreenRecorder Recorder;

        static Log()
        {
            try
            {
                if (!Directory.Exists(LogFolder))
                {
                    Directory.CreateDirectory(LogFolder);
                }
#if false
                StreamWriter = new StreamWriter(Console.OpenStandardOutput()) {AutoFlush = true};
                Console.SetOut(StreamWriter);
#else
                var logFilePath = Path.Combine(LogFolder, @"TestLog.log");
                FileStream = new FileStream(logFilePath, FileMode.Append);
                StreamWriter = new StreamWriter(FileStream, Encoding.UTF8) { AutoFlush = true };
#endif
            }
            catch (Exception e)
            {
#if DEBUG
                Console.WriteLine("Exception happened when redirect stream to console out: " + e);
#else
                Console.WriteLine("Exception happened when create folder or new StreamWriter: " + e);
#endif
                throw;
            }

            Recorder = ScreenRecorder.CreateRecorder(LogFolder + @"\" + "TestRecord.mp4");
            AppDomain.CurrentDomain.ProcessExit += Log_Dtor;
        }

        public static void ShotScreen(this WindowsDriver<WindowsElement> session, string fileName)
        {
            session.TakeScreenshot().SaveAsFile(Path.Combine(LogFolder, fileName), ImageFormat.Png);
        }

        //public static void CaptureScreenAndSave(string fileName/*, ImageFormat imageFormat*/)  // TODO format arg is also unused
        //{
        //    //var fileFullName = Path.Combine(path, fileName, @".png");
        //    var fileFullName = System.IO.Path.Combine(LogFolder, fileName + @".png");
        //    ScreenCapture.CaptureScreen().Save(fileFullName);
        //}

        public static void WriteLine(string message, Exception exception = null)
        {
            var nowTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            StreamWriter.WriteLine("-------" + nowTime + "-------");
            StreamWriter.WriteLine(message);
            if (exception != null)
            {
                StreamWriter.WriteLine(exception);
            }
            StreamWriter.WriteLine("-----------------------------");
        }

        private static void Log_Dtor(object sender, EventArgs e)
        {
            Recorder.EndRecording();

            StreamWriter.Dispose();
            FileStream?.Dispose();
        }
    }
}
