using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportStatViewer.Map
{
    public class SwietokrzyskieArea : Area
    {
        protected override Point[] getAreaPoints()
        {
            return new Point[]
            {
                new Point(472, 386),
                new Point(482, 388),
                new Point(485, 410),
                new Point(485, 421),
                new Point(475, 428),
                new Point(474, 436),
                new Point(468, 437),
                new Point(455, 446),
                new Point(444, 457),
                new Point(424, 462),
                new Point(410, 472),
                new Point(400, 472),
                new Point(394, 463),
                new Point(394, 453),
                new Point(388, 443),
                new Point(368, 439),
                new Point(360, 436),
                new Point(366, 427),
                new Point(355, 418),
                new Point(361, 411),
                new Point(357, 406),
                new Point(364, 389),
                new Point(374, 394),
                new Point(374, 386),
                new Point(370, 382),
                new Point(373, 373),
                new Point(386, 369),
                new Point(395, 364),
                new Point(396, 358),
                new Point(414, 377),
                new Point(428, 378),
                new Point(438, 376),
                new Point(444, 385),
                new Point(456, 384),
                new Point(461, 391)
            };
        }

        protected override Point getPieChartPosition()
        {
            return new Point(420, 417);
        }

        protected override int getPieChartSize()
        {
            return 20;
        }
    }
}
