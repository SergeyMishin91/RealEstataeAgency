using System.Windows;
using Model;
using Repository;
using DAL;
using System;
using RealEstateAgency.BuyerChangeWindows;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
            NewContractOfSale.ContractOfSaleNumber = TextBoxAddCOSNumber.Text;
            NewContractOfSale.ContractOfSaleDate = DateTime.Parse(DPAddCOSDate.Text);
            NewContractOfSale.ContractOfSaleOwner = ComboBoxAddCOSOwner.SelectedItem.ToString(); 
            NewContractOfSale.ContractOfSaleBuyer = ComboBoxAddCOSBuyer.SelectedItem.ToString();
            NewContractOfSale.ContractOfSaleCost = double.Parse(TextBoxAddCOSCost.Text);
            NewContractOfSale.ContractOfSaleEstateInventoryNumber = ComboBoxAddCOSEstateInventoryNumber.SelectedItem.ToString();
            //foreach (Owner owner in new OwnerRepository().GetAll())
            //    if (NewContractOfSale.ContractOfSaleOwner == owner.OwnerName)
            //        NewContractOfSale.ContractOfSaleOwnerID = owner.OwnerID;

            foreach (Buyer buyer in new BuyerRepository().GetAll())
            {
                if (NewContractOfSale.ContractOfSaleBuyer == buyer.BuyerName)
                    NewContractOfSale.ContractOfSaleBuyerID = buyer.BuyerID;
                else winAddBuyer.ShowDialog();
            }

            foreach (Estate estate in new EstateRepository().GetAll())
                if (NewContractOfSale.ContractOfSaleEstateInventoryNumber == estate.EstateInventoryNumber)
                    NewContractOfSale.ContractOfSaleEstateID = estate.EstateID;
            
            cosRepository.AddContractOfSale(NewContractOfSale);
            MessageBox.Show("Данные добавлены.");
            this.Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        protected void ComboBoxAddCOSOwner_Loaded(object sender, RoutedEventArgs e)
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
                _buyerNamesList.Add(buyer.BuyerName);

            ComboBoxAddCOSBuyer.ItemsSource = _buyerNamesList;
        }

        private void ComboBoxAddCOSEstateInventoryNumber_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> _ownerEstateInventoryNumberList = new List<string>();

            foreach (Estate estate in new EstateRepository().GetAll())
                _ownerEstateInventoryNumberList.Add(estate.EstateInventoryNumber);
            
            ComboBoxAddCOSEstateInventoryNumber.ItemsSource = _ownerEstateInventoryNumberList;
        }
    }
}
