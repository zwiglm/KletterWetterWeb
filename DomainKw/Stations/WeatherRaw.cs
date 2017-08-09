using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DomainKw.Stations
{
    [Serializable]
    public class WeatherRaw : Weather
    {

        public WeatherRaw()
            : base()
        {
            PowerStatus = float.NaN;
        }

        public WeatherRaw(string pEvent, DateTime publishedAt, 
                          decimal temp, decimal hum, decimal press, decimal rain, decimal wind, decimal gust, decimal direction,
                          decimal powerStat)
            : base(pEvent, publishedAt, 
                       temp, hum, press, rain, wind, gust, direction)
        {
            this.PowerStatus = (float)powerStat;
        }

        public float PowerStatus { get; set; }


        public static T DeepCopy<T>(T other)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, other);
                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
            }
        }

    }
}
