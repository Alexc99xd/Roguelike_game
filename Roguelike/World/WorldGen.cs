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
        private int downBias = 20;
        private int rightBias = 20;
        private int upBias = 20;
        private int leftBias = 20;
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
            int x = rnd.Next(30, 50);
            int y = rnd.Next(30, 50);
            headCell = new Walker(new Vector2(x * Global.SpriteWidth, y * Global.SpriteHeight), x, y);
            return new Tuple<int, int>(x,y);
        }

        private void ChangeBias(Global.Direction direction, double magnitude)
        {
            upBias = 20;
            leftBias = 20;
            rightBias = 20;
            downBias = 20;
            switch (direction)
            {
                case Global.Direction.Up:
                    upBias = (int)magnitude * upBias;
                    downBias = 16;
                    break;
                case Global.Direction.Right:
                    rightBias = (int)magnitude * rightBias;
                    leftBias = 16;
                    break;
                case Global.Direction.Down:
                    downBias = (int)magnitude * downBias;
                    upBias = 16;
                    break;
                case Global.Direction.Left:
                    leftBias = (int)magnitude * leftBias;
                    rightBias = 16;
                    break;
                case Global.Direction.None:
                    break;
                case Global.Direction.UpRight:
                    upBias = (int)magnitude * upBias;
                    rightBias = (int)magnitude * rightBias;
                    break;
                case Global.Direction.UpLeft:
                    leftBias = (int)magnitude * leftBias;
                    upBias = (int)magnitude * upBias;
                    break;
                case Global.Direction.DownRight:
                    downBias = (int)magnitude * downBias;
                    rightBias = (int)magnitude * rightBias;
                    break;
                case Global.Direction.DownLeft:
                    downBias = (int)magnitude * downBias;
                    leftBias = (int)magnitude * leftBias;
                    break;
            }
        }

        private void StartWalk()
        {
            creatingMode = true;
            ChangeBias(Global.Direction.Right, 4);
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

                    //pond creator
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

                if(walkDistance == 350)
                {
                    ChangeBias(Global.Direction.Down, 2);
                } 
                else if( walkDistance == 680)
                {
                    ChangeBias(Global.Direction.DownLeft, 2);
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