﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Domain
{
    public class ErrorLog 
    {
        public Guid ErrorId { get; set; }
        public string Message { get; set; }
        public string StrackTrace { get; set; }
        public DateTime Time { get; set; }
    }
}
