using SportStatViewer.Data;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SportStatViewer.Widgets
{
    public class ChernoffFace
    {
        public enum FacePartNames { Face, Eyes, Mustache, Lips }
        private int[] facePartTypes;
        private int strokeThickness = 1;
        private SolidColorBrush bkgColor;

        public Point CentrePoint { get; private set; }
        public int Radius { get; private set; }
        public StatisticsData Data { get; private set; }
        public Path[][] Shapes { get; private set; }
        

        public ChernoffFace(Point centrePoint, int radius, StatisticsData statisticsData, 
            StatisticsData minData, StatisticsData maxData)
        {
            CentrePoint = centrePoint;
            Radius = radius;
            Data = statisticsData;

            bkgColor = ColorScheme.GetColorByIndex(
                ColorScheme.GetIndexByValue(statisticsData.Sections, minData.Sections, maxData.Sections),
                ColorScheme.FaceColors);

            facePartTypes = new int[Enum.GetNames(typeof(FacePartNames)).Length];
            facePartTypes[(int)FacePartNames.Face] = 0;
            facePartTypes[(int)FacePartNames.Eyes] = ColorScheme.GetIndexByValue(statisticsData.Boys, minData.Boys, maxData.Boys);
            facePartTypes[(int)FacePartNames.Mustache] = ColorScheme.GetIndexByValue(statisticsData.Womens, minData.Womens, maxData.Womens);
            facePartTypes[(int)FacePartNames.Lips] = ColorScheme.GetIndexByValue(statisticsData.Girls, minData.Girls, maxData.Girls);

            Shapes = new Path[Enum.GetNames(typeof(FacePartNames)).Length][];
            Shapes[(int)FacePartNames.Face] = getFace();
            Shapes[(int)FacePartNames.Eyes] = getEyes(facePartTypes[(int)FacePartNames.Eyes]);
            Shapes[(int)FacePartNames.Mustache] = getMustache(facePartTypes[(int)FacePartNames.Mustache]);
            Shapes[(int)FacePartNames.Lips] = getLips(facePartTypes[(int)FacePartNames.Lips]);
        }

        public ChernoffFace(Point centrePoint, int radius, ChernoffFace chernoffFace)
        {
            CentrePoint = centrePoint;
            Radius = radius;
            Data = chernoffFace.Data;
            bkgColor = chernoffFace.bkgColor;

            facePartTypes = new int[Enum.GetNames(typeof(FacePartNames)).Length];
            Array.Copy(chernoffFace.facePartTypes, facePartTypes, facePartTypes.Length);

            Shapes = new Path[Enum.GetNames(typeof(FacePartNames)).Length][];
            Shapes[(int)FacePartNames.Face] = getFace();
            Shapes[(int)FacePartNames.Eyes] = getEyes(facePartTypes[(int)FacePartNames.Eyes]);
            Shapes[(int)FacePartNames.Mustache] = getMustache(facePartTypes[(int)FacePartNames.Mustache]);
            Shapes[(int)FacePartNames.Lips] = getLips(facePartTypes[(int)FacePartNames.Lips]);
        }

        public ChernoffFace(Point centrePoint, int radius, int index, FacePartNames partName)
        {
            CentrePoint = centrePoint;
            Radius = radius;

            Shapes = new Path[1][];

            if (partName == FacePartNames.Eyes)
                Shapes[0] = getEyes(index);
            else if (partName == FacePartNames.Mustache)
                Shapes[0] = getMustache(index);
            else if (partName == FacePartNames.Lips)
                Shapes[0] = getLips(index);
        }

        private Path[] getFace()
        {
            Path[] faceParts = new Path[1];

            faceParts[0] = new Path();
            faceParts[0].Data = new EllipseGeometry(CentrePoint, Radius, Radius);

            faceParts[0].StrokeThickness = strokeThickness;
            faceParts[0].Stroke = new SolidColorBrush(ColorScheme.FaceBorderColor);
            faceParts[0].Fill = bkgColor;

            return faceParts;
        }


        private Path[] getEyes(int type)
        {
            switch (type)
            {
                case 0:
                    return getEyes1();

                case 1:
                    return getEyes2();

                case 2:
                    return getEyes3();

                case 3:
                    return getEyes4();

                default:
                    return getEyes5();

            }
        }

        private Path[] getEyes1()
        {
            Path[] eyeParts = new Path[4];

            Point eye1Center = new Point(CentrePoint.X - Radius * 0.3, CentrePoint.Y - Radius * 0.5);
            Point eye2Center = new Point(CentrePoint.X + Radius * 0.25, CentrePoint.Y - Radius * 0.5);

            eyeParts[0] = new Path();
            eyeParts[0].Data = new EllipseGeometry(eye1Center, Radius * 0.3, Radius * 0.4);
            eyeParts[0].StrokeThickness = strokeThickness;
            eyeParts[0].Stroke = new SolidColorBrush(Colors.Black);
            eyeParts[0].Fill = new SolidColorBrush(Colors.White);

            TransformGroup eye2Group = new TransformGroup();
            eye2Group.Children.Add(new RotateTransform(-20, eye2Center.X, eye2Center.Y));

            eyeParts[1] = new Path();
            eyeParts[1].Data = new EllipseGeometry(eye2Center, Radius * 0.3, Radius * 0.4);
            eyeParts[1].StrokeThickness = strokeThickness;
            eyeParts[1].Stroke = new SolidColorBrush(Colors.Black);
            eyeParts[1].Fill = new SolidColorBrush(Colors.White);
            eyeParts[1].RenderTransform = eye2Group;

            eyeParts[2] = new Path();
            eyeParts[2].Data = new EllipseGeometry(eye1Center, Radius * 0.15, Radius * 0.12);
            eyeParts[2].StrokeThickness = strokeThickness;
            eyeParts[2].Stroke = new SolidColorBrush(Colors.Black);
            eyeParts[2].Fill = new SolidColorBrush(Colors.Black);

            eyeParts[3] = new Path();
            eyeParts[3].Data = new EllipseGeometry(eye2Center, Radius * 0.15, Radius * 0.12);
            eyeParts[3].StrokeThickness = strokeThickness;
            eyeParts[3].Stroke = new SolidColorBrush(Colors.Black);
            eyeParts[3].Fill = new SolidColorBrush(Colors.Black);

            return eyeParts;
        }

        private Path[] getEyes2()
        {
            Path[] eyeParts = new Path[3];

            eyeParts[0] = new Path();
            eyeParts[0].Data = new EllipseGeometry(new Point(CentrePoint.X + Radius * 0.25, CentrePoint.Y - Radius * 0.5), Radius * 0.3, Radius * 0.4);
            eyeParts[0].StrokeThickness = strokeThickness;
            eyeParts[0].Stroke = new SolidColorBrush(Colors.Black);
            eyeParts[0].Fill = new SolidColorBrush(Colors.White);

            eyeParts[1] = new Path();
            eyeParts[1].Data = new EllipseGeometry(new Point(CentrePoint.X + Radius * 0.15, CentrePoint.Y - Radius * 0.5), Radius * 0.15, Radius * 0.2);
            eyeParts[1].StrokeThickness = strokeThickness;
            eyeParts[1].Stroke = new SolidColorBrush(Colors.Black);
            eyeParts[1].Fill = new SolidColorBrush(Colors.Black);


            BezierSegment bezierSegment1 = new BezierSegment(
                new Point(CentrePoint.X - Radius * 0.7, CentrePoint.Y - Radius * 0.7),
                new Point(CentrePoint.X - Radius * 0.4, CentrePoint.Y + Radius * 0.3),
                new Point(CentrePoint.X - Radius * 0.1, CentrePoint.Y - Radius * 0.7),
                false
                );

            BezierSegment bezierSegment2 = new BezierSegment(
                new Point(CentrePoint.X - Radius * 0.12, CentrePoint.Y - Radius * 0.7),                
                new Point(CentrePoint.X - Radius * 0.4, CentrePoint.Y + Radius * 0.1),
                new Point(CentrePoint.X - Radius * 0.7, CentrePoint.Y - Radius * 0.7),
                false
                );

            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(CentrePoint.X - Radius * 0.7, CentrePoint.Y - Radius * 0.7);
            pathFigure.Segments.Add(bezierSegment1);
            pathFigure.Segments.Add(bezierSegment2);

            PathFigureCollection pathFigureCollection = new PathFigureCollection();
            pathFigureCollection.Add(pathFigure);

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures = pathFigureCollection;

            eyeParts[2] = new Path();
            eyeParts[2].Data = pathGeometry;
            eyeParts[2].StrokeThickness = strokeThickness;
            eyeParts[2].Stroke = new SolidColorBrush(Colors.Black);
            eyeParts[2].Fill = new SolidColorBrush(Colors.Black);

            return eyeParts;
        }

        private Path[] getEyes3()
        {
            Path[] eyeParts = new Path[3];

            eyeParts[0] = new Path();
            eyeParts[0].Data = new EllipseGeometry(new Point(CentrePoint.X - Radius * 0.3, CentrePoint.Y - Radius * 0.5), Radius * 0.3, Radius * 0.4);
            eyeParts[0].StrokeThickness = strokeThickness;
            eyeParts[0].Stroke = new SolidColorBrush(Colors.Black);
            eyeParts[0].Fill = new SolidColorBrush(Colors.White);

            eyeParts[1] = new Path();
            eyeParts[1].Data = new EllipseGeometry(new Point(CentrePoint.X - Radius * 0.25, CentrePoint.Y - Radius * 0.4), Radius * 0.2, Radius * 0.25);
            eyeParts[1].StrokeThickness = strokeThickness;
            eyeParts[1].Stroke = new SolidColorBrush(Colors.Black);
            eyeParts[1].Fill = new SolidColorBrush(Colors.Black);

            BezierSegment bezierSegment1 = new BezierSegment(
                new Point(CentrePoint.X + Radius * 0.1, CentrePoint.Y - Radius * 0.15),
                new Point(CentrePoint.X + Radius * 0.4, CentrePoint.Y - Radius * 0.7),
                new Point(CentrePoint.X + Radius * 0.7, CentrePoint.Y - Radius * 0.4),
                false
                );

            BezierSegment bezierSegment2 = new BezierSegment(
                new Point(CentrePoint.X + Radius * 0.7, CentrePoint.Y - Radius * 0.4),
                new Point(CentrePoint.X + Radius * 0.4, CentrePoint.Y - Radius * 0.5),
                new Point(CentrePoint.X + Radius * 0.15, CentrePoint.Y - Radius * 0.15),
                false
                );

            BezierSegment bezierSegment3 = new BezierSegment(
                new Point(CentrePoint.X + Radius * 0.15, CentrePoint.Y - Radius * 0.17),
                new Point(CentrePoint.X + Radius * 0.3, CentrePoint.Y - Radius * 0.3),
                new Point(CentrePoint.X + Radius * 0.6, CentrePoint.Y - Radius * 0.25),
                false
                );

            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(CentrePoint.X + Radius * 0.1, CentrePoint.Y - Radius * 0.15);
            pathFigure.Segments.Add(bezierSegment1);
            pathFigure.Segments.Add(bezierSegment2);
            pathFigure.Segments.Add(bezierSegment3);

            PathFigureCollection pathFigureCollection = new PathFigureCollection();
            pathFigureCollection.Add(pathFigure);

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures = pathFigureCollection;

            eyeParts[2] = new Path();
            eyeParts[2].Data = pathGeometry;
            eyeParts[2].StrokeThickness = strokeThickness;
            eyeParts[2].Stroke = new SolidColorBrush(Colors.Black);
            eyeParts[2].Fill = new SolidColorBrush(Colors.Black);

            return eyeParts;
        }

        private Path[] getEyes4()
        {
            Path[] eyeParts = new Path[2];

            BezierSegment bezierSegment1 = new BezierSegment(
               new Point(CentrePoint.X - Radius * 0.3, CentrePoint.Y - Radius * 0.1),
               new Point(CentrePoint.X - Radius * 0.8, CentrePoint.Y - Radius * 0.8),
               new Point(CentrePoint.X - Radius * 0.3, CentrePoint.Y - Radius * 0.6),
               false
               );

            BezierSegment bezierSegment2 = new BezierSegment(
               new Point(CentrePoint.X - Radius * 0.3, CentrePoint.Y - Radius * 0.6),               
               new Point(CentrePoint.X + Radius * 0.2, CentrePoint.Y - Radius * 0.8),
               new Point(CentrePoint.X - Radius * 0.3, CentrePoint.Y - Radius * 0.1),
               false
               );

            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(CentrePoint.X - Radius * 0.3, CentrePoint.Y - Radius * 0.1);
            pathFigure.Segments.Add(bezierSegment1);
            pathFigure.Segments.Add(bezierSegment2);

            PathFigureCollection pathFigureCollection = new PathFigureCollection();
            pathFigureCollection.Add(pathFigure);

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures = pathFigureCollection;

            eyeParts[0] = new Path();
            eyeParts[0].Data = pathGeometry;
            eyeParts[0].StrokeThickness = strokeThickness;
            eyeParts[0].Stroke = new SolidColorBrush(Colors.Red);
            eyeParts[0].Fill = new SolidColorBrush(Colors.Red);


            PathFigure pathFigure2 = new PathFigure();
            pathFigure2.StartPoint = new Point(CentrePoint.X - Radius * 0.3, CentrePoint.Y - Radius * 0.1);
            pathFigure2.Segments.Add(bezierSegment1);
            pathFigure2.Segments.Add(bezierSegment2);

            PathFigureCollection pathFigureCollection2 = new PathFigureCollection();
            pathFigureCollection2.Add(pathFigure2);

            PathGeometry pathGeometry2 = new PathGeometry();
            pathGeometry2.Figures = pathFigureCollection2;

            TransformGroup transformGroup2 = new TransformGroup();
            transformGroup2.Children.Add(new TranslateTransform(Radius * 0.5, 0));

            eyeParts[1] = new Path();
            eyeParts[1].Data = pathGeometry2;
            eyeParts[1].StrokeThickness = strokeThickness;
            eyeParts[1].Stroke = new SolidColorBrush(Colors.Red);
            eyeParts[1].Fill = new SolidColorBrush(Colors.Red);
            eyeParts[1].RenderTransform = transformGroup2;

            return eyeParts;
        }

        private Path[] getEyes5()
        {
            Path[] eyeParts = new Path[2];

            PolyLineSegment polyLineSegment1 = new PolyLineSegment(new Point[]
            {
                new Point(CentrePoint.X - Radius * 0.6, CentrePoint.Y - Radius * 0.5),
                new Point(CentrePoint.X - Radius * 0.4, CentrePoint.Y - Radius * 0.5),
                new Point(CentrePoint.X - Radius * 0.3, CentrePoint.Y - Radius * 0.7),
                new Point(CentrePoint.X - Radius * 0.2, CentrePoint.Y - Radius * 0.5),
                new Point(CentrePoint.X, CentrePoint.Y - Radius * 0.5),
                new Point(CentrePoint.X - Radius * 0.1, CentrePoint.Y - Radius * 0.3),
                new Point(CentrePoint.X - Radius * 0.05, CentrePoint.Y - Radius * 0.1),
                new Point(CentrePoint.X - Radius * 0.3, CentrePoint.Y - Radius * 0.2),
                new Point(CentrePoint.X - Radius * 0.55, CentrePoint.Y - Radius * 0.1),
                new Point(CentrePoint.X - Radius * 0.5, CentrePoint.Y - Radius * 0.3),
            },
            false);

            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(CentrePoint.X - Radius * 0.6, CentrePoint.Y - Radius * 0.5);
            pathFigure.Segments.Add(polyLineSegment1);

            PathFigureCollection pathFigureCollection = new PathFigureCollection();
            pathFigureCollection.Add(pathFigure);

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures = pathFigureCollection;

            eyeParts[0] = new Path();
            eyeParts[0].Data = pathGeometry;
            eyeParts[0].StrokeThickness = strokeThickness;
            eyeParts[0].Stroke = new SolidColorBrush(Colors.Gold);
            eyeParts[0].Fill = new SolidColorBrush(Colors.Gold);

            PathFigure pathFigure2 = new PathFigure();
            pathFigure2.StartPoint = new Point(CentrePoint.X - Radius * 0.6, CentrePoint.Y - Radius * 0.5);
            pathFigure2.Segments.Add(polyLineSegment1);

            PathFigureCollection pathFigureCollection2 = new PathFigureCollection();
            pathFigureCollection2.Add(pathFigure2);

            PathGeometry pathGeometry2 = new PathGeometry();
            pathGeometry2.Figures = pathFigureCollection2;

            TransformGroup transformGroup2 = new TransformGroup();
            transformGroup2.Children.Add(new TranslateTransform(Radius * 0.65, 0));

            eyeParts[1] = new Path();
            eyeParts[1].Data = pathGeometry2;
            eyeParts[1].StrokeThickness = strokeThickness;
            eyeParts[1].Stroke = new SolidColorBrush(Colors.Gold);
            eyeParts[1].Fill = new SolidColorBrush(Colors.Gold);
            eyeParts[1].RenderTransform = transformGroup2;

            return eyeParts;
        }


        private Path[] getMustache(int type)
        {
            switch (type)
            {
                case 0:
                    return getMustache1();

                case 1:
                    return getMustache2();

                case 2:
                    return getMustache3();

                case 3:
                    return getMustache4();

                default:
                    return getMustache5();
            }
        }

        private Path[] getMustache1()
        {
            Path[] mustacheParts = new Path[2];

            BezierSegment bezierSegment1 = new BezierSegment(
                new Point(CentrePoint.X, CentrePoint.Y + Radius * 0.2),
                new Point(CentrePoint.X - Radius * 0.4, CentrePoint.Y + Radius * 0.3),
                new Point(CentrePoint.X - Radius * 0.6, CentrePoint.Y + Radius * 0.2),
                true
                );

            BezierSegment bezierSegment2 = new BezierSegment(
                new Point(CentrePoint.X - Radius * 0.6, CentrePoint.Y + Radius * 0.2),
                new Point(CentrePoint.X - Radius, CentrePoint.Y),
                new Point(CentrePoint.X - Radius * 0.8, CentrePoint.Y - Radius * 0.3),
                true
                );

            BezierSegment bezierSegment3 = new BezierSegment(
                new Point(CentrePoint.X - Radius * 0.8, CentrePoint.Y - Radius * 0.3),
                new Point(CentrePoint.X - Radius * 0.95, CentrePoint.Y),
                new Point(CentrePoint.X - Radius * 0.6, CentrePoint.Y + Radius * 0.15),
                true
                );

            BezierSegment bezierSegment4 = new BezierSegment(
                new Point(CentrePoint.X - Radius * 0.6, CentrePoint.Y + Radius * 0.15),
                new Point(CentrePoint.X - Radius * 0.4, CentrePoint.Y + Radius * 0.25),
                new Point(CentrePoint.X, CentrePoint.Y + Radius * 0.07),
                true
                );

            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(CentrePoint.X, CentrePoint.Y + Radius * 0.2);
            pathFigure.Segments.Add(bezierSegment1);
            pathFigure.Segments.Add(bezierSegment2);
            pathFigure.Segments.Add(bezierSegment3);
            pathFigure.Segments.Add(bezierSegment4);

            PathFigureCollection pathFigureCollection = new PathFigureCollection();
            pathFigureCollection.Add(pathFigure);
            
            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures = pathFigureCollection;

            mustacheParts[0] = new Path();
            mustacheParts[0].Data = pathGeometry;
            mustacheParts[0].StrokeThickness = strokeThickness;
            mustacheParts[0].Stroke = new SolidColorBrush(Colors.Black);
            mustacheParts[0].Fill = new SolidColorBrush(Colors.Brown);
            
            PathFigure pathFigure2 = new PathFigure();
            pathFigure2.StartPoint = new Point(CentrePoint.X, CentrePoint.Y + Radius * 0.2);
            pathFigure2.Segments.Add(bezierSegment1);
            pathFigure2.Segments.Add(bezierSegment2);
            pathFigure2.Segments.Add(bezierSegment3);
            pathFigure2.Segments.Add(bezierSegment4);

            PathFigureCollection pathFigureCollection2 = new PathFigureCollection();
            pathFigureCollection2.Add(pathFigure2);

            PathGeometry pathGeometry2 = new PathGeometry();
            pathGeometry2.Figures = pathFigureCollection2;

            TransformGroup transformGroup2 = new TransformGroup();
            transformGroup2.Children.Add(new ScaleTransform(-1, 1, CentrePoint.X - Radius * 0.8, CentrePoint.Y - Radius * 0.2));
            transformGroup2.Children.Add(new TranslateTransform(Radius * 1.6, 0));

            mustacheParts[1] = new Path();
            mustacheParts[1].Data = pathGeometry2;
            mustacheParts[1].StrokeThickness = strokeThickness;
            mustacheParts[1].Stroke = new SolidColorBrush(Colors.Black);
            mustacheParts[1].Fill = new SolidColorBrush(Colors.Brown);
            mustacheParts[1].RenderTransform = transformGroup2;

            return mustacheParts;
        }

        private Path[] getMustache2()
        {
            Path[] mustacheParts = new Path[2];

            BezierSegment bezierSegment1 = new BezierSegment(
                new Point(CentrePoint.X - Radius * 0.02, CentrePoint.Y + Radius * 0.05),
                new Point(CentrePoint.X - Radius * 0.4, CentrePoint.Y + Radius * 0.15),
                new Point(CentrePoint.X - Radius * 0.6, CentrePoint.Y + Radius * 0.2),
                true
                );

            BezierSegment bezierSegment2 = new BezierSegment(
                new Point(CentrePoint.X - Radius * 0.6, CentrePoint.Y + Radius * 0.2),
                new Point(CentrePoint.X - Radius * 0.2, CentrePoint.Y + Radius * 0.15),
                new Point(CentrePoint.X - Radius * 0.02, CentrePoint.Y + Radius * 0.1),
                true
                );

            LineSegment line1 = new LineSegment(new Point(CentrePoint.X - Radius * 0.02, CentrePoint.Y + Radius * 0.05), true);

            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(CentrePoint.X - Radius * 0.02, CentrePoint.Y + Radius * 0.05);
            pathFigure.Segments.Add(bezierSegment1);
            pathFigure.Segments.Add(bezierSegment2);
            pathFigure.Segments.Add(line1);

            PathFigureCollection pathFigureCollection = new PathFigureCollection();
            pathFigureCollection.Add(pathFigure);

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures = pathFigureCollection;

            mustacheParts[0] = new Path();
            mustacheParts[0].Data = pathGeometry;
            mustacheParts[0].StrokeThickness = strokeThickness;
            mustacheParts[0].Stroke = new SolidColorBrush(Colors.Black);
            mustacheParts[0].Fill = new SolidColorBrush(Colors.Brown);

            PathFigure pathFigure2 = new PathFigure();
            pathFigure2.StartPoint = new Point(CentrePoint.X - Radius * 0.02, CentrePoint.Y + Radius * 0.05);
            pathFigure2.Segments.Add(bezierSegment1);
            pathFigure2.Segments.Add(bezierSegment2);
            pathFigure2.Segments.Add(line1);

            PathFigureCollection pathFigureCollection2 = new PathFigureCollection();
            pathFigureCollection2.Add(pathFigure2);

            PathGeometry pathGeometry2 = new PathGeometry();
            pathGeometry2.Figures = pathFigureCollection2;

            TransformGroup transformGroup2 = new TransformGroup();
            transformGroup2.Children.Add(new ScaleTransform(-1, 1, CentrePoint.X - Radius * 0.8, CentrePoint.Y - Radius * 0.2));
            transformGroup2.Children.Add(new TranslateTransform(Radius * 1.6, 0));

            mustacheParts[1] = new Path();
            mustacheParts[1].Data = pathGeometry2;
            mustacheParts[1].StrokeThickness = strokeThickness;
            mustacheParts[1].Stroke = new SolidColorBrush(Colors.Black);
            mustacheParts[1].Fill = new SolidColorBrush(Colors.Brown);
            mustacheParts[1].RenderTransform = transformGroup2;

            return mustacheParts;
        }

        private Path[] getMustache3()
        {
            Path[] mustacheParts = new Path[1];

            BezierSegment bezierSegment1 = new BezierSegment(
                new Point(CentrePoint.X - Radius * 0.4, CentrePoint.Y + Radius * 0.2),
                new Point(CentrePoint.X, CentrePoint.Y - Radius * 0.2),
                new Point(CentrePoint.X + Radius * 0.4, CentrePoint.Y + Radius * 0.2),
                true
                );

            LineSegment line1 = new LineSegment(new Point(CentrePoint.X - Radius * 0.4, CentrePoint.Y + Radius * 0.2), true);

            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(CentrePoint.X - Radius * 0.4, CentrePoint.Y + Radius * 0.2);
            pathFigure.Segments.Add(bezierSegment1);
            pathFigure.Segments.Add(line1);

            PathFigureCollection pathFigureCollection = new PathFigureCollection();
            pathFigureCollection.Add(pathFigure);

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures = pathFigureCollection;

            mustacheParts[0] = new Path();
            mustacheParts[0].Data = pathGeometry;
            mustacheParts[0].StrokeThickness = strokeThickness;
            mustacheParts[0].Stroke = new SolidColorBrush(Colors.Black);
            mustacheParts[0].Fill = new SolidColorBrush(Colors.Brown);

            return mustacheParts;
        }

        private Path[] getMustache4()
        {
            Path[] mustacheParts = new Path[2];

            BezierSegment bezierSegment1 = new BezierSegment(
                new Point(CentrePoint.X, CentrePoint.Y),
                new Point(CentrePoint.X - Radius * 0.4, CentrePoint.Y - Radius * 0.1),
                new Point(CentrePoint.X - Radius * 0.8, CentrePoint.Y + Radius * 0.1),
                true
                );

            BezierSegment bezierSegment2 = new BezierSegment(
                new Point(CentrePoint.X - Radius * 0.8, CentrePoint.Y + Radius * 0.1),
                new Point(CentrePoint.X - Radius, CentrePoint.Y + Radius * 0.2),
                new Point(CentrePoint.X - Radius * 0.7, CentrePoint.Y + Radius * 0.5),
                true
                );

            BezierSegment bezierSegment3 = new BezierSegment(
                new Point(CentrePoint.X - Radius * 0.7, CentrePoint.Y + Radius * 0.5),
                new Point(CentrePoint.X - Radius * 0.8, CentrePoint.Y + Radius * 0.2),
                new Point(CentrePoint.X - Radius * 0.7, CentrePoint.Y + Radius * 0.2),
                true
                );

            BezierSegment bezierSegment4 = new BezierSegment(
                new Point(CentrePoint.X - Radius * 0.7, CentrePoint.Y + Radius * 0.2),
                new Point(CentrePoint.X - Radius * 0.4, CentrePoint.Y),
                new Point(CentrePoint.X, CentrePoint.Y),
                true
                );

            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(CentrePoint.X, CentrePoint.Y);
            pathFigure.Segments.Add(bezierSegment1);
            pathFigure.Segments.Add(bezierSegment2);
            pathFigure.Segments.Add(bezierSegment3);
            pathFigure.Segments.Add(bezierSegment4);

            PathFigureCollection pathFigureCollection = new PathFigureCollection();
            pathFigureCollection.Add(pathFigure);

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures = pathFigureCollection;

            mustacheParts[0] = new Path();
            mustacheParts[0].Data = pathGeometry;
            mustacheParts[0].StrokeThickness = strokeThickness;
            mustacheParts[0].Stroke = new SolidColorBrush(Colors.Black);
            mustacheParts[0].Fill = new SolidColorBrush(Colors.Brown);

            PathFigure pathFigure2 = new PathFigure();
            pathFigure2.StartPoint = new Point(CentrePoint.X, CentrePoint.Y);
            pathFigure2.Segments.Add(bezierSegment1);
            pathFigure2.Segments.Add(bezierSegment2);
            pathFigure2.Segments.Add(bezierSegment3);
            pathFigure2.Segments.Add(bezierSegment4);

            PathFigureCollection pathFigureCollection2 = new PathFigureCollection();
            pathFigureCollection2.Add(pathFigure2);

            PathGeometry pathGeometry2 = new PathGeometry();
            pathGeometry2.Figures = pathFigureCollection2;

            TransformGroup transformGroup2 = new TransformGroup();
            transformGroup2.Children.Add(new ScaleTransform(-1, 1, CentrePoint.X - Radius * 0.8, CentrePoint.Y - Radius * 0.2));
            transformGroup2.Children.Add(new TranslateTransform(Radius * 1.6, 0));

            mustacheParts[1] = new Path();
            mustacheParts[1].Data = pathGeometry2;
            mustacheParts[1].StrokeThickness = strokeThickness;
            mustacheParts[1].Stroke = new SolidColorBrush(Colors.Black);
            mustacheParts[1].Fill = new SolidColorBrush(Colors.Brown);
            mustacheParts[1].RenderTransform = transformGroup2;

            return mustacheParts;
        }

        private Path[] getMustache5()
        {
            Path[] mustacheParts = new Path[2];

            PolyLineSegment polyLineSegment1 = new PolyLineSegment(new Point[]
            {
               new Point(CentrePoint.X - Radius * 0.1, CentrePoint.Y),
               new Point(CentrePoint.X - Radius * 0.7, CentrePoint.Y + Radius * 0.3),
               new Point(CentrePoint.X - Radius * 0.1, CentrePoint.Y + Radius * 0.2),
            },
            true);

            LineSegment line1 = new LineSegment(new Point(CentrePoint.X, CentrePoint.Y), true);
            LineSegment line2 = new LineSegment(new Point(CentrePoint.X - Radius * 0.1, CentrePoint.Y), true);

            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(CentrePoint.X, CentrePoint.Y);
            pathFigure.Segments.Add(polyLineSegment1);
            pathFigure.Segments.Add(line1);
            pathFigure.Segments.Add(line2);

            PathFigureCollection pathFigureCollection = new PathFigureCollection();
            pathFigureCollection.Add(pathFigure);

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures = pathFigureCollection;

            mustacheParts[0] = new Path();
            mustacheParts[0].Data = pathGeometry;
            mustacheParts[0].StrokeThickness = strokeThickness;
            mustacheParts[0].Stroke = new SolidColorBrush(Colors.Black);
            mustacheParts[0].Fill = new SolidColorBrush(Colors.Brown);


            PolyLineSegment polyLineSegment2 = new PolyLineSegment(new Point[]
            {
               new Point(CentrePoint.X + Radius * 0.1, CentrePoint.Y),
               new Point(CentrePoint.X + Radius * 0.7, CentrePoint.Y + Radius * 0.3),
               new Point(CentrePoint.X + Radius * 0.1, CentrePoint.Y + Radius * 0.2),
            },
            true);

            LineSegment line3 = new LineSegment(new Point(CentrePoint.X, CentrePoint.Y), true);
            LineSegment line4 = new LineSegment(new Point(CentrePoint.X + Radius * 0.1, CentrePoint.Y), true);

            PathFigure pathFigure2 = new PathFigure();
            pathFigure2.StartPoint = new Point(CentrePoint.X, CentrePoint.Y);
            pathFigure2.Segments.Add(polyLineSegment2);
            pathFigure2.Segments.Add(line3);
            pathFigure2.Segments.Add(line4);

            PathFigureCollection pathFigureCollection2 = new PathFigureCollection();
            pathFigureCollection2.Add(pathFigure2);

            PathGeometry pathGeometry2 = new PathGeometry();
            pathGeometry2.Figures = pathFigureCollection2;

            mustacheParts[1] = new Path();
            mustacheParts[1].Data = pathGeometry2;
            mustacheParts[1].StrokeThickness = strokeThickness;
            mustacheParts[1].Stroke = new SolidColorBrush(Colors.Black);
            mustacheParts[1].Fill = new SolidColorBrush(Colors.Brown);

            return mustacheParts;
        }


        private Path[] getLips(int type)
        {
            switch (type)
            {
                case 0:
                    return getLips1();

                case 1:
                    return getLips2();

                case 2:
                    return getLips3();

                case 3:
                    return getLips4();

                default:
                    return getLips5();
            }
        }

        private Path[] getLips1()
        {
            Path[] lipsParts = new Path[2];

            BezierSegment bezierSegment1 = new BezierSegment(
                new Point(CentrePoint.X - Radius * 0.6, CentrePoint.Y + Radius * 0.4),
                new Point(CentrePoint.X, CentrePoint.Y + Radius * 0.7),
                new Point(CentrePoint.X + Radius * 0.6, CentrePoint.Y + Radius * 0.4),
                false
                );

            BezierSegment bezierSegment2 = new BezierSegment(
                new Point(CentrePoint.X + Radius * 0.6, CentrePoint.Y + Radius * 0.4),
                new Point(CentrePoint.X, CentrePoint.Y + Radius * 1.7),
                new Point(CentrePoint.X - Radius * 0.6, CentrePoint.Y + Radius * 0.4),
                false
                );

            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(CentrePoint.X - Radius * 0.6, CentrePoint.Y + Radius * 0.4);
            pathFigure.Segments.Add(bezierSegment1);
            pathFigure.Segments.Add(bezierSegment2);

            PathFigureCollection pathFigureCollection = new PathFigureCollection();
            pathFigureCollection.Add(pathFigure);

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures = pathFigureCollection;

            lipsParts[0] = new Path();
            lipsParts[0].Data = pathGeometry;
            lipsParts[0].StrokeThickness = 1;
            lipsParts[0].Stroke = new SolidColorBrush(Colors.Black);
            lipsParts[0].Fill = new SolidColorBrush(Colors.Black);

            BezierSegment bezierSegment3 = new BezierSegment(
                new Point(CentrePoint.X - Radius * 0.3, CentrePoint.Y + Radius * 0.8),
                new Point(CentrePoint.X, CentrePoint.Y + Radius * 0.7),
                new Point(CentrePoint.X + Radius * 0.3, CentrePoint.Y + Radius * 0.8),
                false
                );

            BezierSegment bezierSegment4 = new BezierSegment(
                new Point(CentrePoint.X + Radius * 0.3, CentrePoint.Y + Radius * 0.8),                
                new Point(CentrePoint.X, CentrePoint.Y + Radius * 1.15),
                new Point(CentrePoint.X - Radius * 0.3, CentrePoint.Y + Radius * 0.8),
                false
                );


            PathFigure pathFigure2 = new PathFigure();
            pathFigure2.StartPoint = new Point(CentrePoint.X - Radius * 0.3, CentrePoint.Y + Radius * 0.8);
            pathFigure2.Segments.Add(bezierSegment3);
            pathFigure2.Segments.Add(bezierSegment4);

            PathFigureCollection pathFigureCollection2 = new PathFigureCollection();
            pathFigureCollection2.Add(pathFigure2);

            PathGeometry pathGeometry2 = new PathGeometry();
            pathGeometry2.Figures = pathFigureCollection2;

            lipsParts[1] = new Path();
            lipsParts[1].Data = pathGeometry2;
            lipsParts[1].StrokeThickness = 1;
            lipsParts[1].Stroke = new SolidColorBrush(Colors.Red);
            lipsParts[1].Fill = new SolidColorBrush(Colors.Red);

            return lipsParts;
        }

        private Path[] getLips2()
        {
            Path[] lipsParts = new Path[1];

            BezierSegment bezierSegment1 = new BezierSegment(
                new Point(CentrePoint.X - Radius * 0.6, CentrePoint.Y + Radius * 0.4),
                new Point(CentrePoint.X, CentrePoint.Y + Radius * 1.5),
                new Point(CentrePoint.X + Radius * 0.6, CentrePoint.Y + Radius * 0.4),
                false
                );

            BezierSegment bezierSegment2 = new BezierSegment(
                new Point(CentrePoint.X - Radius * 0.55, CentrePoint.Y + Radius * 0.4),
                new Point(CentrePoint.X, CentrePoint.Y + Radius * 1.2),
                new Point(CentrePoint.X + Radius * 0.55, CentrePoint.Y + Radius * 0.4),
                false
                );

            LineSegment line1 = new LineSegment(new Point(CentrePoint.X - Radius * 0.55, CentrePoint.Y + Radius * 0.4), false);

            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(CentrePoint.X - Radius * 0.6, CentrePoint.Y + Radius * 0.4);
            pathFigure.Segments.Add(bezierSegment1);
            pathFigure.Segments.Add(line1);
            pathFigure.Segments.Add(bezierSegment2);

            PathFigureCollection pathFigureCollection = new PathFigureCollection();
            pathFigureCollection.Add(pathFigure);

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures = pathFigureCollection;

            lipsParts[0] = new Path();
            lipsParts[0].Data = pathGeometry;
            lipsParts[0].StrokeThickness = 1;
            lipsParts[0].Stroke = new SolidColorBrush(Colors.Black);
            lipsParts[0].Fill = new SolidColorBrush(Colors.Black);
            
            return lipsParts;
        }

        private Path[] getLips3()
        {
            Path[] lipsParts = new Path[1];

            LineSegment line1 = new LineSegment(new Point(CentrePoint.X + Radius * 0.5, CentrePoint.Y + Radius * 0.4), true);

            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(CentrePoint.X - Radius * 0.5, CentrePoint.Y + Radius * 0.4);
            pathFigure.Segments.Add(line1);

            PathFigureCollection pathFigureCollection = new PathFigureCollection();
            pathFigureCollection.Add(pathFigure);

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures = pathFigureCollection;

            lipsParts[0] = new Path();
            lipsParts[0].Data = pathGeometry;
            lipsParts[0].StrokeThickness = Radius * 0.1;
            lipsParts[0].Stroke = new SolidColorBrush(Colors.Black);
            lipsParts[0].Fill = new SolidColorBrush(Colors.Black);

            return lipsParts;
        }

        private Path[] getLips4()
        {
            Path[] lipsParts = new Path[1];

            BezierSegment bezierSegment1 = new BezierSegment(
                new Point(CentrePoint.X - Radius * 0.6, CentrePoint.Y + Radius * 0.7),
                new Point(CentrePoint.X, CentrePoint.Y - Radius * 0.2),
                new Point(CentrePoint.X + Radius * 0.6, CentrePoint.Y + Radius * 0.7),
                false
                );

            BezierSegment bezierSegment2 = new BezierSegment(
                new Point(CentrePoint.X - Radius * 0.5, CentrePoint.Y + Radius * 0.7),
                new Point(CentrePoint.X, CentrePoint.Y),
                new Point(CentrePoint.X + Radius * 0.5, CentrePoint.Y + Radius * 0.7),
                false
                );

            LineSegment line1 = new LineSegment(new Point(CentrePoint.X - Radius * 0.5, CentrePoint.Y + Radius * 0.7), false);

            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(CentrePoint.X - Radius * 0.6, CentrePoint.Y + Radius * 0.7);
            pathFigure.Segments.Add(bezierSegment1);
            pathFigure.Segments.Add(line1);
            pathFigure.Segments.Add(bezierSegment2);

            PathFigureCollection pathFigureCollection = new PathFigureCollection();
            pathFigureCollection.Add(pathFigure);

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures = pathFigureCollection;

            lipsParts[0] = new Path();
            lipsParts[0].Data = pathGeometry;
            lipsParts[0].StrokeThickness = 1;
            lipsParts[0].Stroke = new SolidColorBrush(Colors.Black);
            lipsParts[0].Fill = new SolidColorBrush(Colors.Black);

            return lipsParts;
        }

        private Path[] getLips5()
        {
            Path[] lipsParts = new Path[2];

            BezierSegment bezierSegment1 = new BezierSegment(
                new Point(CentrePoint.X - Radius * 0.6, CentrePoint.Y + Radius * 0.7),
                new Point(CentrePoint.X, CentrePoint.Y - Radius * 0.2),
                new Point(CentrePoint.X + Radius * 0.6, CentrePoint.Y + Radius * 0.7),
                false
                );

            BezierSegment bezierSegment2 = new BezierSegment(
                new Point(CentrePoint.X + Radius * 0.6, CentrePoint.Y + Radius * 0.7),
                new Point(CentrePoint.X, CentrePoint.Y + Radius * 1.3),
                new Point(CentrePoint.X - Radius * 0.6, CentrePoint.Y + Radius * 0.7),
                false
                );

            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(CentrePoint.X - Radius * 0.6, CentrePoint.Y + Radius * 0.7);
            pathFigure.Segments.Add(bezierSegment1);
            pathFigure.Segments.Add(bezierSegment2);

            PathFigureCollection pathFigureCollection = new PathFigureCollection();
            pathFigureCollection.Add(pathFigure);

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures = pathFigureCollection;

            lipsParts[0] = new Path();
            lipsParts[0].Data = pathGeometry;
            lipsParts[0].StrokeThickness = 1;
            lipsParts[0].Stroke = new SolidColorBrush(Colors.Black);
            lipsParts[0].Fill = new SolidColorBrush(Colors.Black);

            BezierSegment bezierSegment3 = new BezierSegment(
                new Point(CentrePoint.X - Radius * 0.3, CentrePoint.Y + Radius * 0.85),
                new Point(CentrePoint.X, CentrePoint.Y + Radius * 0.5),
                new Point(CentrePoint.X + Radius * 0.3, CentrePoint.Y + Radius * 0.85),
                false
                );

            BezierSegment bezierSegment4 = new BezierSegment(
                new Point(CentrePoint.X + Radius * 0.3, CentrePoint.Y + Radius * 0.85),
                new Point(CentrePoint.X, CentrePoint.Y + Radius * 0.95),
                new Point(CentrePoint.X - Radius * 0.3, CentrePoint.Y + Radius * 0.85),
                false
                );


            PathFigure pathFigure2 = new PathFigure();
            pathFigure2.StartPoint = new Point(CentrePoint.X - Radius * 0.3, CentrePoint.Y + Radius * 0.85);
            pathFigure2.Segments.Add(bezierSegment3);
            pathFigure2.Segments.Add(bezierSegment4);

            PathFigureCollection pathFigureCollection2 = new PathFigureCollection();
            pathFigureCollection2.Add(pathFigure2);

            PathGeometry pathGeometry2 = new PathGeometry();
            pathGeometry2.Figures = pathFigureCollection2;

            lipsParts[1] = new Path();
            lipsParts[1].Data = pathGeometry2;
            lipsParts[1].StrokeThickness = 1;
            lipsParts[1].Stroke = new SolidColorBrush(Colors.Red);
            lipsParts[1].Fill = new SolidColorBrush(Colors.Red);

            return lipsParts;
        }


        public void Draw(Canvas canvas)
        {
            for (int i = 0; i < Shapes.Length; i++)
                for (int j = 0; j < Shapes[i].Length; j++)
                    canvas.Children.Add(Shapes[i][j]);
        }

        public static ChernoffFace[] GetFaces(PieChart chart, StatisticsData[] datas, 
            StatisticsData minData, StatisticsData maxData)
        {
            double[] sectionsData = new double[datas.Length];

            for (int i = 0; i < datas.Length; i++)
                sectionsData[i] = datas[i].Sections;

            Point[] facePoints = chart.GetMiddleAnglePoints();
            ChernoffFace[] faces = new ChernoffFace[facePoints.Length];

            for (int i = 0; i < faces.Length; i++)
            {
                double pieAngle = (chart.PieAngles[i] > 45) ? 45 : chart.PieAngles[i];
                int faceRadius = (int)((pieAngle * (2 * Math.PI * chart.Radius) / 360) * 0.6);

                if (faceRadius > chart.Radius)
                    faceRadius = chart.Radius;

                Point facePoint = getPointAwayFromA(facePoints[i], chart.CentrePoint, -(faceRadius + 10));

                faces[i] = new ChernoffFace(facePoint, faceRadius, datas[i], minData, maxData);
            }

            return faces;
        }

        private static Point getPointAwayFromA(Point a, Point b, double distance)
        {
            Point w = new Point(b.X - a.X, b.Y - a.Y);
            double d = distance / Math.Sqrt(w.X * w.X + w.Y * w.Y);

            Point wp = new Point(Math.Round(w.X * d), Math.Round(w.Y * d));
            double cY = (a.Y + wp.Y > 0) ? (a.Y + wp.Y) : 0;
            double cX = (a.X + wp.X > 0) ? (a.X + wp.X) : 0;

            return new Point(cX, cY);
        }
    }
}
