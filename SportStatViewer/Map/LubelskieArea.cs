using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportStatViewer.Map
{
    public class LubelskieArea : Area
    {
        protected override Point[] getAreaPoints()
        {
            return new Point[]
            {
                new Point(599, 341),
                new Point(600, 359),
                new Point(625, 402),
                new Point(619, 405),
                new Point(620, 411),
                new Point(625, 417),
                new Point(623, 445),
                new Point(607, 449),
                new Point(594, 463),
                new Point(583, 451),
                new Point(569, 452),
                new Point(560, 460),
                new Point(539, 459),
                new Point(525, 453),
                new Point(525, 446),
                new Point(534, 443),
                new Point(527, 431),
                new Point(510, 423),
                new Point(510, 409),
                new Point(487, 410),
                new Point(484, 386),
                new Point(484, 368),
                new Point(489, 365),
                new Point(489, 351),
                new Point(486, 349),
                new Point(490, 346),
                new Point(490, 334),
                new Point(475, 330),
                new Point(475, 326),
                new Point(482, 327),
                new Point(492, 321),
                new Point(492, 314),
                new Point(498, 309),
                new Point(491, 302),
                new Point(491, 294),
                new Point(501, 287),
                new Point(522, 288),
                new Point(527, 284),
                new Point(539, 285),
                new Point(539, 278),
                new Point(552, 281),
                new Point(563, 263),
                new Point(570, 261),
                new Point(587, 267),
                new Point(597, 279),
                new Point(595, 306),
                new Point(589, 311),
                new Point(592, 335)
            };
        }

        protected override Point getPieChartPosition()
        {
            return new Point(547, 370);
        }

        protected override int getPieChartSize()
        {
            return 27;
        }
    }
}
