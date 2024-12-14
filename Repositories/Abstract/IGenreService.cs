using Book_Store.Models.Domain;

namespace Book_Store.Repositories.Abstract
{
    public interface IGenreService
    {
        bool Add(Genre model);
        bool Update(Genre model);
        bool Delete(int id);
        Genre GetById(int id);
        IEnumerable<Genre> GetAll();

    }
}
