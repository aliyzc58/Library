using Core.Entity;
using Dto;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;

namespace LibraryAPI.Controllers
{
    public class BookController : CustomBaseController
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;
        private readonly ILoanedBookService _loanedBookService;
        public BookController(IBookService bookService, ILoanedBookService loanedBookService, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _loanedBookService = loanedBookService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetBookList()
        {
            /*refoactoring
             * join işlemi ile tek seferde kitaplar ödünç alan kişiyle birlikte çekilebilir
               try catch işlemleri service katmanında yapılıp daha temiz bir kod elde edilebilirdi */
            _logger.LogWarning(ErrorTypes.ListBook);
            List<BookListDto> bookListDtos = new List<BookListDto>();
            
            try
            {             
         
                List<Book> book = _bookService.GetAll();
                foreach (var item in book)
                {
                    BookListDto bookListDto = new BookListDto();
                    bookListDto.Id = item.Id;
                    bookListDto.ImagePath=item.ImagePath;
                    bookListDto.BookName=item.BookName;
                    bookListDto.WriterName=item.WriterName;
                    bookListDto.Status = item.Status;
                    if (item.Status == false)
                    {
                        var loaned = _loanedBookService.GetBy(x => x.BookId == item.Id).FirstOrDefault();
                        bookListDto.BrowwerDate = loaned.BrowwerDate;
                        bookListDto.BrowwerName = loaned.BorrowerName;
                    }
                    bookListDtos.Add(bookListDto);   
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return Ok(bookListDtos);
        }

        //Kitap Ekleme İşlemi
        [HttpPost]
        public IActionResult AddBook(BookCreateDto createDto)
        {
            try
            {
                Book book = new Book()
                {
                    CreateDate = DateTime.Now,
                    IsDeleted = false,
                    BookName = createDto.BookName,
                    WriterName = createDto.WriterName,
                    Status = true,
                    ImagePath = createDto.ImagePath,
                };

                _bookService.Add(book);
                _logger.LogWarning(createDto.BookName + ErrorTypes.AddBook);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return Ok();
        }
        [HttpPost]
        public IActionResult AddBrowwer(BrowwerDto createDto)
        {
            //refactoring 
            /* databaseden kitabın olup olmadığı sorgulanabilir
                   //throw new KitapBulunamadı(); */
            try
            {
                //Ödünç Alan Kişi Oluşturuluyor
                LoanedBook browwer = new LoanedBook()
                {
                    BookId = createDto.BookId,
                    BrowwerDate = createDto.BrowwerDateTime,
                    BorrowerName = createDto.BrowwerName + createDto.BrowwerSurname,

                };
                _loanedBookService.Add(browwer);
                
                //Kitabın kütüphanedeki durumu güncelleniyor
                var book = _bookService.GetById(createDto.BookId);
                book.Status = false;
                book.UpdateDate = DateTime.Now;
                _bookService.Update(book);
                _logger.LogWarning(createDto.BrowwerName + " adlı kişiye kitap emanet edildi");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return Ok();
        }

    }
}
