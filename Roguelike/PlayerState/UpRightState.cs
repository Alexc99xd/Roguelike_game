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
    public class UpRightState : IPlayerState
    {
        public UpRightState()
        {

        }
        public void Update(GameTime gameTime)
        {
            PlayerManager.Instance().Velocity += new Vector2(-1, 1);
        }

        public void MoveUp()
        {

        }

        public void MoveDown()
        {
            PlayerManager.Instance().State = new RightState();
        }

        public void MoveLeft()
        {
            PlayerManager.Instance().State = new UpState();
        }

        public void MoveRight()
        {

        }
    }
}
