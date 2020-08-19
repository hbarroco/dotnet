using System.Collections.Generic;
using Radar.Services.Interface;
using Radar.Domain.Entities;

namespace Radar.Services.Implementation
{
    public class ProdutoService : IProdutoService
    {
        public List<Produto> GetAll()
        {
            var produtos = new List<Produto>();

            for (int i = 0; i < 10; i++)
            {
                produtos.Add(new Produto { Id = i + 1, Name = "Produto" + (i + 1).ToString() });
            }

            return produtos;
        }
    }
}