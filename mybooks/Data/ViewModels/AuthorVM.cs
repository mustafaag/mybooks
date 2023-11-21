namespace mybooks.Data.ViewModels
{
    public class AuthorVM
    {
        public string FullName { get; set; }
    }

    public class AuthorWitBooksVM
    {
        public string FullName { get; set;}
        public List<string> BookTitles { get; set; }
    }
}
