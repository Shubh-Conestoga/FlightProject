using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectByFinal_5.Model
{
    public class DestinationList:IEnumerable
    {
        private List<string> destinations= new List<string>();

        public List<string> Destinations { get => destinations; set => destinations = value; }

        public DestinationList()
        {
            destinations = new List<string>();
            destinations.Add("India");
            destinations.Add("Japan");
            destinations.Add("China");
            destinations.Add("Usa");
            destinations.Add("Russia");
            destinations.Add("Brazil");
        }

        public IEnumerator GetEnumerator()
        {
            return destinations.GetEnumerator();
        }
    }
}
