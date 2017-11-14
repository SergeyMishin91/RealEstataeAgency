using DAL;
using Model;
using RealEstateAgency.COSChangeWindows;
using Repository;
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
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace RealEstateAgency
{
    public partial class MainWindow : Window
    {
        
        private IEstatesRepository estateRepository;
        private IOwnerRepository ownerRepository;
        private IBuyerRepository buyerRepository;
        private IContractOfSaleRepository contractOfSaleRepository;

        public MainWindow()
        {
            InitializeComponent();
            UpdateSelectedEstate();
            UpdateSelectedOwner();
            UpdateSelectedBuyer();
            UpdateSelectedContractOfSale();
        }

        #region ActionsWithEstate

        private void UpdateSelectedEstate()
        {
            estateRepository = new EstateRepository();
            estateSense.Items.Clear();
            foreach (Estate estate in estateRepository.GetAll())
            {
                estateSense.Items.Add(estate);
            }

        }

        private void addEstate_Click(object sender, RoutedEventArgs e)
        {
            WindowAddEstate winAddEstate = new WindowAddEstate();
            winAddEstate.ShowDialog();

            UpdateSelectedEstate();
        }

        private void changeEstate_Click(object sender, RoutedEventArgs e)
        {
            if (estateSense.SelectedItem is Estate)
            {
                WindowChangeEstate winChangeEstate = new WindowChangeEstate((Estate)estateSense.SelectedItem);
                winChangeEstate.ShowDialog();

                UpdateSelectedEstate();
            }
            else
                MessageBox.Show("Объект не выбран. Выберите объект для внесения изменений.");
        }

        private void deleteEstate_Click(object sender, RoutedEventArgs e)
        {
            if (estateSense.SelectedItem is Estate)
            {
                estateRepository.DeleteEstate((Estate)estateSense.SelectedItem);
                UpdateSelectedEstate();
            }
            else
                MessageBox.Show("Объект не выбран. Выберите объект для внесения изменений.");
        }

        private void estateSense_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Estate selectedEstate = estateSense.SelectedItem as Estate;

            if (selectedEstate != null)
            {
                estateDescription.Content =
                    $"Наименование: {selectedEstate.EstateName} \n" +
                    $"Инвентраный номер: {selectedEstate.EstateInventoryNumber} \n" +
                    $"Общая площадь: {selectedEstate.EstateSpace} \n" +
                    $"Местонахождение: {selectedEstate.EstateAdress} \n" +
                    $"Назначение: {selectedEstate.EstateFunction} \n" +
                    $"Год постройки: {selectedEstate.EstateYear} \n" +
                    $"Материал стен: {selectedEstate.EstateWall} \n" +
                    $"Состояние: {selectedEstate.EstateState} \n" +
                    $"Собственник: {selectedEstate.EstateOwner} \n" +
                    $"Покупатель: {selectedEstate.EstateBuyer} \n" +
                    $"Договор: {selectedEstate.EstateContractNumber} \n" +
                    $"Цена продажи: {selectedEstate.EstateCostOfSale} бел.руб.\n" +
                    $"Краткое описание: {selectedEstate.EstateDescription}";
            }
        }

        #endregion

        #region ActionsWithContractOfSale
        private void UpdateSelectedContractOfSale()
        {
            contractOfSaleRepository = new ContractOfSaleRepository();
            contractOfSaleSense.Items.Clear();
            foreach (ContractOfSale cos in contractOfSaleRepository.GetAll())
            {
                contractOfSaleSense.Items.Add(cos);
            }
        }

        private void addContractOfSale_Click(object sender, RoutedEventArgs e)
        {
            WindowAddContractOfSale winAddCOS = new WindowAddContractOfSale();
            winAddCOS.ShowDialog();

            UpdateSelectedEstate();
        }
        #endregion




        private void UpdateSelectedOwner()
        {
            ownerRepository = new OwnerRepository();
            showOwner.Items.Clear();
            foreach (Owner owner in ownerRepository.GetAll())
            {
                showOwner.Items.Add(owner);
            }
        }

        private void UpdateSelectedBuyer()
        {
            buyerRepository = new BuyerRepository();
            showBuyer.Items.Clear();
            foreach (Buyer buyer in buyerRepository.GetAll())
            {
                showBuyer.Items.Add(buyer);
            }
        }

        private void FileExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Estates_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Clients_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Treaties_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
