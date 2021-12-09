using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FinalProjectByFinal_5.Model
{
    public class Person
    {
        private string name;
        private int age;
        private string passport;
        private string concealedCreditCard;
        private string creditcard;
        private string nationality;
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Passport { get => passport; set => passport = value; }
        public string ConcealedCreditCard { get => $"{creditcard.Substring(0, 4)}XXXXXXXX{ creditcard.Substring(11, 4)}"; }
        public string Creditcard { get => creditcard; set => creditcard = value; }

        public string Nationality { get => nationality; set => nationality = value; }



    }
}
