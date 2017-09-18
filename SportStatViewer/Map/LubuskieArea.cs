using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportStatViewer.Map
{
    public class LubuskieArea : Area
    {
        protected override Point[] getAreaPoints()
        {
            return new Point[]
            {
                new Point(116, 295),
                new Point(124, 298),
                new Point(129, 306),
                new Point(140, 307),
                new Point(144, 316),
                new Point(139, 326),
                new Point(140, 332),
                new Point(126, 333),
                new Point(118, 339),
                new Point(117, 331),
                new Point(111, 329),
                new Point(95, 351),
                new Point(89, 343),
                new Point(81, 343),
                new Point(77, 353),
                new Point(66, 351),
                new Point(57, 360),
                new Point(56, 349),
                new Point(41, 341),
                new Point(43, 328),
                new Point(32, 313),
                new Point(39, 303),
                new Point(43, 289),
                new Point(36, 283),
                new Point(39, 267),
                new Point(31, 268),
                new Point(28, 253),
                new Point(33, 249),
                new Point(33, 232),
                new Point(41, 227),
                new Point(49, 210),
                new Point(64, 212),
                new Point(77, 204),
                new Point(81, 195),
                new Point(102, 194),
                new Point(111, 182),
                new Point(114, 188),
                new Point(111, 217),
                new Point(101, 227),
                new Point(110, 245),
                new Point(109, 282),
                new Point(117, 287)
            };
        }

        protected override Point getPieChartPosition()
        {
            return new Point(75, 280);
        }

        protected override int getPieChartSize()
        {
            return 17;
        }
    }
}
