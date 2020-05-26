using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Roguelike.Sprite
{
    public class Sprite : ISprite
    {
        public Vector2 Location { get; set; }
        //possibly have destRect as hitbox, or list of circles, idk. Maybe both lol
        private Texture2D texture;
        private bool updateAnimation = true;
        private int currentFrame;
        private int timeSinceLastFrame;
        private float priority;
        private int frameWidth;
        private int frameHeight;
        private Rectangle destinationRectangle;
        private Color tint;
        private int numFrames = 1;
        private int framesPerSecond = 1;
        private int millisecondsPerFrame => 1000 / framesPerSecond;
        private bool simpleDraw = false;
        public Sprite(Texture2D texture, float priority, Vector2 location)
        {
            this.texture = texture;
            this.priority = priority;
            this.Location = location;
            frameWidth = texture.Width;
            frameHeight = texture.Height;
            tint = Color.White;
        }
        public Sprite(Texture2D texture, float priority, Vector2 location, Color color)
        {
            this.texture = texture;
            this.priority = priority;
            this.Location = location;
            frameWidth = texture.Width;
            frameHeight = texture.Height;
            tint = color;
        }

        public Sprite(Texture2D texture, Vector2 location)
        {
            this.texture = texture;
            this.priority = 0;
            this.Location = location;
            frameWidth = texture.Width;
            frameHeight = texture.Height;
            tint = Color.White;
            simpleDraw = true;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!simpleDraw)
            {
                Rectangle sourceRectangle = new Rectangle(currentFrame * frameWidth, 0, frameWidth, frameHeight);
                destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, frameWidth, frameHeight);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, tint, 0, Vector2.Zero, SpriteEffects.None, priority);
            } 
            else
            {
                spriteBatch.Draw(texture, Location, Color.White);
            }


        }

        public void Draw(SpriteBatch spriteBatch, float priority)
        {
            Rectangle sourceRectangle = new Rectangle(currentFrame * frameWidth, 0, frameWidth, frameHeight);
            destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, frameWidth, frameHeight);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, tint, 0, Vector2.Zero, SpriteEffects.None, priority);
        }



        public void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                UpdateAnimation();
            }
        }
        public void FreezeAnimation()
        {
            updateAnimation = false;
        }
        public void UnfreezeAnimation()
        {
            updateAnimation = true;
        }
        private void UpdateAnimation()
        {
            if (updateAnimation)
                currentFrame = (currentFrame + 1) % (numFrames);
        }
    }
}
