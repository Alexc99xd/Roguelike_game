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
        public Vector2 Velocity { get; set; }

        bool moveUp = false;
        //probably should have player states...
        public MainPlayer()
        {
            Location = new Vector2(100, 100);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
           
        }

        public void Update(GameTime gameTime)
        {
            State.Update(gameTime);
        }

    }
}
