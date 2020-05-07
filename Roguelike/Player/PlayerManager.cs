using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Player
{
    public class PlayerManager
    {
        public MainPlayer PlayerInfo;
        public Vector2 Location { get => PlayerInfo.Location; set => PlayerInfo.Location = value; }

        private PlayerManager()
        {

        }

        private static PlayerManager uniqueInstance;

        public static PlayerManager Instance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new PlayerManager();
            }
            return uniqueInstance;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        //methods for changing state I guess...

        public void MoveUp()
        {
            PlayerInfo.State.MoveUp(); //implement this
        }
    }
}
