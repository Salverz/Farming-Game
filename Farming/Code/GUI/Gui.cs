using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

namespace Farming
{
    // TODO: Add layers like in GuiManager
    public class Gui
    {
        private string _name;
        public string Name { get { return _name; } }
        private List<GuiElement> _guiElements;
        public List<GuiElement> GuiElements
        {
            get
            {
                return _guiElements;
            }
        }

        public Gui(string name)
        {
            _name = name;
            _guiElements = new List<GuiElement>();
            GuiManager.Instance.AddGui(this);
        }

        public void AddGUIElement(GuiElement element)
        {
            foreach (GuiElement guiElement in _guiElements)
            {
                if (guiElement.Name == element.Name)
                {
                    throw new ArgumentException($"An element named {element.Name} already exists in the {_name} GUI");
                }
            }
            GuiElements.Add(element);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (GuiElement element in GuiElements)
            {
                element.Draw(spriteBatch);
            }
        }
    }
}
