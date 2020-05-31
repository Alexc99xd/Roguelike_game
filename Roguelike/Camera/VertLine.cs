using Microsoft.Xna.Framework;
using Roguelike;

namespace RogueLike.Camera
{
    public class VertLine
    {
        //vertical line creator from a sprite
        //aka 1 width rectangles of the sprite
        public Rectangle[] vert { get; set; }
        public VertLine(int textureWidth)
        {
            vert = new Rectangle[textureWidth];

            for (int x = 0; x < textureWidth; x++)
            {
                vert[x] = new Rectangle(x, 0, 1, Global.SpriteHeight);
            }
        }
    }
}