using HB.Sorte.Online.ConsoleTest.TypeBets;
using HB.Sorte.Online.Data.Implementations;
using HB.Sorte.Online.Data.Interfaces;
using HB.Sorte.Online.Services.Implementations;
using HB.Sorte.Online.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Data.SqlClient;


namespace HB.Sorte.Online.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = IoCInject();

            Console.WriteLine("START - Apostas Online - \n ");

            var historyLotoFacilService = serviceProvider.GetService<IHistoryLotoFacilService>();
            historyLotoFacilService.Add(new Domain.Entities.HistoryLotoFacil());

            BetTwentyDozensInSixGames.PrintBetTwentyDozensInSixGames(new List<int> { 2, 3, 5, 6, 7, 10, 11, 12, 14, 17, 19, 20, 21, 24, 25 });

            Console.WriteLine("FINISH - Apostas Online - ");

            Console.ReadLine();
        }

        public static void X()
        {

        }

        public static ServiceProvider IoCInject()
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .Build();

            string dbConnectionString = configuration.GetConnectionString("dbConnection");

            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IHistoryLotoFacilService, HistoryLotoFacilService>()
                .AddSingleton<IHistoryLotoFacilRepository, HistoryLotoFacilRespository>()
                .AddTransient<IDbConnection>((sp) => new SqlConnection(dbConnectionString))
                .BuildServiceProvider();

            //configure console logging
            serviceProvider
                .GetService<ILoggerFactory>();

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            return serviceProvider;
        }
    }
}