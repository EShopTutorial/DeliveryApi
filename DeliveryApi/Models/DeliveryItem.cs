using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DeliveryApi.Models
{
    public class DeliveryItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

      
        public string CustomerName { get; set; }

        public int OrderID { get; set; }
        public int OrderQuantity { get; set; }

        public string Address { get; set; }

        public string DeliveryBoy { get; set; }

        public string DeliveryStatus { get; set; }
    }
}
