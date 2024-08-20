using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Farming
{
    public abstract class Plant
    {
        private int _minTemp;
        private int _maxTemp;
        private int _idealMinTemp;
        private int _idealMaxTemp;
        private int _growthStage;
        private int _maxGrowthStage;
        private int _harvestableGrowthStage;
        private int _harvestedTimes;
        private float _cropQuality; // 0 to 1
        private int _pricePerUnit;
        private Texture2D[] _growthStages;

        public Texture2D CurrentGrowthStageTexture
        {
            get
            {
                return _growthStages[_growthStage];
            }
        }

        public int SellPrice
        {
            get
            {
                return (int)(_pricePerUnit * _cropQuality);
            }
        }

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

            PlantManager.Instance.AddPlacedPlant(this);
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
