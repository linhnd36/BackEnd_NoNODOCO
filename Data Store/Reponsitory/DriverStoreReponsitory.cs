using Data_Store.FirestoreContext;
using Data_Store.Models;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;


namespace Data_Store.Reponsitory
{
    public class DriverStoreReponsitory
    {
        private FirestoreDb fireStoreDb;
        private string collectionName;
        public DriverStoreReponsitory()
        {
            NoNODOCFirestoreDb nODOCFirestoreDb = new NoNODOCFirestoreDb();
            fireStoreDb = nODOCFirestoreDb.getInstance();
            collectionName = "Drivers";

        }

       /* public DriverStore Add<DriverStore>(DriverStore driver) where DriverStore : BaseStore
        {
            CollectionReference colRef = fireStoreDb.Collection(collectionName);
            DocumentReference doc = colRef.AddAsync(driver).GetAwaiter().GetResult();
            driver.DocumentId = doc.Id();
            return driver;
        }
        public bool Update<DriverStore>(DriverStore driver) where DriverStore : BaseStore
        {
            DocumentReference driverRef = fireStoreDb.Collection(collectionName).Document(driver.DocumentId);
            driverRef.SetAsync(driver, SetOptions.MergeAll).GetAwaiter().GetResult();
            return true;
        }
        public bool Delete<DriverStore>(DriverStore driver) where DriverStore : BaseStore
        {
            DocumentReference driverRef = fireStoreDb.Collection(collectionName).Document(driver.DocumentId);
            driverRef.DeleteAsync().GetAwaiter().GetResult();
            return true;
        }
        public DriverStore Get<DriverStore>(DriverStore driver) where DriverStore : BaseStore
        {
            DocumentReference docRef = fireStoreDb.Collection(collectionName).Document(driver.DocumentId);
            DocumentSnapshot snapshot = docRef.GetSnapshotAsync().GetAwaiter().GetResult();
            if (snapshot.Exists)
            {
                DriverStore usr = snapshot.ConvertDriverStoreo<DriverStore>();
                usr.DocumentId = snapshot.Id;
                return usr;
            }
            else
            {
                return null;
            }
        }*/
        public List<DriverStore> GetAll()
        {
            Query query = fireStoreDb.Collection(collectionName);
            QuerySnapshot querySnapshot = query.GetSnapshotAsync().GetAwaiter().GetResult();
            List<DriverStore> list = new List<DriverStore>();
            foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    DriverStore driverStore = new DriverStore();
                    driverStore.DocumentId = documentSnapshot.Id;
                    driverStore.Latitude = Double.Parse(documentSnapshot.GetValue<string>("Latitude"));
                    driverStore.Longitude = Double.Parse(documentSnapshot.GetValue<string>("Longitude"));
                    driverStore.Status = documentSnapshot.GetValue<string>("Status");
                    driverStore.Rate = Double.Parse(documentSnapshot.GetValue<string>("Rate"));
                    driverStore.Email = documentSnapshot.GetValue<string>("Email");
                    if (driverStore.Status == "1")
                    {
                        list.Add(driverStore);
                    }
                }
            }
            return list;
        }
        /*public List<DriverStore> QueryRecords<DriverStore>(Query query) where DriverStore : BaseStore
        {
            QuerySnapshot querySnapshot = query.GetSnapshotAsync().GetAwaiter().GetResult();
            List<DriverStore> list = new List<DriverStore>();
            foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> city = documentSnapshot.DriverStoreoDictionary();
                    string json = JsonConvert.SerializeObject(city);
                    DriverStore newItem = JsonConvert.DeserializeObject<DriverStore>(json);
                    newItem.DocumentId = documentSnapshot.DocumentId;
                    list.Add(newItem);
                }
            }
            return list;
        }*/
    }
}
