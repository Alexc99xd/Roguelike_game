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
    public class UpState : IPlayerState
    {
        public UpState()
        {

        }

        public void Update(GameTime gameTime)
        {
            PlayerManager.Instance().Velocity += new Vector2(-1, 0);
        }

        public void MoveUp()
        {

        }

        public void MoveDown()
        {
            PlayerManager.Instance().State = new DefaultState();
        }

        public void MoveLeft()
        {
            PlayerManager.Instance().State = new UpLeftState();
        }

        public void MoveRight()
        {
            PlayerManager.Instance().State = new UpRightState();
        }
    }
}
