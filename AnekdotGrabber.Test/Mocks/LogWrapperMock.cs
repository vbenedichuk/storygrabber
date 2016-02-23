using AnekdotGrabber.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnekdotGrabber.Test.Mocks
{
    class LogWrapperMock : ILogWrapper
    {
        public void Info(string message, params object[] args)
        {
            
        }
    }
}
