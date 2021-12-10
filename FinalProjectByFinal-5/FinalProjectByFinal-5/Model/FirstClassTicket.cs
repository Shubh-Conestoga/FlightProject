using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectByFinal_5.Model
{
    public class FirstClassTicket:Ticket
    {
        public override decimal GetTicketPrices(string destination)
        {
            return base.GetTicketPrices(destination) * 3;
        }
    }
}
