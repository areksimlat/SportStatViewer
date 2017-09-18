using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportStatViewer.Map
{
    public class KujawskoPomorskieArea : Area
    {
        protected override Point[] getAreaPoints()
        {
            return new Point[]
            {
                new Point(329, 238),
                new Point(323, 243),
                new Point(320, 253),
                new Point(308, 255),
                new Point(301, 252),
                new Point(292, 255),
                new Point(278, 242),
                new Point(269, 240),
                new Point(266, 236),
                new Point(263, 241),
                new Point(252, 241),
                new Point(235, 227),
                new Point(226, 227),
                new Point(220, 221),
                new Point(211, 223),
                new Point(207, 214),
                new Point(215, 204),
                new Point(213, 196),
                new Point(201, 190),
                new Point(204, 180),
                new Point(201, 172),
                new Point(207, 163),
                new Point(204, 157),
                new Point(197, 154),
                new Point(197, 148),
                new Point(206, 143),
                new Point(208, 130),
                new Point(227, 127),
                new Point(235, 112),
                new Point(245, 113),
                new Point(264, 120),
                new Point(285, 120),
                new Point(295, 130),
                new Point(313, 130),
                new Point(318, 136),
                new Point(319, 147),
                new Point(337, 154),
                new Point(346, 157),
                new Point(348, 188),
                new Point(332, 194),
                new Point(332, 209),
                new Point(337, 214),
                new Point(333, 217),
                new Point(328, 230)
            };
        }

        protected override Point getPieChartPosition()
        {
            return new Point(275, 180);
        }

        protected override int getPieChartSize()
        {
            return 28;
        }
    }
}
