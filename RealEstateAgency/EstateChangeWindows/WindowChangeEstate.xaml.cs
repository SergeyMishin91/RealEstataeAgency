using Repository;
using DAL;
using Model;
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
            ComboBoxChangeEstateState.Text = estate.EstateState;
            TextBoxChangeEstateOwner.Text = estate.EstateOwner;
            TextBoxChangeEstateBuyer.Text = estate.EstateBuyer.ToString();
            TextBoxChangeEstateCostOfSale.Text = estate.EstateCostOfSale.ToString();
            TextBoxChangeEstateContract.Text = estate.EstateContractNumber;
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
            _updateEstate.EstateState = ComboBoxChangeEstateState.Text;
            _updateEstate.EstateOwner = TextBoxChangeEstateOwner.Text;
            _updateEstate.EstateBuyer = TextBoxChangeEstateBuyer.Text;
            _updateEstate.EstateCostOfSale = double.Parse(TextBoxChangeEstateCostOfSale.Text);
            _updateEstate.EstateDescription = TextBoxChangeEstateDescription.Text;
            _updateEstate.EstateContractNumber = TextBoxChangeEstateContract.Text;

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
