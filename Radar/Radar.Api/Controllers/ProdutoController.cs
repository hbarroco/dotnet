using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Radar.Services.Interface;
using Radar.Domain.Entities;
using AutoMapper;

namespace Radar.Api.Controllers
{
    [ApiController]
    [Route("api/produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService produtoService;
        private readonly IMapper mapper;

        public ProdutoController(IProdutoService produtoService, IMapper mapper)
        {
            this.produtoService = produtoService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ProdutoDTO> Get()
        {
            var produtosDomain = produtoService.GetAll();

            var produtosDTO = mapper.Map<List<ProdutoDTO>>(produtosDomain);

            return produtosDTO;
        }
    }
}
