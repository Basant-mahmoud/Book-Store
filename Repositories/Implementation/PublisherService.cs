using Book_Store.Models.Domain;
using Book_Store.Repositories.Abstract;

namespace Book_Store.Repositories.Implementation
{
    public class PublisherService : IPublisherService
    {
        private readonly BookStoreContext _context;
        public PublisherService(BookStoreContext context)
        {
            _context = context;
        }
        public bool Add(Publisher model)
        {
            try
            {
                _context.Publishers.Add(model);
                _context.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var publisher = GetById(id);
                if (publisher != null)
                {
                    _context.Publishers.Remove(publisher);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Publisher> GetAll()
        {
            return _context.Publishers.ToList();
        }

        public Publisher GetById(int id)
        {
            return _context.Publishers.Find(id);
        }

        public bool Update(Publisher model)
        {
            try
            {
                _context.Publishers.Update(model);
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
