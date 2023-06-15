﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Models
{
    public record TodoListModel
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public int ItemsCount { get; init; }
        public TodoListModel(Guid id, string title, int itemsCount)
        {
            Id = id;
            Title = title;
            ItemsCount = itemsCount;
        }
    }
}
