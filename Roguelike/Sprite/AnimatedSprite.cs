using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Roguelike.Sprite
{
    public class AnimatedSprite : ISprite
    {
        public Vector2 Location { get; set; }
        //possibly have destRect as hitbox, or list of circles, idk. Maybe both lol
        private Texture2D texture;
        private bool updateAnimation = true;
        private int currentFrame;
        private int timeSinceLastFrame;
        private int numFrames;
        private int framesPerSecond;
        private float priority;
        private int millisecondsPerFrame;
        private int frameWidth;
        private int frameHeight;
        private Rectangle destinationRectangle;
        private Color tint;
        public AnimatedSprite(Texture2D texture, int numOfFrames, int framesPerSecond, float priority, Vector2 location, int rows, int columns)
        {
            this.texture = texture;
            numFrames = numOfFrames;
            this.framesPerSecond = framesPerSecond;
            this.priority = priority;
            this.Location = location;
            millisecondsPerFrame = 1000 / framesPerSecond;
            frameWidth = texture.Width / columns;
            frameHeight = texture.Height / rows;
            tint = Color.White;
        }
        public AnimatedSprite(Texture2D texture, int numOfFrames, int framesPerSecond, float priority, Vector2 location, Color color, int rows, int columns)
        {
            this.texture = texture;
            numFrames = numOfFrames;
            this.framesPerSecond = framesPerSecond;
            this.priority = priority;
            this.Location = location;
            millisecondsPerFrame = 1000 / framesPerSecond;
            frameWidth = texture.Width / numFrames;
            frameHeight = texture.Height;
            tint = color;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
