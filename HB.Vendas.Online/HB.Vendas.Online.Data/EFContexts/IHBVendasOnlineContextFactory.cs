using System;
using System.Collections.Generic;
using System.Text;

namespace HB.Vendas.Online.Data.EFContexts
{
    public interface IHBVendasOnlineContextFactory
    {
        HBVendasOnlineContext Create();
    }
}
