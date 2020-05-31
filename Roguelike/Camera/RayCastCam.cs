using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Roguelike.Interfaces;
using Roguelike.World;
using System;

namespace Roguelike.Camera
{
    public class RayCastCam
    {

        private Vector2 Position = new Vector2(1.5f, 1.4f);
        private Vector2 Direction = new Vector2(1f, 0f);
        private Vector2 Plane = new Vector2(0.0f, 1f);

        private int w = Global.ViewportWidth;
        private int h = Global.ViewportHeight;
        public ICell[,] CellArray;
        private Rectangle[] vertLines;

        //--move speed--//
        private readonly double moveSpeed = 0.08;

        //--rotate speed--//
        private readonly double rotSpeed = -0.05;

        //--cam x pre calc--//
        private double[] camX;

        //--structs that contain rects and tints for each level or "floor" renderered--//
        private Global.Level level;

        public RayCastCam(Rectangle[] vert, Global.Level level)
        {
            //somehow making the direction Sqrt(2) for both X and Y messes things up
            for(int i = 0; i < 20; i++)
            {
                Rotate(-rotSpeed);
            }

            vertLines = vert;
            this.level = level;
            CellArray = WorldManager.Instance().Gen.CellArray;

            //--init cam pre calc array--//
            camX = new double[w];
            preCalcCamX();




            Raycast();
        }

        public void Update()
        {
            //System.Console.WriteLine(pos);
            System.Console.WriteLine((int)Position.X + " " + (int)Position.Y);
            //System.Console.WriteLine(dir);

            Raycast();

            //change to command pattern later
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Q))
            {
                Rotate(rotSpeed);
            }

            if (state.IsKeyDown(Keys.E))
            {
                Rotate(-rotSpeed);
            }

            if (state.IsKeyDown(Keys.W))
            {
                Move(moveSpeed);
            }

            if (state.IsKeyDown(Keys.S))
            {
                Move(-moveSpeed);
            }

            if (state.IsKeyDown(Keys.A))
            {
                Strafe(-moveSpeed);
            }


            if (state.IsKeyDown(Keys.D))
            {
                Strafe(moveSpeed);
            }

        }

        public void Raycast()
        {
            for (int x = 0; x < w; x++)
            {


                CastLevel(x, CellArray, level.cts, level.vl, level.st);

            }

        }

        /**
        * credit : Raycast loop and setting up of vectors for matrix calculations, I just updated it to use modern rendering methods.
        * courtesy - http://lodev.org/cgtutor/raycasting.html
        */
        public void CastLevel(int x, ICell[,] grid, Rectangle[] cts, Rectangle[] vert, Color[] tint)
        {
            //calculate ray position and direction
            double cameraX = camX[x];//x-coordinate in camera space
            double rayDirX = Direction.X + Plane.X * cameraX;
            double rayDirY = Direction.Y + Plane.Y * cameraX;

            //--rays start at camera position--//
            double rayPosX = Position.X;
            double rayPosY = Position.Y;

            //which box of the map we're in
            int mapX = (int)rayPosX;
            int mapY = (int)rayPosY;

            //length of ray from current position to next x or y-side
            double sideDistX;
            double sideDistY;

            //length of ray from one x or y-side to next x or y-side
            double deltaDistX = Math.Sqrt(1 + (rayDirY * rayDirY) / (rayDirX * rayDirX));
            double deltaDistY = Math.Sqrt(1 + (rayDirX * rayDirX) / (rayDirY * rayDirY));
            double perpWallDist;

            //what direction to step in x or y-direction (either +1 or -1)
            int stepX;
            int stepY;

            int hit = 0; //was there a wall hit?
            int side = -1; //was a NS or a EW wall hit?

            //calculate step and initial sideDist
            if (rayDirX < 0)
            {
                stepX = -1;
                sideDistX = (rayPosX - mapX) * deltaDistX;
            }
            else
            {
                stepX = 1;
                sideDistX = (mapX + 1.0 - rayPosX) * deltaDistX;
            }
            if (rayDirY < 0)
            {
                stepY = -1;
                sideDistY = (rayPosY - mapY) * deltaDistY;
            }
            else
            {
                stepY = 1;
                sideDistY = (mapY + 1.0 - rayPosY) * deltaDistY;
            }
            //perform DDA
            while (hit == 0)
            {
                //jump to next map square, OR in x-direction, OR in y-direction
                if (sideDistX < sideDistY)
                {
                    sideDistX += deltaDistX;
                    mapX += stepX;
                    side = 0;
                }
                else
                {
                    sideDistY += deltaDistY;
                    mapY += stepY;
                    side = 1;
                }

                if (grid[mapX, mapY].LayerType > 0)
                {
                    hit = 1;
                }

            }



            //Calculate distance of perpendicular ray (oblique distance will give fisheye effect!)
            if (side == 0)
            {
                perpWallDist = (mapX - rayPosX + (1 - stepX) / 2) / rayDirX;
            }
            else
            {
                perpWallDist = (mapY - rayPosY + (1 - stepY) / 2) / rayDirY;
            }

            //Calculate height of line to draw on screen
            int lineHeight = (int)(h / perpWallDist);

            //calculate lowest and highest pixel to fill in current stripe
            int drawStart = -lineHeight / 2 + h / 2;
            if (drawStart < 0)
            {
                drawStart = 0;
            }

            //texturing calculations
            int texNum = grid[mapX, mapY].LayerType;

            level.currTexNum[x] = texNum;

            //calculate value of wallX
            double wallX; //where exactly the wall was hit
            if (side == 0)
            {
                wallX = rayPosY + perpWallDist * rayDirY;
            }
            else 
            { 
                wallX = rayPosX + perpWallDist * rayDirX; 
            }
            wallX -= Math.Floor(wallX);

            //x coordinate on the texture
            int texX = (int)(wallX * Global.SpriteWidth);
            if (side == 0 && rayDirX > 0)
            {
                texX = Global.SpriteWidth - texX - 1;
            }
            if (side == 1 && rayDirY < 0) 
            {
                texX = Global.SpriteWidth - texX - 1; 
            }

            //https://github.com/Owlzy/OwlRaycastEngine help from here
            //--set current texture slice to be slice x--//
            cts[x] = vertLines[texX];

            //--set height of slice--//
            vert[x].Height = lineHeight;

            //--set draw start of slice--//
            vert[x].Y = drawStart;

            //--due to modern way of drawing using quads this should be down here to ovoid glitches at the edges--//
            if (drawStart < 0) drawStart = 0;
            // if (drawEnd >= h) drawEnd = h - 1;

            //--add a bit of tint to differentiate between walls of a corner--//
            tint[x] = Color.White;
            if (side == 1)
            {
                int wallDiff = 12;
                tint[x].R -= (byte)wallDiff;
                tint[x].G -= (byte)wallDiff;
                tint[x].B -= (byte)wallDiff;
            }
            //--simulates torch light, as if player was carrying a radial light--//
            float lightFalloff = -100; //decrease value to make torch dimmer

            //--sun brightness, illuminates whole level--//
            float sunLight = 300;//global illuminaion

            //--distance based dimming of light--//
            float shadowDepth = (float)Math.Sqrt(perpWallDist) * lightFalloff;
            tint[x].R = (byte)MathHelper.Clamp(tint[x].R + shadowDepth + sunLight, 0, 255);
            tint[x].G = (byte)MathHelper.Clamp(tint[x].G + shadowDepth + sunLight, 0, 255);
            tint[x].B = (byte)MathHelper.Clamp(tint[x].B + shadowDepth + sunLight, 0, 255);

        }


        public void Move(double moveSpeed)
        {

            if (CellArray[(int)(Position.X + Direction.X * moveSpeed * 12), (int)Position.Y].LayerType > 0 == false) Position.X += (float)(Direction.X * moveSpeed);
            if (CellArray[(int)Position.X, (int)(Position.Y + Direction.Y * moveSpeed * 12)].LayerType > 0 == false) Position.Y += (float)(Direction.Y * moveSpeed);
        }

        public void Strafe(double moveSpeed)
        {
            double oldDirX = Direction.X;
            float NinetyDegreeTurnX = (float)(Direction.X * Math.Cos(1.570796) - Direction.Y * Math.Sin(1.570796));
            float NinetyDegreeTurnY = (float)(oldDirX * Math.Sin(1.570796) + Direction.Y * Math.Cos(1.570796));
            if (CellArray[(int)(Position.X + NinetyDegreeTurnX * moveSpeed * 12), (int)Position.Y].LayerType > 0 == false) Position.X += (float)(NinetyDegreeTurnX * moveSpeed);
            if (CellArray[(int)Position.X, (int)(Position.Y + NinetyDegreeTurnY * moveSpeed * 12)].LayerType > 0 == false) Position.Y += (float)(NinetyDegreeTurnY * moveSpeed);
        }


        public void Rotate(double rSpeed)
        {
            double oldDirX = Direction.X;
            Direction.X = (float)(Direction.X * Math.Cos(rSpeed) - Direction.Y * Math.Sin(rSpeed));
            Direction.Y = (float)(oldDirX * Math.Sin(rSpeed) + Direction.Y * Math.Cos(rSpeed));
            double oldPlaneX = Plane.X;
            Plane.X = (float)(Plane.X * Math.Cos(rSpeed) - Plane.Y * Math.Sin(rSpeed));
            Plane.Y = (float)(oldPlaneX * Math.Sin(rSpeed) + Plane.Y * Math.Cos(rSpeed));
        }

        /// <summary>
        /// precalculates camera x coordinate
        /// </summary>
        public void preCalcCamX()
        {
            for (int x = 0; x < w; x++)
            {
                camX[x] = 2 * x / (double)w - 1; //x-coordinate in camera space
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < Global.ViewportWidth; x++)
            {
                if (WorldManager.Instance().Level.currTexNum[x] != 0) //don't draw dirt
                {
                    spriteBatch.Draw(WorldManager.Instance().textures[WorldManager.Instance().Level.currTexNum[x]], WorldManager.Instance().Level.vl[x], WorldManager.Instance().Level.cts[x], WorldManager.Instance().Level.st[x]);
                }
            }
        }
    }
}
