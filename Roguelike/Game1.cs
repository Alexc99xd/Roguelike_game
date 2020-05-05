using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Roguelike.Content;
using Roguelike.Controller;
using Roguelike.Player;

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
        private MainPlayer player;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public PlayerContent playerContent;
        WorldContent worldContent;
        public Texture2D test;

        private Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            keyboard = new KeyboardController();
            //player = MainPlayer.Instance();

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
            // TODO: Add your initialization logic here

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

            playerContent = new PlayerContent(Content);
            test = playerContent.PlayerDefaultSpriteSheet;
            test = Content.Load<Texture2D>("Player/SmileyWalk");
            worldContent = new WorldContent(Content);
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
            MainPlayer.Instance().Update(gameTime);
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

            spriteBatch.Begin(SpriteSortMode.BackToFront);

            MainPlayer.Instance().Draw(spriteBatch);
            //spriteBatch.Draw(test, new Rectangle(0, 0, 800, 480), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
