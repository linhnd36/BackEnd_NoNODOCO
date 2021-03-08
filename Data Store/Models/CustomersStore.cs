using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Store.Models
{
    [FirestoreData]
    public class CustomersStore
    {
        [FirestoreProperty]
        public string CustomerId { get; set; }
        [FirestoreProperty]
        public string Longitude { get; set; }
        [FirestoreProperty]
        public string Latitude { get; set; }   
    }
}
