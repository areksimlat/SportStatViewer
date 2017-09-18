using SportStatViewer.Data;
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

namespace SportStatViewer
{
    /// <summary>
    /// Logika interakcji dla klasy BasicMeasuresWindow.xaml
    /// </summary>
    public partial class BasicMeasuresWindow : Window
    {
        private DataHolder dataHolder;

        public BasicMeasuresWindow(DataHolder dataHolder)
        {
            InitializeComponent();

            this.dataHolder = dataHolder;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            initComboBoxes();
            updateResults();
        }

        private void initComboBoxes()
        {
            voivodeshipComboBox.Items.Add("Polska");
            sportComboBox.Items.Add("Wszystkie");

            for (int i = 0; i < dataHolder.VoivodeshipCount; i++)
                voivodeshipComboBox.Items.Add(VoivodeshipNamesExtensions.GetName((VoivodeshipNames)i));

            for (int i = 0; i < dataHolder.SportCount; i++)
                sportComboBox.Items.Add(dataHolder.SportNames[i]);

            propertyComboBox.Items.Add("Sekcji");
            propertyComboBox.Items.Add("Ogółem");
            propertyComboBox.Items.Add("Kobiet");
            propertyComboBox.Items.Add("Juniorów");
            propertyComboBox.Items.Add("Juniorek");

            voivodeshipComboBox.SelectedIndex = 0;
            voivodeshipComboBox.SelectionChanged += comboBox_SelectionChanged;

            sportComboBox.SelectedIndex = 0;
            sportComboBox.SelectionChanged += comboBox_SelectionChanged;

            propertyComboBox.SelectedIndex = 0;
            propertyComboBox.SelectionChanged += comboBox_SelectionChanged;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateResults();
        }

        private void updateResults()
        {
            string selectedName = (string)voivodeshipComboBox.SelectedValue;
            VoivodeshipNames selectedArea = VoivodeshipNamesExtensions.Parse(selectedName);

            int sportIndex = sportComboBox.SelectedIndex - 1;
            StatisticsDataFields dataField = (StatisticsDataFields)propertyComboBox.SelectedIndex;

            double arithmeticAverage = dataHolder.GetArithmeticAverage(selectedArea, sportIndex, dataField);
            int median = dataHolder.GetMedian(selectedArea, sportIndex, dataField);

            String dominant = "";
            foreach (int dominantValue in dataHolder.GetDominant(selectedArea, sportIndex, dataField))
                dominant += dominantValue + ", ";

            double quarterDeviation = dataHolder.GetQuarterDeviation(selectedArea, sportIndex, dataField);
            double standardDeviation = dataHolder.GetStandardDeviation(selectedArea, sportIndex, dataField);
            double skewness = dataHolder.GetSkewness(selectedArea, sportIndex, dataField);
            double giniCoefficient = dataHolder.GetGiniCoefficient(selectedArea, sportIndex, dataField);

            String skewnessDescription = String.Format("{0:0.00} ", skewness);

            if (skewness < 0)
                skewnessDescription += "(Lewostronna asymetria)";
            else if (skewness > 0)
                skewnessDescription += "(Prawostronna asymetria)";
            else
                skewnessDescription += "(Rozkład symetryczny)";

            arithmeticAverageLabel.Content = String.Format("{0:0.00}", arithmeticAverage);
            medianLabel.Content = median.ToString();
            dominantLabel.Content = dominant;
            quarterDeviationLabel.Content = String.Format("{0:0.00}", quarterDeviation);
            standardDeviationLabel.Content = String.Format("{0:0.00}", standardDeviation);
            skewnessLabel.Content = skewnessDescription;
            giniCoefficientLabel.Content = String.Format("{0:0.00}", giniCoefficient);
        }
    }
}
