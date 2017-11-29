using System.Windows;
using Repository;
using DAL;
using Model;

namespace RealEstateAgency.BuyerChangeWindows
{
    /// <summary>
    /// Interaction logic for WindowChangeBuyer.xaml
    /// </summary>
    public partial class WindowChangeBuyer : Window
    {
        private IBuyerRepository buyerRepository = new BuyerRepository();

        private int counterID;

        public WindowChangeBuyer(Buyer buyer)
        {
            InitializeComponent();
            GetData(buyer);
        }

        Buyer _updateBuyer = new Buyer();

        private void GetData(Buyer buyer)
        {
            counterID = buyer.BuyerID;
            TextBoxChangeBuyerName.Text = buyer.BuyerName;
            TextBoxChangeBuyerAdress.Text = buyer.BuyerAdress;
            TextBoxChangeBuyerUNP.Text = buyer.BuyerUNP.ToString();
            TextBoxChangeBuyerPhone.Text = buyer.BuyerPhone;
            TextBoxChangeBuyerRequest.Text = buyer.BuyerRequest;
        }

        private void ButtonChangeBuyer_Click(object sender, RoutedEventArgs e)
        {
            _updateBuyer.BuyerID = counterID;
            _updateBuyer.BuyerName = TextBoxChangeBuyerName.Text;
            _updateBuyer.BuyerAdress = TextBoxChangeBuyerAdress.Text;
            _updateBuyer.BuyerUNP = int.Parse(TextBoxChangeBuyerUNP.Text);
            _updateBuyer.BuyerPhone = TextBoxChangeBuyerPhone.Text;
            _updateBuyer.BuyerRequest = TextBoxChangeBuyerRequest.Text;

            buyerRepository.UpdateBuyer(_updateBuyer);
            MessageBox.Show("Изменения внесены.");
            this.Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
