using Repository;
using DAL;
using Model;
using System.Windows;
using System.Windows.Controls;

namespace RealEstateAgency
{

    public partial class WindowChangeEstate : Window
    {
        private IEstatesRepository estateRepository = new EstateRepository();

        private int counterID;

        public WindowChangeEstate(Estate estate)
        {
            InitializeComponent();
            GetData(estate);
        }

        Estate _updateEstate = new Estate();

        private void GetData(Estate estate)
        {
            counterID = estate.EstateID; 
            ComboBoxChangeEstateName.SelectedItem = estate.EstateName;
            TextBoxChangeEstateInventoryNumber.Text = estate.EstateInventoryNumber;
            TextBoxChangeEstateSpace.Text = estate.EstateSpace.ToString();
            TextBoxChangeEstateAdress.Text = estate.EstateAdress;
            TextBoxChangeEstateFunction.Text = estate.EstateFunction;
            TextBoxChangeEstateYear.Text = estate.EstateYear.ToString();
            TextBoxChangeEstateWall.Text = estate.EstateWall;
            TextBoxChangeEstateOwner.Text = estate.EstateOwner;
            TextBoxChangeEstateCostOfSale.Text = estate.EstateCostOfSale.ToString();
            TextBoxChangeEstateDescription.Text = estate.EstateDescription;
        }

        private void ButtonUpdateEstate_Click(object sender, RoutedEventArgs e)
        {
            _updateEstate.EstateID = counterID;
            _updateEstate.EstateName = ((ComboBoxItem)ComboBoxChangeEstateName.SelectedItem).Content.ToString();
            _updateEstate.EstateInventoryNumber = TextBoxChangeEstateInventoryNumber.Text;
            _updateEstate.EstateSpace = double.Parse(TextBoxChangeEstateSpace.Text);
            _updateEstate.EstateAdress = TextBoxChangeEstateAdress.Text;
            _updateEstate.EstateFunction = TextBoxChangeEstateFunction.Text;
            _updateEstate.EstateYear = int.Parse(TextBoxChangeEstateYear.Text);
            _updateEstate.EstateWall = TextBoxChangeEstateWall.Text;
            _updateEstate.EstateState = "Не продан";
            _updateEstate.EstateOwner = TextBoxChangeEstateOwner.Text;
            _updateEstate.EstateCostOfSale = double.Parse(TextBoxChangeEstateCostOfSale.Text);
            _updateEstate.EstateDescription = TextBoxChangeEstateDescription.Text;

            estateRepository.UpdateEstate(_updateEstate);
            MessageBox.Show("Изменения внесены.");
            this.Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
