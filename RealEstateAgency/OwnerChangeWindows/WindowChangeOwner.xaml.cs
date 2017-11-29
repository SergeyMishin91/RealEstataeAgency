using System.Windows;
using Repository;
using DAL;
using Model;

namespace RealEstateAgency.OwnerChangeWindows
{
    /// <summary>
    /// Interaction logic for WindowChangeOwner.xaml
    /// </summary>
    public partial class WindowChangeOwner : Window
    {
        private IOwnerRepository ownerRepository = new OwnerRepository();

        private int counterID;

        public WindowChangeOwner(Owner owner)
        {
            InitializeComponent();
            GetData(owner);
        }

        Owner _updateOwner = new Owner();

        private void GetData(Owner owner)
        {
            counterID = owner.OwnerID;
            TextBoxChangeOwnerName.Text = owner.OwnerName;
            TextBoxChangeOwnerAdress.Text = owner.OwnerAdress;
            TextBoxChangeOwnerUNP.Text = owner.OwnerUNP.ToString();
            TextBoxChangeOwnerPhone.Text = owner.OwnerPhone;
        }

        private void ButtonChangeOwner_Click(object sender, RoutedEventArgs e)
        {
            _updateOwner.OwnerID = counterID;
            _updateOwner.OwnerName = TextBoxChangeOwnerName.Text;
            _updateOwner.OwnerAdress = TextBoxChangeOwnerAdress.Text;
            _updateOwner.OwnerUNP = int.Parse(TextBoxChangeOwnerUNP.Text);
            _updateOwner.OwnerPhone = TextBoxChangeOwnerPhone.Text;


            ownerRepository.UpdateOwner(_updateOwner);
            MessageBox.Show("Изменения внесены.");
            this.Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
