using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Farming
{
    public class GameGui : IGuiBuilder
    {
        private static GameGui _instance;
        public static GameGui Instance
        {
            get
            {
                return _instance;
            }
        }

        private string _selectedInventoryItem;
        private string _selectedInventorySlot;
        private List<GuiElement> _inventorySlots;

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
        private GuiElement potatoSeedBuyButton;
        private GuiElement inventoryPotatoSeed;
        private GuiElement wheatSeedBuyButton;
        private GuiElement inventoryWheatSeed;

        public GameGui()
        {
            GuiManager.Instance.RegisterGuiBuilder(this);
            Gui gameGui = new Gui("gameGui");
            _instance = this;
            _selectedInventoryItem = "";
            _selectedInventorySlot = "";
            _inventorySlots = new List<GuiElement>();

            itemSlot1 = new GuiElement.Builder()
                .SetName("ItemSlot1")
                .SetScreenPosition(1800, 0)
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

            potatoSeedBuyButton = new GuiElement.Builder()
                .SetName("potatoBuyButton")
                .SetText("Potato $12")
                .SetScreenPosition(20, 500)
                .SetTextPosition(100, 30)
                .SetTexture("default", TextureHandler.Instance.GetTexture("shop_button"))
                .IsClickable()
                .Build();
            Action potatoBuyButtonOnClickAction = delegate () { HandleBuyItem(new List<Object> { "potatoSeed", 12, 1 }); };
            potatoSeedBuyButton.AddOnClickAction("default", potatoBuyButtonOnClickAction);

            inventoryPotatoSeed = new GuiElement.Builder()
                .SetName("inventoryPotatoSeed")
                .SetText("Potato starts: 0")
                .SetScreenPosition(500, 100)
                .SetTextPosition(0, 0)
                .SetTexture("default", TextureHandler.Instance.GetTexture("ui_slot"))
                .IsClickable()
                .Build();
            Action selectPotatoSeed = delegate () { HandleSelectInventoryItem(new List<Object> { "inventoryPotatoSeed", "potatoSeed" }); };
            inventoryPotatoSeed.AddOnClickAction("default", selectPotatoSeed);

            wheatSeedBuyButton = new GuiElement.Builder()
                .SetName("wheatBuyButton")
                .SetText("Wheat $3")
                .SetScreenPosition(20, 700)
                .SetTextPosition(100, 30)
                .SetTexture("default", TextureHandler.Instance.GetTexture("shop_button"))
                .IsClickable()
                .Build();
            Action wheatBuyButtonOnClickAction = delegate () { HandleBuyItem(new List<Object> { "wheatSeed", 3, 1 }); };
            wheatSeedBuyButton.AddOnClickAction("default", wheatBuyButtonOnClickAction);

            inventoryWheatSeed = new GuiElement.Builder()
                .SetName("inventoryWheatSeed")
                .SetText("Wheat seeds: 0")
                .SetScreenPosition(500, 300)
                .SetTextPosition(0, 0)
                .SetTexture("default", TextureHandler.Instance.GetTexture("ui_slot"))
                .IsClickable()
                .Build();
            Action selectWheatSeed = delegate () { HandleSelectInventoryItem(new List<Object> { "inventoryWheatSeed", "wheatSeed" }); };
            inventoryWheatSeed.AddOnClickAction("default", selectWheatSeed);

            // Add all inventory slots to the list of inventories
            _inventorySlots.Add(inventoryPotatoSeed);
            _inventorySlots.Add(inventoryWheatSeed);

            // Add each GuiElement to the Gui
            gameGui.AddGuiElement(moneyDisplay);
            gameGui.AddGuiElement(temperatureDisplay);
            gameGui.AddGuiElement(potatoSeedBuyButton);
            gameGui.AddGuiElement(inventoryPotatoSeed);
            gameGui.AddGuiElement(wheatSeedBuyButton);
            gameGui.AddGuiElement(inventoryWheatSeed);
        }

        // Public methods
        public string GetSelectedPlant()
        {
            Console.WriteLine($"Selected plant is currently: {_selectedInventoryItem}");
            return _selectedInventoryItem;
        }

        // On-click methods
        // Parameters should be: string item, int costEach, int quantity
        private void HandleBuyItem(List<Object> parameters)
        {
            string item = (string)parameters[0];
            int costEach = (int)parameters[1];
            int quantity = (int)parameters[2];
            PlayerStats.Instance.Money -= costEach * quantity;
            PlayerStats.Instance.AddToInventory(item, quantity);
        }

        // Parameters should be: string inventorySlot, string item
        private void HandleSelectInventoryItem(List<Object> parameters)
        {
            string inventorySlot = (string)parameters[0];
            string item = (string)parameters[1];
            _selectedInventorySlot = inventorySlot;
            _selectedInventoryItem = item;
        }

        public void Update()
        {
            moneyDisplay.SetText($"${PlayerStats.Instance.Money}");
            temperatureDisplay.SetText($"{GameState.Instance.Temperature}F");

            // Set the color of the selected inventory slot to blue
            foreach (GuiElement inventorySlot in _inventorySlots)
            {
                if (_selectedInventorySlot == inventorySlot.Name)
                {
                    inventorySlot.SetColor(Color.Blue);
                }
                else
                {
                    inventorySlot.SetColor(Color.Black);
                }
            }

            inventoryPotatoSeed.SetText($"Potato starts: {PlayerStats.Instance.GetItemCountInInventory("potatoSeed")}");
            inventoryWheatSeed.SetText($"Wheat seeds: {PlayerStats.Instance.GetItemCountInInventory("wheatSeed")}");
        }
    }
}
