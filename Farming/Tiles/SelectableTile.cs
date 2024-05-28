using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Farming
{
    public class SelectableTile : Tile, ICollidable, ISelectable
    {
        public bool IsHovered { get; set; }

        public SelectableTile(string tileType, Texture2D texture, Vector2 position)
            : base(tileType, texture, position)
        {
            IsHovered = false;
        }

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }

        public void Select()
        {
            IsHovered = true;
        }

        public void Deselect()
        {
            IsHovered = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Color color = IsHovered ? Color.Red : Color.White;
            spriteBatch.Draw(_texture, Position, color);
        }
    }
}
