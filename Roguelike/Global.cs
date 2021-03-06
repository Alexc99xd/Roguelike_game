﻿using Microsoft.Xna.Framework;
using System;

namespace Roguelike
{
    public static class Global
    {
        public static readonly int MapWidth = 64;
        public static readonly int MapHeight = 36;
        public static readonly int SpriteWidth = 64;
        public static readonly int SpriteHeight = 64;
        public static readonly int arraySize = 128;
        public static int ViewportWidth = 0;
        public static int ViewportHeight = 0;

        public enum Direction
        {
            Up, Right, Down, Left, None, UpRight, UpLeft, DownRight, DownLeft,
        }
        public struct Level
        {
            public Rectangle[] vl;
            public Rectangle[] cts;
            public Color[] st;
            public int[] currTexNum;
        }

    }
}
