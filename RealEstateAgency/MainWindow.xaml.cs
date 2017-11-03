using DAL;
using Model;
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
        public MainWindow()
        {
            InitializeComponent();
            UpdateSelectedEstate();
        }

        private void UpdateSelectedEstate()
        {
            estateRepository = new EstateRepository();
            estateSense.Items.Clear();
            foreach (Estate estate in estateRepository.GetAll())
            {
                estateSense.Items.Add(estate);
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
                estateDescription.Content = $"Наименование: {selectedEstate.EstateName} \n" +
                    $"Инвентраный номер: {selectedEstate.EstateInventoryNumber} \n" +
                    $"Общая площадь: {selectedEstate.EstateSpace} \n" +
                    $"Местонахождение: {selectedEstate.EstateAdress} \n" +
                    $"Назначение: {selectedEstate.EstateFunction} \n" +
                    $"Год постройки: {selectedEstate.EstateYear} \n" +
                    $"Материал стен: {selectedEstate.EstateWall} \n" +
                    $"Арендатор: {selectedEstate.EstateState} \n" +
                    $"Собственник: {selectedEstate.EstateOwner} \n" +
                    $"Стоимость аренды (1 кв.м.): {selectedEstate.EstateRentPrice} бел.руб.\n" +
                    $"Цена продажи: {selectedEstate.EstateCostOfSale} бел.руб.\n" +
                    $"Статус объекта: {selectedEstate.EstateDeal} \n" +
                    $"Краткое описание: {selectedEstate.EstateDescription}";
            }
        }
    }
}
