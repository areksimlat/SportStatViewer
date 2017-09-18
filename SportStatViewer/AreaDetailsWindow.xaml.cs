using SportStatViewer.Data;
using SportStatViewer.Map;
using SportStatViewer.Widgets;
using System.Windows;
using System.Windows.Media;

namespace SportStatViewer
{
    /// <summary>
    /// Logika interakcji dla klasy AreaDetailsWindow.xaml
    /// </summary>
    public partial class AreaDetailsWindow : Window
    {
        private double scaleRate = 1.1;
        private int chartSize;
        private Point chartPosition;
        private int previewFaceSize;        
        private Point previewFacePosition;               
        private ChernoffFace[] faces;
        private VoivodeshipNames voivodeshipName;
        private MapPainter mapPainter;

        public AreaDetailsWindow(MapPainter mapPainter, VoivodeshipNames voivodeshipName)
        {
            InitializeComponent();

            this.mapPainter = mapPainter;
            this.voivodeshipName = voivodeshipName;

            previewFacePosition = new Point(faceCanvas.Width / 2, faceCanvas.Height / 2);
            previewFaceSize = (int)(faceCanvas.Width / 3);

            chartPosition = new Point(chartCanvas.Width / 2, chartCanvas.Height / 2);            
            chartSize = (int)(chartCanvas.Width / 4);
        }

        public void Init()
        {
            areaNameLabel.Content = VoivodeshipNamesExtensions.GetName(voivodeshipName);

            PieChart pieChart = new PieChart(chartPosition, chartSize);
            pieChart.Create(mapPainter.GetAreaChartValues((int)voivodeshipName));

            StatisticsData[] statisticsData = mapPainter.Holder.VoivodeshipData[(int)voivodeshipName];
            StatisticsData minData = mapPainter.Holder.GetMinDatasInVoivodeship(voivodeshipName);
            StatisticsData maxData = mapPainter.Holder.GetMaxDatasInVoivodeship(voivodeshipName);
            faces = ChernoffFace.GetFaces(pieChart, statisticsData, minData, maxData);

            pieChart.Draw(chartCanvas);
            chartCanvas.Background = Brushes.Azure;

            foreach (ChernoffFace face in faces)
                face.Draw(chartCanvas);

           // ChernoffFace.AdjustView(faces, chartCanvas, chartCanvasScaleTransform, chartCanvasTranslateTransform);

            foreach (string sportName in mapPainter.Holder.SportNames)
                sportNameCb.Items.Add(sportName);

            if (sportNameCb.Items.Count > 0)
                sportNameCb.SelectedIndex = 0;         
        }

        private void Button_ZoomIn_Click(object sender, RoutedEventArgs e)
        {

            chartCanvas.Width *= scaleRate;
            chartCanvas.Height *= scaleRate;
            chartCanvasScaleTransform.ScaleX *= scaleRate;
            chartCanvasScaleTransform.ScaleY *= scaleRate;
        }

        private void Button_ZoomOut_Click(object sender, RoutedEventArgs e)
        {
            chartCanvas.Width /= scaleRate;
            chartCanvas.Height /= scaleRate;
            chartCanvasScaleTransform.ScaleX /= scaleRate;
            chartCanvasScaleTransform.ScaleY /= scaleRate;
        }

        private void initLabels(StatisticsData data)
        {
            totalLabel.Content = data.Total.ToString();
            sectionsLabel.Content = data.Sections.ToString();
            womensLabel.Content = data.Womens.ToString();
            girlsLabel.Content = data.Girls.ToString();
            boysLabel.Content = data.Boys.ToString();
        }

        private void sportNameCb_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            int selectedIndex = sportNameCb.SelectedIndex;

            ChernoffFace chernoffFace 
                = new ChernoffFace(previewFacePosition, previewFaceSize, faces[selectedIndex]);

            chernoffFace.Draw(faceCanvas);

            initLabels(chernoffFace.Data);
        }

        private void Button_LegendShow_Click(object sender, RoutedEventArgs e)
        {
            LegendWindow legendWindow = new LegendWindow(mapPainter.Holder, voivodeshipName);
            legendWindow.Owner = this;

            legendWindow.Show();
        }
    }
}
