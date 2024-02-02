using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Lab1_BrunoLopes_V3.VALIDATION
{
    public class Validator
    {

        public static bool IsValidId(string input)
        {
            if (!Regex.IsMatch(input, @"^\d{4}$"))
            {
                return false;
            }
            return true;
        }

        public static bool IsValidId(string input, int size)
        {
            if (!Regex.IsMatch(input, @"^\d{" + size + "}$"))
            {
                return false;
            }
            return true;
        }

        public static bool IsValidName(string input)
        {
            if (!Regex.IsMatch(input, @"^[a-zA-Z]+$"))
            {
                return false;
            }
            return true;
        }

    }
}