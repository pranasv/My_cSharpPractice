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
using System.Windows.Shapes;
using BusinessLayer;
using DataLayer;


namespace UI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ProdCardWindow : Window
    {

        public ProdCardWindow()
        {
            InitializeComponent();
        }

        private void ChildListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProductService ProductService = new ProductService();
            ProdCardWindow productCardWindow = new ProdCardWindow();
            productCardWindow.ChildListView.ItemsSource = ProductService.GetProductChilds(ChildListView.SelectedItem as Product); ProductService.GetProductChilds((ChildListView.SelectedItem as Product));
            productCardWindow.Title = (ChildListView.SelectedItem as Product).Name;
            productCardWindow.Show();
        }
    }
}
