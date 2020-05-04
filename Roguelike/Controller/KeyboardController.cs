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
            keyStack = new KeyPressStack<Keys>();
        }

        public void Update()
        {

        }

        private void ArrayChangeToStack(Keys[] pressedKeys, Dictionary<Keys, ICommand> mapping)
        {
            IEnumerable<Keys> keyUnpressed = prevKeyArray.Except(pressedKeys);
            IEnumerable<Keys> newKeyPressed = pressedKeys.Except(prevKeyArray);
            foreach (Keys pressed in newKeyPressed)
            {
                if (mapping.ContainsKey(pressed))
                {
                    keyStack.Push(pressed);
                }

            }
            foreach (Keys unpressed in keyUnpressed)
            {
                keyStack.Remove(unpressed);
                //Can up "OnPressUp" (released pressed) command
            }
        }
    }
}
