using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Infrastructure.Extensions;
using CleanArchitecture.Web.BindingModels;
using CleanArchitecture.Web.Commands;
using CleanArchitecture.Web.Queries;
using CleanArchitecture.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Zanha.Pay.Shared.ApiModels;

namespace CleanArchitecture.Web.Pages
{
    public class TodoPageModel : BasePageModel
    {
        private readonly ILogger<TodoPageModel> _logger;

        public TodoPageModel(ILogger<TodoPageModel> logger)
        {
            _logger = logger;
        }
        public List<TodoListViewModel> TodoListViewModel { get; set; }
        public async Task OnGet()
        {
            TodoListViewModel = await Mediator.Send(new GetTodoListsQuery());
        }
        public CreateTodoListBindingModel  CreateTodoListBindingModel { get; set; }
        public async Task<IActionResult> OnPostCreateTodoList(CreateTodoListBindingModel createTodoListBindingModel)
        {
            if(ModelState.IsValid)
            {
                var creatTodoListId = await Mediator.Send(new CreateTodoListCommand(new TodoList(createTodoListBindingModel.Title)));
                if(creatTodoListId.HasValue)
                {
                    return new JsonResult(new AlertApiModel("Create Todo List", $"{createTodoListBindingModel.Title} oluşturuldu.", new { Id = creatTodoListId.Value }));
                }
            }
            return new JsonResult(new AlertApiModel("Create Todo List", ModelState.GetModelStateErrors()))
            {
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
        public DeleteTodoListBindingModel  DeleteTodoListBindingModel { get; set; }
        public async Task<IActionResult> OnPostDeleteTodoList(DeleteTodoListBindingModel deleteTodoListBindingModel)
        {
            if (ModelState.IsValid)
            {
                var deleteTodoListCommandAffected = await Mediator.Send(new DeleteTodoListCommand(deleteTodoListBindingModel.TodoListId.Value));
                if (deleteTodoListCommandAffected != 0)
                {
                    return new JsonResult(new AlertApiModel("Delete Todo List", $"Liste silindi."));
                }
                else
                {
                    return new JsonResult(new AlertApiModel("Delete Todo List", $"Liste silinemedi.")) {

                        StatusCode = StatusCodes.Status500InternalServerError
                    };
                }
            }
            return new JsonResult(new AlertApiModel("Create Todo List", ModelState.GetModelStateErrors()))
            {
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
    }
}
