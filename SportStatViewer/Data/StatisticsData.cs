namespace SportStatViewer.Data
{
    public enum StatisticsDataFields
    {
        Sections,
        Total,
        Womens,
        Boys,
        Girls
    }

    public class StatisticsData
    {
        public int Sections { get; }
        public int Total { get;  }
        public int Womens { get; }
        public int Boys { get; }
        public int Girls { get; }

        public StatisticsData(int sections, int total, int womens, int boys, int girls)
        {
            Sections = sections;
            Total = total;
            Womens = womens;
            Boys = boys;
            Girls = girls;
        }

        public int GetByFiled(StatisticsDataFields field)
        {
            switch (field)
            {
                case StatisticsDataFields.Sections:
                    return Sections;

                case StatisticsDataFields.Total:
                    return Total;

                case StatisticsDataFields.Womens:
                    return Womens;

                case StatisticsDataFields.Boys:
                    return Boys;

                case StatisticsDataFields.Girls:
                    return Girls;
            }

            return 0;
        }
    }
}
