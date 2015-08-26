﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Quartz;

namespace ConsoleApp.Quartz
{
    public class JobDemo : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("this is a job demo");
        }
    }
}
