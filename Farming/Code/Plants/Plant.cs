using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Farming
{
    public abstract class Plant
    {
        protected int _minTemp;
        protected int _maxTemp;
        protected int _idealMinTemp;
        protected int _idealMaxTemp;
        protected int _growthStage;
        protected int _maxGrowthStage;
        protected int _harvestableGrowthStage;
        protected int _harvestedTimes;
        protected float _cropQuality; // 0 to 1
        protected int _pricePerUnit;
        protected Texture2D[] _growthStages;

        public Plant(int minTemp, int maxTemp, int idealMinTemp, int idealMaxTemp, int harvestableGrowthStage, int pricePerUnit, Texture2D[] growthStages)
        {
            _minTemp = minTemp;
            _maxTemp = maxTemp;
            _idealMinTemp = idealMinTemp;
            _idealMaxTemp = idealMaxTemp;
            _harvestableGrowthStage = harvestableGrowthStage;
            _pricePerUnit = pricePerUnit;
            _growthStages = growthStages;
            _maxGrowthStage = growthStages.Length - 1;
            _harvestedTimes = 0;
            _cropQuality = 1f;

            PlantManager.Instance.AddPlant(this);
        }

        public bool IsFullyGrown()
        {
            return _growthStage == _maxGrowthStage;
        }

        public void Grow()
        {
            if (IsFullyGrown())
            {
                return;
            }

            if (GameState.Instance.Temperature < _minTemp || GameState.Instance.Temperature > _maxTemp)
            {

            }

            _growthStage++;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(_growthStages[_growthStage], position, Color.White);
        }
    }
}
