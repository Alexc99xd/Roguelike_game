using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Sprite
{
    public interface ISprite
    {
        void Draw(SpriteBatch spriteBatch);

        void Update(GameTime gameTime);

        Vector2 Location { get; set; }
    }
}
