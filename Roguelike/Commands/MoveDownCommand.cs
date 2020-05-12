using Roguelike.Interfaces;
using Roguelike.Player;

namespace Roguelike.Commands
{
    public class MoveDownCommand : ICommand
    {
        public MoveDownCommand()
        {

        }

        public void Execute()
        {
            PlayerManager.Instance().MoveDown();
        }

        public void DeExecute()
        {
            PlayerManager.Instance().StopMoveDown();
        }
    }
}
