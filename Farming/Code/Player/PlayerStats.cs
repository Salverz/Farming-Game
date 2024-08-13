using System.Collections.Generic;

namespace Farming
{
    // Singleton
    public class PlayerStats
    {
        private static PlayerStats _instance;
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
        private Dictionary<string, int> _inventory;

        public PlayerStats()
        {
            Money = 1000;
            _inventory = new Dictionary<string, int>();
        }

        public void AddToInventory(string item, int quantity)
        {
            if (_inventory.ContainsKey(item))
            {
                _inventory[item] += 1;
                return;
            }
            _inventory[item] = quantity;
        }

        public bool RemoveFromInventory(string item, int quantity)
        {
            if (!_inventory.ContainsKey(item))
            {
                return false;
            }

            if (_inventory[item] < quantity)
            {
                return false;
            }

            _inventory[item] -= quantity;
            return true;
        }

        public int GetItemCountInInventory(string item)
        {
            if (!_inventory.ContainsKey(item))
            {
                return 0;
            }
            return _inventory[item];
        }
    }
}
