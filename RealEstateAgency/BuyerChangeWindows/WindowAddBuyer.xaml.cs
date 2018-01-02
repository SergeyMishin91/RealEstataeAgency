using System;
using System.Windows;
using Model;
using Repository;
using DAL;

namespace RealEstateAgency.BuyerChangeWindows
{

    public partial class WindowAddBuyer : Window
    {
        Buyer _newBuyer = new Buyer();

        public WindowAddBuyer()
        {
            InitializeComponent();
            this.DataContext = _newBuyer;
        }

        private IBuyerRepository buyerRepository = new BuyerRepository();
        

        private void ButtonAddBuyer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(_newBuyer.Error))
                    return;


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
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
