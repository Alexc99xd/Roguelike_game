using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Roguelike.Sprite
{
    public interface ISprite
    {
        void Draw(SpriteBatch spriteBatch);
        void Draw(SpriteBatch spriteBatch, float priority);
        void DrawMini(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);

        Vector2 Location { get; set; }
    }
}
