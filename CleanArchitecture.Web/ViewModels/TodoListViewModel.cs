using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ViewModels
{
    public class TodoListViewModel
    {       
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public int ItemsCount { get; set; }
        public TodoListViewModel(Guid id, string title, int itemsCount)
        {
            Id = id;
            Title = title;
            ItemsCount = itemsCount;
        }
    }
}
