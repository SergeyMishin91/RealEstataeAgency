using System;
using System.Windows;
using Model;
using Repository;
using DAL;

namespace RealEstateAgency.BuyerChangeWindows
{

    public partial class WindowAddBuyer : Window
    {
        public WindowAddBuyer()
        {
            InitializeComponent();
        }

        private IBuyerRepository buyerRepository = new BuyerRepository();
        Buyer _newBuyer = new Buyer();

        private void ButtonAddBuyer_Click(object sender, RoutedEventArgs e)
        {
            int _idCounter = 1;
            foreach (Buyer buyer in buyerRepository.GetAll())
            {
                _idCounter++;
            }

            _newBuyer.BuyerID = _idCounter++;
            _newBuyer.BuyerName = TextBoxAddBuyerName.Text;
            _newBuyer.BuyerAdress = TextBoxAddBuyerAdress.Text; 
            _newBuyer.BuyerUNP = Int32.Parse(TextBoxAddBuyerUNP.Text);
            _newBuyer.BuyerPhone = TextBoxAddBuyerPhone.Text;
            _newBuyer.BuyerRequest = TextBoxAddBuyerRequest.Text;
        
            buyerRepository.AddBuyer(_newBuyer);
            MessageBox.Show("Данные добавлены.");
            this.Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
