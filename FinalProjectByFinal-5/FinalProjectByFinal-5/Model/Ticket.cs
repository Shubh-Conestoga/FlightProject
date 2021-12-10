using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
        private string concealedCreditCard;
        private bool freeMeal;
        private bool wheelChair;
        private bool freeReturns;


        public string PersonName { get => personName; set => personName = value; }
        public string Passport { get => passport; set => passport = value; }
        public decimal Price { get => price; set => price = value; }
        public string Destination { get => destination; set => destination = value; }
        public int Age { get => age; set => age = value; }
        public string Date { get => date; set => date = value; }
        public string Creditcard { get => creditcard; set => creditcard = value; }
        [XmlIgnore]
        public string ConcealedCreditCard { get => $"{creditcard.Substring(0,4)}XXXXXXXX{creditcard.Substring(12,4)}"; }
        public bool FreeMeal { get => freeMeal; set => freeMeal = value; }
        public bool WheelChair { get => wheelChair; set => wheelChair = value; }
        public bool FreeReturns { get => freeReturns; set => freeReturns = value; }

        public virtual decimal GetTicketPrices(string destination)
        {
            return 0m;
        }
    }
}
