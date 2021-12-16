using MercadoEletronicoCore.Context;
using MercadoEletronicoCore.Models;
using MercadoEletronicoCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoEletronicoCore.Repository
{
    public class PedidoItemRepository:IPedidoItemRepository
    {
        private readonly DatabaseContext _context;

        public PedidoItemRepository(DatabaseContext ctx)
        {
            _context = ctx;
        }


        public bool Delete(long codigoPedido)
        {
            var obj = this.GetById(codigoPedido);
            if (obj == null)
                return false;
            _context.Remove(obj);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<PedidoItem> Get()
        {
            return _context.PedidoItem.ToList();
        }

        public PedidoItem GetById(long codigoPedido)
        {
            return _context.PedidoItem.Where(p => p.CodigoPedido == codigoPedido).FirstOrDefault();
        }

        public PedidoItem Post(PedidoItem pedidoItem)
        {
            pedidoItem.Id = new Guid();
            _context.Add(pedidoItem);
            _context.SaveChanges();
            return pedidoItem;
        }

        public PedidoItem Put(long codigoPedido, PedidoItem pedidoItem)
        {
            var obj = this.GetById(codigoPedido);
            if (obj == null)
                return null;

            _context.Update(obj);
            _context.SaveChanges();
            return pedidoItem;
        }
    }
}
