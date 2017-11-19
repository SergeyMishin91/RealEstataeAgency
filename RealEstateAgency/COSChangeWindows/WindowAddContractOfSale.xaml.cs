using System.Windows;
using Model;
using Repository;
using DAL;
using System;
using RealEstateAgency.BuyerChangeWindows;
using System.Collections.Generic;

namespace RealEstateAgency.COSChangeWindows
{

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
            NewContractOfSale.ContractOfSaleDate = DateTime.Parse(DPAddCOSDate.Text);
            NewContractOfSale.ContractOfSaleOwner = ComboBoxAddCOSOwner.SelectedItem.ToString(); //((ComboBoxItem)ComboBoxAddCOSOwner.SelectedItem).Content.ToString();
            NewContractOfSale.ContractOfSaleBuyer = ComboBoxAddCOSBuyer.SelectedItem.ToString();
            NewContractOfSale.ContractOfSaleCost = double.Parse(TextBoxAddCOSCost.Text);
            foreach (Owner owner in new OwnerRepository().GetAll())
                if (NewContractOfSale.ContractOfSaleOwner == owner.OwnerName)
                    NewContractOfSale.ContractOfSaleOwnerID = owner.OwnerID;
            foreach (Buyer buyer in new BuyerRepository().GetAll())
            {
                if (NewContractOfSale.ContractOfSaleBuyer == buyer.EstateBuyerName)
                    NewContractOfSale.ContractOfSaleBuyerID = buyer.EstateBuyerID;
                else winAddBuyer.ShowDialog();
            }
            
            cosRepository.AddContractOfSale(NewContractOfSale);
            MessageBox.Show("Данные добавлены.");
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBoxAddCOSOwner_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> _ownerNamesList = new List<string>();

            foreach (Owner owner in new OwnerRepository().GetAll())
                _ownerNamesList.Add(owner.OwnerName);

            ComboBoxAddCOSOwner.ItemsSource = _ownerNamesList;
        }

        private void ComboBoxAddCOSBuyer_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> _buyerNamesList = new List<string>();

            foreach (Buyer buyer in new BuyerRepository().GetAll())
                _buyerNamesList.Add(buyer.EstateBuyerName);

            ComboBoxAddCOSBuyer.ItemsSource = _buyerNamesList;
        }
    }
}
