using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Roguelike.Camera;
using Roguelike.Content;
using RogueLike.Camera;
using static Roguelike.Global;

namespace Roguelike.World
{
    public class WorldManager
    {

        public World MainWorld;
        public WorldContent WorldCont;
        public WorldGen Gen;
        public Texture2D[] textures;
        public RayCastCam RayCast;
        private VertLine vertLines;
        public Level Level;
        private WorldManager()
        {
        }

        private static WorldManager uniqueInstance;

        public static WorldManager Instance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new WorldManager();
            }
            return uniqueInstance;
        }

        public void Initialize()
        {
            MainWorld = new World();
            Level = CreateLevels(1);
        }

        public void LoadContent(ContentManager content)
        {
            WorldCont = new WorldContent(content);
            MainWorld.InitilizeSprite();
            Gen = new WorldGen();
            textures = new Texture2D[2]; //2 for now, testing 
            textures[0] = WorldCont.Dirt;
            textures[1] = WorldCont.Wall;
            vertLines = new VertLine(Global.SpriteWidth);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Gen.finished)
            {
                Gen.Draw(spriteBatch);
            }
            else
            {
                if(RayCast != null)
                {
                    RayCast.Draw(spriteBatch);
                }
            }

        }

        public void DrawMini(SpriteBatch spriteBatch)
        {
            Gen.DrawMini(spriteBatch);
        }

        public void DrawSkyFloor(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(WorldCont.HeadWalker,
               new Rectangle(0, (int)(Global.ViewportHeight * 0.5f), Global.ViewportWidth, (int)(Global.ViewportHeight * 0.5f)),
               new Rectangle(0, 0, Global.SpriteWidth, Global.SpriteHeight),
               Color.White);
            spriteBatch.Draw(WorldCont.Water,
                    new Rectangle(0, 0, Global.ViewportWidth, (int)(Global.ViewportHeight * 0.5f)),
                    new Rectangle(0, 0, Global.SpriteWidth, Global.SpriteHeight),
                    Color.White);
        }

        public void Update(GameTime gameTime)
        {
            if (!Gen.finished)
            {
                Gen.Update(gameTime);
            }
            else
            {
                if(RayCast == null)
                {
                    RayCast = new RayCastCam(vertLines.vert, Level);
                }
                else
                {
                    RayCast.Update();
                }
            }
                
        }

        public Level CreateLevels(int numLevels)
        {
            Level arr = new Level();
            arr.vl = VertLineMaker();
            arr.cts = new Rectangle[Global.ViewportWidth];
            arr.st = new Color[Global.ViewportWidth];
            arr.currTexNum = new int[Global.ViewportWidth];
            for (int i = 0; i < arr.currTexNum.Length; i++)
            {
                arr.currTexNum[i] = 1;
            }
            return arr;
        }

        public Rectangle[] VertLineMaker()
        {
            Rectangle[] arr = new Rectangle[Global.ViewportWidth];
            for (int x = 0; x < Global.ViewportWidth; x++)
            {
                arr[x] = new Rectangle(x, 0, 1, Global.ViewportHeight);
            }
            return arr;
        }
    }
}
