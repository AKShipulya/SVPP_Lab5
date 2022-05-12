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
using System.Windows.Shapes;

namespace Lab5
{
    /// <summary>
    /// Логика взаимодействия для WindowShape.xaml
    /// </summary>
    public partial class WindowShape : Window
    {
        
        List<string> colors = new List<string> { "Red", "Green", "Blue"};
        Shape shape = new Shape();

        public WindowShape()
        {
            InitializeComponent();
            comboBoxFore.ItemsSource = colors;
            comboBoxBack.ItemsSource = colors;
            stackPanel.DataContext = shape;
        }

        public Shape NewShape
        {
            get
            {
                switch (comboBoxBack.SelectedIndex)
                {
                    case 0: shape.Background = new SolidColorBrush(Colors.Red); break;
                    case 1: shape.Background = new SolidColorBrush(Colors.Green); break;
                    case 2: shape.Background = new SolidColorBrush(Colors.Blue); break;
                    default: shape.Background = new SolidColorBrush(Colors.White); break;
                }
                switch (comboBoxFore.SelectedIndex)
                {
                    case 0: shape.Foreground = new SolidColorBrush(Colors.Red); break;
                    case 1: shape.Foreground = new SolidColorBrush(Colors.Green); break;
                    case 2: shape.Foreground = new SolidColorBrush(Colors.Blue); break;
                    default: shape.Foreground = new SolidColorBrush(Colors.Black); break;
                }
                return shape;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
