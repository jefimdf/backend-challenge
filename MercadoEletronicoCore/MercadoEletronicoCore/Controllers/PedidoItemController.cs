using MercadoEletronicoCore.Models;
using MercadoEletronicoCore.Services;
using MercadoEletronicoCore.Services.Implementations;
using MercadoEletronicoCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoEletronicoCore.Controllers
{
    [Route("pedidoItem")]
    [ApiController]
    public class PedidoItemController : ApiControllerBase
    {
        private readonly IPedidoItemService _pedidoItemService;

        public PedidoItemController(IPedidoItemService pedidoItemService)
        {
            _pedidoItemService = pedidoItemService;
        }

        /// <summary>
        /// Altera Status do Pedido
        /// </summary>
        /// <param name="alteraStatus"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AlteraStatus")]
        public IActionResult AlteraStatus([FromBody] AlteraStatusViewModel alteraStatus)
        {

            try
            {

                RetornoStatusViewModel retorno = new RetornoStatusViewModel();
                retorno.Pedido = alteraStatus.Pedido;
                List<Status> ArrStatus = new List<Status>();

                var consulta = _pedidoItemService.Get().Where(p => p.CodigoPedido == alteraStatus.Pedido);

                if (consulta.Any())
                {
                    var itensAprovados = consulta.Sum(p => p.Quantidade);
                    var valorAprovado = consulta.Sum(p => p.PrecoUnitario) * itensAprovados;


                    if (alteraStatus.Status == "REPROVADO")
                    {
                        ArrStatus.Add(new Status() { status= "REPROVADO" });                        
                    }
                    else if (alteraStatus.Status == "APROVADO")
                    {

                        if (itensAprovados == alteraStatus.ItensAprovados && valorAprovado == alteraStatus.ValorAprovado)
                        {
                            ArrStatus.Add(new Status() { status = "APROVADO" });
                        }

                        if (valorAprovado > alteraStatus.ValorAprovado)
                        {
                            ArrStatus.Add(new Status() { status = "APROVADO_VALOR_A_MENOR" });
                        }

                        if (valorAprovado < alteraStatus.ValorAprovado)
                        {
                            ArrStatus.Add(new Status() { status = "APROVADO_VALOR_A_MAIOR" });
                        }

                        if (itensAprovados > alteraStatus.ItensAprovados)
                        {
                            ArrStatus.Add(new Status() { status = "APROVADO_QTD_A_MENOR" });
                        }

                        if (itensAprovados < alteraStatus.ItensAprovados)
                        {
                            ArrStatus.Add(new Status() { status = "APROVADO_QTD_A_MAIOR" });
                        }

                    }

                }
                else
                {
                    ArrStatus.Add(new Status() { status = "CODIGO_PEDIDO_INVALIDO" });
                }


                retorno.ArrStatus = ArrStatus;

                return Response(retorno);


            }catch(Exception ex)
            {
                return (IActionResult)ex;
            }

        }

        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get() =>
            Response(_pedidoItemService.Get());

        /// <summary>
        /// Get id
        /// </summary>
        /// <param name="codigoPedido"></param>
        /// <returns></returns>
        [HttpGet("{codigoPedido:long}")]
        public IActionResult Get(long codigoPedido)
        {
            var obj = _pedidoItemService.GetById(codigoPedido);

            if (obj == null)
            {
                return NotFound();
            }

            return Response(obj);
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="pedidoItem"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] PedidoItem pedidoItem)
        {
            try
            {
                _pedidoItemService.Post(pedidoItem);

                return Response(pedidoItem);
            }
            catch(Exception ex)
            {
                return (IActionResult)ex;
            }
            
            
        }

        /// <summary>
        /// Put
        /// </summary>
        /// <param name="pedidoItem"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] PedidoItem pedidoItem)
        {
            var obj = _pedidoItemService.GetById(pedidoItem.CodigoPedido);

            if (obj == null)
            {
                return NotFound();
            }

            _pedidoItemService.Put(pedidoItem.CodigoPedido, pedidoItem);

            return NoContent();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="codigoPedido"></param>
        /// <returns></returns>
        [HttpDelete("{codigoPedido:long}")]
        public IActionResult Delete(long codigoPedido)
        {
            var obj = _pedidoItemService.GetById(codigoPedido);

            if (obj == null)
            {
                return NotFound();
            }

            _pedidoItemService.Delete(codigoPedido);

            return NoContent();
        }
    }
}
