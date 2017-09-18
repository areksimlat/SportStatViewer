using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportStatViewer.Map
{
    public class MazowieckieArea : Area
    {
        protected override Point[] getAreaPoints()
        {
            return new Point[]
            {
                new Point(489, 292),
                new Point(488, 302),
                new Point(496, 309),
                new Point(489, 313),
                new Point(489, 321),
                new Point(481, 325),
                new Point(475, 325),
                new Point(472, 331),
                new Point(488, 336),
                new Point(487, 347),
                new Point(484, 349),
                new Point(487, 351),
                new Point(488, 364),
                new Point(481, 367),
                new Point(482, 386),
                new Point(471, 384),
                new Point(461, 388),
                new Point(456, 382),
                new Point(445, 382),
                new Point(439, 373),
                new Point(427, 376),
                new Point(415, 375),
                new Point(397, 356),
                new Point(397, 350),
                new Point(405, 343),
                new Point(392, 322),
                new Point(410, 323),
                new Point(413, 317),
                new Point(405, 312),
                new Point(405, 302),
                new Point(396, 297),
                new Point(388, 296),
                new Point(383, 287),
                new Point(386, 279),
                new Point(373, 270),
                new Point(373, 264),
                new Point(364, 260),
                new Point(350, 262),
                new Point(335, 256),
                new Point(322, 253),
                new Point(324, 244),
                new Point(331, 239),
                new Point(330, 230),
                new Point(336, 217),
                new Point(341, 214),
                new Point(335, 208),
                new Point(335, 196),
                new Point(350, 190),
                new Point(350, 176),
                new Point(363, 170),
                new Point(371, 177),
                new Point(392, 175),
                new Point(397, 166),
                new Point(407, 166),
                new Point(415, 159),
                new Point(423, 158),
                new Point(428, 152),
                new Point(435, 153),
                new Point(449, 147),
                new Point(467, 141),
                new Point(471, 152),
                new Point(470, 167),
                new Point(475, 177),
                new Point(487, 179),
                new Point(487, 186),
                new Point(492, 191),
                new Point(492, 201),
                new Point(509, 202),
                new Point(511, 211),
                new Point(518, 211),
                new Point(518, 228),
                new Point(529, 249),
                new Point(558, 253),
                new Point(560, 262),
                new Point(551, 280),
                new Point(537, 275),
                new Point(536, 283),
                new Point(525, 282),
                new Point(521, 286),
                new Point(502, 286)
            };
        }

        protected override Point getPieChartPosition()
        {
            return new Point(440, 240);
        }

        protected override int getPieChartSize()
        {
            return 34;
        }
    }
}
