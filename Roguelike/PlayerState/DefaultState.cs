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
    public class DefaultState : IPlayerState
    {
        public DefaultState()
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void MoveUp()
        {
            PlayerManager.Instance().State = new UpState();
        }

        public void MoveDown()
        {
            PlayerManager.Instance().State = new DownState();
        }

        public void MoveLeft()
        {
            PlayerManager.Instance().State = new LeftState();
        }

        public void MoveRight()
        {
            PlayerManager.Instance().State = new RightState();
        }
    }
}
