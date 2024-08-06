using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace Farming
{
    public class TileMap
    {
        private const int TileGap = 0;
        private const int TileMapSize = 32;

        public Tile[,] Tiles { get; set; }
        private SelectableTile _hoveredTile;
        public SelectableTile HoveredTile
        {
            get { return _hoveredTile;  }
            set
            {
                // Stop highlighting the previously hovered tile
                if (_hoveredTile != null)
                {
                    _hoveredTile.IsHovered = false;
                }

                if (value == null)
                {
                    return;
                }

                _hoveredTile = value;
                value.IsHovered = true;
            }
        }

        public TileMap()
        {
            Tiles = new Tile[TileMapSize, TileMapSize];
            HoveredTile = null;
        }

        public void FillTileMapWithDirt()
        {
            Texture2D tileTexture = TextureHandler.Instance.GetTexture("dirt");
            for (int row = 0; row < Tiles.GetLength(0); row++)
            {
                for (int col = 0; col < Tiles.GetLength(1); col++)
                {
                    Tiles[row, col] = new SelectableTile("dirt", tileTexture, new Vector2(row * (tileTexture.Width + TileGap), col * (tileTexture.Height + TileGap)));
                }
            }
        }

        public void ChangeTile(int targetTileRow, int targetTileCol, string newTexture)
        {
            Vector2 tilePosition = Tiles[targetTileRow, targetTileCol].Position;
            Tiles[targetTileRow, targetTileCol] = new SelectableTile(newTexture, TextureHandler.Instance.GetTexture(newTexture), tilePosition);
        }
        public void ChangeTile(int targetTileRow, int targetTileCol, Tile newTile)
        {
            Vector2 tilePosition = Tiles[targetTileRow, targetTileCol].Position;
            // Tiles[targetTileRow, targetTileCol] = new SelectableTile(newTexture, TextureHandler.Instance.GetTexture(newTexture), tilePosition);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile tile in Tiles)
            {
                tile.Draw(spriteBatch);
            }
            if (HoveredTile != null)
            {
                Texture2D tileSelectorTexture = TextureHandler.Instance.GetTexture("tile_selector");
                Vector2 tileSelectorPosition = HoveredTile.Position + new Vector2(-3, -3);
                spriteBatch.Draw(tileSelectorTexture, tileSelectorPosition, Color.White);
            }
        }
      
    }
}
