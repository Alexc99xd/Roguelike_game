using Microsoft.Xna.Framework.Input;
using Roguelike.Interfaces;
using System.Collections.Generic;
using System.Linq;

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
            ControllerMappings c = new ControllerMappings();
            currentMapping = c.GameConfigs;
        }

        public void Update()
        {
            pressedKeys = Keyboard.GetState().GetPressedKeys();

            Keys[] keysToPress = DifferenceMapping(pressedKeys, prevKeyArray);
            Keys[] keysToUnPress = DifferenceMapping(prevKeyArray, pressedKeys);

            foreach(Keys k in keysToPress)
            {
                if(currentMapping.ContainsKey(k))
                    currentMapping[k].Execute();
            }

            foreach(Keys k in keysToUnPress)
            {
                if (currentMapping.ContainsKey(k))
                    currentMapping[k].DeExecute();
            }

            prevKeyArray = pressedKeys;
            //we could either do
            //update every key on every frame (aka) key.execute()

            //or we could do it based on button state
            //if pressedDown, key.execute() <- has different functionality
            //if pressedUp, key.DeExecute() <- ends the command state

            //or a bit of both
            //WASD -> could be the pressedDown/pressedUp
            //rest of keys could be everyframe
        }

        private Keys[] DifferenceMapping(Keys[] A, Keys[] B)
        {
            //take everything from A and diff with B
            IEnumerable<Keys> newKeyPressed = A.Except(B);
            //check if each key in newKeyPressed is in mapping

            return newKeyPressed.ToArray();
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
