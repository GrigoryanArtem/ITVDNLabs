using System.Windows;
using System.Windows.Media;

namespace LAB3_PART3_InputOutput
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color?> e)
        {
            ctrlColorLabel.Foreground = new SolidColorBrush(CalculateForegroundColor(e.NewValue));
        }

        private Color CalculateForegroundColor(Color? backgoundColor)
        {
            if (backgoundColor is null)
                return Colors.Black;

            Color color = backgoundColor.Value;
            return (color.R + color.G + color.B) >= 350 || color.A <= 70 ? Colors.Black : Colors.White;
        }
    }
}
