using HB.Vendas.Online.Data;
using HB.Vendas.Online.Data.EFContexts;
using HB.Vendas.Online.Data.Implementation;
using HB.Vendas.Online.Data.Interfaces;
using HB.Vendas.Online.Services.Implementation;
using HB.Vendas.Online.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.Vendas.Online.IoC
{
    public static class StartContainer
    {
        public static void Start(IServiceCollection services)
        {
            //EF Context
            services.AddSingleton<IHBVendasOnlineContextFactory, HBVendasOnlineContextFactory>();

            //Data
            services.AddSingleton<ISampleData, SampleData>();
            
            //Services
            services.AddSingleton<ISampleService, SampleService>();
            services.AddSingleton<ISampleData2, SampleData2>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IStoreService, StoreService>();
        }
    }
}
