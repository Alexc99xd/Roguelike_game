using Microsoft.Xna.Framework;
using Roguelike.Interfaces;
using Roguelike.Player;
using Roguelike.Sprite;


namespace Roguelike.PlayerState
{
    public class UpState : IPlayerState
    {
        public bool isUp { get => true; }
        public bool isDown { get => false; }
        public bool isLeft { get => false; }
        public bool isRight { get => false; }
        private ISprite sprite;
        public UpState()
        {
            PlayerManager.Instance().PlayerInfo.sprite = PlayerSpriteFactory.Instance.CreatePlayerUpSprite(PlayerManager.Instance().Location);
        }

        public void Update(GameTime gameTime)
        {
            PlayerManager.Instance().Velocity = new Vector2(0, -1);
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
