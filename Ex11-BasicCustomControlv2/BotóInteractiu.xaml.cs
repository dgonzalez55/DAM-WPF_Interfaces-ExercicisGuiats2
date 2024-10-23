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
using System.Windows.Media.Animation;
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

            var fontSizeAnimEnter = new DoubleAnimation
            {
                To = Botó.FontSize + 10, // Nou valor de mida (ample o alt)
                Duration = TimeSpan.FromMilliseconds(500) // Duració de l'animació
            };
            var widthAnimEnter = new DoubleAnimation
            {
                To = Botó.Width + 20, // Nou valor de mida (ample o alt)
                Duration = TimeSpan.FromMilliseconds(500) // Duració de l'animació
            };
            var heightAnimEnter = new DoubleAnimation
            {
                To = Botó.Height + 20, // Nou valor de mida (ample o alt)
                Duration = TimeSpan.FromMilliseconds(500) // Duració de l'animació
            };

            // Aplica les animacions
            Botó.BeginAnimation(Control.FontSizeProperty, fontSizeAnimEnter);
            Botó.BeginAnimation(FrameworkElement.WidthProperty, widthAnimEnter);
            Botó.BeginAnimation(FrameworkElement.HeightProperty, heightAnimEnter);
        }

        private void Botó_MouseLeave(object sender, MouseEventArgs e)
        {
            Contorn.Background = Brushes.White;

            var fontSizeAnimEnter = new DoubleAnimation
            {
                To = Botó.FontSize - 10, // Nou valor de mida (ample o alt)
                Duration = TimeSpan.FromMilliseconds(500) // Duració de l'animació
            };
            var widthAnimEnter = new DoubleAnimation
            {
                To = Botó.Width - 20, // Nou valor de mida (ample o alt)
                Duration = TimeSpan.FromMilliseconds(500) // Duració de l'animació
            };
            var heightAnimEnter = new DoubleAnimation
            {
                To = Botó.Height - 20, // Nou valor de mida (ample o alt)
                Duration = TimeSpan.FromMilliseconds(500) // Duració de l'animació
            };

            // Aplica les animacions.
            Botó.BeginAnimation(Control.FontSizeProperty, fontSizeAnimEnter);
            Botó.BeginAnimation(FrameworkElement.WidthProperty, widthAnimEnter);
            Botó.BeginAnimation(FrameworkElement.HeightProperty, heightAnimEnter);
        }

        private void Botó_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Has clicat el botó interactiu!");
        }
    }
}
