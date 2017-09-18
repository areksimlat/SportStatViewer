using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportStatViewer.Map
{
    public class WielkopolskieArea : Area
    {
        protected override Point[] getAreaPoints()
        {
            return new Point[]
            {
                new Point(204, 159),
                new Point(206, 163),
                new Point(199, 171),
                new Point(202, 180),
                new Point(198, 191),
                new Point(211, 197),
                new Point(213, 201),
                new Point(205, 215),
                new Point(211, 226),
                new Point(220, 223),
                new Point(226, 230),
                new Point(235, 229),
                new Point(252, 243),
                new Point(263, 243),
                new Point(266, 239),
                new Point(269, 242),
                new Point(278, 244),
                new Point(291, 258),
                new Point(301, 253),
                new Point(307, 257),
                new Point(306, 265),
                new Point(313, 266),
                new Point(311, 269),
                new Point(301, 268),
                new Point(299, 281),
                new Point(288, 285),
                new Point(288, 294),
                new Point(291, 299),
                new Point(288, 305),
                new Point(278, 305),
                new Point(270, 310),
                new Point(267, 328),
                new Point(266, 346),
                new Point(257, 347),
                new Point(250, 356),
                new Point(250, 365),
                new Point(256, 371),
                new Point(254, 378),
                new Point(243, 384),
                new Point(235, 381),
                new Point(235, 374),
                new Point(230, 374),
                new Point(228, 353),
                new Point(217, 350),
                new Point(218, 337),
                new Point(199, 328),
                new Point(191, 338),
                new Point(177, 337),
                new Point(159, 326),
                new Point(158, 318),
                new Point(146, 316),
                new Point(141, 305),
                new Point(129, 305),
                new Point(125, 296),
                new Point(117, 294),
                new Point(119, 286),
                new Point(111, 282),
                new Point(112, 244),
                new Point(103, 228),
                new Point(113, 218),
                new Point(115, 189),
                new Point(125, 194),
                new Point(139, 186),
                new Point(141, 180),
                new Point(153, 172),
                new Point(161, 158),
                new Point(148, 151),
                new Point(149, 144),
                new Point(163, 139),
                new Point(165, 130),
                new Point(169, 129),
                new Point(181, 141),
                new Point(202, 139),
                new Point(201, 143),
                new Point(196, 147),
                new Point(195, 156)
            };
        }

        protected override Point getPieChartPosition()
        {
            return new Point(200, 276);
        }

        protected override int getPieChartSize()
        {
            return 27;
        }
    }
}
