using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace Ex10_BasicCustomControl
{
    /// <summary>
    /// Lógica de interacción para EtiquetaPersonalitzada.xaml
    /// </summary>
    public partial class EtiquetaPersonalitzada : UserControl
    {
        public EtiquetaPersonalitzada()
        {
            AnimationMillis = 500;
            InitializeComponent();
            this.MouseEnter += Contorn_MouseEnter;
            this.MouseLeave += Contorn_MouseLeave;
        }

        public string Text
        {
            get => TextEtiqueta.Text;
            set => TextEtiqueta.Text = value;
        }

        public Brush TextColor
        {
            get => TextEtiqueta.Foreground;
            set => TextEtiqueta.Foreground = value;
        }

        public double BorderWidth
        {
            get => Contorn.BorderThickness.Left;
            set => Contorn.BorderThickness = new Thickness(value);
        }

        private TimeSpan _animationDuration;

        public double AnimationMillis
        {
            get => _animationDuration.TotalMilliseconds;
            set => _animationDuration = TimeSpan.FromMilliseconds(value);
        }

        private void Contorn_MouseEnter(object sender, MouseEventArgs e)
        {
            // Animació per canviar el color del contorn a blau de forma suau
            var colorAnimEnter = new ColorAnimation
            {
                To = Colors.Blue,
                Duration = _animationDuration
            };
            (Contorn.BorderBrush as SolidColorBrush)?.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimEnter);
        }

        private void Contorn_MouseLeave(object sender, MouseEventArgs e)
        {
            // Animació per tornar el color del contorn a gris de forma suau
            var colorAnimLeave = new ColorAnimation
            {
                To = Colors.Gray,
                Duration = _animationDuration
            };
            (Contorn.BorderBrush as SolidColorBrush)?.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimLeave);
        }
    }

}
