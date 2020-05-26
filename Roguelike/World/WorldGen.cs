using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Roguelike.Cell;
using Roguelike.Interfaces;
using Roguelike.Sprite;
using System;
using System.Collections.Generic;

namespace Roguelike.World
{
    public class WorldGen
    {
        public Random rnd = new Random();
        public ICell[,] CellArray = new ICell[Global.arraySize, Global.arraySize];
        private Tuple<int,int> startCell;
        private ICell headCell;
        private Tuple<int, int> endCell;

        private List<ICell> helperWalkerCells;
        private List<int> helperWalkerCellsLife;
        private int walkDistance = 0;
        private int maxWalkDistance = 1000;
        private int maxHelperWalkDistance = 55;
        private int downBias = 10;
        private int rightBias = 16;
        private int upBias = 10;
        private int leftBias = 8;
        private bool creatingMode;
        private int reproduceRate = 20;
        private int reproduceCounter = 0;

        private int counter = 0;

        public WorldGen()
        {
            helperWalkerCells = new List<ICell>();
            helperWalkerCellsLife = new List<int>();
            InitializeCellArray();
            startCell = GetStartCell();
            
            //get bias

            StartWalk();
            //start the walk
            //draw one per frame for visualize
        }

        private void InitializeCellArray()
        {
            for(int i = 0; i < Global.arraySize; i++)
            {
                for(int j = 0; j < Global.arraySize; j++)
                {
                    CellArray[i, j] = new Wall(new Vector2(i * Global.SpriteWidth, j * Global.SpriteHeight), i , j);
                }
            }
        }

        private Tuple<int,int> GetStartCell()
        {
            int x = rnd.Next(10, 30);
            int y = rnd.Next(100, 120);
            headCell = new Walker(new Vector2(x * Global.SpriteWidth, y * Global.SpriteHeight), x, y);
            return new Tuple<int, int>(x,y);
        }

        private void StartWalk()
        {
            creatingMode = true;
        }

        public void Update(GameTime gameTime)
        {
            if (creatingMode && counter++ % 3 == 0)
            {
                int dir = GetRandomDirectionBias(upBias, rightBias, downBias, leftBias);
                int x = headCell.GridLocation.Item1;
                int y = headCell.GridLocation.Item2;
                switch (dir)
                {
                    case 0:
                        headCell.GridLocation = new Tuple<int, int>(x, (y == 0) ? y : y - 1);
                        break;
                    case 1:
                        headCell.GridLocation = new Tuple<int, int>((x == Global.arraySize - 1) ? x : x + 1, y);
                        break;
                    case 2:
                        headCell.GridLocation = new Tuple<int, int>(x, (y == Global.arraySize - 1) ? y : y + 1);
                        break;
                    case 3:
                        headCell.GridLocation = new Tuple<int, int>((x == 0) ? x : x - 1, y);
                        break;
                    default:
                        break;
                }
                
                headCell.Update(gameTime);
                WalkerCellBreakDirt(headCell.GridLocation.Item1, headCell.GridLocation.Item2);

                if(reproduceCounter > reproduceRate)
                {
                    //make 4? new walker cells
                    helperWalkerCells.Add(new HelperWalker(new Vector2(headCell.GridLocation.Item1 * Global.SpriteWidth, headCell.GridLocation.Item2 * Global.SpriteHeight), headCell.GridLocation.Item1, headCell.GridLocation.Item2));
                    helperWalkerCellsLife.Add(0);
                    helperWalkerCells.Add(new HelperWalker(new Vector2(headCell.GridLocation.Item1 * Global.SpriteWidth, headCell.GridLocation.Item2 * Global.SpriteHeight), headCell.GridLocation.Item1, headCell.GridLocation.Item2));
                    helperWalkerCellsLife.Add(0);
                    helperWalkerCells.Add(new HelperWalker(new Vector2(headCell.GridLocation.Item1 * Global.SpriteWidth, headCell.GridLocation.Item2 * Global.SpriteHeight), headCell.GridLocation.Item1, headCell.GridLocation.Item2));
                    helperWalkerCellsLife.Add(0);
                    helperWalkerCells.Add(new HelperWalker(new Vector2(headCell.GridLocation.Item1 * Global.SpriteWidth, headCell.GridLocation.Item2 * Global.SpriteHeight), headCell.GridLocation.Item1, headCell.GridLocation.Item2));
                    helperWalkerCellsLife.Add(0);
                    reproduceCounter = 0;

                }
                reproduceCounter++;

                for(int i = 0; i < helperWalkerCells.Count; i++)
                {
                    ICell helper = helperWalkerCells[i];
                    int xH = helper.GridLocation.Item1;
                    int yH = helper.GridLocation.Item2;
                    int dir2 = GetRandomDirectionBias(12, 12, 12, 12);
                    switch (dir2)
                    {
                        case 0:
                            helper.GridLocation = new Tuple<int, int>(xH, (yH == 0) ? yH : yH - 1);
                            break;
                        case 1:
                            helper.GridLocation = new Tuple<int, int>((xH == Global.arraySize - 1) ? xH : xH + 1, yH);
                            break;
                        case 2:
                            helper.GridLocation = new Tuple<int, int>(xH, (yH == Global.arraySize - 1) ? yH : yH + 1);
                            break;
                        case 3:
                            helper.GridLocation = new Tuple<int, int>((xH == 0) ? xH : xH - 1, yH);
                            break;
                        default:
                            break;
                    }
                    //add one to it's life in the parallel list
                    helperWalkerCellsLife[i] += 1;

                    //update it
                    helper.Update(gameTime);

                    if (i % 11 == 10)
                    {
                        Tuple<int, int> pond = helperWalkerCells[i].GridLocation;
                        for (int k = 0; k < 3; k++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                CellArray[k + pond.Item1, j + pond.Item2] = new Water(new Vector2((k + pond.Item1) * Global.SpriteWidth, (j + pond.Item2) * Global.SpriteHeight), k + pond.Item1, j + pond.Item2);
                            }
                        }
                    }
                    else
                    {
                        WalkerCellBreakDirt(helper.GridLocation.Item1, helper.GridLocation.Item2);
                    }
                        

                }

                RemoveOldHelpers();

                walkDistance++;
                System.Console.WriteLine(walkDistance);
                if(walkDistance >= maxWalkDistance)
                {
                    creatingMode = false;
                    endCell = headCell.GridLocation;
                    //change all walkers to dirt except last one
                    helperWalkerCells.Clear();
                    CellArray[endCell.Item1, endCell.Item2] = new Hole(new Vector2(endCell.Item1 * Global.SpriteWidth, endCell.Item2 * Global.SpriteHeight), endCell.Item1, endCell.Item2);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawCellArray(spriteBatch);
            //draw walkers. 
            
            for (int i = 0; i < helperWalkerCells.Count; i++)
            {
                helperWalkerCells[i].Draw(spriteBatch);
            }
            if (creatingMode)
            {
                headCell.Draw(spriteBatch);
            }
        }

        private void DrawCellArray(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Global.arraySize; i++)
            {
                for (int j = 0; j < Global.arraySize; j++)
                {
                    CellArray[i, j].Draw(spriteBatch, 0.9f); //needed to see walkers....
                }
            }
        }

        private void WalkerCellBreakDirt(int x, int y)
        {
            CellArray[x, y] = new Dirt(new Vector2(x * Global.SpriteWidth, y * Global.SpriteHeight), x , y);
        }

        private void WalkerCellCreateWater(int x, int y)
        {
            CellArray[x, y] = new Water(new Vector2(x * Global.SpriteWidth, y * Global.SpriteHeight), x, y);
        }

        private void RemoveOldHelpers()
        {
            for(int i = helperWalkerCellsLife.Count - 1; i >= 0; i--)
            {


                if (helperWalkerCellsLife[i] >= maxHelperWalkDistance)
                {

                    helperWalkerCells.RemoveAt(i);
                    helperWalkerCellsLife.RemoveAt(i);
                }

            }
        }

        public int GetRandomDirectionBias(int upBias, int rightBias, int downBias, int leftBias)
        {
            
            int num = rnd.Next(0, upBias + rightBias + downBias + leftBias);
            if (num < upBias)
            {
                return 0;
            }
            else if (num < upBias + rightBias)
            {
                return 1;
            }
            else if (num < upBias + rightBias + downBias)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
    }
}
