using Microsoft.Xna.Framework;
using Roguelike.Interfaces;
using Roguelike.Player;


namespace Roguelike.PlayerState
{
    public class LeftState : IPlayerState
    {
        public LeftState()
        {

        }
        public void Update(GameTime gameTime)
        {
            PlayerManager.Instance().Velocity += new Vector2(0, -1);
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
