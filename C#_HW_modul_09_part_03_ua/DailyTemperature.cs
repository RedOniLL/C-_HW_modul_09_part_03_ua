using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__HW_modul_09_part_03_ua
{
    public class DailyTemperature
    {
        public int Day { get; set; }
        public double HighestTemperature { get; set; }
        public double LowestTemperature { get; set; }

        public DailyTemperature(int day, double highestTemperature, double lowestTemperature)
        {
            Day = day;
            HighestTemperature = highestTemperature;
            LowestTemperature = lowestTemperature;
        }

        public double TemperatureDifference()
        {
            return HighestTemperature - LowestTemperature;
        }
    }
}
