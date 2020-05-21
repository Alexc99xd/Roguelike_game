using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Roguelike.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.World
{
    public class World
    {

        public ISprite placeholder; //probably tile based world 
        public World()
        {

        }

        public void InitilizeSprite()
        {
            placeholder = WorldSpriteFactory.Instance.CreateWorldSprite(new Vector2(0, 0));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            placeholder.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            placeholder.Update(gameTime);
        }
    }
}
