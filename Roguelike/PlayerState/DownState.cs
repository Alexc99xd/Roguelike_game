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
    public class DownState : IPlayerState
    {

        public DownState()
        {

        }
        public void Update(GameTime gameTime)
        {
            PlayerManager.Instance().Velocity += new Vector2(1, 0);
        }

        public void MoveUp()
        {
            PlayerManager.Instance().State = new DefaultState();
        }

        public void MoveDown()
        {

        }

        public void MoveLeft()
        {
            PlayerManager.Instance().State = new DownLeftState();
        }

        public void MoveRight()
        {
            PlayerManager.Instance().State = new DownRightState();
        }
    }
}
