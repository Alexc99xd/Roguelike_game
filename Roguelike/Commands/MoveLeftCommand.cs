using Roguelike.Interfaces;
using Roguelike.Player;

namespace Roguelike.Commands
{
    public class MoveLeftCommand : ICommand
    {
        public MoveLeftCommand()
        {

        }

        public void Execute()
        {
            PlayerManager.Instance().MoveLeft();
        }

        public void DeExecute()
        {
            PlayerManager.Instance().StopMoveLeft();
        }
    }
}
