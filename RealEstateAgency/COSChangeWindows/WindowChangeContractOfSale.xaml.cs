using DAL;
using Model;
using RealEstateAgency.BuyerChangeWindows;
using Repository;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace RealEstateAgency.COSChangeWindows
{
    /// <summary>
    /// Interaction logic for WindowChangeContractOfSale.xaml
    /// </summary>
    public partial class WindowChangeContractOfSale : Window
    {
        public WindowChangeContractOfSale(ContractOfSale contractOfSale)
        {
            InitializeComponent();
            GetData(contractOfSale);
        }

        private IContractOfSaleRepository cosRepository = new ContractOfSaleRepository();
        private int counterID;
        ContractOfSale updateContractOfSale = new ContractOfSale();

        private void GetData(ContractOfSale contractOfSale)
        {
            counterID = contractOfSale.ContractOfSaleID;
            TextBoxUpdateCOSNumber.Text = contractOfSale.ContractOfSaleNumber;
            DPUpdateCOSDate.Text = contractOfSale.ContractOfSaleDate.ToString();
            ComboBoxUpdateCOSOwner.SelectedItem = contractOfSale.ContractOfSaleOwner;
            ComboBoxUpdateCOSBuyer.SelectedItem = contractOfSale.ContractOfSaleBuyer;
            TextBoxUpdateCOSCost.Text = contractOfSale.ContractOfSaleCost.ToString();
            ComboBoxUpdateCOSEstateInventoryNumber.SelectedItem = contractOfSale.ContractOfSaleEstateInventoryNumber;
        }

        private void ButtonUpdateCOS_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                updateContractOfSale.ContractOfSaleID = counterID;
                updateContractOfSale.ContractOfSaleNumber = TextBoxUpdateCOSNumber.Text;
                updateContractOfSale.ContractOfSaleDate = DateTime.Parse(DPUpdateCOSDate.Text);
                updateContractOfSale.ContractOfSaleOwner = ComboBoxUpdateCOSOwner.SelectedItem.ToString().Trim();
                updateContractOfSale.ContractOfSaleBuyer = ComboBoxUpdateCOSBuyer.SelectedItem.ToString().Trim();
                updateContractOfSale.ContractOfSaleCost = double.Parse(TextBoxUpdateCOSCost.Text);
                updateContractOfSale.ContractOfSaleEstateInventoryNumber = ComboBoxUpdateCOSEstateInventoryNumber.SelectedItem.ToString().Trim();

                cosRepository.UpdateContractOfSale(updateContractOfSale);

                MessageBox.Show("Данные изменены.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message);
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        protected void ComboBoxUpdateCOSOwner_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> _ownerNamesList = new List<string>();

            foreach (Owner owner in new OwnerRepository().GetAll())
                _ownerNamesList.Add(owner.OwnerName.Trim());

            ComboBoxUpdateCOSOwner.ItemsSource = _ownerNamesList;

        }

        private void ComboBoxUpdateCOSBuyer_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> _buyerNamesList = new List<string>();

            foreach (Buyer buyer in new BuyerRepository().GetAll())
                _buyerNamesList.Add(buyer.BuyerName.Trim());

            ComboBoxUpdateCOSBuyer.ItemsSource = _buyerNamesList;
        }

        private void ComboBoxUpdateCOSEstateInventoryNumber_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> _ownerEstateInventoryNumberList = new List<string>();

            foreach (Estate estate in new EstateRepository().GetAll())
                _ownerEstateInventoryNumberList.Add(estate.EstateInventoryNumber.Trim());

            ComboBoxUpdateCOSEstateInventoryNumber.ItemsSource = _ownerEstateInventoryNumberList;
        }
    }
}
