﻿using MercadoEletronicoCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoEletronicoCore.Services
{
    public interface IPedidoItemService
    {
        PedidoItem Post(PedidoItem pedidoItem);
        PedidoItem GetById(long codigoPedido);
        IEnumerable<PedidoItem> Get();
        PedidoItem Put(long CodigoPedido, PedidoItem pedidoItem);
        bool Delete(long codigoPedido);
    }
}
