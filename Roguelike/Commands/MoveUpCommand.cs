using Roguelike.Interfaces;

namespace Roguelike.Commands
{
    public class MoveUpCommand : ICommand
    {
        public MoveUpCommand()
        {

        }

        public void Execute()
        {
            Player.MainPlayer.Instance().MoveUp();
        }

        public void DeExecute()
        {
            Player.MainPlayer.Instance().StopMoveUp();
        }
    }
}
