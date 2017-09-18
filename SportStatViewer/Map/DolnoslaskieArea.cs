using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportStatViewer.Map
{
    class DolnoslaskieArea : Area
    {
        protected override Point[] getAreaPoints()
        {
            return new Point[]
            {
                new Point(84, 417),
                new Point(111, 421),
                new Point(115, 428),
                new Point(122, 434),
                new Point(140, 429),
                new Point(151, 439),
                new Point(135, 455),
                new Point(150, 465),
                new Point(163, 486),
                new Point(175, 475),
                new Point(185, 470),
                new Point(175, 454),
                new Point(181, 453),
                new Point(189, 446),
                new Point(190, 436),
                new Point(207, 407),
                new Point(218, 394),
                new Point(219, 375),
                new Point(228, 375),
                new Point(226, 355),
                new Point(215, 351),
                new Point(217, 338),
                new Point(200, 330),
                new Point(192, 339),
                new Point(176, 339),
                new Point(158, 327),
                new Point(157, 319),
                new Point(146, 318),
                new Point(141, 325),
                new Point(142, 334),
                new Point(127, 335),
                new Point(118, 342),
                new Point(116, 332),
                new Point(112, 331),
                new Point(96, 353),
                new Point(88, 345),
                new Point(82, 344),
                new Point(78, 355),
                new Point(67, 353),
                new Point(57, 362),
                new Point(58, 379),
                new Point(47, 409),
                new Point(55, 409),
                new Point(59, 394),
                new Point(74, 396),
                new Point(77, 410)
            };
        }

        protected override Point getPieChartPosition()
        {
            return new Point(150, 381);
        }

        protected override int getPieChartSize()
        {
            return 25;
        }
    }
}
