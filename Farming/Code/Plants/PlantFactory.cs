using System.Collections.Generic;

namespace Farming
{
    public class PlantFactory
    {
        private static PlantFactory _instance;
        public static PlantFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PlantFactory();
                }
                return _instance;
            }
        }

        public Plant CreatePlant(string name)
        {
            if (name == "inventoryWheatSeed")
            {
                return new Wheat
                    (
                        50,
                        90,
                        60,
                        80,
                        7,
                        50
                    );
            }

            throw new KeyNotFoundException($"Plant {name} does not exist");
        }
    }
}
