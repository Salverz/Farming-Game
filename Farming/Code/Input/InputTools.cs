using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

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

        private List<ButtonState> _pressedMouseButtons;

        private InputTools()
        {
            _pressedMouseButtons = new List<ButtonState>();
        }

        public bool CheckForSingleMousePress(ButtonState mouseButton)
        {

            if (mouseButton == ButtonState.Pressed)
            {
                if (_pressedMouseButtons.Contains(mouseButton))
                {
                    return false;
                }
                _pressedMouseButtons.Add(mouseButton);
                return true;
            }

            _pressedMouseButtons.Remove(mouseButton);
            return false;
        }
    }
}
