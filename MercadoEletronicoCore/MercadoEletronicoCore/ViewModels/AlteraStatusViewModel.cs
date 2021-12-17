using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoEletronicoCore.ViewModels
{
    public class AlteraStatusViewModel
    {
        public string Status { get; set; }
        public int ItensAprovados { get; set; }
        public double ValorAprovado { get; set; }
        public long Pedido { get; set; }
    }
}
