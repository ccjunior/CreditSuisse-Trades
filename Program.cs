using CreditSuisse_Trade.Business;
using CreditSuisse_Trade.Business.Interfaces;
using CreditSuisse_Trade.Data.Entities;
using CreditSuisse_Trade.Data.Validate;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace CreditSuisse_Trade
{
    class Program
    {
        private static string date = "";
        private static INegotiationService _negociateService;
        static void Main(string[] args)
        {

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
             _negociateService = serviceProvider.GetService<INegotiationService>();
             _negociateService = serviceProvider.GetService<INegotiationService>();

            Console.WriteLine("CreditSuisse Trades");
            Console.WriteLine("------------------------");
            QuestionOne();
            Console.ReadKey();
            Console.Clear();

        }

        private static void QuestionOne()
        {

            List<string> Output = new List<string>();
            var InitTrades = 1;
            Negotiation negotiation;

            Console.Write("Informe a Data de Referencia (mm/dd/yyyy): ");
            date = Console.ReadLine();
            var dateValidate = Date.Validation(date);
            
            while (!dateValidate)
            {
                Console.Write("Data invalida. Favor informar uma data correta: ");
                date = Console.ReadLine();
                dateValidate = Date.Validation(date);
            }

            var dateReference = DateTime.Parse(date);
           


            Console.Write("Informe o numero de negocios: ");
            var Trades = int.Parse(Numeric.InputValidate());
            Console.WriteLine("");

            while (InitTrades <= Trades)
            {
              
                Console.Write("Informe a descrição da negociação: ");
                negotiation = new Negotiation(dateReference, Console.ReadLine());
                Output.Add(_negociateService.GetCategory(negotiation));
                InitTrades++;
            }
            
            Console.WriteLine("");
            Console.WriteLine("------------------------");
            Console.WriteLine("Saída:");
            foreach (var item in Output)
            {
                Console.WriteLine($"{item}");
            }

            Console.ReadKey();

        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<INegotiationService, NegotiationService>();
        }
    }
}
