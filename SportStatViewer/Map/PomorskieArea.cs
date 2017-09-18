using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportStatViewer.Map
{
    public class PomorskieArea : Area
    {
        protected override Point[] getAreaPoints()
        {
            return new Point[]
            {
                new Point(326, 106),
                new Point(312, 127),
                new Point(295, 127),
                new Point(285, 119),
                new Point(262, 119),
                new Point(245, 111),
                new Point(233, 111),
                new Point(224, 126),
                new Point(207, 127),
                new Point(204, 138),
                new Point(182, 138),
                new Point(171, 126),
                new Point(172, 115),
                new Point(177, 108),
                new Point(172, 103),
                new Point(178, 99),
                new Point(168, 89),
                new Point(166, 73),
                new Point(161, 68),
                new Point(169, 63),
                new Point(169, 42),
                new Point(160, 33),
                new Point(172, 30),
                new Point(186, 18),
                new Point(227, 6),
                new Point(260, 3),
                new Point(280, 11),
                new Point(292, 21),
                new Point(290, 24),
                new Point(279, 14),
                new Point(263, 7),
                new Point(276, 45),
                new Point(294, 52),
                new Point(316, 51),
                new Point(341, 38),
                new Point(343, 39),
                new Point(318, 52),
                new Point(324, 60),
                new Point(319, 79),
                new Point(328, 86),
                new Point(328, 91),
                new Point(341, 91),
                new Point(335, 106)
            };
        }

        protected override Point getPieChartPosition()
        {
            return new Point(230, 63);
        }

        protected override int getPieChartSize()
        {
            return 24;
        }
    }
}
