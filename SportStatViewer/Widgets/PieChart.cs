using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SportStatViewer.Widgets
{
    public class PieChart
    {
        private Path[] paths;
        private double currentAngle;
        public double[] PieValues { get; private set; }
        public double[] PieAngles { get; private set; }
        public Point CentrePoint { get; private set; }
        public int Radius { get; private set; }


        public PieChart(Point position, int radius)
        {
            currentAngle = -Math.PI / 2;
            CentrePoint = position;
            Radius = radius;
        }

        public void Create(double[] values)
        {
            paths = new Path[values.Length];
            PieValues = values;
            PieAngles = convertPercentagesToDegreeAngles(convertValuesToPercentages(values));

            for (int i = 0; i < PieAngles.Length; i++)
                addPie(i, PieAngles[i]);
        }

        private Path getArc(double degreeAngle)
        {
            double arcStartPointX = Math.Cos(currentAngle) * Radius + CentrePoint.X;
            double arcStartPointY = Math.Sin(currentAngle) * Radius + CentrePoint.Y;

            currentAngle += DegreeToRadian(degreeAngle);

            double arcEndPointX = Math.Cos(currentAngle) * Radius + CentrePoint.X;
            double arcEndPointY = Math.Sin(currentAngle) * Radius + CentrePoint.Y;

            Point arcStartPoint = new Point(arcStartPointX, arcStartPointY);
            Point arcEndPoint = new Point(arcEndPointX, arcEndPointY);

            LineSegment line1 = new LineSegment(arcStartPoint, true);
            LineSegment line2 = new LineSegment(CentrePoint, true);

            ArcSegment arcSegment = new ArcSegment();
            arcSegment.SweepDirection = SweepDirection.Clockwise;
            arcSegment.Size = new Size(Radius, Radius);
            arcSegment.RotationAngle = degreeAngle;
            arcSegment.Point = arcEndPoint;
            arcSegment.IsLargeArc = degreeAngle > 180.0;

            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = CentrePoint;
            pathFigure.Segments.Add(line1);
            pathFigure.Segments.Add(arcSegment);
            pathFigure.Segments.Add(line2);

            PathFigureCollection pathFigureCollection = new PathFigureCollection();
            pathFigureCollection.Add(pathFigure);

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures = pathFigureCollection;

            Path path = new Path();
            path.Data = pathGeometry;

            return path;
        }

        private Path getEllipse()
        {
            Path path = new Path();
            path.Data = new EllipseGeometry(CentrePoint, Radius, Radius);

            return path;
        }

        private void addPie(int pieIndex, double degreeAngle)
        {
            if (degreeAngle == 360)
                paths[pieIndex] = getEllipse();
            else
                paths[pieIndex] = getArc(degreeAngle);

            paths[pieIndex].Fill = ColorScheme.GetColorByIndex(pieIndex, ColorScheme.ChartPieColors);
        }

        private double[] convertValuesToPercentages(double[] values)
        {
            double[] percentages = new double[values.Length];
            double total = 0;

            for (int i = 0; i < values.Length; i++)
                total += values[i];

            for (int i = 0; i < percentages.Length; i++)
                percentages[i] = (values[i] * 100) / total;

            return percentages;
        }

        private double[] convertPercentagesToDegreeAngles(double[] values)
        {
            double[] degreeAngles = new double[values.Length];

            for (int i = 0; i < values.Length; i++)
                degreeAngles[i] = values[i] * 360.0 / 100.0;

            return degreeAngles;
        }


        public static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        public static double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }


        public Point[] GetMiddleAnglePoints()
        {
            Point[] middlePoints = new Point[PieAngles.Length];
            double currentTotalAngle = -90;
            double x, y, radianAngle;

            for (int i = 0; i < middlePoints.Length; i++)
            {
                radianAngle = DegreeToRadian(currentTotalAngle + (PieAngles[i] / 2));
                currentTotalAngle += PieAngles[i];

                x = this.CentrePoint.X + Math.Cos(radianAngle) * Radius;
                y = this.CentrePoint.Y + Math.Sin(radianAngle) * Radius;

                middlePoints[i] = new Point(x, y);
            }

            return middlePoints;
        }

        public void Draw(Canvas canvas)
        {
            foreach (Path path in paths)
                canvas.Children.Add(path);
        }

        public bool EqualsPath(Path otherPath)
        {
            foreach (Path path in paths)
                if (path.Equals(otherPath))
                    return true;

            return false;
        }
    }
}
