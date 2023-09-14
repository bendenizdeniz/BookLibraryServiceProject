using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entity
{
    [Table("book")]
    public class Book : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public int PageNumber { get; set; }

        public string Author { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public int? CustomerId { get; set; }

        public int LibraryId { get; set; }

        [ForeignKey("LibraryId")]
        public LibraryCenter Library { get; set; }

        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }

    }
}