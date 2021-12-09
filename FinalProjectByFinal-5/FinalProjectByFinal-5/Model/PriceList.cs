using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectByFinal_5.Model
{
    class PriceList
    {
        private static PriceList priceList=null;
        private Dictionary<string, decimal> ticketPriceList;

        public PriceList()
        {
            decimal price=0.01m;
            DestinationList destinationList = new DestinationList();
            foreach(string destination in destinationList)
            {
                ticketPriceList.Add(destination.ToLower().Trim(),price*4500);
                price += 0.01m;
            }
        }

        public PriceList GetPriceList()
        {
            return priceList;
        }

        public decimal GetPriceOfDestination(string destination)
        {
            string processedKey = destination.Trim().ToLower();
            if (ticketPriceList.ContainsKey(processedKey))
            {
                return ticketPriceList[processedKey];
            }
            else 
            {
                return -1m;
            }
        }
    }
}
