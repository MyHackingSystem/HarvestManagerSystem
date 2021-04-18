using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HarvestManagerSystem.outil
{
    class Validation
    {
        public static bool isNumeric(string txt)
        {
            Regex regex = new Regex(@"^[0-9]+\.?[0-9]*$");
            return regex.Match(txt).Success;
        }
    }
}
