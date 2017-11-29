using DAL;
using Model;
using RealEstateAgency.BuyerChangeWindows;
using RealEstateAgency.COSChangeWindows;
using RealEstateAgency.OwnerChangeWindows;
using Repository;
using System.Windows;
using System.Windows.Controls;

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
                    $"Продан/не продан: {selectedEstate.EstateState} \n" +
                    $"Собственник: {selectedEstate.EstateOwner} \n" +
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

            UpdateSelectedContractOfSale();
        }
        #endregion

        #region Actions with Owner
        private void UpdateSelectedOwner()
        {
            ownerRepository = new OwnerRepository();
            showOwner.Items.Clear();
            foreach (Owner owner in ownerRepository.GetAll())
            {
                showOwner.Items.Add(owner);
            }
        }

        private void changeOwner_Click(object sender, RoutedEventArgs e)
        {
            if (showOwner.SelectedItem is Owner)
            {
                WindowChangeOwner winChangeOwner = new WindowChangeOwner((Owner)showOwner.SelectedItem);
                winChangeOwner.ShowDialog();

                UpdateSelectedOwner();
            }
            else
                MessageBox.Show("Объект не выбран. Выберите объект для внесения изменений.");
        }


        #endregion

        #region Actions with Buyer
        private void UpdateSelectedBuyer()
        {
            buyerRepository = new BuyerRepository();
            showBuyer.Items.Clear();
            foreach (Buyer buyer in buyerRepository.GetAll())
            {
                showBuyer.Items.Add(buyer);
            }
        }

        private void addBuyer_Click(object sender, RoutedEventArgs e)
        {
            WindowAddBuyer winAddBuyer = new WindowAddBuyer();
            winAddBuyer.ShowDialog();

            UpdateSelectedBuyer();
        }

        private void changeBuyer_Click(object sender, RoutedEventArgs e)
        {
            if (showBuyer.SelectedItem is Buyer)
            {
                WindowChangeBuyer winChangeBuyer = new WindowChangeBuyer((Buyer)showBuyer.SelectedItem);
                winChangeBuyer.ShowDialog();

                UpdateSelectedBuyer();
            }
            else
                MessageBox.Show("Объект не выбран. Выберите объект для внесения изменений.");

        }

        private void deleteBuyer_Click(object sender, RoutedEventArgs e)
        {
            if (showBuyer.SelectedItem is Buyer)
            {
                buyerRepository.DeleteBuyer((Buyer)showBuyer.SelectedItem);
                UpdateSelectedBuyer();
            }
            else
                MessageBox.Show("Объект не выбран. Выберите объект для внесения изменений.");
        }
        #endregion

        #region Menu Options
        private void FileExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Estates_Click(object sender, RoutedEventArgs e)
        {
            allOptionsTC.SelectedItem = TabItemEstates;
        }

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            allOptionsTC.SelectedItem = TabItemClients;
        }

        private void Treaties_Click(object sender, RoutedEventArgs e)
        {
            allOptionsTC.SelectedItem = TabItemTreaties;
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Курсовая работа. Выполнил слушатель группы 60322-1 Мишин С.И.");
        }
        #endregion

    }
}
