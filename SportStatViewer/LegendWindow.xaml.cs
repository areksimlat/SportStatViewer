using SportStatViewer.Data;
using SportStatViewer.Widgets;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace SportStatViewer
{
    /// <summary>
    /// Logika interakcji dla klasy LegendWindow.xaml
    /// </summary>
    public partial class LegendWindow : Window
    {
        private DataHolder holder;

        public LegendWindow(DataHolder holder, VoivodeshipNames name)
        {
            InitializeComponent();

            this.holder = holder;

            initMapLegend();
            initChartLegend();
            initChernoffFaceLegend(name);                
        }

        private void initMapLegend()
        {
            mapRectColor1.Fill = ColorScheme.GetColorByIndex(0, ColorScheme.VoivodeshipColors);
            mapRectColor2.Fill = ColorScheme.GetColorByIndex(1, ColorScheme.VoivodeshipColors);
            mapRectColor3.Fill = ColorScheme.GetColorByIndex(2, ColorScheme.VoivodeshipColors);
            mapRectColor4.Fill = ColorScheme.GetColorByIndex(3, ColorScheme.VoivodeshipColors);
            mapRectColor5.Fill = ColorScheme.GetColorByIndex(4, ColorScheme.VoivodeshipColors);

            double[] totals = holder.GetSumTotalInAllVoivodeships();
            double min = holder.GetMin(totals);
            double max = holder.GetMax(totals);
            double[] valueIntervals = ColorScheme.GetValueIntervals(min, max);

            mapLabelColor1.Content = String.Format("{0:0.##} - {1:0.##}", valueIntervals[0], valueIntervals[1]);
            mapLabelColor2.Content = String.Format("{0:0.##} - {1:0.##}", valueIntervals[1], valueIntervals[2]);
            mapLabelColor3.Content = String.Format("{0:0.##} - {1:0.##}", valueIntervals[2], valueIntervals[3]);
            mapLabelColor4.Content = String.Format("{0:0.##} - {1:0.##}", valueIntervals[3], valueIntervals[4]);
            mapLabelColor5.Content = String.Format("{0:0.##} - {1:0.##}", valueIntervals[4], valueIntervals[5]);
        }

        private void initChartLegend()
        {
            for (int i = 0; i < holder.SportCount; i++)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.SetValue(Grid.RowProperty, i);
                rectangle.Width = 40;
                rectangle.Height = 40;
                rectangle.Margin = new Thickness(0, 2, 0, 2);
                rectangle.Fill = ColorScheme.GetColorByIndex(i, ColorScheme.ChartPieColors);

                Label label = new Label();
                label.Content = holder.SportNames[i];
                label.SetValue(Grid.RowProperty, i);
                label.SetValue(Grid.ColumnProperty, 1);
                label.VerticalAlignment = VerticalAlignment.Center;
                label.HorizontalAlignment = HorizontalAlignment.Center;
                label.FontSize = 15;

                ChartLegendGrid.RowDefinitions.Add(new RowDefinition());
                ChartLegendGrid.Children.Add(rectangle);
                ChartLegendGrid.Children.Add(label);
            }
        }

        private void initChernoffFaceLegend(VoivodeshipNames name)
        {
            if (name == VoivodeshipNames.None)
            {
                faceTabItem.IsEnabled = false;
            }
            else
            {
                faceTabItem.IsEnabled = true;
                legendTabControl.SelectedIndex = 2;

                StatisticsData minData = holder.GetMinDatasInVoivodeship(name);
                StatisticsData maxData = holder.GetMaxDatasInVoivodeship(name);

                initChernoffFaceColorLegend(ColorScheme.GetValueIntervals(minData.Sections, maxData.Sections));
                initChernoffFaceEyesLegend(ColorScheme.GetValueIntervals(minData.Boys, maxData.Boys));
                initChernoffFaceMustacheLegend(ColorScheme.GetValueIntervals(minData.Womens, maxData.Womens));
                initChernoffFaceLipsLegend(ColorScheme.GetValueIntervals(minData.Girls, maxData.Girls));
            }
        }

        private void initChernoffFaceColorLegend(double[] valueIntervals)
        {
            faceBkgRectColor1.Fill = ColorScheme.GetColorByIndex(0, ColorScheme.FaceColors);
            faceBkgRectColor2.Fill = ColorScheme.GetColorByIndex(1, ColorScheme.FaceColors);
            faceBkgRectColor3.Fill = ColorScheme.GetColorByIndex(2, ColorScheme.FaceColors);
            faceBkgRectColor4.Fill = ColorScheme.GetColorByIndex(3, ColorScheme.FaceColors);
            faceBkgRectColor5.Fill = ColorScheme.GetColorByIndex(4, ColorScheme.FaceColors);

            faceBkgLabelColor1.Content = String.Format("{0:0.##} - {1:0.##}", valueIntervals[0], valueIntervals[1]);
            faceBkgLabelColor2.Content = String.Format("{0:0.##} - {1:0.##}", valueIntervals[1], valueIntervals[2]);
            faceBkgLabelColor3.Content = String.Format("{0:0.##} - {1:0.##}", valueIntervals[2], valueIntervals[3]);
            faceBkgLabelColor4.Content = String.Format("{0:0.##} - {1:0.##}", valueIntervals[3], valueIntervals[4]);
            faceBkgLabelColor5.Content = String.Format("{0:0.##} - {1:0.##}", valueIntervals[4], valueIntervals[5]);
        }

        private void initChernoffFaceEyesLegend(double[] valueIntervals)
        {
            new ChernoffFace(new Point(20, 30), 40, 0, ChernoffFace.FacePartNames.Eyes).Draw(faceEyesCanvas1);
            new ChernoffFace(new Point(20, 30), 40, 1, ChernoffFace.FacePartNames.Eyes).Draw(faceEyesCanvas2);
            new ChernoffFace(new Point(20, 30), 40, 2, ChernoffFace.FacePartNames.Eyes).Draw(faceEyesCanvas3);
            new ChernoffFace(new Point(20, 30), 40, 3, ChernoffFace.FacePartNames.Eyes).Draw(faceEyesCanvas4);
            new ChernoffFace(new Point(20, 30), 40, 4, ChernoffFace.FacePartNames.Eyes).Draw(faceEyesCanvas5);

            faceEyesLabelColor1.Content = String.Format("{0:0.##} - {1:0.##}", valueIntervals[0], valueIntervals[1]);
            faceEyesLabelColor2.Content = String.Format("{0:0.##} - {1:0.##}", valueIntervals[1], valueIntervals[2]);
            faceEyesLabelColor3.Content = String.Format("{0:0.##} - {1:0.##}", valueIntervals[2], valueIntervals[3]);
            faceEyesLabelColor4.Content = String.Format("{0:0.##} - {1:0.##}", valueIntervals[3], valueIntervals[4]);
            faceEyesLabelColor5.Content = String.Format("{0:0.##} - {1:0.##}", valueIntervals[4], valueIntervals[5]);
        }

        private void initChernoffFaceMustacheLegend(double[] valueIntervals)
        {
            new ChernoffFace(new Point(20, 10), 40, 0, ChernoffFace.FacePartNames.Mustache).Draw(faceMustacheCanvas1);
            new ChernoffFace(new Point(20, 10), 40, 1, ChernoffFace.FacePartNames.Mustache).Draw(faceMustacheCanvas2);
            new ChernoffFace(new Point(20, 10), 40, 2, ChernoffFace.FacePartNames.Mustache).Draw(faceMustacheCanvas3);
            new ChernoffFace(new Point(20, 10), 40, 3, ChernoffFace.FacePartNames.Mustache).Draw(faceMustacheCanvas4);
            new ChernoffFace(new Point(20, 10), 40, 4, ChernoffFace.FacePartNames.Mustache).Draw(faceMustacheCanvas5);

            faceMustacheLabelColor1.Content = String.Format("{0:0.##} - {1:0.##}", valueIntervals[0], valueIntervals[1]);
            faceMustacheLabelColor2.Content = String.Format("{0:0.##} - {1:0.##}", valueIntervals[1], valueIntervals[2]);
            faceMustacheLabelColor3.Content = String.Format("{0:0.##} - {1:0.##}", valueIntervals[2], valueIntervals[3]);
            faceMustacheLabelColor4.Content = String.Format("{0:0.##} - {1:0.##}", valueIntervals[3], valueIntervals[4]);
            faceMustacheLabelColor5.Content = String.Format("{0:0.##} - {1:0.##}", valueIntervals[4], valueIntervals[5]);
        }

        private void initChernoffFaceLipsLegend(double[] valueIntervals)
        {
            new ChernoffFace(new Point(20, -10), 40, 0, ChernoffFace.FacePartNames.Lips).Draw(faceLipsCanvas1);
            new ChernoffFace(new Point(20, -10), 40, 1, ChernoffFace.FacePartNames.Lips).Draw(faceLipsCanvas2);
            new ChernoffFace(new Point(20, -10), 40, 2, ChernoffFace.FacePartNames.Lips).Draw(faceLipsCanvas3);
            new ChernoffFace(new Point(20, -10), 40, 3, ChernoffFace.FacePartNames.Lips).Draw(faceLipsCanvas4);
            new ChernoffFace(new Point(20, -10), 40, 4, ChernoffFace.FacePartNames.Lips).Draw(faceLipsCanvas5);

            faceLipsLabelColor1.Content = String.Format("{0:0.##} - {1:0.##}", valueIntervals[0], valueIntervals[1]);
            faceLipsLabelColor2.Content = String.Format("{0:0.##} - {1:0.##}", valueIntervals[1], valueIntervals[2]);
            faceLipsLabelColor3.Content = String.Format("{0:0.##} - {1:0.##}", valueIntervals[2], valueIntervals[3]);
            faceLipsLabelColor4.Content = String.Format("{0:0.##} - {1:0.##}", valueIntervals[3], valueIntervals[4]);
            faceLipsLabelColor5.Content = String.Format("{0:0.##} - {1:0.##}", valueIntervals[4], valueIntervals[5]);
        }
    }
}
