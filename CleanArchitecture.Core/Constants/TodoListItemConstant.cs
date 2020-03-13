using CleanArchitecture.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

public partial class Constants
{
    public static class TodoListItem
    {
        public static EntityValidatorConstant Title { get; } = new EntityValidatorConstant(3, 500, true);
        public static EntityValidatorConstant Description { get; } = new EntityValidatorConstant(3, 500, true);
        public const bool IsDoneRequired = true;
    }
}
