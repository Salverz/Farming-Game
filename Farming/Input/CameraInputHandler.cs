using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Farming
{
    // Singleton
    public class CameraInputHandler
    {
        public static CameraInputHandler _instance = null;

        private int previousScrollWheelValue;
        private int cameraSpeed;
        private float cameraSlowdownAcceleration;

        private Dictionary<string, float> directionSpeeds;

        private CameraInputHandler()
        {
            previousScrollWheelValue = 0;
            cameraSpeed = 1000;
            cameraSlowdownAcceleration = 12f;
            directionSpeeds = new Dictionary<string, float>
            {
                {"up", 0f},
                {"down", 0f},
                {"left", 0f},
                {"right", 0f},
            };
        }

        public static CameraInputHandler Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CameraInputHandler();
                }
                return _instance;
            }
        }

        public void Update(Camera camera, GameTime gameTime)
        {
            // Handle keyboard panning
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.W))
            {
                camera.Position = new Vector2(camera.Position.X, camera.Position.Y - cameraSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
                directionSpeeds["up"] = cameraSpeed;
            }
            else if (directionSpeeds["up"] >= 0f && gameTime.ElapsedGameTime.TotalMilliseconds != 0f)
            {
                directionSpeeds["up"] /= (float)gameTime.ElapsedGameTime.TotalMilliseconds / cameraSlowdownAcceleration;
                camera.Position = new Vector2(camera.Position.X, camera.Position.Y - directionSpeeds["up"] * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (keyState.IsKeyDown(Keys.S))
            {
                camera.Position = new Vector2(camera.Position.X, camera.Position.Y + cameraSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
                directionSpeeds["down"] = cameraSpeed;
            }
            else if (directionSpeeds["down"] >= 0f && gameTime.ElapsedGameTime.TotalMilliseconds != 0f)
            {
                directionSpeeds["down"] /= (float)gameTime.ElapsedGameTime.TotalMilliseconds / cameraSlowdownAcceleration;
                camera.Position = new Vector2(camera.Position.X, camera.Position.Y + directionSpeeds["down"] * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (keyState.IsKeyDown(Keys.A))
            {
                camera.Position = new Vector2(camera.Position.X - cameraSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds, camera.Position.Y);
                directionSpeeds["left"] = cameraSpeed;
            }
            else if (directionSpeeds["left"] >= 0f && gameTime.ElapsedGameTime.TotalMilliseconds != 0f)
            {
                directionSpeeds["left"] /= (float)gameTime.ElapsedGameTime.TotalMilliseconds / cameraSlowdownAcceleration;
                camera.Position = new Vector2(camera.Position.X - directionSpeeds["left"] * (float)gameTime.ElapsedGameTime.TotalSeconds, camera.Position.Y);
            }

            if (keyState.IsKeyDown(Keys.D))
            {
                camera.Position = new Vector2(camera.Position.X + cameraSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds, camera.Position.Y);
                directionSpeeds["right"] = cameraSpeed;
            } 
            else if (directionSpeeds["right"] >= 0f && gameTime.ElapsedGameTime.TotalMilliseconds != 0f)
            {
                directionSpeeds["right"] /= (float)gameTime.ElapsedGameTime.TotalMilliseconds / cameraSlowdownAcceleration;
                camera.Position = new Vector2(camera.Position.X + directionSpeeds["right"] * (float)gameTime.ElapsedGameTime.TotalSeconds, camera.Position.Y);
            }

            // Handle zoom in/out
            MouseState currentMouseState = Mouse.GetState();
            float scrollDelta = currentMouseState.ScrollWheelValue - previousScrollWheelValue;
            previousScrollWheelValue = currentMouseState.ScrollWheelValue;
            if (scrollDelta != 0)
            {
                float zoomAmount = scrollDelta / 1200f;
                camera.ZoomCentered(zoomAmount, new Vector2(currentMouseState.X, currentMouseState.Y));
            }
        }
    }
}
