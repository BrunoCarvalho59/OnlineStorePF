using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.API.Erros
{
    public class ApiException : ApiResponse
    {
        public ApiException(int statusCode, string message = null, string details = null) : base(statusCode, message)
        {
            Details = details;
        }

        public string Details { get; set; }
    }
}