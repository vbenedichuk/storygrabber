using AnekdotGrabber.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnekdotGrabber.Logic
{
    class LogWrapper : ILogWrapper
    {
        private Logger logger; 
        private string className;

        public LogWrapper(string className)
        {
            this.className = className;
            this.logger = LogManager.GetLogger(className);
        }
        public void Info(string message, params object[] args)
        {
            logger.Info(message, args);
        }
    }
}
