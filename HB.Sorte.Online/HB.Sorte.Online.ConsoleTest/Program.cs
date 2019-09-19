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
using HB.Sorte.Online.ConsoleTest.Utilities;
using HB.Sorte.Online.Domain.Entities;

namespace HB.Sorte.Online.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ExecuteIoCAndConfigs();

            var lastLotoFacil = new List<int> {1, 2, 3, 4, 5, 10, 11, 12, 13, 14, 16, 20, 21, 23, 25};

            #region Setup Dados LotoFacil
            //SetupHistoryLotoFacil(serviceProvider);
            #endregion

            #region Run Bet BetTwentyDozensInSixGames
            var betTwentyDozensInSixGames = new BetTwentyDozensInSixGames(serviceProvider, lastLotoFacil);
            betTwentyDozensInSixGames.Run();
            #endregion

            #region Run Bet BetFixedTableNineDozensGames
            var betFixedTableNineDozensGames = new BetFixedTableNineDozensGames(serviceProvider, lastLotoFacil);
            betFixedTableNineDozensGames.Run();
            #endregion

            Console.ReadLine();
        }

        public static void SetupHistoryLotoFacil(ServiceProvider serviceProvider)
        {
            var historyLotoFacilService = serviceProvider.GetService<IHistoryLotoFacilService>();
            var listHistoryLotoFacil = Utility.ReadLatestBetsFromFile();
            historyLotoFacilService.LoadHistory(listHistoryLotoFacil);
        }

        #region Configs Methods
        private static ServiceProvider ExecuteIoCAndConfigs()
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .Build();

            var dbConnectionString = configuration.GetConnectionString("dbConnection");

            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IHistoryLotoFacilService, HistoryLotoFacilService>()
                .AddSingleton<IHistoryLotoFacilRepository, HistoryLotoFacilRespository>()
                .AddSingleton<IFixedTableNineDozensRepository, FixedTableNineDozensRepository>()
                .AddSingleton<IFixedTableNineDozensService, FixedTableNineDozensService>()
                .AddSingleton<IRankingLotoFacilService, RankingLotoFacilService>()
                .AddTransient<IDbConnection>((sp) => new SqlConnection(dbConnectionString))
                .Configure<HBConfiguration>(x => { x.ConnectionString = dbConnectionString; })
                .BuildServiceProvider();

            //configure console logging
            serviceProvider
                .GetService<ILoggerFactory>();

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            return serviceProvider;
        }
        #endregion
    }
}