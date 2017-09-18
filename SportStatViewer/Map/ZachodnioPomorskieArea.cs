using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportStatViewer.Map
{
    public class ZachodnioPomorskieArea : Area
    {
        protected override Point[] getAreaPoints()
        {
            return new Point[]
            {
                new Point(169, 102),
                new Point(175, 109),
                new Point(171, 113),
                new Point(169, 126),
                new Point(163, 127),
                new Point(161, 138),
                new Point(148, 143),
                new Point(146, 151),
                new Point(159, 158),
                new Point(150, 171),
                new Point(139, 179),
                new Point(137, 185),
                new Point(126, 191),
                new Point(117, 187),
                new Point(110, 180),
                new Point(101, 192),
                new Point(79, 193),
                new Point(74, 204),
                new Point(64, 209),
                new Point(48, 207),
                new Point(39, 225),
                new Point(32, 230),
                new Point(23, 227),
                new Point(3, 209),
                new Point(5, 197),
                new Point(16, 190),
                new Point(20, 164),
                new Point(13, 123),
                new Point(25, 131),
                new Point(30, 103),
                new Point(21, 103),
                new Point(12, 109),
                new Point(3, 105),
                new Point(3, 100),
                new Point(19, 100),
                new Point(34, 90),
                new Point(127, 60),
                new Point(148, 37),
                new Point(157, 35),
                new Point(166, 44),
                new Point(166, 61),
                new Point(156, 68),
                new Point(163, 74),
                new Point(166, 91),
                new Point(174, 98)
            };
        }

        protected override Point getPieChartPosition()
        {
            return new Point(90, 130);
        }

        protected override int getPieChartSize()
        {
            return 28;
        }
    }
}
