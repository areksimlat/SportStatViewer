using SportStatViewer.Data;
using SportStatViewer.Widgets;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace SportStatViewer.Map
{
    public class MapPainter
    {
        public int BaseWidth { get { return 630; } }
        public int BaseHeight { get { return 590; } }
        public Area BackgroundArea { get; private set; }
        public Area[] VoivodeshipAreas { get; private set; }
        public PieChart[] Charts { get; private set; }
        public DataHolder Holder { get; private set; }


        public MapPainter(DataHolder dataHolder)
        {
            this.Holder = dataHolder;

            VoivodeshipAreas = new Area[dataHolder.VoivodeshipCount];
            Charts = new PieChart[dataHolder.VoivodeshipCount];

            initAreas();
            initCharts();
        }


        private void initAreas()
        {
            BackgroundArea = new BackgroundArea();

            VoivodeshipAreas[(int)VoivodeshipNames.Dolnoslaskie] = new DolnoslaskieArea();
            VoivodeshipAreas[(int)VoivodeshipNames.Kujawskopomorskie] = new KujawskoPomorskieArea();
            VoivodeshipAreas[(int)VoivodeshipNames.Lubelskie] = new LubelskieArea();
            VoivodeshipAreas[(int)VoivodeshipNames.Lubuskie] = new LubuskieArea();
            VoivodeshipAreas[(int)VoivodeshipNames.Lodzkie] = new LodzkieArea();
            VoivodeshipAreas[(int)VoivodeshipNames.Malopolskie] = new MalopolskieArea();
            VoivodeshipAreas[(int)VoivodeshipNames.Mazowieckie] = new MazowieckieArea();
            VoivodeshipAreas[(int)VoivodeshipNames.Opolskie] = new OpolskieArea();
            VoivodeshipAreas[(int)VoivodeshipNames.Podkarpackie] = new PodkarpackieArea();
            VoivodeshipAreas[(int)VoivodeshipNames.Podlaskie] = new PodlaskieArea();
            VoivodeshipAreas[(int)VoivodeshipNames.Pomorskie] = new PomorskieArea();
            VoivodeshipAreas[(int)VoivodeshipNames.Slaskie] = new SlaskieArea();
            VoivodeshipAreas[(int)VoivodeshipNames.Swietokrzyskie] = new SwietokrzyskieArea();
            VoivodeshipAreas[(int)VoivodeshipNames.Warminskomazurskie] = new WarminskoMazurskieArea();
            VoivodeshipAreas[(int)VoivodeshipNames.Wielkopolskie] = new WielkopolskieArea();
            VoivodeshipAreas[(int)VoivodeshipNames.Zachodniopomorskie] = new ZachodnioPomorskieArea();

            double[] totals = Holder.GetSumTotalInAllVoivodeships();
            double minTotal = Holder.GetMin(totals);
            double maxTotal = Holder.GetMax(totals);

            for (int i = 0; i < VoivodeshipAreas.Length; i++)
                VoivodeshipAreas[i].Shape.Fill =
                    ColorScheme.GetColorByIndex(
                        ColorScheme.GetIndexByValue(totals[i], minTotal, maxTotal), 
                        ColorScheme.VoivodeshipColors);            
        }

        private void initCharts()
        {
            double[][] areasTotal = Holder.GetTotalInAllVoivodeships();

            for (int i = 0; i < areasTotal.Length; i++)
            {
                Charts[i] = new PieChart(VoivodeshipAreas[i].ChartPosition, VoivodeshipAreas[i].ChartSize);
                Charts[i].Create(areasTotal[i]);
            }
        }

        public int GetAreaIndexBySource(Object source)
        {
            if (source is Polygon)
            {
                Polygon sourcePolygon = (Polygon)source;

                for (int i = 0; i < VoivodeshipAreas.Length; i++)
                    if (VoivodeshipAreas[i].Shape.Equals(sourcePolygon))
                        return i;
            }
            else if (source is Path)
            {
                Path sourcePath = (Path)source;

                for (int i = 0; i < Charts.Length; i++)
                    if (Charts[i].EqualsPath(sourcePath))
                        return i;
            }

            return -1;
        }

        public Point GetChartPositionByAreaIndex(int areaIndex)
        {
            if (areaIndex >= 0 && areaIndex < VoivodeshipAreas.Length)
                return VoivodeshipAreas[areaIndex].ChartPosition;

            return new Point();
        }

        public double[] GetAreaChartValues(int areaIndex)
        {
            return Charts[areaIndex].PieValues;
        }

        public void DrawAreas(Canvas canvas)
        {
            BackgroundArea.Draw(canvas);

            foreach (Area area in VoivodeshipAreas)
                area.Draw(canvas);

            foreach (PieChart chart in Charts)
                chart.Draw(canvas);
        }
    }
}
