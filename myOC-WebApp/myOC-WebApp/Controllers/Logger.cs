using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myOC_WebApp.Controllers
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            System.Diagnostics.Debug.WriteLine("Logged " + message);
        }
    }
}