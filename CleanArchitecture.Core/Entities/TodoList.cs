using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities
{
    public class TodoList : BaseEntity
    {
        public string Title { get; set; }
        private readonly List<TodoListItem>  _todoListItems = new List<TodoListItem>();
        public IReadOnlyCollection<TodoListItem> TodoListItems => _todoListItems.AsReadOnly();
        public TodoList(string title)
        {
            Title = title;
        }    
    }
}
