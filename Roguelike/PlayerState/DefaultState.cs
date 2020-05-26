using Microsoft.Xna.Framework;
using Roguelike.Interfaces;
using Roguelike.Player;
using Roguelike.Sprite;

namespace Roguelike.PlayerState
{
    public class DefaultState : IPlayerState
    {
        public bool isUp { get => false; }
        public bool isDown { get => false; }
        public bool isLeft { get => false; }
        public bool isRight { get => false;  }

        public DefaultState()
        {
            PlayerManager.Instance().PlayerInfo.sprite = PlayerSpriteFactory.Instance.CreatePlayerDefaultSprite(PlayerManager.Instance().Location);
        }


        public void Update(GameTime gameTime)
        {
            PlayerManager.Instance().Velocity = new Vector2(0, 0);
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
