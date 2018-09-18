using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace ServisDB.Klase
{
    public class Helper
    {

        public static string GetReportRoot()
        {
#if (DEBUG)
            return "..\\..\\report_scripts\\";
#else
      return "report_scripts";
#endif
        }

        public static string ListToString(List<string> list)
        {
            if (list == null || list.Count == 0)
                return null;
            string res = "";
            foreach (var el in list)
            {
                res += "," + el;
            }
            return res.Substring(1);
        }

        public static List<string> StringToList(string value)
        {
            if (value == null)
                return null;
            else
                return value.Split(',').ToList();
        }
    }
}

