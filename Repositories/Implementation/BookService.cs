using Book_Store.Models.Domain;
using Book_Store.Repositories.Abstract;

namespace Book_Store.Repositories.Implementation
{
    public class BookService : IBookService
    {
        private readonly BookStoreContext _context;
        public BookService(BookStoreContext context)
        {
            _context= context;
        }
        public bool Add(Book model)
        {
            try
            {
                _context.Books.Add(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex) { 
                return false;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                var Book = GetById(Id);
                if (Book != null)
                {
                    _context.Books.Remove(Book);
                    _context.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (Exception ex) { 
                return false;
                }
        }

        public IEnumerable<Book> GetAll()
        {
            var books = (from book in _context.Books join Author in _context.Authors
                         on book.AutherId equals Author.Id
                         join Publisher in _context.Publishers
                         on book.PublisherId equals Publisher.Id
                         join Genre in _context.Genres
                         on book.GenreId equals Genre.Id
                         select new Book 
                         {
                             Id=book.Id,AutherId=book.AutherId,
                             PublisherId=book.PublisherId,
                             GenreId=book.GenreId,Isbn=book.Isbn,
                             Title=book.Title,
                             TotalPages=book.TotalPages,
                         AuthorName=book.AuthorName,
                         GenreName=book.GenreName,
                         PublisherName=book.PublisherName,
                        }).ToList();
            return books;
        }

        public Book GetById(int id)
        {
            return _context.Books.Find(id);

        }

        public bool Update( Book model)
        {
            try
            {
               
                    _context.Books.Update(model);
                    _context.SaveChanges();
                    return true;

          
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
