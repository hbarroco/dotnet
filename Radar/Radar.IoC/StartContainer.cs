using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Radar.Services.Interface;
using Radar.Services.Implementation;
using Radar.Data.Interface;
using Radar.Data.Implementation;

namespace Radar.IoC
{
    public static class StartContainer
    {
        public static void Start(IServiceCollection services)
        {
            //EF Context
            //services.AddSingleton<IHBVendasOnlineContextFactory, HBVendasOnlineContextFactory>();

            //Services
            services.AddSingleton<IProdutoService, ProdutoService>();

            //Data
            services.AddSingleton<IProdutoData, ProdutoData>();
        }
    }
}