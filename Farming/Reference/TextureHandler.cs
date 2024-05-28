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
            _textures["water"] = content.Load<Texture2D>("Textures/Tiles/water");
            _textures["farmland"] = content.Load<Texture2D>("Textures/Tiles/farmland");
            _textures["wet_farmland"] = content.Load<Texture2D>("Textures/Tiles/farmland_moist");
            _textures["dirt"] = content.Load<Texture2D>("Textures/Tiles/dirt");
            Debug.WriteLine("Textures loaded!");
            Debug.WriteLine(_textures.ToString());
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
