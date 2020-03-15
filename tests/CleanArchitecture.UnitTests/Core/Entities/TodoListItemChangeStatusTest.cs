using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CleanArchitecture.UnitTests.Core.Entities
{    
    public class TodoListItemChangeStatusTest
    {
        [Fact]
        public void SetsIsDoneTrue()
        {
            var todoListItem = new TodoListItem();
            todoListItem.ChangeStatus(true);
            Assert.True(todoListItem.IsDone);
        }
    }
}
