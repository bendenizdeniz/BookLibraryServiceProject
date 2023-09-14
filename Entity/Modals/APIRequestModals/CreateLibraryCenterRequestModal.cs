using Entity.Entity;

namespace BookLibraryAPI.Models.APIRequestModels
{
    public class CreateLibraryCenterRequestModal
    {
        public string Name { get; set; } = String.Empty;

        public int TotalBooknumber { get; set; } = 0;

        public List<Book> BookList { get; set; } = new List<Book>();
    }
}
