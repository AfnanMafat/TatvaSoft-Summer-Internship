using BooksApi.Entities.Entities;

namespace BooksApi.Entities.Repositories.Interface
{
    public interface IBookRepository
    {
        Task InsertBook(BookDetails bookDetails);
        BookDetails GetById(int id);
        List<BookDetails> GetAllBooks();

        void UpdateBook(BookDetails bookDetails);
        void DeleteBook(int id);
    }
}
