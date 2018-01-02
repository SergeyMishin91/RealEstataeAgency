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
        ContractOfSale _newContractOfSale = new ContractOfSale();

        public WindowAddContractOfSale()
        {
            InitializeComponent();
            this.DataContext = _newContractOfSale;
        }

        private IContractOfSaleRepository cosRepository = new ContractOfSaleRepository();
        private IEstatesRepository estateRepository = new EstateRepository();


        WindowAddBuyer winAddBuyer = new WindowAddBuyer();


        private void ButtonAddCOS_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(_newContractOfSale.Error))
                    return;

                bool beBuyer = true;
                int _idCounter = 1;
                foreach (ContractOfSale cos in cosRepository.GetAll())
                {
                    _idCounter++;
                }

                _newContractOfSale.ContractOfSaleID = _idCounter++;
                _newContractOfSale.ContractOfSaleNumber = TextBoxAddCOSNumber.Text;
                _newContractOfSale.ContractOfSaleDate = DateTime.Parse(DPAddCOSDate.Text);
                _newContractOfSale.ContractOfSaleOwner = ComboBoxAddCOSOwner.SelectedItem.ToString().Trim();
                _newContractOfSale.ContractOfSaleBuyer = ComboBoxAddCOSBuyer.Text.Trim();

                _newContractOfSale.ContractOfSaleCost = double.Parse(TextBoxAddCOSCost.Text);
                _newContractOfSale.ContractOfSaleEstateInventoryNumber = ComboBoxAddCOSEstateInventoryNumber.SelectedItem.ToString().Trim();

                foreach (Buyer buyer in new BuyerRepository().GetAll())
                {
                    if (_newContractOfSale.ContractOfSaleBuyer.Trim() == buyer.BuyerName.Trim())
                    {
                        beBuyer = true;
                        _newContractOfSale.ContractOfSaleBuyerID = buyer.BuyerID;
                        break;
                    }
                    else
                        beBuyer = false; 
                }

                if (beBuyer == false)
                    winAddBuyer.ShowDialog();

                foreach (Estate estate in new EstateRepository().GetAll())
                    if (_newContractOfSale.ContractOfSaleEstateInventoryNumber.Trim() == estate.EstateInventoryNumber.Trim())
                    {
                        _newContractOfSale.ContractOfSaleEstateID = estate.EstateID;
                        estate.EstateState = "Продан";
                        estateRepository.UpdateEstate(estate);
                        break;
                    }

                cosRepository.AddContractOfSale(_newContractOfSale);
            
                MessageBox.Show("Данные добавлены.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        protected void ComboBoxAddCOSOwner_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> _ownerNamesList = new List<string>();

            foreach (Estate estate in new EstateRepository().GetAll())
            {
                if (estate.EstateState.Trim() == "Не продан")
                {
                    foreach (Owner owner in new OwnerRepository().GetAll())
                        if (estate.EstateOwnerID == owner.OwnerID && !_ownerNamesList.Contains(owner.OwnerName.Trim()))
                        {
                            _ownerNamesList.Add(owner.OwnerName.Trim());
                            break;
                        }
                }
            }
            ComboBoxAddCOSOwner.ItemsSource = _ownerNamesList;
        }

        private void ComboBoxAddCOSBuyer_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> _buyerNamesList = new List<string>();

            foreach (Buyer buyer in new BuyerRepository().GetAll())
                _buyerNamesList.Add(buyer.BuyerName.Trim());

            ComboBoxAddCOSBuyer.ItemsSource = _buyerNamesList;
        }

        private void ComboBoxAddCOSEstateInventoryNumber_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> _ownerEstateInventoryNumberList = new List<string>();

            foreach (Estate estate in new EstateRepository().GetAll())
                if (estate.EstateState.Trim() == "Не продан")
                    _ownerEstateInventoryNumberList.Add(estate.EstateInventoryNumber.Trim());
            
            ComboBoxAddCOSEstateInventoryNumber.ItemsSource = _ownerEstateInventoryNumberList;
        }
    }
}
