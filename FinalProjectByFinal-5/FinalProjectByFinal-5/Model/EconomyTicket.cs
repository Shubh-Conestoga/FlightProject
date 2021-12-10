using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectByFinal_5.Model
{
    public class EconomyTicket: Ticket
    {
        public override decimal GetTicketPrices(string destination)
        {
            return base.GetTicketPrices(destination) * 1;
        }
    }
}
