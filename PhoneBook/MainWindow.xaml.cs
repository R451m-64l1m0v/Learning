using Microsoft.EntityFrameworkCore;
using PhoneBook.DataBase;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            userViewSource.Source =
                _applicationDbContext.Users.Local.ToObservableCollection();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {            
            _applicationDbContext.SaveChanges();
            userDataGrid.Items.Refresh();
            userDataGrid.IsReadOnly = !userDataGrid.IsReadOnly;
            Start.Content = Start.Content == "Сохранить"
                ? Start.Content = "Редaктировать"
                : Start.Content = "Сохранить";
            Delete.Visibility = Start.Content == "Редaктировать" ? Delete.Visibility = Visibility.Hidden : Delete.Visibility = Visibility.Visible;
        }

        protected override void OnClosing(CancelEventArgs e)
        {

            _applicationDbContext.Dispose();
            base.OnClosing(e);
        }

        

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            IQueryable<User> filtered = null;

            if (nameFilter.Text != "")
            {
                filtered = _applicationDbContext.Users.Where(x => x.Name == nameFilter.Text);
            }

            if (surNameFilter.Text != "")
            {
                filtered = filtered == null
                    ? _applicationDbContext.Users.Where(x => x.SurName == surNameFilter.Text)
                    : filtered.Where(y => y.SurName == surNameFilter.Text);
            }

            if (phoneNumberFilter.Text != "")
            {
                if (Int64.TryParse(phoneNumberFilter.Text, out var number))
                {
                    filtered = filtered == null
                        ? _applicationDbContext.Users.Where(x => x.PhoneNumber == number)
                        : filtered.Where(y => y.PhoneNumber == number);
                }
            }

           
            if (filtered == null)
            {
                userViewSource.Source = _applicationDbContext.Users.Local.ToObservableCollection();
            }
            else
            {
                userViewSource.Source = new ObservableCollection<User>(filtered.ToList());
            }            
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = userDataGrid.SelectedItem as User;
            var currentUserDel = _applicationDbContext.Users.FirstOrDefault(x => x.Id == currentUser.Id);
            _applicationDbContext.Users.Remove(currentUserDel);
            userDataGrid.Items.Refresh();
        }
    }
}
