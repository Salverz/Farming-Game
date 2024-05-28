using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Farming
{
    public abstract class Tile
    {
        protected Texture2D _texture;
        public string TileType { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle BoundingBox { get; set; }

        public Tile(string tileType, Texture2D texture, Vector2 position)
        {
            TileType = tileType;
            _texture = texture;
            Position = position;
            BoundingBox = new Rectangle(
                            (int)Position.X,
                            (int)Position.Y,
                            _texture.Width,
                            _texture.Height
                        );
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }
    }
}
