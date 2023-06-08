using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Models
{
    public class TodoListModel
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public int ItemsCount { get; private set; }
        public TodoListModel(Guid id, string title, int itemsCount)
        {
            Id = id;
            Title = title;
            ItemsCount = itemsCount;
        }
    }
}
