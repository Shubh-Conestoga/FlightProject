using FinalProjectByFinal_5.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace FinalProjectByFinal_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //List for storing data in xml file
        private TicketList bookings = null;
        private ObservableCollection<Ticket> bookingsObservable = null;
        private List<string> availableDates = null;
        private List<string> destinations = null;

        //creating property of bookingsObservable
        public ObservableCollection<Ticket> BookingsObservable { get => bookingsObservable; set => bookingsObservable = value; }
        public List<string> AvailableDates { get => availableDates; set => availableDates = value; }
        public List<string> Destinations { get => destinations; set => destinations = value; }

        public MainWindow()
        {
            InitializeComponent();

            //setting datacontext
            DataContext = this;

            //initializing the bookingsObservable object
            bookingsObservable = new ObservableCollection<Ticket>();

            //initializing the Ticketlist object
            bookings = new TicketList();

            //initializing available dates list and adding dates 
            //Showing this combo by setting item source in this file
            //showing first availabel selected by default
            availableDates = new List<string>();
            FillAvailabelDates();
            listDates.ItemsSource = AvailableDates;
            SetAvailableDateToFirst();

            //destination lists initializing and populating
            //showing this combo box using item source binding from Xaml file
            //showing first destination selected by default
            destinations = new List<string>();
            FillDestinations();
            listDestination.SelectedIndex = 0;

            //Reading Data from file
            if (File.Exists("bookings.xml"))
            {
                TicketList bookedTickets = GetDataFromXML();
                foreach (Ticket ticket in bookedTickets)
                {
                    availableDates.Remove(ticket.Date);
                }
                SetAvailableDateToFirst();
            }


        }

        //writing data to xml file
        void WtiteDataToXML()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TicketList));
            TextWriter textWriter = new StreamWriter("bookings.xml");
            xmlSerializer.Serialize(textWriter, bookings);
        }

        void ReadeDataFromXML()
        {
            //Getting data from XML File
            TicketList bookingDtlsFromFile = GetDataFromXML();
            //Crearing the records from observable collection to remove data from datagrid
            bookingsObservable.Clear();
            //adding data of bookingDtlsFromFile to observable collection to show data in datagrid
            foreach (Ticket ticket in bookingDtlsFromFile)
            {
                bookingsObservable.Add(ticket);
            }
        }

        //Rrturning deserialized data of TicketList from file
        TicketList GetDataFromXML()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TicketList));
            TextReader textReader = new StreamReader("bookings.xml");
            return (TicketList)xmlSerializer.Deserialize(textReader);
        }

        void FillAvailabelDates()
        {
            string monthDate = "/12/2021";
            string date = string.Empty;
            for (int i=1;i<=31;i++)
            {
                date = $"{i}{monthDate}";
                AvailableDates.Add(date);
            }
        }

        void FillDestinations()
        {
            destinations.Add("India");
            destinations.Add("Japan");
            destinations.Add("China");
            destinations.Add("USA");
            destinations.Add("Russia");
            destinations.Add("Brazil");
        }
        void SetAvailableDateToFirst()
        {
            //if ticket availabel on then user can fill the form else submit button will be hidden
            if (listDates.Items.Count > 0)
            {
                listDates.SelectedItem = listDates.Items[0];
            }
            else
            {
                btnSubmit.Visibility = Visibility.Hidden;
            }
        }
    }

   
}
