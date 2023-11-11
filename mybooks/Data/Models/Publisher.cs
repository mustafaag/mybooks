namespace mybooks.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        // Navigations Properties 
        public List<Book> Books { get; set; }
    }
}
