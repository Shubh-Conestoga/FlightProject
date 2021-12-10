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
    /// 

    enum TicketClass { 
        EconomyClass,
        BusinessClass,
        FirstClass
    }
    public partial class MainWindow : Window
    {
        //List for storing data in xml file
        private TicketList bookings = null;
        private ObservableCollection<Ticket> bookingsObservable = null;
        private List<string> availableDates = null;
        private List<string> destinations = null;
        private PriceList priceList = null;


        //creating property of bookingsObservable
        public ObservableCollection<Ticket> BookingsObservable { get => bookingsObservable; set => bookingsObservable = value; }
        public List<string> AvailableDates { get => availableDates; set => availableDates = value; }
        public List<string> Destinations { get => destinations; set => destinations = value; }

        public MainWindow()
        {
            InitializeComponent();

            //initializing the bookingsObservable object
            bookingsObservable = new ObservableCollection<Ticket>();

            //initializing priceList
            priceList = new PriceList();

            //initializing the Ticketlist object
            bookings = new TicketList();

            //initializing available dates list and adding dates 
            //Showing this combo by setting item source in this file
            //showing first availabel selected by default
            availableDates = new List<string>();
            FillAvailabelDates();
            SetAvailableDateToFirst();

            //destination lists initializing and populating
            //showing this combo box using item source binding from Xaml file
            //showing first destination selected by default
            destinations = new List<string>();
            FillDestinations();
            listDestination.ItemsSource = Destinations;
            radioFirstClass.IsChecked = true;
            listDestination.SelectedIndex = 0;

            //Reading Data from file
            if (File.Exists("bookings.xml"))
            {
                TicketList bookedTickets = GetDataFromXML();
                foreach (Ticket ticket in bookedTickets.Tickets)
                {
                   availableDates.Remove(ticket.Date);
                }
            }

            //setting datacontext
            DataContext = this;

        }

        //writing data to xml file
        void WriteDataToXML()
        {
            bookings.Clear();
            foreach (Ticket bookingToSave in bookingsObservable)
            {
                bookings.Add(bookingToSave);
            }
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
            foreach (Ticket ticket in bookingDtlsFromFile.Tickets)
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
            destinations.Add("Usa");
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
            //else
            //{
            //    btnSubmit.Visibility = Visibility.Hidden;
            //}
        }

        private void destinationChanged(object sender, SelectionChangedEventArgs e)
        {
            SetFlightPrice(radioEconomyClass.IsChecked.Value,radioBusinessClass.IsChecked.Value,radioFirstClass.IsChecked.Value,listDestination.SelectedValue.ToString());
        }

        void SetFlightPrice(bool isEconomyclass,bool isBussinessclass,bool isFirstclass,string destination)
        {
            decimal price = priceList.GetPriceOfDestination(destination);
            if (isBussinessclass)
            {
                price = price * 2;
            }
            else if (isFirstclass)
            {
                price = price * 3;
            }
            else
            {
                price = price * 1;
            }
            txtPrices.Text = price.ToString();
        }

        private void firstClassSelected(object sender, RoutedEventArgs e)
        {
            if (listDestination.SelectedIndex != -1)
            {
                SetFlightPrice(false, false, true, listDestination.Text);
            }
            else
            {
                SetFlightPrice(false, false, true, destinations[0]);
            }
        }

        private void economyClassSelected(object sender, RoutedEventArgs e)
        {
            if (listDestination.SelectedIndex != -1)
            {
                SetFlightPrice(true, false, false, listDestination.Text);
            }
            else
            {
                SetFlightPrice(true, false, false, destinations[0]);
            }
        }

        private void businessClassSelected(object sender, RoutedEventArgs e)
        {
            if (listDestination.SelectedIndex != -1)
            {
                SetFlightPrice(false, true, false, listDestination.Text);
            }
            else
            {
                SetFlightPrice(false, true, false, destinations[0]);
            }
        }

        private void btnSubmitClicked(object sender, RoutedEventArgs e)
        {
            int age = 0;
            long creditCard = 0;
            if ((listDates.SelectedIndex >= 0) && (listDestination.SelectedIndex >= 0) && (txtPersonName.Text.Trim().Length > 0) && (txtPassport.Text.Trim().Length == 6) && (txtCreditCard.Text.Trim().Length == 16) && (int.TryParse(txtAge.Text.Trim(), out age)) && (long.TryParse(txtCreditCard.Text.Trim(), out creditCard)))
            {
                Ticket ticket = null;
                if (radioBusinessClass.IsChecked.Value)
                {
                    ticket = new BusinessTicket();
                }
                else if (radioEconomyClass.IsChecked.Value)
                {
                    ticket = new EconomyTicket();
                }
                else
                {
                    ticket = new FirstClassTicket();
                }

                ticket.PersonName = txtPersonName.Text;
                ticket.Passport = txtPassport.Text;
                ticket.Destination = listDestination.Text;
                ticket.Date = listDates.Text;

                ticket.Age = int.Parse(txtAge.Text);
                ticket.Creditcard = txtCreditCard.Text;
                ticket.Price = decimal.Parse(txtPrices.Text);

                if (chkFreemeal.IsChecked.Value)
                {
                    ticket.FreeMeal = true;
                }
                else
                {
                    ticket.FreeMeal = false;
                }
                if (chkReturn.IsChecked.Value)
                {
                    ticket.FreeReturns = true;
                }
                else
                {
                    ticket.FreeReturns = false;
                }
                if (chkwhlchair.IsChecked.Value)
                {
                    ticket.WheelChair = true;
                }
                else
                {
                    ticket.WheelChair = false;
                }

                bookingsObservable.Add(ticket);

                WriteDataToXML();
                availableDates.Remove(listDates.Text);
                listDates.Items.Refresh();

                ClearField();
            }
        }

        void ClearField()
        {
            txtPersonName.Text = "";
            txtPassport.Text = "";
            txtAge.Text = "";
            txtCreditCard.Text = "";
            listDestination.SelectedIndex = 0;
            chkwhlchair.IsChecked = false;
            chkReturn.IsChecked = false;
            chkFreemeal.IsChecked = false;
            radioFirstClass.IsChecked = true;
            radioEconomyClass.IsChecked = false;
            radioBusinessClass.IsChecked = false;
            SetAvailableDateToFirst();
        }

        private void searchBtnClicked(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                myDataGrid.ItemsSource = bookingsObservable;
            }
            else
            {
                SearchDataByDestination(txtSearch.Text);
            }
        }

        void SearchDataByDestination(string destinationSearchTxt)
        {
            string searchText = $"{destinationSearchTxt[0].ToString().ToUpper()}{destinationSearchTxt.Substring(1).ToLower()}";
            var data = from booking in bookingsObservable
                       where booking.Destination == searchText
                       select booking;
            myDataGrid.ItemsSource = data;
        }

        private void displayBtnClicked(object sender, RoutedEventArgs e)
        {
            ReadeDataFromXML();
            myDataGrid.ItemsSource = bookingsObservable;
        }
    }

   
}
