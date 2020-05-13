using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Roguelike.Interfaces;
using Roguelike.Player;
using Roguelike.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.PlayerState
{
    public class DownState : IPlayerState
    {
        public bool isUp { get => false; }
        public bool isDown { get => true; }
        public bool isLeft { get => false; }
        public bool isRight { get => false; }
        private ISprite sprite;
        public DownState()
        {
            PlayerManager.Instance().PlayerInfo.sprite = PlayerSpriteFactory.Instance.CreatePlayerDownSprite(PlayerManager.Instance().Location);
        }

        public void Update(GameTime gameTime)
        {
            PlayerManager.Instance().Velocity = new Vector2(0, 1);
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
