using Dto;
using LibraryUI.FileUpload;
using LibraryUI.Models;
using Microsoft.AspNetCore.Mvc;
using Service.APIHandler;
using System.Diagnostics;

namespace LibraryUI.Controllers
{
    public class HomeController : CustomBaseController
    {
        private readonly IFileUpload _fileUpload;
        public HomeController(IAPIHandler apiHandler, IConfiguration configuration, IFileUpload fileUpload) : base(apiHandler, configuration)
        {
            _fileUpload = fileUpload;
        }

        public IActionResult Index()
        {
            List<BookListDto> listbook = _apiHandler.GetApi<List<BookListDto>>(_url + UrlStrings.GetBookList);
            return View(listbook); 
        }


        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddBook(BookCreateDto createDto,IFormFile formFile)
        {
            if(formFile != null) 
            {
                createDto.ImagePath = _fileUpload.FileUploads(formFile); 
            }
            var post = _apiHandler.PostApi<BookCreateDto>(createDto, _url + UrlStrings.AddBook);
            return RedirectToAction("Index");
        }
        public IActionResult Browwer(BrowwerDto dto)
        {
            var post = _apiHandler.PostApi<BookCreateDto>(dto, _url + UrlStrings.AddBrowwer);

            return RedirectToAction("Index");
        }

       
    }
}