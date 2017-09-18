using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SportStatViewer.Widgets
{
    public class ColorScheme
    {
        public static Color FaceBorderColor = Colors.Green;
        public static Color LineColor = Color.FromRgb(158, 59, 51);

        public static readonly SolidColorBrush[] FaceColors = new SolidColorBrush[]
        {
            new SolidColorBrush(Color.FromRgb(144, 238, 144)),
            new SolidColorBrush(Color.FromRgb(124, 252, 0)),
            new SolidColorBrush(Color.FromRgb(34, 139, 34)),
            new SolidColorBrush(Color.FromRgb(107, 142, 35)),
            new SolidColorBrush(Color.FromRgb(85, 107, 47))
        };

        public static readonly SolidColorBrush[] VoivodeshipColors = new SolidColorBrush[]
        {
            new SolidColorBrush(Color.FromRgb(135, 206, 235)),
            new SolidColorBrush(Color.FromRgb(70, 130, 180)),
            new SolidColorBrush(Color.FromRgb(30, 144, 255)),            
            new SolidColorBrush(Color.FromRgb(0, 0, 255)),
            new SolidColorBrush(Color.FromRgb(25, 25, 112))
        };

        public static readonly SolidColorBrush[] ChartPieColors = new SolidColorBrush[]
        {
            Brushes.Red,
            Brushes.Aquamarine,
            Brushes.Beige,
            Brushes.Blue,
            Brushes.BlueViolet,
            Brushes.BurlyWood,
            Brushes.CadetBlue,
            Brushes.Chartreuse,
            Brushes.Coral,
            Brushes.Crimson,
            Brushes.DarkCyan,
            Brushes.DarkGray,
            Brushes.DarkOliveGreen,
            Brushes.DarkOrchid,
            Brushes.DeepPink,
            Brushes.DimGray,
            Brushes.FloralWhite,
            Brushes.Fuchsia,
            Brushes.Gold,
            Brushes.Green,
            Brushes.IndianRed,
            Brushes.Khaki
        };


        public static int GetIndexByValue(double value, double minValue, double maxValue)
        {
            double d = (maxValue - minValue) / 5;
            int colorIndex = (int)((value - minValue) / d);

            return colorIndex;
        }

        public static SolidColorBrush GetColorByIndex(int index, SolidColorBrush[] palette)
        {
            if (index >= palette.Length)
                return palette[palette.Length - 1];

            return palette[index];
        }

        public static double[] GetValueIntervals(double minValue, double maxValue)
        {
            double d = (maxValue - minValue) / 5;

            double[] result = new double[]
            {
                minValue,
                minValue + d,
                minValue + (d * 2),
                minValue + (d * 3),
                minValue + (d * 4),
                maxValue
            };

            return result;
        }

        public static SolidColorBrush GetTint(double percent, Color fromColor, Color toColor)
        {
            byte r = (byte)(toColor.R + ((fromColor.R - toColor.R) * percent) / 100);
            byte g = (byte)(toColor.G + ((fromColor.G - toColor.G) * percent) / 100);
            byte b = (byte)(toColor.B + ((fromColor.B - toColor.B) * percent) / 100);

            return new SolidColorBrush(Color.FromRgb(r, g, b));
        }
    }
}
