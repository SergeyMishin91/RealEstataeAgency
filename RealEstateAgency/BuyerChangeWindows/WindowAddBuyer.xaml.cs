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

            _newBuyer.EstateBuyerID = _idCounter++;
            _newBuyer.EstateBuyerName = TextBoxAddBuyerName.Text;
            _newBuyer.EstateBuyerAdress = TextBoxAddBuyerAdress.Text; 
            _newBuyer.EstateBuyerUNP = Int32.Parse(TextBoxAddBuyerUNP.Text);
            _newBuyer.EstateBuyerPhone = TextBoxAddBuyerPhone.Text;
            _newBuyer.EstateBuyerRequest = TextBoxAddBuyerRequest.Text;
            foreach (ContractOfSale cos in new ContractOfSaleRepository().GetAll())
            {
                if (cos.ContractOfSaleID == 0)
                    _newBuyer.ContractOfSaleID = 0;
                if (cos.ContractOfSaleID > 0)
                {
                    int currID = 0;
                    foreach (ContractOfSale cosTwo in new ContractOfSaleRepository().GetAll())
                        currID++;
                    _newBuyer.ContractOfSaleID = currID;
                }
            }
        
            buyerRepository.AddBuyer(_newBuyer);
            MessageBox.Show("Данные добавлены.");
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
