using NUnit.Framework;
using MercadoEletronicoCore.Controllers;
using MercadoEletronicoCore.Models;
using MercadoEletronicoCore.Services;
using MercadoEletronicoCore.Services.Implementations;
using MercadoEletronicoCore.Repository;
using MercadoEletronicoCore.Context;

using System;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MercadoEletronicoCore.ViewModels;

namespace MercadoEletronico.Test
{
    
    public class Tests
    {
        Mock<IPedidoItemRepository> _pedidoItemRepository;
        IPedidoItemService _pedidoService;
        PedidoItemController _pedidoItemController;

        [SetUp]
        public void Setup()
        {
            _pedidoItemRepository = new Mock<IPedidoItemRepository>();
            _pedidoService = new PedidoItemService(_pedidoItemRepository.Object);
            _pedidoItemController = new PedidoItemController(_pedidoService);
        }

        [Test]
        public void Post_Pedido()
        {

            var _objPedidoItem = new PedidoItem()
            {
                CodigoPedido = 123456,
                Descricao = "Item A",
                Id = new Guid(),
                PrecoUnitario = 10,
                Quantidade = 1
            };

            var result = _pedidoItemController.Post(_objPedidoItem);

            Assert.IsTrue(result != null);

        }

        [Test]
        public void Get_Pedido()
        {
            var result = _pedidoItemController.Get();

            Assert.IsTrue(result != null);
        }

        [Test]
        public void Get_Pedido_Id()
        {
            var result = _pedidoItemController.Get(123456);

            Assert.IsTrue(result != null);
        }

        [Test]
        public void AlteraStatus()
        {
            var _alteraStatus = new AlteraStatusViewModel()
            {
                ItensAprovados = 1,
                Pedido = 123456,
                Status = "APROVADO",
                ValorAprovado = 10
            };

            var result = _pedidoItemController.AlteraStatus(_alteraStatus);

            Assert.IsTrue(result != null);
        }

        [Test]
        public void Put_Pedido()
        {

            var _objPedidoItem = new PedidoItem()
            {
                CodigoPedido = 123456,
                Descricao = "Item B",
                Id = new Guid(),
                PrecoUnitario = 5,
                Quantidade = 2
            };

            var result = _pedidoItemController.Put(_objPedidoItem);

            Assert.IsTrue(result != null);
            
        }


        [Test]
        public void Delete_Pedido()
        {
            var result = _pedidoItemController.Delete(123456);

            Assert.IsTrue(result != null);
        }

    }
}