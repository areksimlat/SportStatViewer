using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportStatViewer.Map
{
    public class SlaskieArea : Area
    {
        protected override Point[] getAreaPoints()
        {
            return new Point[]
            {
                new Point(350, 401),
                new Point(351, 406),
                new Point(355, 406),
                new Point(359, 412),
                new Point(351, 419),
                new Point(364, 428),
                new Point(357, 437),
                new Point(367, 442),
                new Point(365, 446),
                new Point(349, 450),
                new Point(350, 456),
                new Point(324, 482),
                new Point(314, 497),
                new Point(325, 512),
                new Point(337, 521),
                new Point(339, 533),
                new Point(326, 542),
                new Point(322, 551),
                new Point(310, 554),
                new Point(310, 542),
                new Point(301, 541),
                new Point(298, 528),
                new Point(286, 522),
                new Point(285, 504),
                new Point(272, 503),
                new Point(250, 489),
                new Point(251, 479),
                new Point(271, 470),
                new Point(271, 452),
                new Point(276, 440),
                new Point(284, 438),
                new Point(284, 434),
                new Point(276, 427),
                new Point(281, 419),
                new Point(281, 410),
                new Point(286, 404),
                new Point(286, 393),
                new Point(289, 387),
                new Point(301, 385),
                new Point(309, 383),
                new Point(314, 390),
                new Point(323, 392),
                new Point(330, 389),
                new Point(340, 403)
            };
        }

        protected override Point getPieChartPosition()
        {
            return new Point(304, 459);
        }

        protected override int getPieChartSize()
        {
            return 15;
        }
    }
}
