using System;
using System.Diagnostics;

namespace Farming
{
    // Singleton
    public class GameState
    {
        private static GameState _instance;
        public static GameState Instance {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameState();
                }

                return _instance;
            }
        }

        public const int DaysPerSeason = 13;

        private int _totalDays;
        private int _temperature;
        public int DayInYear
        {
            get
            {
                return _totalDays % (DaysPerSeason * 4);
            }
        }
        public int TotalWeeks { get { return _totalDays; } }
        public int Year { get { return _totalDays / (DaysPerSeason * 4); } }
        public string Season {
            get
            {
                switch (DayInYear / DaysPerSeason)
                {
                    case 0:
                        return "Spring";
                    case 1:
                        return "Summer";
                    case 2:
                        return "Fall";
                    case 3:
                        return "Winter";
                    default:
                        return "Error";
                }
            }
        }

        public int Temperature
        {
            get
            {
                return _temperature;
            }
        }

        private GameState()
        {
            _totalDays = 0;
        }

        private void SetTemperature()
        {
                Random random = new Random();
                if (Season == "Spring")
                {
                    _temperature = random.Next(46,82);
                }
                else if (Season == "Summer")
                {
                    _temperature = random.Next(72,101);
                }
                else if (Season == "Fall")
                {
                    _temperature = random.Next(46,82);
                }
                else
                {
                    _temperature = random.Next(29,62);
                }
        }

        public void AdvanceDay()
        {
            _totalDays++;
            SetTemperature();
            PlantManager.Instance.GrowPlants();
        }

        public string CurrentDayString()
        {
            return $"Year {Year} | Day {DayInYear} ({Season})";
        }
    }
}
