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

namespace Tema3_PixelArt
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //smallButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

        }

        private void resizePanel(object sender, RoutedEventArgs e)
        {
            Button b = (Button) sender;
            int size = int.Parse(b.Tag.ToString());
            if (MessageBox.Show("¿Seguro que quieres perder tu dibujo?",
                "Nuevo dibujo",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                pixelPanelGrid.Children.Clear();
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        Border bd = new Border();

                        bd.Margin = new Thickness(0);
                        bd.BorderBrush = Brushes.Gray;
                        bd.BorderThickness = new Thickness(0.5);
                        pixelPanelGrid.Children.Add(bd);
                    }
                }
            }
        }
    }
}
