using mybooks.Data.Models;
using mybooks.Data.ViewModels;

namespace mybooks.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }


        public void AddAuthor(AuthorVM authorVm)
        {
            var _author = new Author()
            {
                FullName = authorVm.FullName,
            };

            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public List<Author> GetAllAuthors() => _context.Authors.ToList();
        public Author GetAuthor(int id) => _context.Authors.FirstOrDefault(author => author.Id == id);
        public AuthorWitBooksVM GetAuthorWitBooks(int authorId)
        {
            var author = _context.Authors.Where(a => a.Id == authorId).Select(n => new AuthorWitBooksVM
            {
                FullName = n.FullName,
                BookTitles = n.Book_Authors.Select(ba => ba.Book.Title).ToList()
            }).FirstOrDefault();

            return author;
        }
    }
}
