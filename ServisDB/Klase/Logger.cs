using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TMS.Core.Helpers
{
  public class Logger
  {
    public static void Exception(Exception e)
    {
      try
      {
        StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\log.txt", true);
        sw.Write("------------" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "-----------");
        if (e.Data["id"] != null)
          sw.WriteLine("ID: " + e.Data["id"].ToString());
        sw.WriteLine("MESSAGE: " + e.Message);
        sw.WriteLine("STACK TRACE: " + e.StackTrace);
        sw.Close();
      }
      catch (Exception)
      {
        //JBG :)
      }
    }
  }
}
