using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities
{
    public class TodoList : BaseEntity
    {
        public string Title { get; private set; }
    }
}
