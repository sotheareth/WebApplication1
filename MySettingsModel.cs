﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class MySettingsModel
    {
        public string DbConnection { get; set; }
        public string Email { get; set; }
        public string SMTPPort { get; set; }
    }
}
