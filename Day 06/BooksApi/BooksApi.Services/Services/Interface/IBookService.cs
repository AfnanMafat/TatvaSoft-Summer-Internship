
using BooksApi.Entities.Entities;
using BooksApi.Models;

namespace BooksApi.Services.Services.Interface
{
    public interface IBookService
    {
        //void AddBook(Book book);
        //List<Book> GetAll();
        //Book? GetBookById(int id);
        //Task InsertBook(BookDetails bookDetails);
        //BookDetails GetBookDetailsById(int id);

        Task InsertBook(BookDetails bookDetails);
        List<BookDetails> GetAll();
        BookDetails? GetBookDetailsById(int id);

        void UpdateBook(BookDetails bookDetails);
        void DeleteBook(int id);
    }
}
