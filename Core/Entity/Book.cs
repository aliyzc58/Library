using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Book : BaseEntity
    {
        public string BookName { get; set; }
        public string WriterName { get; set; }
        public string ImagePath { get;set; }
    }
}
