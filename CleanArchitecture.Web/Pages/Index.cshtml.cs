using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Web.Pages
{
    public class IndexPageModel : PageModel
    {
        private readonly ILogger<IndexPageModel> _logger;

        public IndexPageModel(ILogger<IndexPageModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
