using Data_Store.Models;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Text;
using Data_Store.FirestoreContext;

namespace Data_Store.Reponsitory
{
    public class BaseFirestoryReponsitory 
    {
        private FirestoreDb fireStoreDb;
        public BaseFirestoryReponsitory()
        {
            NoNODOCFirestoreDb nODOCFirestoreDb = new NoNODOCFirestoreDb();
            fireStoreDb = nODOCFirestoreDb.getInstance();
        }

    }
}

