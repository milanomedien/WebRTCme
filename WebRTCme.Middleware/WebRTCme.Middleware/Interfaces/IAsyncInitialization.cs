﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebRTCme.Middleware
{
    public interface IAsyncInitialization
    {
        Task Initialization { get; }
    }
}