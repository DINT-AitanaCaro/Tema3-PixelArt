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
        private Brush color = Brushes.White;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void resizePanel(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
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
                        bd.Style = (Style)this.Resources["borderPixelArt"];
                        pixelPanelGrid.Children.Add(bd);
                    }
                }
            }
        }

        private void radioButtonColor_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Tag.ToString() == "Personalizado") colorPersonalizadoTextBox.IsEnabled = true;
            else cambioColor(rb.Tag.ToString(), false);
        }
        private void personalizadoRadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            colorPersonalizadoTextBox.IsEnabled = false;
            personalizadoRadioButton.Foreground = Brushes.Black;
        }
        private void colorPersonalizadoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) cambioColor(((TextBox)sender).Text, true);
        }
        private void cambioColor(String colorNuevo, bool isPersonalized)
        {
            BrushConverter bc = new BrushConverter();
            try
            {
                color = (Brush)bc.ConvertFrom(colorNuevo);
                if (isPersonalized) personalizadoRadioButton.Foreground = (Brush)bc.ConvertFrom(colorNuevo);
            }
            catch (FormatException)
            {
                MessageBox.Show($"Color {colorNuevo} no válido.","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
        private void bordeBorder_PreviewMouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            Border bo = (Border)sender;
            bo.Background = color;
        }

        private void bordeBorder_MouseEnter(object sender, RoutedEventArgs e)
        {
            Border b = (Border)sender;
            if (System.Windows.Input.Mouse.LeftButton == MouseButtonState.Pressed)
                    b.Background = color;
        }

        private void rellenarButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Object o in pixelPanelGrid.Children)
            {
                ((Border)o).Background = color;
            }
        }

    
    }
}
