﻿using mybooks.Data.Models;
using mybooks.Data.ViewModels;
using System.Threading;

namespace mybooks.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
           _context = context;
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead : null,
                Rate = book.IsRead ? book.Rate : null,
                Genre = book.Genre,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
            };

            _context.Books.Add(_book);
            _context.SaveChanges();
        }

        public List<Book> GetAllBooks() => _context.Books.ToList();

        public Book GetBook(int id) => _context.Books.FirstOrDefault(book => book.Id == id);

        public Book UpdateBookById(int  id, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(x => x.Id == id);
            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead : null;
                _book.Rate = book.IsRead ? book.Rate : null;
                _book.Genre = book.Genre;
                _book.Author = book.Author;
                _book.CoverUrl = book.CoverUrl;
            }
            _context.SaveChanges();
            return _book;
        }

        public void DeleteBookId(int id)
        {
            var _book = _context.Books.FirstOrDefault(x => x.Id == id);
            if( _book != null )
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }

        }

    }
}