using Microsoft.Xna.Framework.Input;
using Roguelike.Commands;
using Roguelike.Interfaces;
using System.Collections.Generic;



namespace Roguelike.Controller
{
    public class ControllerMappings
    {

        public Dictionary<Keys, ICommand> GameConfigs { get; set; }

        public ControllerMappings()
        {
            GameConfigs = new Dictionary<Keys, ICommand> { 
                { Keys.W, new MoveUpCommand() } ,
            };
        }

    }
}
