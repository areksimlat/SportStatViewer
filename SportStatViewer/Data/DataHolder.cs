using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace SportStatViewer.Data
{
    public class DataHolder
    {
        public StatisticsData[][] VoivodeshipData { get; private set; }
        public string[] SportNames { get; private set; }
        public int VoivodeshipCount { get; private set; }
        public int SportCount { get; private set; }

        public DataHolder()
        {
            VoivodeshipCount = 16;
            SportCount = 0;     
        }


        public int Load(string[] paths)
        {
            int incorrect = 0;

            List<StatisticsData>[] statistics = new List<StatisticsData>[VoivodeshipCount];
            List<string> sportNames = new List<string>();

            for (int i = 0; i < VoivodeshipCount; i++)
                statistics[i] = new List<StatisticsData>();

            foreach (string path in paths)
            {
                StatisticsData[] statisticsData = new StatisticsData[VoivodeshipCount];
                string sportName;

                if (loadFile(path, statisticsData, out sportName))
                {
                    sportNames.Add(sportName);

                    for (int i = 0; i < statisticsData.Length; i++)
                        statistics[i].Add(statisticsData[i]);                    
                }
                else
                {
                    incorrect++;
                }
            }

            if (incorrect != paths.Length)
            {
                SportCount = statistics[0].Count;
                VoivodeshipData = new StatisticsData[VoivodeshipCount][];

                for (int i = 0; i < VoivodeshipCount; i++)
                        VoivodeshipData[i] = statistics[i].ToArray();

                SportNames = sportNames.ToArray();
            }

            return incorrect;
        }

        private bool loadFile(string path, StatisticsData[] statistics, out string sportName)
        {
            string line;
            int sections, total, womens, boys, girls;
            VoivodeshipNames vooivodeshipName;
            StatisticsData statisticsData;

            using (StreamReader reader = new StreamReader(path))
            {
                sportName = reader.ReadLine();

                if (string.IsNullOrEmpty(sportName) || sportName.Split(';').Length > 1)
                    return false;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] readedData = line.Split(';');

                    statisticsData = null;
                    vooivodeshipName = VoivodeshipNames.None;

                    try
                    {
                        vooivodeshipName = VoivodeshipNamesExtensions.Parse(readedData[0]);

                        if (vooivodeshipName == VoivodeshipNames.None)
                            return false;

                        if (Int32.TryParse(readedData[1], out sections) &&
                            Int32.TryParse(readedData[2], out total) &&
                            Int32.TryParse(readedData[3], out womens) &&
                            Int32.TryParse(readedData[4], out boys) &&
                            Int32.TryParse(readedData[5], out girls))
                        {
                            statisticsData = new StatisticsData(
                                sections,
                                total,
                                womens,
                                boys,
                                girls);
                        }
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }

                    statistics[(int)vooivodeshipName] = statisticsData;
                }
            }

            return true;
        }


        public double[] GetSumTotalInAllVoivodeships()
        {
            double[] sums = new double[VoivodeshipCount];

            for (int i = 0; i < VoivodeshipCount; i++)
                for (int j = 0; j < SportCount; j++)
                    sums[i] += VoivodeshipData[i][j].Total;           

            return sums;
        }

        public double[][] GetTotalInAllVoivodeships()
        {
            double[][] result = new double[VoivodeshipCount][];

            for (int i = 0; i < VoivodeshipCount; i++)
            {
                result[i] = new double[SportCount];

                for (int j = 0; j < SportCount; j++)
                    result[i][j] = VoivodeshipData[i][j].Total;
            }

            return result;
        }


        public StatisticsData GetMaxDatasInVoivodeship(VoivodeshipNames name)
        {
            int maxSections = int.MinValue;
            int maxTotal = int.MinValue;
            int maxWomens = int.MinValue;
            int maxBoys = int.MinValue;
            int maxGirls = int.MinValue;

            for (int i = 0; i < SportCount; i++)
            {
                if (maxSections < VoivodeshipData[(int)name][i].Sections)
                    maxSections = VoivodeshipData[(int)name][i].Sections;

                if (maxTotal < VoivodeshipData[(int)name][i].Total)
                    maxTotal = VoivodeshipData[(int)name][i].Total;

                if (maxWomens < VoivodeshipData[(int)name][i].Womens)
                    maxWomens = VoivodeshipData[(int)name][i].Womens;

                if (maxBoys < VoivodeshipData[(int)name][i].Boys)
                    maxBoys = VoivodeshipData[(int)name][i].Boys;

                if (maxGirls < VoivodeshipData[(int)name][i].Girls)
                    maxGirls = VoivodeshipData[(int)name][i].Girls;
            }

            return new StatisticsData(maxSections, maxTotal, maxWomens, maxBoys, maxGirls);
        }

        public StatisticsData GetMinDatasInVoivodeship(VoivodeshipNames name)
        {
            int minSections = int.MaxValue;
            int minTotal = int.MaxValue;
            int minWomens = int.MaxValue;
            int minBoys = int.MaxValue;
            int minGirls = int.MaxValue;

            for (int i = 0; i < SportCount; i++)
            {
                if (minSections > VoivodeshipData[(int)name][i].Sections)
                    minSections = VoivodeshipData[(int)name][i].Sections;

                if (minTotal > VoivodeshipData[(int)name][i].Total)
                    minTotal = VoivodeshipData[(int)name][i].Total;

                if (minWomens > VoivodeshipData[(int)name][i].Womens)
                    minWomens = VoivodeshipData[(int)name][i].Womens;

                if (minBoys > VoivodeshipData[(int)name][i].Boys)
                    minBoys = VoivodeshipData[(int)name][i].Boys;

                if (minGirls > VoivodeshipData[(int)name][i].Girls)
                    minGirls = VoivodeshipData[(int)name][i].Girls;
            }

            return new StatisticsData(minSections, minTotal, minWomens, minBoys, minGirls);
        }


        public double GetMin(double[] values)
        {
            double minValue = values[0];

            for (int i = 1; i < values.Length; i++)
                if (minValue > values[i])
                    minValue = values[i];

            return minValue;
        }

        public double GetMax(double[] values)
        {
            double maxValue = values[0];

            for (int i = 1; i < values.Length; i++)
                if (maxValue < values[i])
                    maxValue = values[i];

            return maxValue;
        }


        private List<int> getDataByCriteria(VoivodeshipNames name, int sportIndex, StatisticsDataFields field)
        {
            List<int> dataList = new List<int>();

            if (name != VoivodeshipNames.None && sportIndex >= 0)
            {
                dataList.Add(VoivodeshipData[(int)name][sportIndex].GetByFiled(field));
            }
            else if (name != VoivodeshipNames.None)
            {
                for (int i = 0; i < VoivodeshipData[(int)name].Length; i++)
                    dataList.Add(VoivodeshipData[(int)name][i].GetByFiled(field));
            }
            else if (sportIndex >= 0)
            {
                for (int i = 0; i < VoivodeshipData.Length; i++)
                    dataList.Add(VoivodeshipData[i][sportIndex].GetByFiled(field));
            }
            else
            {
                for (int i = 0; i < VoivodeshipData.Length; i++)
                    for (int j = 0; j < VoivodeshipData[i].Length; j++)
                        dataList.Add(VoivodeshipData[i][j].GetByFiled(field));
            }

            return dataList;
        }

        public List<Point> GetPointsByCriteria(VoivodeshipNames name, int sportIndex, 
            StatisticsDataFields fieldX, StatisticsDataFields fieldY)
        {
            List<Point> points = new List<Point>();

            if (name != VoivodeshipNames.None && sportIndex >= 0)
            {
                points.Add(new Point(
                    VoivodeshipData[(int)name][sportIndex].GetByFiled(fieldX),
                    VoivodeshipData[(int)name][sportIndex].GetByFiled(fieldY)
                    ));
            }
            else if (name != VoivodeshipNames.None)
            {
                for (int i = 0; i < VoivodeshipData[(int)name].Length; i++)
                    points.Add(new Point(
                        VoivodeshipData[(int)name][i].GetByFiled(fieldX),
                        VoivodeshipData[(int)name][i].GetByFiled(fieldY)
                        ));
            }
            else if (sportIndex >= 0)
            {
                for (int i = 0; i < VoivodeshipData.Length; i++)
                    points.Add(new Point(
                        VoivodeshipData[i][sportIndex].GetByFiled(fieldX),
                        VoivodeshipData[i][sportIndex].GetByFiled(fieldY)
                        ));
            }
            else
            {
                for (int i = 0; i < VoivodeshipData.Length; i++)
                    for (int j = 0; j < VoivodeshipData[i].Length; j++)
                        points.Add(new Point(
                            VoivodeshipData[i][j].GetByFiled(fieldX),
                            VoivodeshipData[i][j].GetByFiled(fieldY)
                            ));
            }

            return points;
        }

        private double getArithmeticAverage(List<int> data)
        {
            int sum = 0;

            foreach (int value in data)
                sum += value;

            return sum / (double)data.Count;
        }

        public double GetArithmeticAverage(VoivodeshipNames name, int sportIndex, StatisticsDataFields field)
        {
            List<int> data = getDataByCriteria(name, sportIndex, field);

            return getArithmeticAverage(data);            
        }

        private int getMedian(List<int> sortedData)
        {
            if (sortedData.Count % 2 == 0)
            {
                int middle = sortedData.Count / 2;
                int average = (sortedData[middle] + sortedData[middle + 1]) / 2;

                return average;
            }

            return sortedData[sortedData.Count / 2];
        }

        public int GetMedian(VoivodeshipNames name, int sportIndex, StatisticsDataFields field)
        {
            List<int> data = getDataByCriteria(name, sportIndex, field);
            data.Sort();

            return getMedian(data);            
        }

        public List<int> GetDominant(VoivodeshipNames name, int sportIndex, StatisticsDataFields field)
        {
            List<int> data = getDataByCriteria(name, sportIndex, field);
            data.Sort();

            int maxValue = int.MinValue;
            int count;

            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            foreach (int value in data)
            {
                if (dictionary.TryGetValue(value, out count))
                {
                    count += 1;
                    dictionary[value] = count;
                }
                else
                {
                    count = 1;
                    dictionary.Add(value, count);
                }

                if (count > maxValue)
                    maxValue = count;
            }

            List<int> results = new List<int>();

            foreach (KeyValuePair<int, int> entry in dictionary)
                if (entry.Value == maxValue)
                    results.Add(entry.Key);

            return results;
        }

        public double GetQuarterDeviation(VoivodeshipNames name, int sportIndex, StatisticsDataFields field)
        {
            List<int> data = getDataByCriteria(name, sportIndex, field);
            data.Sort();

            if (data.Count < 2)
                return 0;

            double lowerQuartile, upperQuartile;
            int index;

            if (data.Count % 4 == 0)
            {
                index = data.Count / 4;
                lowerQuartile = (data[index] + data[index + 1]) / 2;
            }
            else
            {
                index = (int)Math.Round(data.Count / 4.0);
                lowerQuartile = data[index];
            }


            if ((3 * data.Count) % 4 == 0)
            {
                index = (3 * data.Count) / 4;
                upperQuartile = (data[index] + data[index + 1]) / 2;
            }
            else
            {
                index = (int)Math.Round((3 * data.Count) / 4.0);
                upperQuartile = data[index];
            }

            return (upperQuartile - lowerQuartile) / 2.0;
        }

        private double getStandardDeviation(List<int> data)
        {
            int total = 0;
            int sum = 0;

            foreach (int value in data)
            {
                total += value * value;
                sum += value;
            }

            double average = sum / (double)data.Count;

            return Math.Sqrt((total / (double)data.Count) - (average * average));
        }

        public double GetStandardDeviation(VoivodeshipNames name, int sportIndex, StatisticsDataFields field)
        {
            List<int> data = getDataByCriteria(name, sportIndex, field);

            return getStandardDeviation(data);
        }

        public double GetSkewness(VoivodeshipNames name, int sportIndex, StatisticsDataFields field)
        {
            List<int> data = getDataByCriteria(name, sportIndex, field);

            double arithmeticAverage = getArithmeticAverage(data);
            double standardDeviation = getStandardDeviation(data);

            data.Sort();
            double median = getMedian(data);

            return 3 * ((arithmeticAverage - median) / standardDeviation);
        }

        public double GetGiniCoefficient(VoivodeshipNames name, int sportIndex, StatisticsDataFields field)
        {
            List<int> data = getDataByCriteria(name, sportIndex, field);
            data.Sort();

            int sum = 0;
            double avg = 0;

            for (int i = 0; i < data.Count; i++)
            {
                sum += (2 * i - data.Count - 1) * data[i];
                avg += data[i];
            }

            avg /= data.Count;

            return sum / ((data.Count * data.Count) * avg);
        }


        public double GetPearsonCorrelationCoefficient(List<Point> points)
        {
            int n = points.Count;
            double sumX = 0, sumY = 0, sumXSqr = 0, sumYSqr = 0, sumProductXY = 0;

            foreach (Point point in points)
            {
                sumX += point.X;
                sumY += point.Y;
                sumProductXY += point.X * point.Y;
                sumXSqr += point.X * point.X;
                sumYSqr += point.Y * point.Y;
            }

            double avgX = sumX / n;
            double avgY = sumY / n;

            double r = ((sumProductXY / n) - (avgX * avgY)) / Math.Sqrt(
                ((sumXSqr / n) - (avgX * avgX)) * ((sumYSqr / n) - (avgY * avgY)));

            return r;
        }
    }
}
