using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    [Table("libraryCenter")]
    public class LibraryCenter : BaseEntity
    {
        public int TotalBookNumber { get; set; }

        public List<Book> BookList { get; set; } = new List<Book>();
    }
}
