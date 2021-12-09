using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectByFinal_5.Model
{
    public class Ticket : ITicket
    {
        private string personName;
        private string passport;
        private decimal price;
        private string destination;
        private int age;
        private string date;
        private string creditcard;

        public string PersonName { get => personName; set => personName = value; }
        public string Passport { get => passport; set => passport = value; }
        public decimal Price { get => price; set => price = value; }
        public string Destination { get => destination; set => destination = value; }
        public int Age { get => age; set => age = value; }
        public string Date { get => date; set => date = value; }
        public string Creditcard { get => creditcard; set => creditcard = value; }

        public virtual decimal GetTicketPrices(string destination)
        {
            throw new NotImplementedException();
        }
    }
}
