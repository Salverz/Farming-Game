using Microsoft.Xna.Framework.Graphics;

namespace Farming
{
    public class Potato : Plant
    {
        public Potato(int minTemp, int maxTemp, int idealMinTemp, int idealMaxTemp, int harvestableGrowthStage, int pricePerUnit)
            : base(minTemp, maxTemp, idealMinTemp, idealMaxTemp, harvestableGrowthStage, pricePerUnit, new Texture2D[]
            {
                TextureHandler.Instance.GetTexture("potato_stage0"),
                TextureHandler.Instance.GetTexture("potato_stage1"),
                TextureHandler.Instance.GetTexture("potato_stage2"),
                TextureHandler.Instance.GetTexture("potato_stage3")
            })
        {
        }
    }
}
