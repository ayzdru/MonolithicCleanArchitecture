using CleanArchitecture.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities
{
    public class TodoList : BaseEntity
    {
        public string Title { get; private set; }
        public Colour Colour { get; private set; } = Colour.White;
        private readonly List<TodoListItem>  _todoListItems = new List<TodoListItem>();
        public IReadOnlyCollection<TodoListItem> TodoListItems => _todoListItems.AsReadOnly();
        public TodoList(string title)
        {
            Title = title;
        }
        public TodoList(string title, Colour colour )
        {
            Title = title; 
            Colour = colour;
        }        
        public void Add(TodoListItem item)
        {
            _todoListItems.Add(item);
        }
        public void SetTitle(string title) { Title = title; }
        public void UpdateColour(Colour colour)
        {
            Colour = colour;
        }
    }
}
