﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WpfDi.Services
{
    public class SampleService : ISampleService
    {
        public string GetCurrentDate() => DateTime.Now.ToLongDateString();
    }
}
