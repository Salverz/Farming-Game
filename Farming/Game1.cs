using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace Farming
{
    public class Game1 : Game
    {
        private TileMap _tileMap;
        private SpriteFont _arial;
        private Gui gui;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Camera _camera;

        // Temporary
        private bool dayButtonPressed;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _camera = new Camera(GraphicsDevice.Viewport);
            _tileMap = new TileMap();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load textures
            TextureHandler.Instance.LoadTextures(Content);
            // Load fonts
            FontHandler.Instance.LoadFonts(Content);

            _arial = Content.Load<SpriteFont>("Fonts/Silkscreen");
            LoadScene();

            // TODO: use this.Content to load your game content here
        }

        private void LoadScene()
        {
            new GameGui();
            GuiManager.Instance.EnableGui("gameGui", 1);
            dayButtonPressed = false;

            _tileMap.FillTileMapWithDirt();
        }

        protected override void Update(GameTime gameTime)
        {
            // Exit game on Esc
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // Handle Camera Input
            CameraInputHandler.Instance.Update(_camera, gameTime);
            MouseInputManager.Instance.Update(_camera, _tileMap);

            // TEMPORARY/TESTING - Advance day
            if (Keyboard.GetState().IsKeyDown(Keys.P))
            {
                if (!dayButtonPressed)
                {
                    dayButtonPressed = true;
                    GameState.Instance.AdvanceDay();
                    PlayerStats.Instance.Money -= 100;
                }
            }
            else
            {
                dayButtonPressed = false;
            }

            // TEMPORARY/TESTING - Decrease money
            if (Keyboard.GetState().IsKeyDown(Keys.F12))
            {
                PlayerStats.Instance.Money += 100;
            }

            // Update Guis
            GuiManager.Instance.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw game
            _spriteBatch.Begin(transformMatrix: _camera.GetViewMatrix(), samplerState: SamplerState.PointClamp);
            _tileMap.Draw(_spriteBatch);
            _spriteBatch.End();

            // Draw to UI
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.DrawString(_arial, GameState.Instance.CurrentDayString(), new Vector2(-1, -9), Color.Black);
            GuiManager.Instance.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
