using DeliveryApi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApi.Services
{
    public class DeliveryService
    {
        private readonly IMongoCollection<DeliveryItem> _delivery;

        public DeliveryService(IDeliveryDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _delivery = database.GetCollection<DeliveryItem>(settings.DeliveryCollectionName);
        }

        public List<DeliveryItem> Get() =>
            _delivery.Find(book => true).ToList();

        public DeliveryItem Get(string id) =>
            _delivery.Find<DeliveryItem>(book => book.Id == id).FirstOrDefault();

        public DeliveryItem Create(DeliveryItem book)
        {
            _delivery.InsertOne(book);
            return book;
        }

        public void Update(string id, DeliveryItem bookIn) =>
            _delivery.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(DeliveryItem bookIn) =>
            _delivery.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) =>
            _delivery.DeleteOne(book => book.Id == id);
    }
}
