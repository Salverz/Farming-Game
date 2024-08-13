using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace Farming
{
    // Singleton
    public class GuiManager
    {
        private static GuiManager _instance;
        public static GuiManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GuiManager();
                }
                return _instance;
            }
        }

        // List of all GUIs
        private List<Gui> guis;
        // The current active GUIs and they layer they are on
        private Dictionary<Gui, int> activeGuis;
        // List of all GUI builder classes
        private List<IGuiBuilder> guiBuilders;

        private GuiManager()
        {
            guis = new List<Gui>();
            activeGuis = new Dictionary<Gui, int>();
            guiBuilders = new List<IGuiBuilder>();
        }

        // Add a GUI to the list of available GUIs
        public void AddGui(Gui gui)
        {
            guis.Add(gui);
        }

        public void RegisterGuiBuilder(IGuiBuilder guiBuilder)
        {
            guiBuilders.Add(guiBuilder);
        }

        // Remove a GUI from the list of available GUIs
        public void RemoveGui(string guiName)
        {
            foreach (Gui gui in guis)
            {
                if (gui.Name == guiName)
                {
                    guis.Remove(gui);
                    return;
                }
            }
            throw new ArgumentException($"{guiName} does not exist");
        }

        public void EnableGui(string guiName, int layer)
        {
            foreach (Gui gui in guis)
            {
                if (gui.Name == guiName)
                {
                    // GUI is already enabled
                    if (activeGuis.ContainsKey(gui))
                    {
                        throw new ArgumentException($"{guiName} is already active");
                    }
                    activeGuis.Add(gui, layer);
                }
            }
        }

        public void DisableGui(string guiName)
        {
            foreach (Gui gui in activeGuis.Keys)
            {
                if (gui.Name == guiName)
                {
                    activeGuis.Remove(gui);
                    return;
                }
            }
            throw new ArgumentException($"{guiName} is not enabled");
        }

        public int GetTopGui()
        {
            int topLayer = 0;
            foreach (int layer in activeGuis.Values)
            {
                if (layer > topLayer)
                {
                    topLayer = layer;
                }
            }
            return topLayer;
        }

        public int GetBottomGui()
        {
            int bottomLayer = int.MaxValue;
            foreach (int layer in activeGuis.Values)
            {
                if (layer < bottomLayer)
                {
                    bottomLayer = layer;
                }
            }
            return bottomLayer;
        }

        public GuiElement GetGuiElementAtPosition(int x, int y)
        {
            foreach (Gui gui in activeGuis.Keys)
            {
                foreach (GuiElement guiElement in gui.GuiElements)
                {
                    if (guiElement.ClickBoundingBox.Contains(new Point(x, y))) {
                        // Debug.WriteLine($"found Gui element: {guiElement.Name}");
                        return guiElement;
                    }
                }
            }
            // Debug.WriteLine($"Did not find gui element");
            return null;
        }

        public void Update()
        {
            foreach (IGuiBuilder guiBuilder in guiBuilders)
            {
                guiBuilder.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Debug.WriteLine(activeGuis.Values);
            foreach (Gui gui in activeGuis.Keys)
            {
                gui.Draw(spriteBatch);
            }
        }
    }
}
