using Google.Cloud.Firestore;

namespace NewsletterAPI.Modals
{
    [FirestoreData]
    public class EmailDocument
    {
        [FirestoreDocumentId]
        public string Email { get; set; }

        [FirestoreProperty]
        public string Name { get; set; }
    }
}
