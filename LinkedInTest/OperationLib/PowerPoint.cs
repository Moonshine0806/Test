using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedInTest.OperationLib
{
    public struct PowerPointFlag {}
    public class PowerPoint : CommonOperation<PowerPointFlag>
    {
        public static PowerPoint Open()
        {
            const string pptAppId = "POWERPNT.EXE";
            OpenHelper(pptAppId);
            FindSpecificTypeElementByName(Session, ControlType.ListItem, "Blank Presentation").Click();

            return new PowerPoint();
        }
    }
}
