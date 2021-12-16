using MercadoEletronicoCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoEletronicoCore.Services
{
    public interface IPedidoItemServiceMongoDb
    {
        PedidoItemMongoDb Post(PedidoItemMongoDb pedidoItem);
        Task<PedidoItemMongoDb> GetById(long codigoPedido);
        Task<List<PedidoItemMongoDb>> Get();
        PedidoItemMongoDb Put(long CodigoPedido, PedidoItemMongoDb pedidoItem);
        void Delete(long codigoPedido);
    }
}
