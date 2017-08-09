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
        public IList<WeatherRaw> WeatherRowsBackdate { get; private set; }


        public TableStationData(DateTime fromDate, DateTime tillDate, IList<WeatherRaw> weathers)
        {
            this.FromDate = fromDate;
            this.TillDate = tillDate;
            
            this.WeatherRows = weathers;
            this.setBackWrBackdateFromDb();
        }


        #region Private

        private void setBackWrBackdateFromDb()
        {
            DateTime checkLast = this.WeatherRows.Last().PublishedAt;

            IList<WeatherRaw> result = new List<WeatherRaw>();
            foreach (WeatherRaw item in this.WeatherRows)
            {
                WeatherRaw newEntry = WeatherRaw.DeepCopy(item);
                DateTime newDate = item.PublishedAt.AddHours(GlobalConst.CHART_DATA_OVERLAY_HRS);
                newEntry.PublishedAt = newDate;

                if (newDate <= checkLast)
                    result.Add(newEntry);
            }
            this.WeatherRowsBackdate = result;
        }

        private IList<WeatherRaw> prettyWeatherRows(IList<WeatherRaw> withGaps)
        {
            List<WeatherRaw> result = new List<WeatherRaw>();

            DateTime dtKeep = DateTime.Now;
            for (int i = 0; i < withGaps.Count; i++)
            {
                WeatherRaw entry = withGaps[i];
                result.Add(entry);

                dtKeep = entry.PublishedAt.AddSeconds(GlobalConst.PRETTY_FILL_TIME_SECS);
                while ((i < (withGaps.Count - 1)) && (dtKeep < withGaps[i + 1].PublishedAt))
                {
                    WeatherRaw addEmpty = new WeatherRaw();
                    addEmpty.PublishedAt = dtKeep;
                    result.Add(addEmpty);

                    dtKeep = addEmpty.PublishedAt.AddSeconds(GlobalConst.PRETTY_FILL_TIME_SECS);
                }
                i++;
            }

            return result;
        }

        #endregion

    }
}