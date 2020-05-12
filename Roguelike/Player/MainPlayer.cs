using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Roguelike.Interfaces;
using Roguelike.PlayerState;
using Roguelike.Sprite;
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
        public ISprite sprite;

        //probably should have player states...
        public MainPlayer()
        {
            Location = new Vector2(100, 100);

        }

        public void InitializeState()
        {
            State = new DefaultState();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //draw states for now?
            sprite.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            State.Update(gameTime);
            sprite.Location = Location;
        }

    }
}
