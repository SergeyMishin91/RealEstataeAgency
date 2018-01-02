using DAL;
using Model;
using RealEstateAgency.BuyerChangeWindows;
using RealEstateAgency.COSChangeWindows;
using RealEstateAgency.Graphs;
using RealEstateAgency.OwnerChangeWindows;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

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

            UpdateSelectedOwner();
            UpdateSelectedEstate();
        }

        private void changeEstate_Click(object sender, RoutedEventArgs e)
        {
            if (estateSense.SelectedItem is Estate)
            {
                WindowChangeEstate winChangeEstate = new WindowChangeEstate((Estate)estateSense.SelectedItem);
                winChangeEstate.ShowDialog();

                UpdateSelectedOwner();
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
                estateDescription.Text =
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

            UpdateSelectedEstate();
            UpdateSelectedContractOfSale();
            UpdateSelectedBuyer();
        }

        private void changeContractOfSale_Click(object sender, RoutedEventArgs e)
        {
            if (contractOfSaleSense.SelectedItem is ContractOfSale)
            {
                WindowChangeContractOfSale winChangeCOS = new WindowChangeContractOfSale((ContractOfSale)contractOfSaleSense.SelectedItem);
                winChangeCOS.ShowDialog();

                UpdateSelectedContractOfSale();
                UpdateSelectedOwner();
                UpdateSelectedBuyer();
                UpdateSelectedEstate();
            }
            else
                MessageBox.Show("Объект не выбран. Выберите объект для внесения изменений.");
        }

        private void deleteContractOfSale_Click(object sender, RoutedEventArgs e)
        {
            if (contractOfSaleSense.SelectedItem is ContractOfSale)
            {
                contractOfSaleRepository.DeleteContractOfSale((ContractOfSale)contractOfSaleSense.SelectedItem);
                UpdateSelectedContractOfSale();
            }
            else
                MessageBox.Show("Объект не выбран. Выберите объект для внесения изменений.");
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

        private void deleteOwner_Click(object sender, RoutedEventArgs e)
        {
            if (showOwner.SelectedItem is Owner)
            {
                ownerRepository.DeleteOwner((Owner)showOwner.SelectedItem);
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

        #region Graphs
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            GraphEstateRegion win = new GraphEstateRegion();
            win.Show(); 
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region WorkWithXML
        private void WriteToXML_Click(object sender, RoutedEventArgs e)
        {
            XDocument doc = new XDocument();
            XElement root = new XElement("RealEstateAgencyXMLData");

            foreach (var buyer in new BuyerRepository().GetAll())
            {
                XElement buyerElement = new XElement("buyer",
                    new XElement("id", buyer.BuyerID),
                    new XElement("name", buyer.BuyerName.Trim()),
                    new XElement("adress", buyer.BuyerAdress.Trim()),
                    new XElement("unp", buyer.BuyerUNP),
                    new XElement("phone", buyer.BuyerPhone.Trim()),
                    new XElement("request", buyer.BuyerRequest.Trim()));
                root.Add(buyerElement);
            }

            //foreach (var owner in new OwnerRepository().GetAll())
            //{
            //    XElement ownerElement = new XElement("owner",
            //        new XElement("id", owner.OwnerID),
            //        new XElement("name", owner.OwnerName.Trim()),
            //        new XElement("adress", owner.OwnerAdress.Trim()),
            //        new XElement("unp", owner.OwnerUNP),
            //        new XElement("phone", owner.OwnerPhone.Trim()));
            //    root.Add(ownerElement);
            //}

            //foreach (var cos in new ContractOfSaleRepository().GetAll())
            //{
            //    XElement cosElement = new XElement("ContractOfSale",
            //        new XElement("cosId", cos.ContractOfSaleID),
            //        new XElement("cosEstateId", cos.ContractOfSaleEstateID),
            //        new XElement("cosBuyerId", cos.ContractOfSaleBuyerID),
            //        new XElement("cosNumber", cos.ContractOfSaleNumber),
            //        new XElement("cosDate", cos.ContractOfSaleDate),
            //        new XElement("cosOwner", cos.ContractOfSaleOwner.Trim()),
            //        new XElement("cosBuyer", cos.ContractOfSaleBuyer.Trim()),
            //        new XElement("cosCost", cos.ContractOfSaleCost),
            //        new XElement("cosInvNumber", cos.ContractOfSaleEstateInventoryNumber.Trim()));
            //    root.Add(cosElement);
            //}

            //foreach (var estate in new EstateRepository().GetAll())
            //{
            //    XElement estateElement = new XElement("Estate",
            //        new XElement("estateId", estate.EstateID),
            //        new XElement("estateId", estate.EstateOwnerID),
            //        new XElement("estateId", estate.EstateName.Trim()),
            //        new XElement("estateId", estate.EstateFunction.Trim()),
            //        new XElement("estateId", estate.EstateInventoryNumber.Trim()),
            //        new XElement("estateId", estate.EstateSpace),
            //        new XElement("estateId", estate.EstateAdress.Trim()),
            //        new XElement("estateId", estate.EstateYear),
            //        new XElement("estateId", estate.EstateWall.Trim()),
            //        new XElement("estateId", estate.EstateState.Trim()),
            //        new XElement("estateId", estate.EstateOwner.Trim()),
            //        new XElement("estateId", estate.EstateCostOfSale),
            //        new XElement("estateId", estate.EstateDescription.Trim()));

            //    root.Add(estateElement);
            //}

            doc.Add(root);
            doc.Save("Data.xml");
            MessageBox.Show("Данные сохранены в XML файл");
        }

        private void ReadFromXML_Click(object sender, RoutedEventArgs e)
        {
            List<Buyer> newBuyersList = new List<Buyer>();

            try
            {
                XDocument doc = XDocument.Load(@"e:\Обучение\переподготовка\ч.3\курсовая\Project WPF\RealEstataeAgency\RealEstateAgency\bin\Debug\Data.xml");
                var root = doc.Root;
                foreach (var element in root.Elements())
                {
                    var buyer = new Buyer();
                    buyer.BuyerID = int.Parse( element.Element("id").Value);
                    buyer.BuyerName = element.Element("name").Value;
                    buyer.BuyerAdress = element.Element("adress").Value;
                    buyer.BuyerUNP = int.Parse(element.Element("unp").Value);
                    buyer.BuyerPhone = element.Element("phone").Value;
                    buyer.BuyerRequest = element.Element("request").Value;

                    newBuyersList.Add(buyer);
                }

                IBuyerRepository buyerXMLRepository = new BuyerRepository();
                foreach (var buyerRepo in buyerXMLRepository.GetAll())
                {
                    buyerXMLRepository.DeleteBuyer(buyerRepo);
                }

                foreach (var buyerXML in newBuyersList)
                {
                    buyerXMLRepository.AddBuyer(buyerXML);
                }

                UpdateSelectedBuyer();
                MessageBox.Show("Данные  импортированы");

            }
            catch (Exception ex) { MessageBox.Show("Невозможно импортировать данные."); }
        }

        #endregion

        #region SortEstates
        private void SortCost_Selected(object sender, RoutedEventArgs e)
        {
            estateSense.Items.SortDescriptions.Clear();
            estateSense.Items.SortDescriptions.Add(new SortDescription("EstateCostOfSale", ListSortDirection.Ascending));
        }

        private void SortYear_Selected(object sender, RoutedEventArgs e)
        {
            estateSense.Items.SortDescriptions.Clear();
            estateSense.Items.SortDescriptions.Add(new SortDescription("EstateYear", ListSortDirection.Ascending));
        }

        private void SortArea_Selected(object sender, RoutedEventArgs e)
        {
            estateSense.Items.SortDescriptions.Clear();
            estateSense.Items.SortDescriptions.Add(new SortDescription("EstateSpace", ListSortDirection.Ascending));
        }

        private void SortWithout_Selected(object sender, RoutedEventArgs e)
        {
            UpdateSelectedEstate();
        }

        private void SortOnSale_Selected(object sender, RoutedEventArgs e)
        {
            estateRepository = new EstateRepository();
            estateSense.Items.Clear();
            foreach (Estate estate in estateRepository.GetAll())
            {
                if (estate.EstateState.Trim() == "Не продан")
                    estateSense.Items.Add(estate);
            }
        }

        private void SortSaled_Selected(object sender, RoutedEventArgs e)
        {
            estateRepository = new EstateRepository();
            estateSense.Items.Clear();
            foreach (Estate estate in estateRepository.GetAll())
            {
                if (estate.EstateState.Trim() == "Продан")
                    estateSense.Items.Add(estate);
            }
        }

        #endregion

        private void SortCity_SelectionChanged(object sender, RoutedEventArgs e)
        {
            //estateRepository = new EstateRepository();
            //estateSense.Items.Clear();
            //foreach (Estate estate in estateRepository.GetAll())
            //{
            //    if (SortCity.Text == estate.EstateAdress.ToString().Trim() && SortCity.Text!=null)
            //        estateSense.Items.Add(estate);
            //}
        }
    }
}
