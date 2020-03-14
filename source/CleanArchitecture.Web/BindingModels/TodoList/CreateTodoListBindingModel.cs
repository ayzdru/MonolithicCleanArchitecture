using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.BindingModels
{
    public class CreateTodoListBindingModel
    {
        [Required]
        [StringLength(Constants.TodoList.TitleMaximumLength,MinimumLength = Constants.TodoList.TitleMinimumLength)]
        public string Title { get; set; }
    }
}
