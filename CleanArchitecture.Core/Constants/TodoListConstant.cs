using CleanArchitecture.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

public partial class Constants
{
    public static class TodoList
    {
        public static EntityValidatorConstant Title { get; } = new EntityValidatorConstant(3, 500, true);
    }
}
