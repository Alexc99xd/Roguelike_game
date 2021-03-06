﻿using Roguelike.Interfaces;
using Roguelike.Player;

namespace Roguelike.Commands
{
    public class MoveUpCommand : ICommand
    {
        public MoveUpCommand()
        {

        }

        public void Execute()
        {
            PlayerManager.Instance().MoveUp();
        }

        public void DeExecute()
        {
            PlayerManager.Instance().StopMoveUp();
        }
    }
}
