using Microsoft.Xna.Framework.Input;
using System;

namespace Farming
{
    public class InputTools
    {
        private static InputTools _instance;

        public static InputTools Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InputTools();
                }
                return _instance;
            }
        }

        private bool leftMouseClicked;

        private InputTools()
        {
            leftMouseClicked = false;
        }

        // Return true if the mouse button has been pressed and then released, otherwise return false
        public bool ActivateOnMouseRelease(ButtonState mouseButton)
        {
            if (leftMouseClicked && mouseButton == ButtonState.Released)
            {
                leftMouseClicked = false;
                return true;
            }
            else if (mouseButton == ButtonState.Pressed)
            {
                leftMouseClicked = true;
            }
            return false;
        }

    }
}
