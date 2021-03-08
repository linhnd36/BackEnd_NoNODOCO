using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Store.Models
{
    [FirestoreData]
    public class DriverStore : BaseStore
    {
        [FirestoreProperty]
        public double Longitude { get; set; }
        [FirestoreProperty]
        public double Latitude { get; set; }
        [FirestoreProperty]
        public string Status { get; set; }
        [FirestoreProperty]
        public double Rate { get; set; }
        [FirestoreProperty]
        public string Email { get; set; }
        public DriverStore()
        {
        }
    }
}

