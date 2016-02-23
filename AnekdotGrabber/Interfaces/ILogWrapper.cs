using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnekdotGrabber.Interfaces
{
    public interface ILogWrapper
    {
        void Error(string message, params object[] args);
        void Info(string message, params object[] args);
    }
}
