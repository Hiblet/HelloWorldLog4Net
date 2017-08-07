﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldCore.Models
{
    public class HelloWorld
    {
        public string Timestamp { get; set; }

        public HelloWorld()
        {
            Timestamp = DateTime.UtcNow.ToString("HH:mm:ss.fff");
        }
    }
}
