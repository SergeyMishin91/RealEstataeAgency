using System.Windows;
using System.Windows.Controls;
using Model;
using DAL;
using Repository;

namespace RealEstateAgency
{
    public partial class WindowAddEstate : Window
    {
        public WindowAddEstate()
        {
            InitializeComponent();
        }

        private IEstatesRepository estateRepository = new EstateRepository();
        
        Estate _newEstate = new Estate();

        private void ButtonAddEstate_Click(object sender, RoutedEventArgs e)
        {
            int idCounter=1;
            foreach (Estate _estate in estateRepository.GetAll())
            {
                idCounter++;
            }

            _newEstate.EstateID = idCounter++;
            _newEstate.EstateName = ((ComboBoxItem)ComboBoxAddEstateName.SelectedItem).Content.ToString();
            _newEstate.EstateInventoryNumber = TextBoxAddEstateInventoryNumber.Text;
            _newEstate.EstateSpace = double.Parse(TextBoxAddEstateSpace.Text);
            _newEstate.EstateAdress = TextBoxAddEstateAdress.Text;
            _newEstate.EstateFunction = TextBoxAddEstateFunction.Text;
            _newEstate.EstateYear = int.Parse(TextBoxAddEstateYear.Text);
            _newEstate.EstateWall = TextBoxAddEstateWall.Text;
            _newEstate.EstateState = "не продан";
            _newEstate.EstateOwner = TextBoxAddEstateOwner.Text;
            _newEstate.EstateCostOfSale = double.Parse(null);
            _newEstate.EstateDescription = TextBoxAddEstateDescription.Text;
            _newEstate.EstateBuyer = "";
            _newEstate.EstateContractNumber = TextBoxAddEstateOwner.Text;

            estateRepository.AddEstate(_newEstate);

            MessageBox.Show("Данные добавлены.");
            this.Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
