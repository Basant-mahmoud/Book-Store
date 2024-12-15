using Book_Store.Models.Domain;

namespace Book_Store.Repositories.Abstract
{
    public interface IBookService
    {
        bool Add(Book model);
        bool Delete(int  Id);
        bool Update(Book model);
        Book GetById(int id);   
        IEnumerable<Book> GetAll();

    }
}
