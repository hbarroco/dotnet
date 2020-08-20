using System.Collections.Generic;
using Radar.Services.Interface;
using Radar.Domain.Entities;
using Radar.Data.Interface;

namespace Radar.Services.Implementation
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoData produtoData;

        public ProdutoService(IProdutoData produtoData)
        {
            this.produtoData = produtoData;
        }

        public List<Produto> GetAll()
        {
            var produtos = new List<Produto>();

            // for (int i = 0; i < 10; i++)
            // {
            //     produtos.Add(new Produto { Id = i + 1, Name = "Produto" + (i + 1).ToString() });
            // }

            produtos = produtoData.GetAll();

            return produtos;
        }
    }
}