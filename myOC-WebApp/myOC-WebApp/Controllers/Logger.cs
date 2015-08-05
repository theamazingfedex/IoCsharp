using myOC_WebApp.Interfaces;

namespace myOC_WebApp.Controllers
{
    public class Logger : ILogger
    {
        private readonly string prefix;
        public Logger() : this("Logged"){ }
        public Logger(string prefix)
        {
            this.prefix = prefix;
        }
        public void Log(string message)
        {
            System.Diagnostics.Debug.WriteLine(prefix + " " + message);
        }
    }
}