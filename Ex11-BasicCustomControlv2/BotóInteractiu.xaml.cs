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

namespace Ex11_BasicCustomControlv2
{
    /// <summary>
    /// Lógica de interacción para BotóInteractiu.xaml
    /// </summary>
    public partial class BotóInteractiu : UserControl
    {
        public BotóInteractiu()
        {
            InitializeComponent();
            Botó.MouseEnter += Botó_MouseEnter;
            Botó.MouseLeave += Botó_MouseLeave;
            Botó.Click += Botó_Click;
        }

        private void Botó_MouseEnter(object sender, MouseEventArgs e)
        {
            Contorn.Background = Brushes.LightBlue;
            Botó.Width += 20;
            Botó.Height += 20;
            Botó.FontSize += 10;
        }

        private void Botó_MouseLeave(object sender, MouseEventArgs e)
        {
            Contorn.Background = Brushes.White;
            Botó.Width -= 20;
            Botó.Height -= 20;
            Botó.FontSize -= 10;
        }

        private void Botó_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Has clicat el botó interactiu!");
        }
    }
}
