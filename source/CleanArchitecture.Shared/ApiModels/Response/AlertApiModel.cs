using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zanha.Pay.Shared.ApiModels
{
    public class AlertApiModel
    {
        public AlertApiModel(string title, string message)
        {
            Title = title;
            Message = message;
        }

        public AlertApiModel(string title, string message, object body) : this(title, message)
        {
            Body = body;
        }

        public string Title { get; private set; }
        public string Message { get; private set; }
        public object Body { get; set; } = null;
    }
}
