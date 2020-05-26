using Microsoft.Xna.Framework;
using Roguelike.Interfaces;
using Roguelike.Player;
using Roguelike.Sprite;

namespace Roguelike.PlayerState
{
    public class DownRightState : IPlayerState
    {
        public bool isUp { get => false; }
        public bool isDown { get => true; }
        public bool isLeft { get => false; }
        public bool isRight { get => true; }
        private ISprite sprite;
        public DownRightState()
        {
            PlayerManager.Instance().PlayerInfo.sprite = PlayerSpriteFactory.Instance.CreatePlayerDownRightSprite(PlayerManager.Instance().Location);
        }

        public void Update(GameTime gameTime)
        {
            PlayerManager.Instance().Velocity = new Vector2(1, 1);
        }

        public void MoveUp()
        {
            PlayerManager.Instance().State = new RightState();
        }

        public void MoveDown()
        {
            
        }

        public void MoveLeft()
        {
            PlayerManager.Instance().State = new DownState();
        }

        public void MoveRight()
        {

        }
    }
}
