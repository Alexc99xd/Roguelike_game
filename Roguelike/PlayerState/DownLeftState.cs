using Microsoft.Xna.Framework;
using Roguelike.Interfaces;
using Roguelike.Player;
using Roguelike.Sprite;

namespace Roguelike.PlayerState
{
    public class DownLeftState : IPlayerState
    {
        public bool isUp { get => false; }
        public bool isDown { get => true; }
        public bool isLeft { get => true; }
        public bool isRight { get => false; }
        private ISprite sprite;
        public DownLeftState()
        {
            PlayerManager.Instance().PlayerInfo.sprite = PlayerSpriteFactory.Instance.CreatePlayerDownLeftSprite(PlayerManager.Instance().Location);
        }

        public void Update(GameTime gameTime)
        {
            PlayerManager.Instance().Velocity = new Vector2(-1, 1); //later have some speed constant instead of 1,1
        }

        public void MoveUp()
        {
            PlayerManager.Instance().State = new LeftState();
        }

        public void MoveDown()
        {

        }

        public void MoveLeft()
        {

        }

        public void MoveRight()
        {
            PlayerManager.Instance().State = new DownState();
        }
    }
}
