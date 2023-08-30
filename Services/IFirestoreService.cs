using Google.Cloud.Firestore;
using NewsletterAPI.Modals;

namespace NewsletterAPI.Services
{
    public interface IFirestoreService
    {
        public Task AddAsync(EmailDocument EmailDocument);
        public Task DeleteAsync(EmailDocument EmailDocument);
        public Task<List<EmailDocument>> GetAll();
    }
}
