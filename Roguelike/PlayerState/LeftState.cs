using Microsoft.Xna.Framework;
using Roguelike.Interfaces;
using Roguelike.Player;
using Roguelike.Sprite;

namespace Roguelike.PlayerState
{
    public class LeftState : IPlayerState
    {
        public bool isUp { get => false; }
        public bool isDown { get => false; }
        public bool isLeft { get => true; }
        public bool isRight { get => false; }
        private ISprite sprite;
        public LeftState()
        {
            PlayerManager.Instance().PlayerInfo.sprite = PlayerSpriteFactory.Instance.CreatePlayerLeftSprite(PlayerManager.Instance().Location);
        }

        public void Update(GameTime gameTime)
        {
            PlayerManager.Instance().Velocity = new Vector2(-1, 0);
        }

        public void MoveUp()
        {
            PlayerManager.Instance().State = new UpLeftState();
        }

        public void MoveDown()
        {
            PlayerManager.Instance().State = new DownLeftState();
        }

        public void MoveLeft()
        {

        }

        public void MoveRight()
        {
            PlayerManager.Instance().State = new DefaultState();
        }
    }
}
