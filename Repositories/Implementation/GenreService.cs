using Book_Store.Models.Domain;
using Book_Store.Repositories.Abstract;

namespace Book_Store.Repositories.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly BookStoreContext _context;
        public GenreService(BookStoreContext context)
        {
            _context = context;
        }
        public bool Add(Genre model)
        {
            try
            {
                _context.Genres.Add(model);
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
                var data= GetById(id);
                if (data == null) { return false; }
               _context.Genres.Remove(data);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Genre GetById(int id)
        {
            return _context.Genres.Find(id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return _context.Genres.ToList();
        }

        public bool Update(Genre model)
        {
            try
            {
                _context.Genres.Update(model);
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
