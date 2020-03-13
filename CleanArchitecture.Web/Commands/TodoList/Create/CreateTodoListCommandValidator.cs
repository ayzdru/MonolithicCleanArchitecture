using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Commands
{
    public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoListCommand>
    {
        public CreateTodoItemCommandValidator()
        {
            RuleFor(v => v.TodoList.Title)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
