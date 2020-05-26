using Microsoft.Xna.Framework;
using Roguelike.Interfaces;
using Roguelike.Player;
using Roguelike.Sprite;

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
