using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Farming
{
    public class SelectableTile : Tile, ICollidable, ISelectable
    {
        public Plant Plant {  get; set; }
        public bool IsHovered { get; set; }

        public SelectableTile(string tileType, Texture2D texture, Vector2 position)
            : base(tileType, texture, position)
        {
            IsHovered = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Color color = IsHovered ? Color.Red : Color.White;
            spriteBatch.Draw(_texture, Position, Color.White);

            if (Plant != null)
            {
                Plant.Draw(spriteBatch, Position);
            }
        }
    }
}
