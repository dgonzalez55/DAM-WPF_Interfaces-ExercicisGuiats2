using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Ex12_CustomGallery
{
    /// <summary>
    /// Lógica de interacción para GaleriaImatges.xaml
    /// </summary>
    public partial class GaleriaImatges : UserControl
    {
        private int _index = 0;
        private List<string> _imatges = new List<string>();

        public GaleriaImatges()
        {
            InitializeComponent();
        }

        // Propietat pública per establir el directori d'imatges
        public string? DirectoriImatges
        {
            get => _directoriImatges;
            set
            {
                _directoriImatges = value;
                CarregarImatgesDelDirectori();
            }
        }
        private string? _directoriImatges;

        // Carrega les imatges del directori especificat
        private void CarregarImatgesDelDirectori()
        {
            if (string.IsNullOrEmpty(_directoriImatges)) return;
            // Resol la ruta relativa des de l'executable actual
            var rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _directoriImatges);

            if (Directory.Exists(rutaCompleta))
            {
                _imatges = new List<string>(Directory.GetFiles(rutaCompleta, "*.*", SearchOption.TopDirectoryOnly)
                    .Where(file => file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                   file.EndsWith(".png", StringComparison.OrdinalIgnoreCase)));

                if (_imatges.Count > 0)
                {
                    _index = 0;
                    CarregarImatge();
                }
                else
                {
                    MessageBox.Show("No s'han trobat imatges a la carpeta especificada.");
                }
            }
            else
            {
                MessageBox.Show("El directori especificat no existeix.");
            }
        }

        // Carrega la imatge actual amb una animació de dissolució
        private void CarregarImatge()
        {
            if (_imatges.Count == 0) return;

            Imatge.Source = new BitmapImage(new Uri(_imatges[_index], UriKind.Absolute));

            // Animació de transició (dissolució)
            var anim = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.5));
            Imatge.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        private void Anterior_Click(object sender, RoutedEventArgs e)
        {
            if (_imatges.Count == 0) return;
            _index = (_index - 1 + _imatges.Count) % _imatges.Count;
            CarregarImatge();
        }

        private void Següent_Click(object sender, RoutedEventArgs e)
        {
            if (_imatges.Count == 0) return;
            _index = (_index + 1) % _imatges.Count;
            CarregarImatge();
        }
    }

}
