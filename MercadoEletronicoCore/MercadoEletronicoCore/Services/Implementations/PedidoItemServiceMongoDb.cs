using MercadoEletronicoCore.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoEletronicoCore.Services.Implementations
{
    public class PedidoItemServiceMongoDb : IPedidoItemServiceMongoDb
    {
        private readonly IMongoCollection<PedidoItemMongoDb> _pedidoItem;

        public PedidoItemServiceMongoDb(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _pedidoItem = database.GetCollection<PedidoItemMongoDb>(settings.BooksCollectionName);

        }




        public void Delete(long codigoPedido)
        {
            Task result = _pedidoItem.DeleteOneAsync(PedidoItem => PedidoItem.CodigoPedido == codigoPedido);
            result.Wait();

        }

        public Task<List<PedidoItemMongoDb>> Get()
        {
            Task<List<PedidoItemMongoDb>> result = _pedidoItem.Find(PedidoItem => true).ToListAsync();
            result.Wait();

            if (result.IsCompleted)
                return result;

            return null;
        }

        public Task<PedidoItemMongoDb> GetById(long codigoPedido)
        {
            Task<PedidoItemMongoDb> result = _pedidoItem.Find<PedidoItemMongoDb>(PedidoItem => PedidoItem.CodigoPedido == codigoPedido).FirstOrDefaultAsync();
            result.Wait();

            if (result.IsCompleted)
                return result;

            return null;
        }

        public PedidoItemMongoDb Post(PedidoItemMongoDb pedidoItem)
        {
            pedidoItem.Id = new Guid();

            Task result = _pedidoItem.InsertOneAsync(pedidoItem);
            result.Wait();

            if (result.IsCompleted)
                return pedidoItem;

            return null;
        }

        public PedidoItemMongoDb Put(long CodigoPedido, PedidoItemMongoDb pedidoItem)
        {
            Task result = _pedidoItem.ReplaceOneAsync(PedidoItem => PedidoItem.CodigoPedido == CodigoPedido, pedidoItem);
            result.Wait();

            if (result.IsCompleted)
                return pedidoItem;

            return null;
        }

    }
}
