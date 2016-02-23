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
        public int Count { get; set; }

        public LogWrapperMock()
        {
        }

        public void Info(string message, params object[] args)
        {
            Count++;
        }

        public void Error(string message, params object[] args)
        {
            Count++;
        }
    }
}
