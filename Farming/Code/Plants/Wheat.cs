using Microsoft.Xna.Framework.Graphics;

namespace Farming
{
    public class Wheat : Plant
    {
        public Texture2D CurrentGrowthStageTexture
        {
            get
            {
                return _growthStages[_growthStage];
            }
        }

        public Wheat(int minTemp, int maxTemp, int idealMinTemp, int idealMaxTemp, int harvestableGrowthStage, int pricePerUnit)
            : base(minTemp, maxTemp, idealMinTemp, idealMaxTemp, harvestableGrowthStage, pricePerUnit, new Texture2D[]
            {
                TextureHandler.Instance.GetTexture("potato_plant_stage1"),
                TextureHandler.Instance.GetTexture("wheat_stage1"),
                TextureHandler.Instance.GetTexture("wheat_stage2"),
                TextureHandler.Instance.GetTexture("wheat_stage3"),
                TextureHandler.Instance.GetTexture("wheat_stage4"),
                TextureHandler.Instance.GetTexture("wheat_stage5"),
                TextureHandler.Instance.GetTexture("wheat_stage6"),
                TextureHandler.Instance.GetTexture("wheat_stage7")
            })
        {
        }
    }
}
