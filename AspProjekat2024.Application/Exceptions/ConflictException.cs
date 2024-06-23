using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat2024.Application.Exceptions
{
    public class ConflictException : Exception
    {
        public ConflictException(string reason) : base(reason)
        {
            
        }
    }
}
