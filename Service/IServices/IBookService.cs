using Core.Entity;
using Core.IService;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IBookService : IGenericService<Book>
    {
        List<BookListDto> GetBookList();
    }
}
