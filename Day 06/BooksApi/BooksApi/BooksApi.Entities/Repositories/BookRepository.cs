
using BooksApi.Entities.Context;
using BooksApi.Entities.Entities;
using BooksApi.Entities.Repositories.Interface;

namespace BooksApi.Entities.Repositories
{
    public class BookRepository(BookDbContext bookDbContext)   : IBookRepository
    {
        private readonly BookDbContext _dbContext = bookDbContext;

        public async Task InsertBook(BookDetails bookDetails)
        {
            await _dbContext.BookDetails.AddAsync(bookDetails);
            await _dbContext.SaveChangesAsync();
        }

        public BookDetails GetById(int id)
        {
            return _dbContext.BookDetails.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookDetails> GetAllBooks()
        {
            return _dbContext.BookDetails.ToList();
        }

        public void UpdateBook(BookDetails bookDetails)
        {
            // Option A: Attach and mark Modified
            _dbContext.BookDetails.Update(bookDetails);
            _dbContext.SaveChanges();

            // Option B (alternative):
            // var existing = _dbContext.BookDetails.Find(bookDetails.Id);
            // if (existing != null)
            // {
            //     existing.Title = bookDetails.Title;
            //     existing.Description = bookDetails.Description;
            //     existing.Author = bookDetails.Author;
            //     _dbContext.SaveChanges();
            // }
        }
        // ──────────────────────────────────────────────────────────────────────────

        // ─────────────────────────── Implement Delete ───────────────────────────
        public void DeleteBook(int id)
        {
            var entity = _dbContext.BookDetails.Find(id);
            if (entity != null)
            {
                _dbContext.BookDetails.Remove(entity);
                _dbContext.SaveChanges();
            }
        }
        // ──────────────────────────────────────────────────────────────────────────
    }
}

