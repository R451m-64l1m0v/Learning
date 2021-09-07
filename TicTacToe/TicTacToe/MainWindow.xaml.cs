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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool firstPlayer = true;       

        public MainWindow()
        {
            InitializeComponent();
            Сleaning_game();
            SetState(false);
        }

        private void Srart_Click(object sender, RoutedEventArgs e)
        {
            Сleaning_game();
            canSelect();
            SetState(true);
        }

        private void Сleaning_game()
        {
            firstPlayer = true;
            Button1.Content = "";
            Button2.Content = "";
            Button3.Content = "";
            Button4.Content = "";
            Button5.Content = "";
            Button6.Content = "";
            Button7.Content = "";
            Button8.Content = "";
            Button9.Content = "";
        }

        private void SetState(bool State)
        {
            Button1.IsEnabled = State;
            Button2.IsEnabled = State;
            Button3.IsEnabled = State;
            Button4.IsEnabled = State;
            Button5.IsEnabled = State;
            Button6.IsEnabled = State;
            Button7.IsEnabled = State;
            Button8.IsEnabled = State;
            Button9.IsEnabled = State;
        }

        private void canSelect()
        {
            if (firstPlayer)
            {
                Hod.Text = "Ход X";
            }
            else
            {
                Hod.Text = "Ход 0";
            }
        }

        private void CheckVictory()
        {
            if (Button1.Content == Button2.Content && Button2.Content == Button3.Content && Button1.Content != "" && Button2.Content != "" && Button3.Content != "")
            {
                ShowVictoryMsg(Button1.Content as string);
            }

            if (Button4.Content == Button5.Content && Button5.Content == Button6.Content && Button4.Content != "" && Button5.Content != "" && Button6.Content != "")
            {
                ShowVictoryMsg(Button1.Content as string);
            }

            if (Button7.Content == Button8.Content && Button8.Content == Button9.Content && Button7.Content != "" && Button8.Content != "" && Button9.Content != "")
            {
                ShowVictoryMsg(Button1.Content as string);
            }

            if (Button1.Content == Button4.Content && Button4.Content == Button7.Content && Button1.Content != "" && Button4.Content != "" && Button7.Content != "")
            {
                ShowVictoryMsg(Button1.Content as string);
            }

            if (Button2.Content == Button5.Content && Button5.Content == Button8.Content && Button2.Content != "" && Button5.Content != "" && Button8.Content != "")
            {
                ShowVictoryMsg(Button1.Content as string);
            }

            if (Button3.Content == Button6.Content && Button6.Content == Button9.Content && Button3.Content != "" && Button6.Content != "" && Button9.Content != "")
            {
                ShowVictoryMsg(Button1.Content as string);
            }

            if (Button1.Content == Button5.Content && Button5.Content == Button9.Content && Button1.Content != "" && Button5.Content != "" && Button9.Content != "")
            {
                ShowVictoryMsg(Button1.Content as string);
            }

            if (Button3.Content == Button5.Content && Button5.Content == Button7.Content && Button3.Content != "" && Button5.Content != "" && Button7.Content != "")
            {
                ShowVictoryMsg(Button1.Content as string);
            }
        }

        private void ShowVictoryMsg(string znak)
        {
            MessageBox.Show($"Победа {znak}");
            Сleaning_game();
            SetState(false);
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            if (firstPlayer)
            {
                if (btn.Content == "")
                {
                    btn.Content = "x";
                    firstPlayer = false;
                    canSelect();
                }                
            }
            else
            {
                if (btn.Content == "")
                {
                    btn.Content = "0";
                    firstPlayer = true;
                    canSelect();
                }                
            }
            CheckVictory();
        }           
    }
}
