using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities
{
    public class TodoListItem : BaseEntity
    {     
        public TodoList TodoList { get; private set; }
        public Guid TodoListId { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; private set; }
        public TodoListItem(Guid todoListId, string title, string description)
        {
            TodoListId = todoListId;
            Title = title;
            Description = description;
        }
        public void MarkComplete()
        {
            IsDone = true;         
        }
    }
}
