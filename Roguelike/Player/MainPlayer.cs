using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Player
{
    public sealed class MainPlayer
    {
        int X;
        int Y;
        bool moveUp = false;
        //probably should have player states...
        private MainPlayer()
        {

            X = 100;
            Y = 100;
        }

        private static MainPlayer uniqueInstance;

        public static MainPlayer Instance()
        {
            if(uniqueInstance == null)
            {
                uniqueInstance = new MainPlayer();
            }
            return uniqueInstance;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Game1.GetInstance().test, new Rectangle(X, Y, 320, 320), Color.White);
            //spriteBatch.Draw(Game1.GetInstance().playerContent.PlayerDefaultSpriteSheet, new Rectangle(X, Y, Game1.GetInstance().playerContent.PlayerDefaultSpriteSheet.Width, Game1.GetInstance().playerContent.PlayerDefaultSpriteSheet.Height), new Rectangle(Game1.GetInstance().playerContent.PlayerDefaultSpriteSheet.Width, Game1.GetInstance().playerContent.PlayerDefaultSpriteSheet.Height, Game1.GetInstance().playerContent.PlayerDefaultSpriteSheet.Width, Game1.GetInstance().playerContent.PlayerDefaultSpriteSheet.Height), Color.White);
        }

        public void Update(GameTime gameTime)
        {
            //if state = move up...
            if (moveUp)
            {
                Y--;
            }
        }

        public void MoveUp()
        {
            moveUp = true;
        }

        public void StopMoveUp()
        {
            moveUp = false;
        }


    }
}
