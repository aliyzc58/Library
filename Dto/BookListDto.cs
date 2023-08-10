using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class BookListDto
    {
        public int Id { get; set; }
        public string WriterName { get; set; }
        public string BookName { get; set; }
        public bool Status { get; set; }
        public string ImagePath { get; set; }
        public string? BrowwerName { get; set; }
        public DateTime? BrowwerDate { get; set; }
    }
}
