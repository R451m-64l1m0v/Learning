using Microsoft.EntityFrameworkCore;
using PhoneBook.DataBase;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace PhoneBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly ApplicationDBContext _applicationDbContext;

        private CollectionViewSource userViewSource;


        public MainWindow()
        {
            _applicationDbContext = new ApplicationDBContext();

            _applicationDbContext.Database.EnsureCreated();

            InitializeComponent();
            userViewSource = (CollectionViewSource)FindResource(nameof(userViewSource));           
            

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            _applicationDbContext.Users.Load();
            var a = _applicationDbContext.Users.ToList();

            userViewSource.Source =
                _applicationDbContext.Users.Local.ToObservableCollection();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // all changes are automatically tracked, including
            // deletes!
            _applicationDbContext.SaveChanges();

            // this forces the grid to refresh to latest values
            userDataGrid.Items.Refresh();
            
        }

        protected override void OnClosing(CancelEventArgs e)
        {

            _applicationDbContext.Dispose();
            base.OnClosing(e);
        }

    }
}
