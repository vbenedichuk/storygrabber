﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnekdotGrabber.Interfaces
{
    public interface ILogWrapper
    {
        void Info(string message, params object[] args);
    }
}
