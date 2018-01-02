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
        private int estateOwnerID;
        Estate _updateEstate = new Estate();

        public WindowChangeEstate(Estate estate)
        {
            InitializeComponent();
            GetData(estate);
        }

        

        private void GetData(Estate estate)
        {
            counterID = estate.EstateID;
            estateOwnerID = estate.EstateOwnerID;
            ComboBoxChangeEstateName.Text = estate.EstateName.Trim();
            TextBoxChangeEstateInventoryNumber.Text = estate.EstateInventoryNumber.Trim();
            TextBoxChangeEstateSpace.Text = estate.EstateSpace.ToString();
            TextBoxChangeEstateAdress.Text = estate.EstateAdress.Trim();
            ComboBoxChangeEstateFunction.Text = estate.EstateFunction.Trim();
            TextBoxChangeEstateYear.Text = estate.EstateYear.ToString();
            TextBoxChangeEstateWall.Text = estate.EstateWall.Trim();
            TextBoxChangeEstateOwner.Text = estate.EstateOwner.Trim();
            TextBoxChangeEstateCostOfSale.Text = estate.EstateCostOfSale.ToString();
            TextBoxChangeEstateDescription.Text = estate.EstateDescription.Trim();
        }

        private void ButtonUpdateEstate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _updateEstate.EstateID = counterID;
                _updateEstate.EstateOwnerID = estateOwnerID;
                _updateEstate.EstateName = ((ComboBoxItem)ComboBoxChangeEstateName.SelectedItem).Content.ToString();
                _updateEstate.EstateInventoryNumber = TextBoxChangeEstateInventoryNumber.Text;
                _updateEstate.EstateSpace = double.Parse(TextBoxChangeEstateSpace.Text);
                _updateEstate.EstateAdress = TextBoxChangeEstateAdress.Text;
                _updateEstate.EstateFunction = ((ComboBoxItem)ComboBoxChangeEstateFunction.SelectedItem).Content.ToString();
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
