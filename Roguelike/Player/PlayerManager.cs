using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Roguelike.Interfaces;

namespace Roguelike.Player
{
    public class PlayerManager
    {
        public MainPlayer PlayerInfo { get; set; }
        public PlayerContent PlayerCont;
        public IPlayerState State { get => PlayerInfo.State; set => PlayerInfo.State = value; }
        public Vector2 Location { get => PlayerInfo.Location; set => PlayerInfo.Location = value; }
        public Vector2 Velocity { get => PlayerInfo.Velocity; set => PlayerInfo.Velocity = value; }
        //public Vector2 SpriteCenter {  //get from state? or Sprite?}

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

        public void Initialize()
        {
            PlayerInfo = new MainPlayer();

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            PlayerInfo.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            PlayerInfo.Update(gameTime);
            Location += Velocity;
        }

        public void LoadContent(ContentManager content)
        {
            PlayerCont = new PlayerContent(content);
            PlayerInfo.InitializeState();
        }


        //methods for changing state I guess...

        public void MoveUp()
        {
            //check if down state and do supermove up?
            if (PlayerInfo.State.isDown)
            {
                PlayerInfo.State.MoveUp();
            }
            PlayerInfo.State.MoveUp();
        }

        public void MoveDown()
        {
            if (PlayerInfo.State.isUp)
            {
                PlayerInfo.State.MoveDown();
            }
            PlayerInfo.State.MoveDown();
        }

        public void MoveLeft()
        {
            if (PlayerInfo.State.isRight)
            {
                PlayerInfo.State.MoveLeft();
            }
            PlayerInfo.State.MoveLeft();
        }

        public void MoveRight()
        {
            if (PlayerInfo.State.isLeft)
            {
                PlayerInfo.State.MoveRight();
            }
            PlayerInfo.State.MoveRight();
        }

        //these methods don't just change state by calling MoveUp() or the others, 
        //they check to see if it is actually in an upstate before changing 
        public void StopMoveUp()
        {
            if (PlayerInfo.State.isUp)
            {
                PlayerInfo.State.MoveDown();
            }
        }
        public void StopMoveDown()
        {
            if (PlayerInfo.State.isDown)
            {
                PlayerInfo.State.MoveUp();
            }
        }
        public void StopMoveLeft()
        {
            if (PlayerInfo.State.isLeft)
            {
                PlayerInfo.State.MoveRight();
            }
        }
        public void StopMoveRight()
        {
            if (PlayerInfo.State.isRight)
            {
                PlayerInfo.State.MoveLeft();
            }
        }
    }
}
