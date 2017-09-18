using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportStatViewer.Map
{
    public class PodlaskieArea : Area
    {
        protected override Point[] getAreaPoints()
        {
           return new Point[]
           {
                new Point(544, 95),
                new Point(537, 109),
                new Point(497, 134),
                new Point(491, 135),
                new Point(488, 141),
                new Point(470, 141),
                new Point(474, 151),
                new Point(472, 164),
                new Point(476, 173),
                new Point(490, 177),
                new Point(490, 185),
                new Point(495, 188),
                new Point(495, 198),
                new Point(512, 198),
                new Point(512, 207),
                new Point(522, 208),
                new Point(521, 224),
                new Point(531, 246),
                new Point(560, 251),
                new Point(561, 258),
                new Point(569, 258),
                new Point(581, 233),
                new Point(602, 219),
                new Point(614, 210),
                new Point(612, 167),
                new Point(593, 132),
                new Point(581, 68),
                new Point(549, 42),
                new Point(543, 44),
                new Point(541, 52),
                new Point(531, 56),
                new Point(526, 61),
                new Point(534, 69),
                new Point(534, 77),
                new Point(540, 85)
           };
        }

        protected override Point getPieChartPosition()
        {
            return new Point(551, 165);
        }

        protected override int getPieChartSize()
        {
            return 26;
        }
    }
}
