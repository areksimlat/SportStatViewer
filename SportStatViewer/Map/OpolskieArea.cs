using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportStatViewer.Map
{
    public class OpolskieArea : Area
    {
        protected override Point[] getAreaPoints()
        {
            return new Point[]
            {
                new Point(284, 402),
                new Point(280, 409),
                new Point(280, 417),
                new Point(275, 429),
                new Point(282, 435),
                new Point(282, 437),
                new Point(273, 440),
                new Point(269, 453),
                new Point(269, 468),
                new Point(251, 478),
                new Point(248, 491),
                new Point(237, 497),
                new Point(224, 481),
                new Point(235, 472),
                new Point(227, 462),
                new Point(210, 468),
                new Point(194, 455),
                new Point(182, 454),
                new Point(190, 447),
                new Point(191, 436),
                new Point(209, 408),
                new Point(219, 394),
                new Point(221, 377),
                new Point(233, 376),
                new Point(233, 382),
                new Point(244, 386),
                new Point(255, 379),
                new Point(280, 383),
                new Point(285, 389)
            };
        }

        protected override Point getPieChartPosition()
        {
            return new Point(239, 429);
        }

        protected override int getPieChartSize()
        {
            return 18;
        }
    }
}
