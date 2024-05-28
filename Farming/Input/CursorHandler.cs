using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace Farming
{
    // Singleton
    public class CursorHandler
    {
        private static CursorHandler _instance = null;
        private bool _isLeftMouseButtonHeld;
        private Tile _currentHoveredTile;
        private int _currentHoveredTileRow;
        private int _currentHoveredTileCol;

        public static CursorHandler Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CursorHandler();
                }
                return _instance;
            }
        }

        private CursorHandler()
        {
            _isLeftMouseButtonHeld = false;
            _currentHoveredTile = null;
            _currentHoveredTileRow = -1;
            _currentHoveredTileCol = -1;
        }

        private bool IsLeftMouseButtonPressed
        {
            get
            {
                if ((int)Mouse.GetState().LeftButton == 1)
                {
                    return true;
                }
                return false;
            }
        }

        private Vector2 GetMouseWorldPosition(Camera camera)
        {
            Vector2 mousePosition = Mouse.GetState().Position.ToVector2();
            return camera.ScreenToWorld(mousePosition);
        }

        private void GetCurrentHoveredTile(Camera camera, TileMap tileMap)
        {
            Vector2 mouseWorldPosition = GetMouseWorldPosition(camera);

            for (int row = 0; row < tileMap.Tiles.GetLength(0); row++)
            {
                for (int col = 0; col < tileMap.Tiles.GetLength(1); col++)
                {
                    if (tileMap.Tiles[row, col].BoundingBox.Contains(mouseWorldPosition))
                    {
                        _currentHoveredTile = tileMap.Tiles[row, col];
                        _currentHoveredTileRow = row;
                        _currentHoveredTileCol = col;
                        return;
                    }
                }
            }
            _currentHoveredTile = null;
            _currentHoveredTileRow = -1;
            _currentHoveredTileCol = -1;
        }

        public void Update(Camera camera, TileMap tileMap)
        {
            GetCurrentHoveredTile(camera, tileMap);

            if (_currentHoveredTile is SelectableTile)
            {
                tileMap.SelectedTile = (SelectableTile)_currentHoveredTile;
            }
            else
            {
                tileMap.SelectedTile = null;
                return;
            }

            if (IsLeftMouseButtonPressed)
            {
                if (_isLeftMouseButtonHeld)
                {
                    return;
                }
                _isLeftMouseButtonHeld = true;
            } 
            else
            {
                _isLeftMouseButtonHeld = false;
                return;
            }

            Debug.WriteLine($"Clicking box {_currentHoveredTileRow}, {_currentHoveredTileCol}!");
            if (_currentHoveredTile.TileType == "dirt")
            {
                tileMap.ChangeTile(_currentHoveredTileRow, _currentHoveredTileCol, "water");
            }
            else if (_currentHoveredTile.TileType == "water")
            {
                tileMap.ChangeTile(_currentHoveredTileRow, _currentHoveredTileCol, "dirt");
            }
        }
    }
}
