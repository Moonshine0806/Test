﻿using System;
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
            var p = new PowerPoint();
            // Open application
            return p;
        }
    }
}
