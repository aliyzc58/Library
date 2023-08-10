using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dto
{
    public class CustomResponseDto
    {
        public dynamic? Data { get; set; }
        public bool? Status { get; set; }
        public string? Message { get; set; }
        public List<dynamic>? ValidationErrors { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public static CustomResponseDto Success(int StatusCode, bool Status, string Message, dynamic data)
        {
            return new CustomResponseDto { StatusCode = StatusCode, Status = Status, Message = Message, Data = data };
        }
        public static CustomResponseDto Success(int StatusCode, bool Status, string Message)
        {
            return new CustomResponseDto { StatusCode = StatusCode, Status = Status, Message = Message };
        }
        public static CustomResponseDto Fail(string Errors, int statusCode)
        {
            return new CustomResponseDto { Message = Errors, StatusCode = statusCode };
        }
        public static CustomResponseDto Fail(int statusCode, bool Status, string Message, dynamic Validation)
        {
            return new CustomResponseDto { StatusCode = statusCode, Status = Status, Message = Message, ValidationErrors = new List<dynamic>() { Validation } };
        }


    }
}
