using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Roguelike.Controller;
using Roguelike.Player;
using Roguelike.World;
using Roguelike.Camera;

namespace Roguelike
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private static Game1 uniqueInstance;
        //private PlayerManager
        //private IController;
        private KeyboardController keyboard;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public PlayerContent playerContent;
        public Texture2D test;
        private GameCamera cam;


        private Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 900;
            graphics.PreferredBackBufferWidth = 1600;
            cam = new GameCamera();
            keyboard = new KeyboardController();

        }

        public static Game1 GetInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new Game1();
            }

            return uniqueInstance;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Global.ViewportWidth = graphics.GraphicsDevice.Viewport.Width;
            Global.ViewportHeight = graphics.GraphicsDevice.Viewport.Height;
            PlayerManager.Instance().Initialize();
            WorldManager.Instance().Initialize();

            

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            PlayerManager.Instance().LoadContent(Content);
            WorldManager.Instance().LoadContent(Content);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (WorldManager.Instance().RayCast == null)
            {
                cam.CenterOn(PlayerManager.Instance().Location);
            }
            //PlayerManager.Instance().Update(gameTime);
            WorldManager.Instance().Update(gameTime);
            keyboard.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //spriteBatch.Begin(SpriteSortMode.BackToFront);

            if(WorldManager.Instance().RayCast == null) //2d top down camera needed
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, cam.TranslationMatrix);
                WorldManager.Instance().Draw(spriteBatch);
                spriteBatch.End();
            }
            else //2.5D camera needed
            {
               
                spriteBatch.Begin();
                WorldManager.Instance().DrawSkyFloor(spriteBatch);
                spriteBatch.End();


                spriteBatch.Begin();
                WorldManager.Instance().Draw(spriteBatch);
                spriteBatch.End();


            }

            base.Draw(gameTime);
        }


    }
}
