using MtgApiManager.Lib.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_Card_Fetcher
{
    class Program
    {
        static IMtgServiceProvider service = new MtgServiceProvider();
        static ICardService cardService = service.GetCardService();

        public static void Main()
        {
            var res = getCardName("shock");
            Console.WriteLine(res);
            Console.WriteLine("Complete");
        }

        private static async Task<List<string>> getCardName(string cardname)
        {
            //return await cardService.Where(x => x.Name == "Shock")
                                                //.AllAsync();

            var result = await cardService.GetCardTypesAsync();
            return (List<string>)result;
        }

    }
}
