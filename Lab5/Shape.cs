using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Microsoft.Win32;

namespace Lab5
{
    [Serializable]
    public class Shape
    {
        [NonSerialized]
        private SolidColorBrush background;
        [NonSerialized]
        private SolidColorBrush foreground;

        byte[] color_background = new byte[3];
        byte[] color_foreground = new byte[3];

        public int Width { get; set; }
        public SolidColorBrush Background { get => background; set => background = value; }
        public SolidColorBrush Foreground { get => foreground; set => foreground = value; }
        public double X { get; set; }
        public double Y { get; set; }

        public Shape()
        {
        }

        public Shape(int width, SolidColorBrush background, SolidColorBrush foreground, double x, double y)
        {
            Width = width;
            Background = background;
            Foreground = foreground;
            X = x;
            Y = y;
        }

        private void PackColor()
        {
            color_background[0] = Background.Color.R;
            color_background[1] = Background.Color.G;
            color_background[2] = Background.Color.B;

            color_foreground[0] = Foreground.Color.R;
            color_foreground[1] = Foreground.Color.G;
            color_foreground[2] = Foreground.Color.B;
        }

        private void UnpackColor()
        {
            background = new SolidColorBrush(Color.FromRgb(color_background[0], color_background[1], color_background[2]));
            foreground = new SolidColorBrush(Color.FromRgb(color_foreground[0], color_foreground[1], color_foreground[2]));
        }

        public void SaveToFile()
        {
            PackColor();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Files (dat)|*.dat|All files|*.*";
            if(saveFileDialog.ShowDialog() != true)
            {
                return;
            }
            FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Close();
        }

        public static Shape LoadFromFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Files (dat)|*.dat|All files|*.*";
            if (openFileDialog.ShowDialog() != true)
            {
                return null;
            }
            FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            Shape shape = (Shape)bf.Deserialize(fs);
            shape.UnpackColor();
            fs.Close();
            return shape;
        }

        public override string ToString()
        {
            return $"Width={Width} Baclground={Background} Foreground={Foreground} X={X} Y={Y}";
        }
    }
}
