using Microsoft.Win32;
using SportStatViewer.Data;
using SportStatViewer.Map;
using SportStatViewer.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SportStatViewer
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const double scaleRate = 1.1;
        private int currentActivePreview = -1;
        private LegendWindow legendWindow;

        private DataHolder dataHolder = null;
        private MapPainter mapPainter;

        public MainWindow()
        {
            InitializeComponent();

            initWindowSize();
        }

        private void initTreeViewData()
        {
            dataTreeView.Items.Clear();

            for (int i = 0; i < dataHolder.VoivodeshipCount; i++)
            {
                TreeViewItem item = new TreeViewItem()
                {
                    Header = VoivodeshipNamesExtensions.GetName((VoivodeshipNames)i)
                };

                for (int j = 0; j < dataHolder.SportCount; j++)
                {
                    TreeViewItem sportItem = new TreeViewItem()
                    {
                        Header = dataHolder.SportNames[j]
                    };

                    sportItem.Items.Add(new TreeViewItem()
                    {
                        Header = "Sekcji: " + dataHolder.VoivodeshipData[i][j].Sections
                    });

                    sportItem.Items.Add(new TreeViewItem()
                    {
                        Header = "Ogółem: " + dataHolder.VoivodeshipData[i][j].Total
                    });

                    sportItem.Items.Add(new TreeViewItem()
                    {
                        Header = "Kobiet: " + dataHolder.VoivodeshipData[i][j].Womens
                    });

                    sportItem.Items.Add(new TreeViewItem()
                    {
                        Header = "Juniorów: " + dataHolder.VoivodeshipData[i][j].Boys
                    });

                    sportItem.Items.Add(new TreeViewItem()
                    {
                        Header = "Juniorek: " + dataHolder.VoivodeshipData[i][j].Girls
                    });

                    item.Items.Add(sportItem);
                }

                dataTreeView.Items.Add(item);
            }
        }

        private void initWindowSize()
        {
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double screenWidth = SystemParameters.PrimaryScreenWidth;

            double height = screenHeight * .7;
            double width = screenWidth * .7;

            double size = height > width ? width : height;

            mapCanvas.Width *= size;
            mapCanvas.Height *= size;
            mapScrollViewer.Width = size;
            mapScrollViewer.Height = size;
        }

        private void initView()
        {
            initTreeViewData();

            mapPainter = new MapPainter(dataHolder);
            mapPainter.DrawAreas(mapCanvas);

            double mapScaleRateX = (mapScrollViewer.Width - 25) / mapPainter.BaseWidth;
            double mapScaleRateY = (mapScrollViewer.Height - 25) / mapPainter.BaseHeight;
            double mapScaleRate = mapScaleRateX > mapScaleRateY ? mapScaleRateY : mapScaleRateX;

            mapCanvas.Width *= mapScaleRate;
            mapCanvas.Height *= mapScaleRate;
            mapCanvasScaleTransform.ScaleX = mapScaleRate;
            mapCanvasScaleTransform.ScaleY = mapScaleRate;
        }


        private void MenuItem_Load_Click(object sender, RoutedEventArgs e)
        {
            dataHolder = new DataHolder();            

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".csv";
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv|TXT Files (.txt)|*.txt";
            openFileDialog.Multiselect = true;

            Nullable<bool> result = openFileDialog.ShowDialog();

            if (result.HasValue && result.Value)
            {
                int incorrectFiles = dataHolder.Load(openFileDialog.FileNames);
                int allFiles = openFileDialog.FileNames.Length;
                    
                MessageBox.Show(String.Format(
                    "Wczytano {0} z {1} plików", (allFiles - incorrectFiles), allFiles)
                    );

                initView();
            }
        }

        private void MenuItem_BasicMeasures_Click(object sender, RoutedEventArgs e)
        {
            if (dataHolder != null)
            {
                previewPopup.IsOpen = false;

                BasicMeasuresWindow basicMeasuresWindow = new BasicMeasuresWindow(dataHolder);
                basicMeasuresWindow.Owner = this;
                basicMeasuresWindow.ShowDialog();
            }
        }

        private void MenuItem_CorrelationCoefficient_Click(object sender, RoutedEventArgs e)
        {
            if (dataHolder != null)
            {
                previewPopup.IsOpen = false;

                CorrelationCoefficientWindow correlationCoefficientWindow = new CorrelationCoefficientWindow(dataHolder);
                correlationCoefficientWindow.Owner = this;
                correlationCoefficientWindow.ShowDialog();
            }
        }

        private void MenuItem_LegendShow_Click(object sender, RoutedEventArgs e)
        {
            if (dataHolder != null)
            {
                legendWindow = new LegendWindow(dataHolder, VoivodeshipNames.None);
                legendWindow.Owner = this;

                legendWindow.Show();
            }
        }


        private void Button_ZoomIn_Click(object sender, RoutedEventArgs e)
        {
            mapCanvas.Width *= scaleRate;
            mapCanvas.Height *= scaleRate;
            mapCanvasScaleTransform.ScaleX *= scaleRate;
            mapCanvasScaleTransform.ScaleY *= scaleRate;
        }

        private void Button_ZoomOut_Click(object sender, RoutedEventArgs e)
        {
            mapCanvas.Width /= scaleRate;
            mapCanvas.Height /= scaleRate;
            mapCanvasScaleTransform.ScaleX /= scaleRate;
            mapCanvasScaleTransform.ScaleY /= scaleRate;
        }

        private void drawPreview(int areaIndex)
        {
            VoivodeshipNames areaName = (VoivodeshipNames)areaIndex;
            prevLabel.Content = VoivodeshipNamesExtensions.GetName(areaName);

            Point chartPosition = new Point(previewCanvas.Width / 2, previewCanvas.Height / 2);
            int chartSize = (int)(previewCanvas.Width / 4);

            PieChart pieChart = new PieChart(chartPosition, chartSize);
            pieChart.Create(mapPainter.GetAreaChartValues(areaIndex));

            StatisticsData[] statisticsData = mapPainter.Holder.VoivodeshipData[areaIndex];
            StatisticsData minData = mapPainter.Holder.GetMinDatasInVoivodeship(areaName);
            StatisticsData maxData = mapPainter.Holder.GetMaxDatasInVoivodeship(areaName);
            ChernoffFace[] faces = ChernoffFace.GetFaces(pieChart, statisticsData, minData, maxData);

            previewCanvas.Children.Clear();

            pieChart.Draw(previewCanvas);

            foreach (ChernoffFace face in faces)
                face.Draw(previewCanvas);
        }

        private void mapCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (mapPainter == null)
                return;

            int areaIndex = mapPainter.GetAreaIndexBySource(e.Source);

            if (areaIndex == -1)
            {
                previewPopup.IsOpen = false;
                currentActivePreview = -1;
                return;
            }

            if (areaIndex != currentActivePreview)
            {
                previewPopup.IsOpen = false;

                Point placementPoint = mapPainter.GetChartPositionByAreaIndex(areaIndex);
                previewPopup.HorizontalOffset = placementPoint.X;
                previewPopup.VerticalOffset = placementPoint.Y;

                drawPreview(areaIndex);
                previewPopup.IsOpen = true;
                currentActivePreview = areaIndex;


            }
        }

        private void mapCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (mapPainter == null)
                return;

            int areaIndex = mapPainter.GetAreaIndexBySource(e.Source);
            
            if (areaIndex != -1)
            {
                previewPopup.IsOpen = false;

                AreaDetailsWindow detailsWindow
                    = new AreaDetailsWindow(mapPainter, (VoivodeshipNames)areaIndex);

                detailsWindow.Owner = this;
                detailsWindow.Init();
                detailsWindow.ShowDialog();
            }
        }

        private void previewPopup_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (currentActivePreview != -1)
            {
                previewPopup.IsOpen = false;

                AreaDetailsWindow detailsWindow
                    = new AreaDetailsWindow(mapPainter, (VoivodeshipNames)currentActivePreview);

                detailsWindow.Owner = this;
                detailsWindow.Init();
                detailsWindow.ShowDialog();
            }
        }
    }
}
