using mybooks.Data.Models;
using mybooks.Data.ViewModels;

namespace mybooks.Data.Services
{
    public class PublisherService
    {
        private AppDbContext _context;
        public PublisherService(AppDbContext context)
        {
            _context = context;
        }


        public void AddPublisher(PublisherVM publisherVM)
        {
            var _publisher = new Publisher()
            {
                Name = publisherVM.Name,
            };

            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }

        public List<Publisher> GetALlPublishers() => _context.Publishers.ToList();
        public Publisher GetPublisher(int id) => _context.Publishers.FirstOrDefault(publisher => publisher.Id == id);

    }
}
