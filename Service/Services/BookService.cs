using Core.Entity;
using Core.IRepository;
using Core.IService;
using Core.IUnitOfWork;
using Dto;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class BookService : GenericService<Book>, IBookService
    {
        public BookService(IGenericRepository<Book> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public List<BookListDto> GetBookList()
        {
            List<BookListDto> list = new List<BookListDto>()
            {
                new BookListDto
                {
                    Id=1,
                    Status=true,
                    BookName="Yaşlı Adam ve Deniz",
                    WriterName="Hemmingway",
                    ImagePath="kitap.jpg",
                }, new BookListDto
                {
                    Id=1,
                    Status=false,
                    BookName="Yaşlı Adam ve Deniz",
                    WriterName="Hemmingway",
                    ImagePath="kitap.jpg",
                    BrowwerDate=DateTime.Now,
                    BrowwerName="Ali Yazıcı",
                }, new BookListDto
                {
                    Id=1,
                    Status=true,
                    BookName="Yaşlı Adam ve Deniz",
                    WriterName="Hemmingway",
                    ImagePath="kitap.jpg",
                },
            };
            return list;
        }
    }
}
