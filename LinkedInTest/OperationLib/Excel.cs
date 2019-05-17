using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedInTest.OperationLib
{
    public struct ExcelFlag {}
    public class Excel : CommonOperation<ExcelFlag>
    {
        public static Excel Open()
        {
            const string excelAppId = "EXCEL.EXE";
            OpenHelper(excelAppId, () => FindSpecificTypeElementByName(DesktopSession(), ControlType.Window, "Excel"));
            FindSpecificTypeElementByName(Session, ControlType.ListItem, "Blank workbook").Click();

            return new Excel();
        }
    }
}
