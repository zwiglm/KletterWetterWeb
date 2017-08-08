using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomainKw;
using DomainKw.Stations;

namespace KletterWetter.Models
{
    public class TableStationData
    {

        public DateTime FromDate { get; set; }
        public DateTime TillDate { get; set; }
        public IList<WeatherRaw> WeatherRows { get; private set; }
        public IList<WeatherRaw> PrettyWeatherRows { get; private set; }

        public TableStationData(DateTime fromDate, DateTime tillDate, IList<WeatherRaw> weathers)
        {
            this.FromDate = fromDate;
            this.TillDate = tillDate;
            this.WeatherRows = weathers;

            this.prettyWeatherRows();
        }


        #region Private

        private void prettyWeatherRows()
        {
            List<WeatherRaw> result = new List<WeatherRaw>();
            IList<WeatherRaw> ordered = this.WeatherRows;

            DateTime dtKeep = DateTime.Now;
            for (int i = 0; i < ordered.Count; i++)
            {
                WeatherRaw entry = ordered[i];
                result.Add(entry);

                dtKeep = entry.PublishedAt.AddMinutes(GlobalConst.PRETTY_FILL_TIME_MIN);
                while (i < (ordered.Count - 1) && dtKeep < ordered[i + 1].PublishedAt)
                {
                    WeatherRaw addEmpty = WeatherRaw.Empty;
                    addEmpty.PublishedAt = dtKeep;
                    result.Add(addEmpty);

                    dtKeep = addEmpty.PublishedAt.AddMinutes(GlobalConst.PRETTY_FILL_TIME_MIN);
                }
                i++;
            }

            this.PrettyWeatherRows = result;
        }

        #endregion

    }
}