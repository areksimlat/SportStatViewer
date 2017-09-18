using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SportStatViewer.Map
{
    public class BackgroundArea : Area
    {
        public BackgroundArea() : base()
        {
            Shape.Fill = Brushes.Black;
        }

        protected override Point[] getAreaPoints()
        {
            return new Point[]
            {
                new Point(125, 58),
                new Point(32, 88),
                new Point(16, 97),
                new Point(2, 98),
                new Point(2, 107),
                new Point(12, 111),
                new Point(20, 107),
                new Point(26, 105),
                new Point(23, 125),
                new Point(8, 117),
                new Point(17, 164),
                new Point(13, 188),
                new Point(1, 196),
                new Point(0, 210),
                new Point(20, 229),
                new Point(29, 233),
                new Point(29, 249),
                new Point(26, 251),
                new Point(29, 271),
                new Point(36, 270),
                new Point(34, 284),
                new Point(40, 291),
                new Point(37, 303),
                new Point(29, 313),
                new Point(40, 328),
                new Point(39, 342),
                new Point(55, 351),
                new Point(57, 379),
                new Point(45, 411),
                new Point(56, 411),
                new Point(60, 396),
                new Point(73, 397),
                new Point(75, 412),
                new Point(84, 418),
                new Point(101, 422),
                new Point(109, 423),
                new Point(113, 429),
                new Point(122, 436),
                new Point(139, 431),
                new Point(148, 440),
                new Point(133, 455),
                new Point(150, 468),
                new Point(162, 490),
                new Point(176, 477),
                new Point(188, 471),
                new Point(178, 455),
                new Point(193, 456),
                new Point(209, 469),
                new Point(227, 464),
                new Point(233, 472),
                new Point(222, 480),
                new Point(237, 499),
                new Point(249, 492),
                new Point(272, 506),
                new Point(283, 506),
                new Point(284, 524),
                new Point(296, 530),
                new Point(299, 544),
                new Point(308, 544),
                new Point(309, 556),
                new Point(323, 554),
                new Point(328, 543),
                new Point(340, 536),
                new Point(350, 556),
                new Point(359, 556),
                new Point(360, 572),
                new Point(371, 571),
                new Point(378, 578),
                new Point(383, 564),
                new Point(397, 554),
                new Point(419, 553),
                new Point(430, 563),
                new Point(440, 559),
                new Point(442, 551),
                new Point(457, 548),
                new Point(465, 552),
                new Point(474, 549),
                new Point(484, 556),
                new Point(494, 558),
                new Point(503, 570),
                new Point(553, 591),
                new Point(555, 581),
                new Point(545, 575),
                new Point(547, 557),
                new Point(540, 538),
                new Point(570, 493),
                new Point(608, 449),
                new Point(625, 446),
                new Point(627, 416),
                new Point(620, 406),
                new Point(628, 403),
                new Point(602, 357),
                new Point(601, 340),
                new Point(594, 332),
                new Point(592, 312),
                new Point(597, 309),
                new Point(599, 277),
                new Point(588, 265),
                new Point(572, 259),
                new Point(582, 234),
                new Point(603, 221),
                new Point(616, 210),
                new Point(614, 166),
                new Point(595, 131),
                new Point(583, 67),
                new Point(550, 40),
                new Point(525, 46),
                new Point(457, 50),
                new Point(363, 40),
                new Point(352, 39),
                new Point(342, 50),
                new Point(326, 57),
                new Point(321, 52),
                new Point(346, 40),
                new Point(341, 36),
                new Point(317, 49),
                new Point(295, 49),
                new Point(279, 44),
                new Point(274, 31),
                new Point(266, 10),
                new Point(278, 15),
                new Point(291, 28),
                new Point(294, 21),
                new Point(281, 9),
                new Point(261, 0),
                new Point(226, 3),
                new Point(184, 15),
                new Point(170, 27),
                new Point(143, 33)
            };
        }

        protected override Point getPieChartPosition()
        {
            return new Point();
        }

        protected override int getPieChartSize()
        {
            return 0;
        }

        public override void Draw(Canvas canvas)
        {
            canvas.Children.Add(Shape);
        }
    }
}
