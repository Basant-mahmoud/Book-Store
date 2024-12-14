using Microsoft.EntityFrameworkCore;

namespace Book_Store.Models.Domain
{
    public class BookStoreContext:DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext>options) :base(options){ }
        public DbSet<Book> Books { get; set; }
        public DbSet<Authorcs> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Genre> Genres { get; set; }




    }
}
