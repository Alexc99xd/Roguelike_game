using Microsoft.Xna.Framework;
using Roguelike.Interfaces;
using Roguelike.Player;
using Roguelike.Sprite;

namespace Roguelike.PlayerState
{
    public class RightState : IPlayerState
    {
        public bool isUp { get => false; }
        public bool isDown { get => false; }
        public bool isLeft { get => false; }
        public bool isRight { get => true; }
        private ISprite sprite;
        public RightState()
        {
            PlayerManager.Instance().PlayerInfo.sprite = PlayerSpriteFactory.Instance.CreatePlayerRightSprite(PlayerManager.Instance().Location);
        }

        public void Update(GameTime gameTime)
        {
            PlayerManager.Instance().Velocity = new Vector2(1, 0);
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
