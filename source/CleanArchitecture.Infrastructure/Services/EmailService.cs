using CleanArchitecture.Core.Interfaces;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Services
{
    public class EmailService : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {            
            return Task.CompletedTask;
        }
    }
}
