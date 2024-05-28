using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace Farming
{
    public class TileMap
    {
        public Tile[,] Tiles { get; set; }
        private SelectableTile _selectedTile;
        public SelectableTile SelectedTile
        {
            get { return _selectedTile;  }
            set
            {
                // Stop highlighting the previously hovered tile
                if (_selectedTile != null)
                {
                    _selectedTile.IsHovered = false;
                }

                if (value == null)
                {
                    return;
                }

                _selectedTile = value;
                value.IsHovered = true;
            }
        }

        public TileMap()
        {
            Tiles = new Tile[32, 32];
            SelectedTile = null;
        }

        public void FillTileMapWithDirt()
        {
            Texture2D tileTexture = TextureHandler.Instance.GetTexture("dirt");
            for (int row = 0; row < Tiles.GetLength(0); row++)
            {
                for (int col = 0; col < Tiles.GetLength(1); col++)
                {
                    Tiles[row, col] = new SelectableTile("dirt", tileTexture, new Vector2(row * tileTexture.Width, col * tileTexture.Height));
                }
            }
        }

        public void ChangeTile(int targetTileRow, int targetTileCol, string newTexture)
        {
            Vector2 tilePosition = Tiles[targetTileRow, targetTileCol].Position;
            Tiles[targetTileRow, targetTileCol] = new SelectableTile(newTexture, TextureHandler.Instance.GetTexture(newTexture), tilePosition);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile tile in Tiles)
            {
                tile.Draw(spriteBatch);
            }
        }
      
    }
}
