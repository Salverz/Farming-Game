using Microsoft.Xna.Framework.Graphics;

namespace Farming
{
    public class Wheat : Plant
    {
        public Wheat(int minTemp, int maxTemp, int idealMinTemp, int idealMaxTemp, int harvestableGrowthStage, int pricePerUnit)
            : base(minTemp, maxTemp, idealMinTemp, idealMaxTemp, harvestableGrowthStage, pricePerUnit, new Texture2D[]
            {
                TextureHandler.Instance.GetTexture("wheat_stage0"),
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
