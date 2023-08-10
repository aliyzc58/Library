using Dto;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {

        public CustomBaseController()
        {
        }
        
        public enum HttpStatusCode
        {
            NotFound = 404,
            BadRequest = 404,
            UnSporttedMediaType = 415,
            Created = 201,
            NoContent = 204,
            Ok = 200

        }

        public enum EntityStatus
        {
            Passive = 2,
            Active = 1,
            AwaitingResponseDiveCenter = 0
        }
       
        public class ErrorTypes
        {
            public static string AddBook = " adlı kitap eklendi";
            public static string ListBook = "Kitap liste sayfası açıldı";

        }
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDto response)
        {
            if (response.StatusCode == 204)
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };

            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }

    }
}
