using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities
{
    public class TodoListItem : BaseEntity
    {     
        public TodoList TodoList { get; private set; }
        public Guid TodoListId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool IsDone { get; private set; }
        public TodoListItem()
        {

        }
        public TodoListItem(Guid todoListId, string title, string description)
        {
            TodoListId = todoListId;
            Title = title;
            Description = description;
        }
        public void ChangeStatus(bool isDone)
        {
            IsDone = isDone;         
        }
    }
}
