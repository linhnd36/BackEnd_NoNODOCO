using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Data_Store.FirestoreContext
{
    public class NoNODOCFirestoreDb
    {
        public FirestoreDb fireStoreDb;

        public FirestoreDb getInstance()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "keys", "firebase_admin_sdk.json");
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            fireStoreDb = FirestoreDb.Create("test-uber-app-58711");
            return fireStoreDb;
        }

    }
}
