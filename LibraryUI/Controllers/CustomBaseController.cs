using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.APIHandler;

namespace LibraryUI.Controllers
{
    public class CustomBaseController : Controller
    {
        protected readonly IAPIHandler _apiHandler;
        protected readonly IConfiguration _configuration;
        protected readonly string _url;

        public CustomBaseController(IAPIHandler apiHandler, IConfiguration configuration)
        {
            _apiHandler = apiHandler;
            _configuration = configuration;
            _url = this._configuration["BaseUrl"];
        }

     

    }
}
