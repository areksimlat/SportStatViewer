using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportStatViewer.Map
{
    public class MalopolskieArea : Area
    {
        protected override Point[] getAreaPoints()
        {
            return new Point[]
           {
                new Point(444, 459),
                new Point(444, 496),
                new Point(452, 503),
                new Point(443, 508),
                new Point(444, 517),
                new Point(456, 521),
                new Point(455, 536),
                new Point(459, 541),
                new Point(461, 548),
                new Point(457, 546),
                new Point(441, 550),
                new Point(438, 557),
                new Point(430, 561),
                new Point(419, 551),
                new Point(396, 552),
                new Point(380, 563),
                new Point(378, 574),
                new Point(372, 569),
                new Point(363, 569),
                new Point(361, 553),
                new Point(352, 552),
                new Point(341, 534),
                new Point(339, 519),
                new Point(326, 510),
                new Point(316, 498),
                new Point(327, 481),
                new Point(340, 469),
                new Point(352, 456),
                new Point(351, 451),
                new Point(365, 447),
                new Point(369, 441),
                new Point(387, 445),
                new Point(392, 455),
                new Point(392, 462),
                new Point(397, 472),
                new Point(410, 474),
                new Point(425, 464)
           };
        }

        protected override Point getPieChartPosition()
        {
            return new Point(390, 512);
        }

        protected override int getPieChartSize()
        {
            return 20;
        }
    }
}
