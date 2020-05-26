using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Roguelike.Content;


namespace Roguelike.World
{
    public class WorldManager
    {

        public World MainWorld;
        public WorldContent WorldCont;
        public WorldGen Gen;
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
        }

        public void LoadContent(ContentManager content)
        {
            WorldCont = new WorldContent(content);
            MainWorld.InitilizeSprite();
            Gen = new WorldGen();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //MainWorld.Draw(spriteBatch);
            Gen.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            //MainWorld.Update(gameTime);
            Gen.Update(gameTime);
        }
    }
}
