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
    public class UpLeftState : IPlayerState
    {
        public bool isUp { get => true; }
        public bool isDown { get => false; }
        public bool isLeft { get => true; }
        public bool isRight { get => false; }
        private ISprite sprite;
        public UpLeftState()
        {
            PlayerManager.Instance().PlayerInfo.sprite = PlayerSpriteFactory.Instance.CreatePlayerUpLeftSprite(PlayerManager.Instance().Location);
        }

        public void Update(GameTime gameTime)
        {
            PlayerManager.Instance().Velocity = new Vector2(-1, -1);
        }

        public void MoveUp()
        {

        }

        public void MoveDown()
        {
            PlayerManager.Instance().State = new LeftState();
        }

        public void MoveLeft()
        {

        }

        public void MoveRight()
        {
            PlayerManager.Instance().State = new UpState();
        }
    }
}
