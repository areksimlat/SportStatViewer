using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportStatViewer.Map
{
    public class LodzkieArea : Area
    {
        protected override Point[] getAreaPoints()
        {
            return new Point[]
            {
                new Point(385, 280),
                new Point(381, 286),
                new Point(387, 298),
                new Point(396, 300),
                new Point(403, 303),
                new Point(403, 313),
                new Point(411, 318),
                new Point(409, 322),
                new Point(389, 321),
                new Point(403, 343),
                new Point(395, 349),
                new Point(393, 364),
                new Point(383, 369),
                new Point(373, 371),
                new Point(368, 383),
                new Point(373, 386),
                new Point(373, 393),
                new Point(364, 386),
                new Point(356, 404),
                new Point(352, 404),
                new Point(351, 400),
                new Point(341, 401),
                new Point(330, 386),
                new Point(323, 390),
                new Point(315, 389),
                new Point(309, 381),
                new Point(297, 384),
                new Point(285, 386),
                new Point(280, 381),
                new Point(256, 377),
                new Point(257, 369),
                new Point(253, 364),
                new Point(252, 356),
                new Point(259, 349),
                new Point(268, 347),
                new Point(269, 328),
                new Point(272, 312),
                new Point(279, 307),
                new Point(288, 307),
                new Point(293, 299),
                new Point(290, 293),
                new Point(290, 285),
                new Point(301, 283),
                new Point(302, 270),
                new Point(313, 269),
                new Point(315, 265),
                new Point(309, 264),
                new Point(309, 257),
                new Point(323, 255),
                new Point(334, 257),
                new Point(350, 265),
                new Point(363, 263),
                new Point(371, 265),
                new Point(370, 271)
            };
        }

        protected override Point getPieChartPosition()
        {
            return new Point(337, 330);
        }

        protected override int getPieChartSize()
        {
            return 27;
        }
    }
}
