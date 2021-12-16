using MercadoEletronicoCore.Context;
using MercadoEletronicoCore.Models;
using MercadoEletronicoCore.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoEletronicoCore.Services.Implementations
{
    public class PedidoItemService:IPedidoItemService
    {
        private readonly IPedidoItemRepository _pedidoItem;

        public PedidoItemService(IPedidoItemRepository pedidoItem)
        {
            _pedidoItem = pedidoItem;
        }


        public bool Delete(long codigoPedido)
        {
            return _pedidoItem.Delete(codigoPedido);
        }

        public IEnumerable<PedidoItem> Get()
        {
            return _pedidoItem.Get();
        }

        public PedidoItem GetById(long codigoPedido)
        {
            return _pedidoItem.GetById(codigoPedido);
        }

        public PedidoItem Post(PedidoItem pedidoItem)
        {
            return _pedidoItem.Post(pedidoItem);            
        }

        public PedidoItem Put(long codigoPedido, PedidoItem pedidoItem)
        {
            return _pedidoItem.Put(codigoPedido, pedidoItem);            
        }
               
    }
}
