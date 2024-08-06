using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace Farming
{
    // Singleton
    public class TextureHandler
    {
        private static TextureHandler _instance;

        public static TextureHandler Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TextureHandler();
                }
                return _instance;
            }
        }

        private Dictionary<string, Texture2D> _textures;

        public TextureHandler()
        {
            Debug.WriteLine("TextureHandler created!");
            _textures = new Dictionary<string, Texture2D>();
        }

        public void LoadTextures(ContentManager content)
        {
            Debug.WriteLine("Loading textures...");
            // Tiles
            LoadTileTextures(content);

            LoadGUITextures(content);

            Debug.WriteLine("Textures loaded!");
            Debug.WriteLine(_textures.ToString());
        }

        private void LoadGUITextures(ContentManager content)
        {
            // Buttons
            _textures["next_day_button"] = content.Load<Texture2D>("Textures/UI/Buttons/next_day_button");
            _textures["ui_slot"] = content.Load<Texture2D>("Textures/UI/ui_slot");
        }
        
        private void LoadTileTextures(ContentManager content)
        {
            _textures["tile_selector"] = content.Load<Texture2D>("Textures/Tiles/tile_selector16");
            _textures["water"] = content.Load<Texture2D>("Textures/Tiles/water");
            _textures["farmland"] = content.Load<Texture2D>("Textures/Tiles/farmland");
            _textures["wet_farmland"] = content.Load<Texture2D>("Textures/Tiles/farmland_moist");
            _textures["dirt"] = content.Load<Texture2D>("Textures/Tiles/dirt16");
            _textures["wheat_stage0"] = content.Load<Texture2D>("Textures/Tiles/wheat_stage0");
            _textures["wheat_stage1"] = content.Load<Texture2D>("Textures/Tiles/wheat_stage1");
            _textures["wheat_stage2"] = content.Load<Texture2D>("Textures/Tiles/wheat_stage2");
            _textures["wheat_stage3"] = content.Load<Texture2D>("Textures/Tiles/wheat_stage3");
            _textures["wheat_stage4"] = content.Load<Texture2D>("Textures/Tiles/wheat_stage4");
            _textures["wheat_stage5"] = content.Load<Texture2D>("Textures/Tiles/wheat_stage5");
            _textures["wheat_stage6"] = content.Load<Texture2D>("Textures/Tiles/wheat_stage6");
            _textures["wheat_stage7"] = content.Load<Texture2D>("Textures/Tiles/wheat_stage7");
            _textures["potato_plant_stage1"] = content.Load<Texture2D>("Textures/Plants/Potato/potato_plant_stage1");
        }    

        public Texture2D GetTexture(string name)
        {
            if (_textures.ContainsKey(name))
            {
                return _textures[name];
            }
            else
            {
                throw new KeyNotFoundException($"Texture '{name}' not found");
            }
        }
    }
}
