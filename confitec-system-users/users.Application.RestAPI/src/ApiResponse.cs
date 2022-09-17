using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace users.Application.RestAPI.src
{
    public class ApiResponse
    {
        public int StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 401:
                    return "Não autorizado";
                case 404:
                    return "Recurso não encontrado";
                case 405:
                    return "Método não permitido";
                case 500:
                    return "Um erro não tratado ocorreu no request";
                default:
                    return null;
            }
        }
    }
    public class ApiOKResponse : ApiResponse
    {
        public object Result { get; }

        public ApiOKResponse(object result) : base(200)
        {
            Result = result;
        }
    }
}
