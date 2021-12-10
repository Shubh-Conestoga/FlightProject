using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FinalProjectByFinal_5.Model
{
    //For saving data in xml file
    [XmlRoot("BookingList")]
    //to save data in xml file also of derived class of Ticket class
    [XmlInclude(typeof(EconomyTicket))]
    [XmlInclude(typeof(FirstClassTicket))]
    [XmlInclude(typeof(BusinessTicket))]
    public class TicketList 
    {
        private List<Ticket> tickets = null;

        //indexer
        public Ticket this[int i] { get => tickets[i]; set => tickets.Add(value); }

        public TicketList()
        {
            Tickets = new List<Ticket>();
        }

        //for saving data in xml file
        [XmlArray("Tickets")]
        [XmlArrayItem("Ticket")]
        public List<Ticket> Tickets { get => tickets; set => tickets = value; }
        //to add new booking
        public void Add(Ticket ticket)
        {
            tickets.Add(ticket);
        }
        //to delete booking
        public void Delete(Ticket ticket)
        {
            tickets.Remove(ticket);
        }
        public void Clear()
        {
            tickets.Clear();
        }
    }
}
