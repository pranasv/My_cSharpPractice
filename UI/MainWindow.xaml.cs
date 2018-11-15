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
using BusinessLayer;
using DataLayer;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        private ProductService ProductService = new ProductService();

        public MainWindow()
        {
            InitializeComponent();
            AllProductsList.ItemsSource = ProductService.GetAllProducts();
        }

        private void AllProductsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AllProductsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProdCardWindow productCardWindow = new ProdCardWindow();
            var selectedItem = AllProductsList.SelectedItem as Product;
            productCardWindow.ChildListView.ItemsSource = ProductService.GetProductChilds(selectedItem); ProductService.GetProductChilds(selectedItem);
            productCardWindow.Title = selectedItem.Name;
            productCardWindow.Show();
        }
    }
}
