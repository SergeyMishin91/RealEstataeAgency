using System.Windows;
using Model;
using Repository;
using DAL;
using System.Windows.Controls;
using System;
using RealEstateAgency.BuyerChangeWindows;

namespace RealEstateAgency.COSChangeWindows
{
    /// <summary>
    /// Interaction logic for WindowAddContractOfSale.xaml
    ///
    /// </summary>
    public partial class WindowAddContractOfSale : Window
    {
        public WindowAddContractOfSale()
        {
            InitializeComponent();
            
        }

        private IContractOfSaleRepository cosRepository = new ContractOfSaleRepository();

        ContractOfSale NewContractOfSale = new ContractOfSale();
        WindowAddBuyer winAddBuyer = new WindowAddBuyer();

        private void ButtonAddCOS_Click(object sender, RoutedEventArgs e)
        {
            int _idCounter = 1;
            foreach (ContractOfSale cos in cosRepository.GetAll())
            {
                _idCounter++;
            }

            NewContractOfSale.ContractOfSaleID = _idCounter++;
            NewContractOfSale.ContractOfSaleDate = DateTime.Parse(TextBoxAddCOSDate.Text);
            NewContractOfSale.ContractOfSaleOwner = ((ComboBoxItem)ComboBoxAddCOSOwner.SelectedItem).Content.ToString();
            NewContractOfSale.ContractOfSaleBuyer = TextBoxAddCOSBuyer.Text;
            NewContractOfSale.ContractOfSaleCost = double.Parse(TextBoxAddCOSCost.Text);
            foreach (Owner owner in new OwnerRepository().GetAll())
                if (NewContractOfSale.ContractOfSaleOwner == owner.OwnerName)
                    NewContractOfSale.EstateOwnerID = owner.EstateID;
            foreach (Buyer buyer in new BuyerRepository().GetAll())
            {
                if (NewContractOfSale.ContractOfSaleBuyer == buyer.EstateBuyerName)
                    NewContractOfSale.EstateBuyerID = buyer.EstateBuyerID;
                else winAddBuyer.ShowDialog();
            }
            
            cosRepository.AddContractOfSale(NewContractOfSale);
            MessageBox.Show("Данные добавлены.");
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
