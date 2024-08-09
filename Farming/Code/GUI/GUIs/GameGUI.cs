using System;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Farming
{
    public class GameGUI : IGuiBuilder
    {
        private GuiElement itemSlot1;
        private GuiElement itemSlot2;
        private GuiElement itemSlot3;
        private GuiElement itemSlot4;
        private GuiElement itemSlot5;
        private GuiElement itemSlot6;
        private GuiElement itemSlot7;
        private GuiElement itemSlot8;
        private GuiElement itemSlot9;
        private GuiElement moneyDisplay;
        private GuiElement temperatureDisplay;
        private GuiElement potatoBuyButton;

        public GameGUI()
        {
            Gui gameGui = new Gui("gameGui");
            GuiManager.Instance.RegisterGuiBuilder(this);

            itemSlot1 = new GuiElement.Builder()
                .SetName("ItemSlot1")
                .SetScreenPosition(1800, 0)
                .SetTexture("default", TextureHandler.Instance.GetTexture("ui_slot"))
                .Build();

            itemSlot2 = new GuiElement.Builder()
                .SetName("ItemSlot2")
                .SetScreenPosition(1800, 120)
                .SetTexture("default", TextureHandler.Instance.GetTexture("ui_slot"))
                .Build();

            itemSlot3 = new GuiElement.Builder()
                .SetName("ItemSlot3")
                .SetScreenPosition(1800, 240)
                .SetTexture("default", TextureHandler.Instance.GetTexture("ui_slot"))
                .Build();

            itemSlot4 = new GuiElement.Builder()
                .SetName("ItemSlot4")
                .SetScreenPosition(1800, 360)
                .SetTexture("default", TextureHandler.Instance.GetTexture("ui_slot"))
                .Build();

            itemSlot5 = new GuiElement.Builder()
                .SetName("ItemSlot5")
                .SetScreenPosition(1800, 480)
                .SetTexture("default", TextureHandler.Instance.GetTexture("ui_slot"))
                .Build();

            itemSlot6 = new GuiElement.Builder()
                .SetName("ItemSlot6")
                .SetScreenPosition(1800, 600)
                .SetTexture("default", TextureHandler.Instance.GetTexture("ui_slot"))
                .Build();

            itemSlot7 = new GuiElement.Builder()
                .SetName("ItemSlot7")
                .SetScreenPosition(1800, 720)
                .SetTexture("default", TextureHandler.Instance.GetTexture("ui_slot"))
                .Build();

            itemSlot8 = new GuiElement.Builder()
                .SetName("ItemSlot8")
                .SetScreenPosition(1800, 840)
                .SetTexture("default", TextureHandler.Instance.GetTexture("ui_slot"))
                .Build();

            itemSlot9 = new GuiElement.Builder()
                .SetName("ItemSlot9")
                .SetScreenPosition(1800, 960)
                .SetTexture("default", TextureHandler.Instance.GetTexture("ui_slot"))
                .Build();

            moneyDisplay = new GuiElement.Builder()
                .SetName("moneyDisplay")
                .SetText($"${PlayerStats.Instance.Money}")
                .SetScreenPosition(0, 0)
                .SetTextPosition(1000, 50)
                .SetTextColor(Color.Green)
                .Build();

            temperatureDisplay = new GuiElement.Builder()
                .SetName("temperatureDisplay")
                .SetText($"{GameState.Instance.Temperature}F")
                .SetScreenPosition(0, 0)
                .SetTextPosition(500, 100)
                .Build();

            potatoBuyButton = new GuiElement.Builder()
                .SetName("potatoBuyButton")
                .SetText("Potato $12")
                .SetScreenPosition(20, 500)
                .SetTextPosition(100, 30)
                .SetTexture("default", TextureHandler.Instance.GetTexture("shop_button"))
                .IsClickable()
                .Build();


            Action potatoBuyButtonOnClickAction = PotatoBuyButtonOnClick;
            potatoBuyButton.AddOnClickAction("default", potatoBuyButtonOnClickAction);


            gameGui.AddGUIElement(itemSlot1);
            gameGui.AddGUIElement(itemSlot2);
            gameGui.AddGUIElement(itemSlot3);
            gameGui.AddGUIElement(itemSlot4);
            gameGui.AddGUIElement(itemSlot5);
            gameGui.AddGUIElement(itemSlot6);
            gameGui.AddGUIElement(itemSlot7);
            gameGui.AddGUIElement(itemSlot8);
            gameGui.AddGUIElement(itemSlot9);
            gameGui.AddGUIElement(moneyDisplay);
            gameGui.AddGUIElement(temperatureDisplay);
            gameGui.AddGUIElement(potatoBuyButton);
        }

        private void PotatoBuyButtonOnClick()
        {
            Debug.WriteLine("Potato button clicked!");
        }

        public void Update()
        {
            moneyDisplay.SetText($"${PlayerStats.Instance.Money}");
            temperatureDisplay.SetText($"{GameState.Instance.Temperature}F");
        }
    }
}
