using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace Farming
{
    // Singleton
    public class TileMouseInputHandler
    {
        private static TileMouseInputHandler _instance = null;
        private bool _isLeftMouseButtonHeld;
        private Tile _currentHoveredTile;
        private int _currentHoveredTileRow;
        private int _currentHoveredTileCol;

        public static TileMouseInputHandler Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TileMouseInputHandler();
                }
                return _instance;
            }
        }

        private TileMouseInputHandler()
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

        public void HandleTileSelection(Camera camera, TileMap tileMap)
        {
            GetCurrentHoveredTile(camera, tileMap);

            if (_currentHoveredTile is SelectableTile)
            {
                tileMap.HoveredTile = (SelectableTile)_currentHoveredTile;
            }
            else
            {
                tileMap.HoveredTile = null;
                return;
            }

            MouseState mouseState = Mouse.GetState();
            if (!InputTools.Instance.ActivateOnMouseRelease(mouseState.LeftButton))
            {
                return;
            }

            if (_currentHoveredTile is SelectableTile && ((SelectableTile)_currentHoveredTile).Plant == null)
            {

                ((SelectableTile)_currentHoveredTile).Plant = PlantFactory.Instance.CreatePlant(GameGui.Instance.GetSelectedPlant());
            }
            else if (((SelectableTile)_currentHoveredTile).Plant.IsFullyGrown())
            {
                PlayerStats.Instance.Money += 50;
                ((SelectableTile)_currentHoveredTile).Plant = null;
            }
        }
    }
}
