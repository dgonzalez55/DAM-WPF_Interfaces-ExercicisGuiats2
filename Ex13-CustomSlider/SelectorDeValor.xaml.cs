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

namespace Ex13_CustomSlider
{
    /// <summary>
    /// Lógica de interacción para SelectorDeValor.xaml
    /// </summary>
    public partial class SelectorDeValor : UserControl
    {
        public SelectorDeValor()
        {
            InitializeComponent();
            ActualitzarColor(SliderControl.Value);
        }

        // Propietat de valor mínim
        public double ValorMinim
        {
            get => SliderControl.Minimum;
            set => SliderControl.Minimum = value;
        }

        // Propietat de valor màxim
        public double ValorMaxim
        {
            get => SliderControl.Maximum;
            set => SliderControl.Maximum = value;
        }

        // Propietat per obtenir o establir el valor actual
        public double Valor
        {
            get => SliderControl.Value;
            set
            {
                if (value >= ValorMinim && value <= ValorMaxim)
                {
                    SliderControl.Value = value;
                    TextBoxValor.Text = value.ToString("F0"); // Mostra el valor com un número enter
                    ActualitzarColor(value); // Canvia el color segons el valor
                }
            }
        }

        // Mètode per canviar el color en funció del valor
        private void ActualitzarColor(double valor)
        {
            if (valor < (ValorMaxim - ValorMinim) * 0.3)
                TextBoxValor.Background = Brushes.LightGreen;
            else if (valor < (ValorMaxim - ValorMinim) * 0.7)
                TextBoxValor.Background = Brushes.LightYellow;
            else
                TextBoxValor.Background = Brushes.IndianRed;
        }

        // Event del Slider per canviar el valor
        private void SliderControl_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TextBoxValor.Text = SliderControl.Value.ToString("F0");
            ActualitzarColor(SliderControl.Value);
        }

        // Event del TextBox per validar el valor introduït
        private void TextBoxValor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(TextBoxValor.Text, out double nouValor))
            {
                if (nouValor >= ValorMinim && nouValor <= ValorMaxim)
                {
                    SliderControl.Value = nouValor;
                    ActualitzarColor(nouValor);
                }
                else
                {
                    // Mostra un color d'error si el valor no està dins del rang
                    TextBoxValor.Background = Brushes.LightCoral;
                }
            }
            else
            {
                // Mostra un color d'error si el text no és un número vàlid
                TextBoxValor.Background = Brushes.LightCoral;
            }
        }
    }
}
