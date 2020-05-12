using Roguelike.Interfaces;
using Roguelike.Player;

namespace Roguelike.Commands
{
    public class MoveRightCommand : ICommand
    {
        public MoveRightCommand()
        {

        }

        public void Execute()
        {
            PlayerManager.Instance().MoveRight();
        }

        public void DeExecute()
        {
            PlayerManager.Instance().StopMoveRight();
        }
    }
}
