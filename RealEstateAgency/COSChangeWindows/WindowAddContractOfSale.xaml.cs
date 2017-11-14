using System.Windows;
using Model;
using Repository;
using DAL;
using System.Windows.Controls;

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

        private void ButtonAddCOS_Click(object sender, RoutedEventArgs e)
        {
            int _idCounter = 1;
            foreach (ContractOfSale cos in cosRepository.GetAll())
            {
                _idCounter++;
            }

            NewContractOfSale.ContractOfSaleID = _idCounter++;
            //NewContractOfSale.ContractOfSaleDate = ;
            NewContractOfSale.ContractOfSaleOwner = ((ComboBoxItem)ComboBoxAddCOSOwner.SelectedItem).Content.ToString();
            NewContractOfSale.ContractOfSaleBuyer = TextBoxAddCOSBuyer.Text;
            NewContractOfSale.ContractOfSaleCost = double.Parse(TextBoxAddCOSCost.Text);

        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
