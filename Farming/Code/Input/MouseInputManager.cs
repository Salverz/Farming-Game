using System;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Microsoft.Xna.Framework.Input;

namespace Farming
{
    public class MouseInputManager
    {
        private static MouseInputManager _instance = null;
        public static MouseInputManager Instance { get
            {
                if (_instance == null)
                {
                    _instance = new MouseInputManager();
                }
                return _instance;
            }
        }

        public void Update(Camera camera, TileMap tileMap)
        {
            MouseState mouseState = Mouse.GetState();
            GuiElement mouseTarget = GuiManager.Instance.GetGuiElementAtPosition(mouseState.X, mouseState.Y);
            if (mouseTarget == null)
            {
                TileMouseInputHandler.Instance.HandleTileSelection(camera, tileMap);
                return;
            }
            
            if (InputTools.Instance.CheckForSingleMousePress(mouseState.LeftButton))
            {
                mouseTarget.ElementClicked();
            }
        }
    }
}
