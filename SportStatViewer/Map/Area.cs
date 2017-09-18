using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SportStatViewer.Map
{
    public abstract class Area
    {
        public Polygon Shape { get; private set; }

        public Point ChartPosition { get; private set; }

        public int ChartSize { get; private set; }

        
        protected Area()
        {
            Shape = new Polygon();
            Shape.StrokeThickness = 1;
            Shape.Points = new PointCollection(getAreaPoints());

            ChartPosition = getPieChartPosition();
            ChartSize = getPieChartSize();
        }


        protected abstract Point[] getAreaPoints();

        protected abstract Point getPieChartPosition();

        protected abstract int getPieChartSize();

    
        public virtual void Draw(Canvas canvas)
        {
            canvas.Children.Add(Shape);
        }
    }
}
