﻿using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CleanArchitecture.UnitTests.Core.Entities
{    
    public class TodoListTests
    {
        [Fact]
        public void TodoList_Add_CountIsEqualOne()
        {
            var todoList = new TodoList("TEST", Colour.Yellow);
            todoList.Add(new TodoListItem("TEST", "TEST"));
            Assert.True(todoList.TodoListItems.Count == 1);
        }
    }
}
