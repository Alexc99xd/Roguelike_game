using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Roguelike.Sprite;
using System;

namespace Roguelike.Interfaces
{
    public interface ICell
    {
        ISprite Sprite { get; set; }
        Vector2 Location { get; set; }
        Tuple<int,int> GridLocation { get; set; }
        void Draw(SpriteBatch spriteBatch);
        void Draw(SpriteBatch spriteBatch, float priority);
        void DrawMini(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
        int LayerType { get; set; }
    }
}
