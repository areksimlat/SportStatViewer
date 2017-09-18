using SportStatViewer.Data;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SportStatViewer
{
    /// <summary>
    /// Logika interakcji dla klasy CorrelationCoefficientWindow.xaml
    /// </summary>
    public partial class CorrelationCoefficientWindow : Window
    {
        private DataHolder dataHolder;
        private string[] axisValues = new string[] { "Sekcji", "Ogółem", "Kobiet", "Juniorów", "Juniorek" };

        public CorrelationCoefficientWindow(DataHolder dataHolder)
        {
            InitializeComponent();

            this.dataHolder = dataHolder;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            initComboBoxes();
            initChart();
            update();
        }

        private void initComboBoxes()
        {
            voivodeshipComboBox.Items.Add("Wszystkie");
            sportComboBox.Items.Add("Wszystkie");

            for (int i = 0; i < dataHolder.VoivodeshipCount; i++)
                voivodeshipComboBox.Items.Add(VoivodeshipNamesExtensions.GetName((VoivodeshipNames)i));

            for (int i = 0; i < dataHolder.SportCount; i++)
                sportComboBox.Items.Add(dataHolder.SportNames[i]);

            for (int i = 0; i < axisValues.Length; i++)
            {
                axisXComboBox.Items.Add(axisValues[i]);
                axisYComboBox.Items.Add(axisValues[i]);
            }

            voivodeshipComboBox.SelectedIndex = 0;
            sportComboBox.SelectedIndex = 0;
            axisXComboBox.SelectedIndex = 0;
            axisYComboBox.SelectedIndex = 0;

            voivodeshipComboBox.SelectionChanged += comboBox_SelectionChanged;
            sportComboBox.SelectionChanged += comboBox_SelectionChanged;
            axisXComboBox.SelectionChanged += comboBox_SelectionChanged;
            axisYComboBox.SelectionChanged += comboBox_SelectionChanged;
        }

        private void initChart()
        {            
            chart.ChartAreas["chartArea"].AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chart.ChartAreas["chartArea"].AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
        }

        private void update()
        {
            string axisX = (string)axisXComboBox.SelectedValue;
            string axisY = (string)axisYComboBox.SelectedValue;
            int sportIndex = sportComboBox.SelectedIndex - 1;
            string selectedName = (string)voivodeshipComboBox.SelectedValue;
            VoivodeshipNames selectedArea = VoivodeshipNamesExtensions.Parse(selectedName);
            StatisticsDataFields dataFieldX = (StatisticsDataFields)axisXComboBox.SelectedIndex;
            StatisticsDataFields dataFieldY = (StatisticsDataFields)axisYComboBox.SelectedIndex;

            chart.ChartAreas["chartArea"].AxisX.Title = axisX;
            chart.ChartAreas["chartArea"].AxisY.Title = axisY;
            chart.Series["series"].Points.Clear();

            List<Point> points = dataHolder.GetPointsByCriteria(selectedArea, sportIndex, dataFieldX, dataFieldY);
            double pearsonCoefficient = dataHolder.GetPearsonCorrelationCoefficient(points);
            string pearsonCoefficientDescription = String.Format("{0:0.00} ", pearsonCoefficient);

            if (pearsonCoefficient < 0.2)
                pearsonCoefficientDescription += "(brak związku liniowego)";
            else if (pearsonCoefficient < 0.4)
                pearsonCoefficientDescription += "(słaba zależność)";
            else if (pearsonCoefficient < 0.7)
                pearsonCoefficientDescription += "(umiarkowana zależność)";
            else if (pearsonCoefficient < 0.9)
                pearsonCoefficientDescription += "(dość silna zależność)";
            else 
                pearsonCoefficientDescription += "(bardzo silna zależność)";

            pearsonCoefficientLabel.Content = pearsonCoefficientDescription;

            foreach (Point point in points)
                chart.Series["series"].Points.AddXY(point.X, point.Y);
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            update();
        }
    }
}
