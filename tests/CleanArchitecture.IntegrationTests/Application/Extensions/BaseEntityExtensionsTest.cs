using CleanArchitecture.Application.Extensions;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CleanArchitecture.IntegrationTests.Application.Extensions
{
    public class BaseEntityExtensionsTest : TestFixture
    {
        [Fact]
        public void GetById()
        {
            var todoList = new TodoList("TEST");
            _dbContext.TodoLists.Add(todoList);
            _dbContext.SaveChanges();
            var getByIdTodoList =_dbContext.TodoLists.GetById(todoList.Id).SingleOrDefault();
            Assert.Equal(todoList.Id, getByIdTodoList?.Id);
        }
    }
}
