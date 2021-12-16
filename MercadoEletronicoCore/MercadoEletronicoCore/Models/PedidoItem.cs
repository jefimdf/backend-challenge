using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using Newtonsoft.Json;

namespace MercadoEletronicoCore.Models
{
    public class PedidoItem
    {

        [Key]
        public Guid Id { get; set; }

        [JsonProperty("CodigoPedido")]
        public long CodigoPedido { get; set; }
        
        [JsonProperty("Descricao")]
        public string Descricao { get; set; }
        
        [JsonProperty("PrecoUnitario")]
        public double PrecoUnitario { get; set; }
        
        [JsonProperty("Quantidade")]
        public int Quantidade { get; set; }

    }
}
