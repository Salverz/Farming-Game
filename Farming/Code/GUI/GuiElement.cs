using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace Farming
{
    // Builder pattern
    public class GuiElement
    {
        private Dictionary<string, Texture2D> _textures;
        private string _text;
        private string _name;

        public string Name { get { return _name; } }
        public bool HasText { get; }
        public Color TextColor { get; set; }
        public bool HasTexture { get; }
        public Vector2 ScreenPosition { get; set; }
        public string SelectedTextureName { set; get; }
        public Texture2D SelectedTexture
        {
            get
            {
                return _textures[SelectedTextureName];
            }
        }
        public string Text
        {
            get
            {
                if (HasText)
                {
                    return _text;
                }
                throw new InvalidOperationException("This GuiElement cannot display text");
            }
            set
            {
                if (HasText)
                {
                    _text = value;
                }
                else
                {
                    throw new InvalidOperationException("This GuiElement cannot display text");
                }
            }
        }
        private Vector2 _textPosition;
        public class Builder
        {
            private string _name;
            private Dictionary<string, Texture2D> _textures;
            private string _defaultTextureName;
            private Vector2 _screenPosition;
            private bool _hasText;
            private bool _hasTexture;
            private Color _textColor;
            private string _text;
            private Vector2 _textPosition;
            private bool _textPositionSet;

            public Builder()
            {
                _hasText = false;
                _hasTexture = false;
                _textColor = Color.Black;
                _textPosition = Vector2.Zero;
                _textPositionSet = false;
                _textures = new Dictionary<string, Texture2D>();
                _defaultTextureName = "";
            }

            public Builder SetName(string name)
            {
                _name = name;
                return this;
            }

            public Builder SetScreenPosition(int x, int y)
            {
                _screenPosition = new Vector2(x, y);
                return this;
            }

            public Builder SetTexture(string textureName, Texture2D texture)
            {
                _hasTexture = true;
                _textures[textureName] = texture;

                if (_defaultTextureName == "")
                {
                    _defaultTextureName = textureName;
                }
                return this;
            }

            public Builder SetDefaultTextureName(string textureName)
            {
                _defaultTextureName = textureName;
                return this;
            }

            public Builder SetText(string text)
            {
                _hasText = true;
                _text = text;
                return this;
            }

            public Builder SetTextPosition(int x, int y)
            {
                _textPosition = new Vector2(x, y);
                _textPositionSet = true;
                return this;
            }

            public Builder SetTextColor(Color color)
            {
                _textColor = color;
                return this;

            }

            public GuiElement Build()
            {
                if (_name == "")
                {
                    throw new ArgumentException("No name was provided for the GuiElement");
                }

                Debug.WriteLine(_textures.ToString());
                if (!_hasText && !_textures.ContainsKey(_defaultTextureName))
                {
                    throw new ArgumentException("No textures were provided");
                }

                // Set text position to local position
                if (_hasText && _textPositionSet)
                {
                    _textPosition = new Vector2(_textPosition.X + _screenPosition.X, _textPosition.Y + _screenPosition.Y);
                }
                // Center text on default sprite if no text position is specified
                else if (_hasText)
                {
                    Vector2 stringPixelLength = FontHandler.Instance.GetFont("Silkscreen").MeasureString(_text);
                    _textPosition = new Vector2(-stringPixelLength.X + _screenPosition.X + (_textures[_defaultTextureName].Width / 2), _screenPosition.Y + (_textures[_defaultTextureName].Height / 2));
                    // _textPosition = new Vector2(_screenPosition.X, _screenPosition.Y);
                    Debug.WriteLine($"Screen pos: {_screenPosition.X}, {_screenPosition.Y}");
                    Debug.WriteLine($"size / 2: {_textures[_defaultTextureName].Width / 2}, {_textures[_defaultTextureName].Height / 2}");
                    Debug.WriteLine($"String length: {stringPixelLength}");
                    _textPosition = new Vector2(
                        _screenPosition.X
                        - 1 // SpriteFont offset
                        - stringPixelLength.X / 2 // Center based on string length
                        + 4 // SpriteFont center offset
                        + _textures[_defaultTextureName].Width / 2 // Center on sprite
                        ,
                        _screenPosition.Y
                        - 9 // SpriteFont offset
                        + stringPixelLength.Y / 2 // Center based on string height
                        - 20 // SpriteFont center offset
                        + _textures[_defaultTextureName].Height / 2 // Center on sprite
                        );
                }

                return new GuiElement
                    (
                        _name,
                        _screenPosition,
                        _textures,
                        _defaultTextureName,
                        _hasText,
                        _hasTexture,
                        _text,
                        _textPosition,
                        _textColor
                    );
            }
        }

        private GuiElement
            (
                string name,
                Vector2 screenPosition,
                Dictionary<string, Texture2D> textures,
                string defaultTextureName,
                bool hasText,
                bool hasTexture,
                string text,
                Vector2 textPosition,
                Color textColor
            )
        {
            _name = name;
            ScreenPosition = screenPosition;
            _textures = textures;
            SelectedTextureName = defaultTextureName;
            HasText = hasText;
            HasTexture = hasTexture;
            _text = text;
            _textPosition = textPosition;
            TextColor = textColor;
        }

        public void SetTextPosition(int x, int y)
        {
            _textPosition = new Vector2(ScreenPosition.X + x, ScreenPosition.Y + y);
        }

        public void SetText(string newText)
        {
            if (!HasText)
            {
                throw new InvalidOperationException($"Cannot change text of GuiElement ({_name} does not have any text)");
            }
            
            Text = newText;
        }

        public void SetColor(Color color)
        {
            TextColor = color;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (HasTexture)
            {
                spriteBatch.Draw(_textures[SelectedTextureName], ScreenPosition, null, Color.White, 0f, Vector2.Zero, 6f, SpriteEffects.None, 0f);
                // spriteBatch.Draw(_textures[SelectedTextureName], ScreenPosition, Color.White);
            }
            if (HasText)
            {
                //Debug.WriteLine("Writing: " + Text + " @ " + _textPosition.ToString() + " & screen pos: " + ScreenPosition);
                spriteBatch.DrawString(FontHandler.Instance.GetFont("Silkscreen"), Text, _textPosition, TextColor);
            }
        }
    }
}
