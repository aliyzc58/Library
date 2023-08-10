using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class LoanedBook : BaseEntity
    {
        [ForeignKey("BookId")]
        public int BookId { get; set; }
        public string BorrowerName { get; set; }
        public DateTime BrowwerDate { get; set; }
        public Book Book { get; set; }

    }
}
