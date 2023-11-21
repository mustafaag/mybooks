using mybooks.Data.Models;

namespace mybooks.Data
{
    public class AppDBInitialiser
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if(!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "Title",
                        Description = "Description",
                        IsRead = true,
                        DateAdded = DateTime.Now,
                        DateRead = DateTime.Now.AddDays(-1),
                        Rate = 4,
                        CoverUrl = "...",
                        Genre = "Drama"
                    },
                    new Book()
                    {
                        Title = "Second Title",
                        Description = "Second Description",
                        IsRead = true,
                        DateAdded = DateTime.Now,
                        DateRead = DateTime.Now.AddDays(-3),
                        Rate = 4,
                        CoverUrl = "...sad",
                        Genre = "Thriller"
                    });
                }

                //context.SaveChanges();
            }
        }
    }
}
