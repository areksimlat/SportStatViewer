using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportStatViewer.Map
{
    public class PodkarpackieArea : Area
    {
        protected override Point[] getAreaPoints()
        {
            return new Point[]
            {
                new Point(539, 462),
                new Point(561, 462),
                new Point(570, 454),
                new Point(582, 453),
                new Point(592, 463),
                new Point(568, 492),
                new Point(537, 538),
                new Point(544, 557),
                new Point(542, 575),
                new Point(551, 583),
                new Point(550, 587),
                new Point(504, 568),
                new Point(495, 554),
                new Point(485, 554),
                new Point(474, 547),
                new Point(466, 550),
                new Point(462, 548),
                new Point(461, 540),
                new Point(457, 536),
                new Point(457, 519),
                new Point(446, 515),
                new Point(444, 510),
                new Point(454, 503),
                new Point(445, 495),
                new Point(445, 459),
                new Point(456, 447),
                new Point(469, 439),
                new Point(476, 437),
                new Point(476, 430),
                new Point(486, 423),
                new Point(487, 413),
                new Point(508, 412),
                new Point(508, 425),
                new Point(525, 434),
                new Point(531, 441),
                new Point(523, 446),
                new Point(523, 455)
            };
        }

        protected override Point getPieChartPosition()
        {
            return new Point(502, 500);
        }

        protected override int getPieChartSize()
        {
            return 25;
        }
    }
}
