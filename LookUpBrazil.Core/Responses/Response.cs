using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LookUpBrazil.Core.Responses
{
    public class Response<TResponse>
    {
        [JsonConstructor]
        public Response() => _code = Configuration.DefaultStatusCode;
        public Response(TResponse? data, int code = Configuration.DefaultStatusCode, string? message = null)
        {
            Data = data;
            _code = code;
            Message = message;
        }
        private int _code = Configuration.DefaultStatusCode;
        public string? Message { get; set; }
        public TResponse? Data { get; set; }
        [JsonIgnore]
        public bool IsSuccess => _code is >= 200 and < 300;
    }
}
