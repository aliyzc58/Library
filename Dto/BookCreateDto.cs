using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class BookCreateDto
    {
        public string ImagePath{ get; set; }
        public string BookName{ get; set; }
        public string WriterName{ get; set; }
    }
}
