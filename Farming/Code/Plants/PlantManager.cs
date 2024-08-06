using System.Collections.Generic;

namespace Farming
{
    // Singleton
    public class PlantManager
    {
        private static PlantManager _instance;
        public static PlantManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PlantManager();
                }
                return _instance;
            }
        }

        private List<Plant> _plants;

        private PlantManager()
        {
            _plants = new List<Plant>();
        }

        public void AddPlant(Plant plant)
        {
            _plants.Add(plant);
        }

        public void GrowPlants()
        {
            foreach (Plant plant in _plants)
            {
                plant.Grow();
            }
        }
    }
}
