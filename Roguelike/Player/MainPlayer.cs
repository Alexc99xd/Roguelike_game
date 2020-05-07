using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Roguelike.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Player
{
    public class MainPlayer
    {
        public Vector2 Location { get; set; }
        public IPlayerState State;

        bool moveUp = false;
        //probably should have player states...
        public MainPlayer()
        {
            Location = new Vector2(100, 100);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Game1.GetInstance().test, new Rectangle(X, Y, 320, 320), Color.White);
            //spriteBatch.Draw(Game1.GetInstance().playerContent.PlayerDefaultSpriteSheet, new Rectangle(X, Y, Game1.GetInstance().playerContent.PlayerDefaultSpriteSheet.Width, Game1.GetInstance().playerContent.PlayerDefaultSpriteSheet.Height), new Rectangle(Game1.GetInstance().playerContent.PlayerDefaultSpriteSheet.Width, Game1.GetInstance().playerContent.PlayerDefaultSpriteSheet.Height, Game1.GetInstance().playerContent.PlayerDefaultSpriteSheet.Width, Game1.GetInstance().playerContent.PlayerDefaultSpriteSheet.Height), Color.White);
        }

        public void Update(GameTime gameTime)
        {

        }

    }
}
