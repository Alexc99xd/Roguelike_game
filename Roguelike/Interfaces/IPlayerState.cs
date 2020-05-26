using Microsoft.Xna.Framework;

namespace Roguelike.Interfaces
{
    public interface IPlayerState
    {
        void Update(GameTime gameTime);
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        bool isUp { get; }
        bool isDown { get; }
        bool isLeft { get; }
        bool isRight { get; }

    }
}
