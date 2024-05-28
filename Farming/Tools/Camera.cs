using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Farming
{
    public class Camera
    {
        public Vector2 Position { get; set; }
        public float Zoom { get; set; }

        private readonly Viewport _viewport;

        public Camera(Viewport viewport)
        {
            _viewport = viewport;
            Position = Vector2.Zero;
            Zoom = 1f;
        }

        // Zoom centered on the mouse's position
        public void ZoomCentered(float zoomAmount, Vector2 screenCenter)
        {
            Vector2 beforeZoomWorldPosition = ScreenToWorld(screenCenter);
            Zoom += zoomAmount;
            Zoom = Math.Clamp(Zoom, 0.5f, 3f);
            Vector2 afterZoomWorldPosition = ScreenToWorld(screenCenter);
            Position += beforeZoomWorldPosition - afterZoomWorldPosition;
        }

        public Vector2 ScreenToWorld(Vector2 screenPosition)
        {
            return Vector2.Transform(screenPosition, Matrix.Invert(GetViewMatrix()));
        }

        public Matrix GetViewMatrix()
        {
            return
                Matrix.CreateTranslation(new Vector3(-Position, 0f)) *
                Matrix.CreateScale(Zoom, Zoom, 1f) *
                Matrix.CreateTranslation(new Vector3(_viewport.Width * .5f, _viewport.Height * .5f, 0f));
        }
    }
}
