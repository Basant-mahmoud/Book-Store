using Book_Store.Models.Domain;
namespace Book_Store.Repositories.Abstract
{
    public interface IPublisherService
    {
        bool Add(Publisher model);
        bool Update(Publisher model);
        bool Delete(int id);
        Publisher GetById(int id);
        IEnumerable<Publisher> GetAll();
    }
}
