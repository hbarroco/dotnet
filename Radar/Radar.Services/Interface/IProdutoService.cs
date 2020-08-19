using System.Collections.Generic;
using Radar.Domain.Entities;

namespace Radar.Services.Interface
{
    public interface IProdutoService
    {
        List<Produto> GetAll();
    }
}