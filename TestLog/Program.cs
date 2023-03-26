using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestLog;
using System.Configuration;


namespace TestLog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClassLibrary.Log log = new ClassLibrary.Log(MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().Name, ConfigurationManager.AppSettings["Path"], ConfigurationManager.AppSettings["FirstNamefile"]);

            log.Info("start");
            log.Info("message");
            log.Info("message");
            log.Info("message");
            log.Info("message");
            log.Info("message");
            log.Info("message");
            log.Info("message");
            log.Info("message");
            log.Info("message");
            log.Info("message");
            log.Info("message");
            log.Info("message");
            log.Info("message");
            log.Info("message");
            log.Info("message");
            log.Info("end");
            //log = log.Error("message");
            //_log = log.Debug("message");










        }

    }
}
