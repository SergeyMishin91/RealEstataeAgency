using System.Windows;
using System.Windows.Controls;
using Model;
using DAL;
using Repository;
using System.Collections.Generic;
using RealEstateAgency.OwnerChangeWindows;

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
            _newEstate.EstateState = "Не продан";
            _newEstate.EstateOwner = TextBoxAddEstateOwner.Text;
            _newEstate.EstateCostOfSale = double.Parse(TextBoxAddEstateSale.Text);
            _newEstate.EstateDescription = TextBoxAddEstateDescription.Text;
            foreach (Owner owner in new OwnerRepository().GetAll())
            {
                if (_newEstate.EstateOwner == owner.OwnerName.Trim())
                    _newEstate.EstateOwnerID = owner.OwnerID;
                else
                {
                    WindowAddOwner winAddOwner = new WindowAddOwner(_newEstate.EstateOwner);
                    winAddOwner.ShowDialog();
                }

            }

            estateRepository.AddEstate(_newEstate);

            MessageBox.Show("Данные добавлены.");
            this.Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //private void ComboBoxAddEstateOwner_Loaded(object sender, RoutedEventArgs e)
        //{
        //    List<string> _ownerNamesList = new List<string>();

        //    foreach (Owner owner in new OwnerRepository().GetAll())
        //        _ownerNamesList.Add(owner.OwnerName);

        //    ComboBoxAddEstateOwner.ItemsSource = _ownerNamesList;
        //}
    }
}
