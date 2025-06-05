using BooksApi.Entities.Entities;
using BooksApi.Entities.Repositories.Interface;
using BooksApi.Models;
using BooksApi.Services.Services.Interface;

namespace BooksApi.Services
{
    // For CRUD on books
    public class BookService : IBookService
    {
        private List<Book> _books;
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _books = new List<Book>();
        }

        // To Add Book
        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        // To Get All Books
        public List<BookDetails> GetAll()
        {
            return _bookRepository.GetAllBooks();
        }

        public BookDetails? GetBookDetailsById(int id)
        {
            return _bookRepository.GetById(id);
        }

        // To Get Single Book
        public Book? GetBookById(int id)
        {
            return _books.Find(x => x.Id == id);
        }

        public async Task InsertBook(BookDetails bookDetails)
        {
            await _bookRepository.InsertBook(bookDetails);
        }


        //public BookDetails GetBookDetailsById(int id)
        //{
        //    return _bookRepository.GetById(id);
        //}

        // To Update Book
        // To Delete Book

        public void UpdateBook(BookDetails bookDetails)
        {
            _bookRepository.UpdateBook(bookDetails);
        }
        // ──────────────────────────────────────────────────────────────────────────

        // ─────────────────────────── Implement Delete ────────────────────────────
        public void DeleteBook(int id)
        {
            _bookRepository.DeleteBook(id);
        }
    }
}
