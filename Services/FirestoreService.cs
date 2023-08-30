using Google.Cloud.Firestore;
using NewsletterAPI.Modals;

namespace NewsletterAPI.Services
{
    public class FirestoreService:IFirestoreService
    {
        private readonly FirestoreDb _firestoreDb;

        private const string _collectionName = "Emails";
        public FirestoreService(FirestoreDb firestoreDb)
        {
            _firestoreDb = firestoreDb;
        }

        public async Task AddAsync(EmailDocument emailDocument)
        {
            var collection = _firestoreDb.Collection(_collectionName);
            await collection.Document(emailDocument.Email).SetAsync(emailDocument);
        }
        public async Task DeleteAsync(EmailDocument emailDocument)
        {
            DocumentReference cityRef = _firestoreDb.Collection(_collectionName).Document(emailDocument.Email);
            await cityRef.DeleteAsync();
        }

        public async Task<List<EmailDocument>> GetAll()
        {
            var collection = _firestoreDb.Collection(_collectionName);
            var snapshot = await collection.GetSnapshotAsync();

            var emailDocuments = snapshot.Documents.Select(s => s.ConvertTo<EmailDocument>()).ToList();
            return emailDocuments;
        }


    }
}
