using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace Farming
{
    public class FontHandler
    {
        private static FontHandler _instance;
        public static FontHandler Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FontHandler();
                }
                return _instance;
            }
        }

        private Dictionary<string, SpriteFont> _fonts;

        private FontHandler()
        {
            _fonts = new Dictionary<string, SpriteFont>();
        }

        public void LoadFonts(ContentManager content)
        {
            _fonts["Silkscreen"] = content.Load<SpriteFont>("Fonts/Silkscreen");
        }

        public SpriteFont GetFont(string font)
        {
            if (_fonts.ContainsKey(font))
            {
                return _fonts[font];
            }
            throw new KeyNotFoundException($"Font {font} not found");
        }
    }
}
