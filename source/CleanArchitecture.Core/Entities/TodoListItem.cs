using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities
{
    public class TodoListItem : BaseEntity
    {     
        public TodoList TodoList { get; protected set; }
        public Guid TodoListId { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public bool IsDone { get; protected set; }
       
        public TodoListItem(Guid todoListId, string title, string description, bool isDone)
        {
            TodoListId = todoListId;
            Title = title;
            Description = description;
            IsDone = isDone;
        }
        public TodoListItem(string title, string description)
        {          
            Title = title;
            Description = description;
        }
       
    }
}
