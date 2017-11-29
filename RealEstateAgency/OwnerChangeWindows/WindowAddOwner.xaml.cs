using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Windows;
using Model;
using Repository;
using DAL;

namespace RealEstateAgency.OwnerChangeWindows
{
    /// <summary>
    /// Interaction logic for WindowAddOwner.xaml
    /// </summary>
    public partial class WindowAddOwner : Window
    {
        public WindowAddOwner()
        {
            InitializeComponent();
        }

        public WindowAddOwner(string ownerName)
        {
            InitializeComponent();
            this.ownerName = ownerName;
        }

        private IOwnerRepository ownerRepository = new OwnerRepository();
        Owner _newOwner = new Owner();
        private string ownerName;

        private void ButtonAddOwner_Click(object sender, RoutedEventArgs e)
        {
            int _idCounter = 1;
            foreach (Owner owner in ownerRepository.GetAll())
            {
                _idCounter++;
            }

            _newOwner.OwnerID = _idCounter++;
            if (ownerName != null)
            {
                _newOwner.OwnerName = ownerName;
            }
            else    
                _newOwner.OwnerName = TextBoxAddOwnerName.Text;
            _newOwner.OwnerAdress = TextBoxAddOwnerAdress.Text;
            _newOwner.OwnerUNP = Int32.Parse(TextBoxAddOwnerUNP.Text);
            _newOwner.OwnerPhone = TextBoxAddOwnerPhone.Text;

            ownerRepository.AddOwner(_newOwner);
            MessageBox.Show("Данные добавлены.");
            this.Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBoxAddOwnerName_Loaded(object sender, RoutedEventArgs e)
        {
            TextBoxAddOwnerName.Text = ownerName;
        }
    }
}
