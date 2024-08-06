using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Farming
{
    public class NonSelectableTile : Tile
    {
        public NonSelectableTile(string tileType, Texture2D texture, Vector2 position)
            : base(tileType, texture, position) { }
    }
}
