using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoEletronicoCore.ViewModels
{
    public class RetornoStatusViewModel
    {
        public long Pedido { get; set; }
        public List<Status> ArrStatus { get; set; }

    }

    public class Status
    {
        public string status { get; set; }
    }
}
