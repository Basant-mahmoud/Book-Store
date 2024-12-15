using Book_Store.Models.Domain;
namespace Book_Store.Repositories.Abstract
{
    public interface IAuthorService
    {
        bool Add(Author model);
        bool Update(Author model);
        bool Delete(int id);
        Author GetById(int id);
        IEnumerable<Author> GetAll();
    }
}
