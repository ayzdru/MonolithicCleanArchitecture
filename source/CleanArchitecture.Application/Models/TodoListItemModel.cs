using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Models
{
    public class TodoListItemModel
    {       
        public Guid TodoListItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public TodoListItemModel(Guid todoListItemId, string title, string description, bool isDone)
        {
            TodoListItemId = todoListItemId;
            Title = title;
            Description = description;
            IsDone = isDone;
        }
    }
}
