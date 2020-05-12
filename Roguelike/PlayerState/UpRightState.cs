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
    public class UpRightState : IPlayerState
    {
        public bool isUp { get => true; }
        public bool isDown { get => false; }
        public bool isLeft { get => false; }
        public bool isRight { get => true; }
        private ISprite sprite;
        public UpRightState()
        {
            PlayerManager.Instance().PlayerInfo.sprite = PlayerSpriteFactory.Instance.CreatePlayerUpRightSprite(PlayerManager.Instance().Location);
        }

        public void Update(GameTime gameTime)
        {
            PlayerManager.Instance().Velocity = new Vector2(-1, 1);
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
