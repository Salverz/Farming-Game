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
        private GuiElement potatoBuyButton;
        private GuiElement inventoryPotato;
        private GuiElement wheatBuyButton;
        private GuiElement inventoryWheat;

        public GameGui()
        {
            Gui gameGui = new Gui("gameGui");
            GuiManager.Instance.RegisterGuiBuilder(this);
            _instance = this;
            _selectedInventoryItem = "";
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

            inventoryPotato = new GuiElement.Builder()
                .SetName("inventoryPotatoSeed")
                .SetText("Potato starts: 0")
                .SetScreenPosition(500, 100)
                .SetTextPosition(0, 0)
                .SetTexture("default", TextureHandler.Instance.GetTexture("ui_slot"))
                .IsClickable()
                .Build();
            Action selectPotatoSeed = PotatoSeedButtonOnClick;
            inventoryPotato.AddOnClickAction("default", selectPotatoSeed);

            wheatBuyButton = new GuiElement.Builder()
                .SetName("wheatBuyButton")
                .SetText("Wheat $3")
                .SetScreenPosition(20, 700)
                .SetTextPosition(100, 30)
                .SetTexture("default", TextureHandler.Instance.GetTexture("shop_button"))
                .IsClickable()
                .Build();
            Action wheatBuyButtonOnClickAction = WheatBuyButtonOnClick;
            wheatBuyButton.AddOnClickAction("default", wheatBuyButtonOnClickAction);

            inventoryWheat = new GuiElement.Builder()
                .SetName("inventoryWheatSeed")
                .SetText("Wheat seeds: 0")
                .SetScreenPosition(500, 300)
                .SetTextPosition(0, 0)
                .SetTexture("default", TextureHandler.Instance.GetTexture("ui_slot"))
                .IsClickable()
                .Build();
            Action selectWheatSeed = WheatSeedButtonOnClick;
            inventoryWheat.AddOnClickAction("default", selectWheatSeed);

            // Add all inventory slots to the list of inventories
            _inventorySlots.Add(inventoryPotato);
            _inventorySlots.Add(inventoryWheat);

            // Add each GuiElement to the Gui
            gameGui.AddGuiElement(moneyDisplay);
            gameGui.AddGuiElement(temperatureDisplay);
            gameGui.AddGuiElement(potatoBuyButton);
            gameGui.AddGuiElement(inventoryPotato);
            gameGui.AddGuiElement(wheatBuyButton);
            gameGui.AddGuiElement(inventoryWheat);
        }

        // Public methods
        public string GetSelectedPlant()
        {
            Console.WriteLine($"Selected plant is currently: {_selectedInventoryItem}");
            return _selectedInventoryItem;
        }

        // On-click methods
        // Potato
        private void PotatoBuyButtonOnClick()
        {
            BuyItem("potato seed", 12, 1);
        }

        private void PotatoSeedButtonOnClick()
        {
            _selectedInventoryItem = "inventoryPotatoSeed";
        }

        // Wheat
        private void WheatBuyButtonOnClick()
        {
            BuyItem("wheat seed", 3, 1);
        }

        private void WheatSeedButtonOnClick()
        {
            _selectedInventoryItem = "inventoryWheatSeed";
            Console.WriteLine($"set selection to {_selectedInventoryItem}");
        }

        private void BuyItem(string item, int costEach, int quantity)
        {
            PlayerStats.Instance.Money -= costEach * quantity;
            PlayerStats.Instance.AddToInventory(item, quantity);
        }

        public void Update()
        {
            moneyDisplay.SetText($"${PlayerStats.Instance.Money}");
            temperatureDisplay.SetText($"{GameState.Instance.Temperature}F");

            // Set the color of the selected inventory slot to blue
            foreach (GuiElement inventorySlot in _inventorySlots)
            {
                if (_selectedInventoryItem == inventorySlot.Name)
                {
                    inventorySlot.SetColor(Color.Blue);
                }
                else
                {
                    inventorySlot.SetColor(Color.Black);
                }
            }

            inventoryPotato.SetText($"Potato starts: {PlayerStats.Instance.GetItemCountInInventory("potato seed")}");
            inventoryWheat.SetText($"Wheat seeds: {PlayerStats.Instance.GetItemCountInInventory("wheat seed")}");
        }
    }
}
