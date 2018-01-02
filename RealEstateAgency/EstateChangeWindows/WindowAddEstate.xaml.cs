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
        Estate _newEstate = new Estate();

        public WindowAddEstate()
        {
            InitializeComponent();
            this.DataContext = _newEstate;
        }

        private IEstatesRepository estateRepository = new EstateRepository();
        

        private void ButtonAddEstate_Click(object sender, RoutedEventArgs e)
        {

            bool beOwner = true;
            int oldOwnerId = 0;
            try
            {
                if (!string.IsNullOrWhiteSpace(_newEstate.Error))
                    return;
                int idCounter = 1;
                foreach (Estate _estate in estateRepository.GetAll())
                {
                    idCounter++;
                }

                _newEstate.EstateID = idCounter++;
                _newEstate.EstateName = ((ComboBoxItem)ComboBoxAddEstateName.SelectedItem).Content.ToString();
                _newEstate.EstateInventoryNumber = TextBoxAddEstateInventoryNumber.Text;
                _newEstate.EstateSpace = double.Parse(TextBoxAddEstateSpace.Text);
                _newEstate.EstateAdress = TextBoxAddEstateAdress.Text;
                _newEstate.EstateFunction = ((ComboBoxItem)ComboBoxAddEstateFunction.SelectedItem).Content.ToString();
                _newEstate.EstateYear = int.Parse(TextBoxAddEstateYear.Text);
                _newEstate.EstateWall = TextBoxAddEstateWall.Text;
                _newEstate.EstateState = "Не продан";
                _newEstate.EstateOwner = ComboBoxAddEstateOwner.Text;
                _newEstate.EstateCostOfSale = double.Parse(TextBoxAddEstateSale.Text);
                _newEstate.EstateDescription = TextBoxAddEstateDescription.Text;
                foreach (Owner owner in new OwnerRepository().GetAll())
                {
                    if (_newEstate.EstateOwner.Trim() == owner.OwnerName.Trim())
                    {
                        oldOwnerId = owner.OwnerID;
                        beOwner = true;
                        break;
                    }
                    else
                        beOwner = false;                    
                }

                if (beOwner == false)
                {
                    WindowAddOwner winAddOwner = new WindowAddOwner(_newEstate.EstateOwner);
                    winAddOwner.ShowDialog();
                    foreach (Owner newOwner in new OwnerRepository().GetAll())
                        _newEstate.EstateOwnerID = newOwner.OwnerID;
                    
                }
                else
                    _newEstate.EstateOwnerID = oldOwnerId;

                estateRepository.AddEstate(_newEstate);

                MessageBox.Show("Данные добавлены.");
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

        private void ComboBoxAddEstateOwner_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> _ownerNamesList = new List<string>();

            foreach (Owner owner in new OwnerRepository().GetAll())
                _ownerNamesList.Add(owner.OwnerName.Trim());

            ComboBoxAddEstateOwner.ItemsSource = _ownerNamesList;
        }
    }
}
