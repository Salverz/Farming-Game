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

        private List<Plant> _placedPlants;
        private Dictionary<string, Plant> _plantTypes;

        private PlantManager()
        {
            _placedPlants = new List<Plant>();
        }

        public void RegisterPlant(string name, Plant plant)
        {
            _plantTypes.Add(name, plant);
        }

        public void AddPlacedPlant(Plant plant)
        {
            _placedPlants.Add(plant);
        }

        public void GrowPlants()
        {
            foreach (Plant plant in _placedPlants)
            {
                plant.Grow();
            }
        }
    }
}
