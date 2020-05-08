using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Interfaces
{
    public interface IPlayerState
    {
        void Update(GameTime gameTime);
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();

    }
}
