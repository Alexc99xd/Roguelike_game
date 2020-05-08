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
    public class RightState : IPlayerState
    {
        public RightState()
        {

        }

        public void Update(GameTime gameTime)
        {
            PlayerManager.Instance().Velocity += new Vector2(0, 1);
        }

        public void MoveUp()
        {
            PlayerManager.Instance().State = new UpRightState();
        }

        public void MoveDown()
        {
            PlayerManager.Instance().State = new DownRightState();
        }

        public void MoveLeft()
        {
            PlayerManager.Instance().State = new DefaultState();
        }

        public void MoveRight()
        {

        }
    }
}
