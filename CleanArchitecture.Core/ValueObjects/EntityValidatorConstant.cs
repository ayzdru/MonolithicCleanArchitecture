using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.ValueObjects
{
    public class EntityValidatorConstant : ValueObject
    {
        public int MinimumLength { get; private set; }
        public int MaximumLength { get; private set; }       
        public bool Required { get; set; }
        public EntityValidatorConstant(int minimumLength, int maximumLength, bool required)
        {          
            MinimumLength = minimumLength;
            MaximumLength = maximumLength;
            Required = required;
        }       
    }
}
