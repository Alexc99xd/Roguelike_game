using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Roguelike.Interfaces;


namespace Roguelike.Player
{
    public class PlayerManager
    {
        public MainPlayer PlayerInfo;
        public IPlayerState State { get => PlayerInfo.State; set => PlayerInfo.State = value; }
        public Vector2 Location { get => PlayerInfo.Location; set => PlayerInfo.Location = value; }
        public Vector2 Velocity { get => PlayerInfo.Velocity; set => PlayerInfo.Velocity = value; }

        private PlayerManager()
        {

        }

        private static PlayerManager uniqueInstance;

        public static PlayerManager Instance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new PlayerManager();
            }
            return uniqueInstance;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            PlayerInfo.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            PlayerInfo.Update(gameTime);
        }

        //methods for changing state I guess...

        public void MoveUp()
        {
            PlayerInfo.State.MoveUp(); //implement this
        }

        public void MoveDown()
        {
            PlayerInfo.State.MoveDown();
        }

        public void MoveLeft()
        {
            PlayerInfo.State.MoveLeft();
        }

        public void MoveRight()
        {
            PlayerInfo.State.MoveRight();
        }
    }
}
