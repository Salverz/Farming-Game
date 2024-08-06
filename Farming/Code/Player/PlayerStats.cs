using Microsoft.Xna.Framework;

namespace Farming
{
    // Singleton
    public class PlayerStats
    {
        public static PlayerStats _instance;
        public static PlayerStats Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PlayerStats();
                }
                return _instance;
            }
        }

        public int Money { get; set; }

        public PlayerStats()
        {
            Money = 1000;
        }
    }
}
