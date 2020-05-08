using Microsoft.Xna.Framework;
using Roguelike.Interfaces;
using Roguelike.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.PlayerState
{
    public class DownLeftState : IPlayerState
    {
        public DownLeftState()
        {

        }

        public void Update(GameTime gameTime)
        {
            PlayerManager.Instance().Velocity += new Vector2(1, -1); //later have some speed constant instead of 1,1
        }

        public void MoveUp()
        {
            PlayerManager.Instance().State = new LeftState();
        }

        public void MoveDown()
        {

        }

        public void MoveLeft()
        {

        }

        public void MoveRight()
        {
            PlayerManager.Instance().State = new DownState();
        }
    }
}
