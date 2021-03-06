﻿using Microsoft.Xna.Framework;


namespace Roguelike.Camera
{
    public class GameCamera
    {
        // Construct a new Camera class with standard zoom (no scaling)
        public GameCamera()
        {
            Zoom = 0.15f;
        }

        // Centered Position of the Camera in pixels.
        public Vector2 Position { get; private set; }
        // Current Zoom level with 1.0f being standard
        public float Zoom { get; private set; }

        // Height and width of the viewport window which we need to adjust
        // any time the player resizes the game window.
        public int ViewportWidth { get; set; }
        public int ViewportHeight { get; set; }

        public Matrix TranslationMatrix {  get => Matrix.CreateTranslation(-(int)Position.X, -(int)Position.Y, 0) * Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) * Matrix.CreateTranslation(new Vector3(ViewportCenter, 0)); }

        // Center of the Viewport which does not account for scale
        public Vector2 ViewportCenter { get => new Vector2(ViewportWidth * 0.5f, ViewportHeight * 0.5f); }



        // Call this method with negative values to zoom out
        // or positive values to zoom in. It looks at the current zoom
        // and adjusts it by the specified amount. If we were at a 1.0f
        // zoom level and specified -0.5f amount it would leave us with
        // 1.0f - 0.5f = 0.5f so everything would be drawn at half size.
        public void AdjustZoom(float amount)
        {
            Zoom += amount;
            if (Zoom < 0.25f)
            {
                Zoom = 0.25f;
            }
        }


        // Center the camera on specific pixel coordinates
        public void CenterOn(Vector2 position)
        {
            Position = position;
            Position -= new Vector2(Global.ViewportWidth / 2, Global.ViewportHeight / 2);
            Position += new Vector2(16, 16);
            //change later to subtract from sprite center
        }

    }
}
