using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.ValueObjects
{
    public class Error : ValueObject
    {       
        public string Key { get; private set; }
        public string Message { get; private set; }
        public Error(string key, string message)
        {
            Key = key;
            Message = message;
        }
    }
}
