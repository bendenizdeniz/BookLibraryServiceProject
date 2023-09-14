using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Modals.APIRequestModals
{
    public class CreateBookRequestModal
    {
        public string Name { get; set; } = string.Empty;

        public int PageNumber { get; set; }

        public string Author { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public int LibraryId { get; set; }
    }
}
