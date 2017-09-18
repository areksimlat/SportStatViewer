using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportStatViewer.Map
{
    public class WarminskoMazurskieArea : Area
    {
        protected override Point[] getAreaPoints()
        {
            return new Point[]
            {
                new Point(315, 129),
                new Point(320, 135),
                new Point(321, 145),
                new Point(335, 151),
                new Point(349, 154),
                new Point(350, 173),
                new Point(365, 167),
                new Point(372, 174),
                new Point(390, 173),
                new Point(395, 162),
                new Point(407, 162),
                new Point(413, 156),
                new Point(423, 155),
                new Point(427, 149),
                new Point(434, 150),
                new Point(448, 144),
                new Point(469, 137),
                new Point(486, 138),
                new Point(490, 132),
                new Point(497, 132),
                new Point(536, 107),
                new Point(542, 95),
                new Point(538, 85),
                new Point(532, 77),
                new Point(531, 69),
                new Point(523, 61),
                new Point(529, 55),
                new Point(539, 51),
                new Point(540, 45),
                new Point(526, 47),
                new Point(456, 53),
                new Point(353, 41),
                new Point(343, 52),
                new Point(327, 60),
                new Point(322, 77),
                new Point(330, 84),
                new Point(330, 88),
                new Point(344, 88),
                new Point(336, 109),
                new Point(327, 109)
            };
        }

        protected override Point getPieChartPosition()
        {
            return new Point(430, 99);
        }

        protected override int getPieChartSize()
        {
            return 25;
        }
    }
}
