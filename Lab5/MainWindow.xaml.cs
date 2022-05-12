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

namespace Lab5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Shape shape;
        public MainWindow()
        {
            InitializeComponent();
            CommandBinding commandBindingHelp = new CommandBinding();
            commandBindingHelp.Command = ApplicationCommands.Help;
            commandBindingHelp.Executed += help;
            menuItemHelp.CommandBindings.Add(commandBindingHelp);

            CommandBinding commandBindingSave = new CommandBinding();
            commandBindingSave.Command = ApplicationCommands.Save;
            commandBindingSave.Executed += save;
            commandBindingSave.CanExecute += save_CanExecute;
            menuItemSave.CommandBindings.Add(commandBindingSave);
            buttonItemSave.CommandBindings.Add(commandBindingSave);

            CommandBinding commandBindingLoad = new CommandBinding();
            commandBindingLoad.Command = ApplicationCommands.Open;
            commandBindingLoad.Executed += load;
            menuItemLoad.CommandBindings.Add(commandBindingLoad);
            buttonItemOpen.CommandBindings.Add(commandBindingLoad);

            CommandBinding commandBindingClose = new CommandBinding();
            commandBindingClose.Command = ApplicationCommands.Close;
            commandBindingClose.Executed += close;
            menuItemExit.CommandBindings.Add(commandBindingClose);
        }

        private void save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = shape != null;
        }

        private void help(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Application help");
        }

        private void load(object sender, ExecutedRoutedEventArgs e)
        {
            shape = Shape.LoadFromFile();
        }

        private void save(object sender, ExecutedRoutedEventArgs e)
        {
            shape.SaveToFile();
        }

        private void close(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            WindowShape windowShape = new WindowShape();
            if(windowShape.ShowDialog() == true)
            {
                shape = windowShape.NewShape;
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            textBlockCursorPosition.Text = $"Mouse position: X = {e.GetPosition(canvas).X} | Y = {e.GetPosition(canvas).Y}";
        }

        private void canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(shape == null)
            {
                return;
            }
            Polygon t = new Polygon();
            t.Points = new PointCollection();
            Point point1 = e.GetPosition(canvas);
            shape.X = point1.X;
            shape.Y = point1.Y;
            t.Points.Add(point1);
            t.Points.Add(new Point(shape.X + 100, shape.Y));
            t.Points.Add(new Point(shape.X, shape.Y + 100));
            t.Points.Add(new Point(shape.X -100, shape.Y + 100));
            t.Fill = shape.Background;
            t.Stroke = shape.Foreground;
            t.StrokeThickness = shape.Width;
            canvas.Children.Add(t);
        }
    }
}
