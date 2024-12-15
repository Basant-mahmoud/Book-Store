using Book_Store.Models.Domain;
using Book_Store.Repositories.Abstract;

namespace Book_Store.Repositories.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly BookStoreContext _context;
        public AuthorService(BookStoreContext context)
        {
            _context = context;
        }
        public bool Add(Author model)
        {
            try
            {
                _context.Authors.Add(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex) { 
            return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var author = GetById(id);
                if (author != null)
                {
                    _context.Authors.Remove(author);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex) { return false; }
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public Author GetById(int id)
        {
            return _context.Authors.Find(id);
        }

        public bool Update(Author model)
        {
            try
            {
                _context.Authors.Update(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex) { return false; }
        }
    }
}
