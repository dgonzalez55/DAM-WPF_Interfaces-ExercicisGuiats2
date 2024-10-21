using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ex14_AddressInput
{
    /// <summary>
    /// Lógica de interacción para AddressControl.xaml
    /// </summary>
    public partial class AddressControl : UserControl
    {
        public AddressControl()
        {
            InitializeComponent();
        }

        // Propietats per accedir als valors dels camps
        public string Carrer
        {
            get => TextBoxCarrer.Text;
            set => TextBoxCarrer.Text = value;
        }

        public string Numero
        {
            get => TextBoxNumero.Text;
            set => TextBoxNumero.Text = value;
        }

        public string Ciutat
        {
            get => TextBoxCiutat.Text;
            set => TextBoxCiutat.Text = value;
        }

        public string Provincia
        {
            get => TextBoxProvincia.Text;
            set => TextBoxProvincia.Text = value;
        }

        public string CodiPostal
        {
            get => TextBoxCodiPostal.Text;
            set => TextBoxCodiPostal.Text = value;
        }

        public string? Pais
        {
            get => (ComboBoxPais.SelectedItem as ComboBoxItem)?.Content.ToString();
            set
            {
                foreach (ComboBoxItem item in ComboBoxPais.Items)
                {
                    if (item.Content.ToString() == value)
                    {
                        ComboBoxPais.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        // Validació automàtica per assegurar que el codi postal només contingui números
        private void TextBoxCodiPostal_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(TextBoxCodiPostal.Text, out _) || TextBoxCodiPostal.Text.Length!=5)
            {
                //Utilitzem la propietat Tag per indicar si hi ha un error (veure el control template al XAML)
                TextBoxCodiPostal.Tag = "Error"; // Valor invàlid, estableix l'estat d'error
            }
            else
            {
                TextBoxCodiPostal.Tag = null; // Valor vàlid, elimina l'estat d'error
            }
        }

        // Mètode per restablir tots els camps
        private void ButtonRestablir_Click(object sender, RoutedEventArgs e)
        {
            TextBoxCarrer.Text = string.Empty;
            TextBoxNumero.Text = string.Empty;
            TextBoxCiutat.Text = string.Empty;
            TextBoxProvincia.Text = string.Empty;
            TextBoxCodiPostal.Text = string.Empty;
            ComboBoxPais.SelectedIndex = -1;
        }
    }
}
