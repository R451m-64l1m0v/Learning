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
using System.Windows.Threading;

namespace SpeedClick
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
            Time.Text = "10";
            counter = 0;

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            

            Button1.Background = Brushes.AliceBlue;
            Button2.Background = Brushes.AliceBlue;
            Button3.Background = Brushes.AliceBlue;
            Button4.Background = Brushes.AliceBlue;
            Button5.Background = Brushes.AliceBlue;
            Button6.Background = Brushes.AliceBlue;
            Button7.Background = Brushes.AliceBlue;
            Button8.Background = Brushes.AliceBlue;
            Button9.Background = Brushes.AliceBlue;          
            
            Random RND = new Random();            
            var b = RND.Next(1, 10);
            if (b == 1)
            {
                Button1.Background = Brushes.Red;
            }
            if (b == 2)
            {
                Button2.Background = Brushes.Red;
            }
            if (b == 3)
            {
                Button3.Background = Brushes.Red;
            }
            if (b == 4)
            {
                Button4.Background = Brushes.Red;
            }
            if (b == 5)
            {
                Button5.Background = Brushes.Red;
            }
            if (b == 6)
            {
                Button6.Background = Brushes.Red;
            }
            if (b == 7)
            {
                Button7.Background = Brushes.Red;
            }
            if (b == 8)
            {
                Button8.Background = Brushes.Red;
            }
            if (b == 9)
            {
                Button9.Background = Brushes.Red;
            }     

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var relTime = double.Parse(Time.Text);
            relTime = relTime - 1;
            Time.Text = relTime.ToString();            
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            var a = (Button)sender;

            if (a.Background == Brushes.Red)
            {
                a.Background = Brushes.White;

                Random RND = new Random();
                var b = RND.Next(1, 10);

                if (b == 1)
                {
                    counter++;
                    Button1.Background = Brushes.Red;
                }
                if (b == 2)
                {
                    counter++;
                    Button2.Background = Brushes.Red;
                }
                if (b == 3)
                {
                    counter++;
                    Button3.Background = Brushes.Red;
                }
                if (b == 4)
                {
                    counter++;
                    Button4.Background = Brushes.Red;
                }
                if (b == 5)
                {
                    counter++;
                    Button5.Background = Brushes.Red;
                }
                if (b == 6)
                {
                    counter++;
                    Button6.Background = Brushes.Red;
                }
                if (b == 7)
                {
                    counter++;
                    Button7.Background = Brushes.Red;
                }
                if (b == 8)
                {
                    counter++;
                    Button8.Background = Brushes.Red;
                }
                if (b == 9)
                {
                    counter++;
                    Button9.Background = Brushes.Red;
                }

                if (double.Parse(Time.Text)  < 0)
                {
                    MessageBox.Show($"Bаш результат: {counter}");
                    timer.Stop();
                    Time.Text = 10.ToString();
                }
            }

            
        }
    }
}
