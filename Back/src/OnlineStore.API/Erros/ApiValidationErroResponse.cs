using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.API.Erros
{
    public class ApiValidationErroResponse : ApiResponse
    {
        public ApiValidationErroResponse() : base(400)
        {
        }
        public IEnumerable<string> Errors { get; set; }
    }
}