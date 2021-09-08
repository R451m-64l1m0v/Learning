using RoundRobin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
using SnakeGame.Models;

namespace SnakeGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        CancellationTokenSource cts = new CancellationTokenSource();
        private object locker = new object();
        RoundRobinLst<int> RoundRobinLstUD = new RoundRobinLst<int>(new List<int> {0, 1, 2, 3, 4}, 2);
        RoundRobinLst<int> RoundRobinLstLR = new RoundRobinLst<int>(new List<int> {0, 1, 2, 3, 4}, 2);
        private const int speed = 500;
        private Direction currentDirection;
        private Direction previousDirection;
        Food _food = new Food();



        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);
        }

        private void Srart_Click(object sender, RoutedEventArgs e)
        {
            cts.Cancel();
            _food.incerdNewEat(Food);

            var rnd = new Random();
            var rndDir = rnd.Next(0, 4);

            currentDirection = (Direction) rndDir;
            previousDirection = currentDirection;

            Task.Factory.StartNew(() =>
            {
                lock (locker)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Head.SetValue(Grid.ColumnProperty, 2);
                        Head.SetValue(Grid.RowProperty, 2);
                    });

                    RoundRobinLstUD.StartPos(2);
                    RoundRobinLstLR.StartPos(2);

                    Task.Delay(200).Wait();

                    cts = new CancellationTokenSource();
                    while (!cts.IsCancellationRequested)
                    {
                        Application.Current.Dispatcher.Invoke(() => Dvijenie());
                        try
                        {
                            Task.Delay(speed).Wait(cts.Token);
                        }
                        catch
                        {
                        }
                    }
                }
            }, TaskCreationOptions.LongRunning);
        }

        public void Dvijenie()
        {
            if (currentDirection == Direction.R)
            {
                Head.SetValue(Grid.ColumnProperty, RoundRobinLstLR.NextF());
            }

            if (currentDirection == Direction.L)
            {
                Head.SetValue(Grid.ColumnProperty, RoundRobinLstLR.NextB());
            }

            if (currentDirection == Direction.D)
            {
                Head.SetValue(Grid.RowProperty, RoundRobinLstUD.NextF());
            }

            if (currentDirection == Direction.U)
            {
                Head.SetValue(Grid.RowProperty, RoundRobinLstUD.NextB());
            }

            var headX = (int) Head.GetValue(Grid.ColumnProperty);
            var headY = (int) Head.GetValue(Grid.RowProperty);

            var foodX = (int) Food.GetValue(Grid.ColumnProperty);
            var foodY = (int) Food.GetValue(Grid.RowProperty);

            if (headX == foodX && headY == foodY)
            {
                _food.incerdNewEat(Food);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btnName = ((Button) sender).Name;

            if (btnName == UpBtn.Name && previousDirection != Direction.D)
            {
                currentDirection = Direction.U;
            }
            else if (btnName == DownBtn.Name && previousDirection != Direction.U)
            {
                currentDirection = Direction.D;
            }
            else if (btnName == LeftBtn.Name && previousDirection != Direction.R)
            {
                currentDirection = Direction.L;
            }
            else if (btnName == RightBtn.Name && previousDirection != Direction.L)
            {
                currentDirection = Direction.R;
            }
            previousDirection = currentDirection;
        }

        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Down:
                    if (previousDirection != Direction.U)
                        currentDirection = Direction.D;
                    break;
                case Key.Up:
                    if (previousDirection != Direction.D)
                        currentDirection = Direction.U;
                    break;
                case Key.Left:
                    if (previousDirection != Direction.R)
                        currentDirection = Direction.L;
                    break;
                case Key.Right:
                    if (previousDirection != Direction.L)
                        currentDirection = Direction.R;
                    break;
            }
            previousDirection = currentDirection;
        }
    }
}