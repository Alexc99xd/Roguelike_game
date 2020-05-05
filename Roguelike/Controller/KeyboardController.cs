using Microsoft.Xna.Framework.Input;
using Roguelike.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Controller
{
    public class KeyboardController
    {
        KeyPressStack<Keys> keyStack;
        private Keys[] pressedKeys;
        private Keys[] prevKeyArray = { Keys.None };
        private Dictionary<Keys, ICommand> currentMapping;

        public KeyboardController()
        {
            //keyStack = new KeyPressStack<Keys>();
        }

        public void Update()
        {
            //we could either do
            //update every key on every frame (aka) key.execute()

            //or we could do it based on button state
            //if pressedDown, key.execute() <- has different functionality
            //if pressedUp, key.DeExecute() <- ends the command state

            //or a bit of both
            //WASD -> could be the pressedDown/pressedUp
            //rest of keys could be everyframe
        }

        //private void ArrayChangeToStack(Keys[] pressedKeys, Dictionary<Keys, ICommand> mapping)
        //{
        //    IEnumerable<Keys> keyUnpressed = prevKeyArray.Except(pressedKeys);
        //    IEnumerable<Keys> newKeyPressed = pressedKeys.Except(prevKeyArray);
        //    foreach (Keys pressed in newKeyPressed)
        //    {
        //        if (mapping.ContainsKey(pressed))
        //        {
        //            keyStack.Push(pressed);
        //        }

        //    }
        //    foreach (Keys unpressed in keyUnpressed)
        //    {
        //        keyStack.Remove(unpressed);
        //        //Can up "OnPressUp" (released pressed) command
        //    }
        //}
    }
}
