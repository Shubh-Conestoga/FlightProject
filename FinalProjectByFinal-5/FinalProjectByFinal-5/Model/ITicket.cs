using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectByFinal_5.Model
{
    public interface ITicket
    {
        public string PersonName { get; set; }
        public string Passport { get; set; }
        public decimal Price { get; set; }
        public int Age { get; set; }
        public string Destination { get; set; }
        public string Date { get; set; }
        public string Creditcard { get; set; }

        public decimal GetTicketPrices(string destination);
    }
}
