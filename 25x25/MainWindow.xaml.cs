using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace _25x25
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        int counter;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Srart_Click(object sender, RoutedEventArgs e)
        {

            Time.Text = "0";
            var button = Enumerable.Range(1, 25).ToList();
            
            Random RND = new Random();
            for (int i = 0; i < button.Count; i++)
            {
                int tmp = button[0];
                button.RemoveAt(0);
                button.Insert(RND.Next(button.Count), tmp);
            }

            Button1.Content = button[0];
            Button2.Content = button[1];
            Button3.Content = button[2];
            Button4.Content = button[3];
            Button5.Content = button[4];
            Button6.Content = button[5];
            Button7.Content = button[6];
            Button8.Content = button[7];
            Button9.Content = button[8];
            Button10.Content = button[9];
            Button11.Content = button[10];
            Button12.Content = button[11];
            Button13.Content = button[12];
            Button14.Content = button[13];
            Button15.Content = button[14];
            Button16.Content = button[15];
            Button17.Content = button[16];
            Button18.Content = button[17];
            Button19.Content = button[18];
            Button20.Content = button[19];
            Button21.Content = button[20];
            Button22.Content = button[21];
            Button23.Content = button[22];
            Button24.Content = button[23];
            Button25.Content = button[24];           

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            counter = 1;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var relTime = double.Parse(Time.Text);
            relTime = relTime + 1;
            Time.Text = relTime.ToString();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            NewMethod(sender);
        }

        private void NewMethod(object sender)
        {
            var a = (Button)sender;
            var b = (int)a.Content;
            if (b == counter)
            {
                counter++;
            }
            if (b == 25 && counter == 26)
            {
                timer.Stop();
                MessageBox.Show($"Bаш результат: {Time.Text} сек.");
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            NewMethod(sender);
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            NewMethod(sender);
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            NewMethod(sender);
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            NewMethod(sender);
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            NewMethod(sender);
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            NewMethod(sender);
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            NewMethod(sender);
        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            NewMethod(sender);
        }

        private void Button10_Click(object sender, RoutedEventArgs e)
        {
            NewMethod(sender);
        }

        private void Button11_Click(object sender, RoutedEventArgs e)
        {
            NewMethod(sender);
        }

        private void Button12_Click(object sender, RoutedEventArgs e)
        {
            NewMethod(sender);
        }

        private void Button13_Click(object sender, RoutedEventArgs e)
        {
            NewMethod(sender);
        }

        private void Button14_Click(object sender, RoutedEventArgs e)
        {
            NewMethod(sender);
        }

        private void Button15_Click(object sender, RoutedEventArgs e)
        {
            NewMethod(sender);
        }

        private void Button16_Click(object sender, RoutedEventArgs e)
        {
            NewMethod(sender);
        }

        private void Button17_Click(object sender, RoutedEventArgs e)
        {
            NewMethod(sender);
        }

        private void Button18_Click(object sender, RoutedEventArgs e)
        {
            NewMethod(sender);
        }

        private void Button19_Click(object sender, RoutedEventArgs e)
        {
            NewMethod(sender);
        }

        private void Button20_Click(object sender, RoutedEventArgs e)
        {
            NewMethod(sender);
        }

        private void Button21_Click(object sender, RoutedEventArgs e)
        {
            NewMethod(sender);
        }

        private void Button22_Click(object sender, RoutedEventArgs e)
        {
            NewMethod(sender);
        }

        private void Button23_Click(object sender, RoutedEventArgs e)
        {
            NewMethod(sender);
        }

        private void Button24_Click(object sender, RoutedEventArgs e)
        {
            NewMethod(sender);
        }

        private void Button25_Click(object sender, RoutedEventArgs e)
        {
            NewMethod(sender);
        }
    }
}
