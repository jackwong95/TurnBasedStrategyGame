using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Strategy_Game.GameSystem;

namespace Strategy_Game
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        Camera cam;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Map map;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            map = new Map(200, 200);
            cam = new Camera(GraphicsDevice.Viewport);

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
            map.LoadContent(this.Content);
           // temp = new Texture2D(GraphicsDevice, 200, 200);
            //noiseGen = new PerlinNoise(0.01, 4);
            // TODO: use this.Content to load your game content here
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            cam.UpdateCamera(GraphicsDevice.Viewport);
            /*
            // TODO: Add your update logic here
            Color[,] colors2D = new Color[200, 200]; // a nice 2d array for our texture
            for (int x = 0; x < 200; x++)
            {
                for (int y = 0; y < 200; y++)
                {
                    double noise = noiseGen.GetNoise(x, y, 0); // get the noise at the current position (a value from 0.0 - 1.0)         
                    byte value = (byte)(255 * noise); // turn that value into a byte (0 - 255)         
                    colors2D[x, y] = new Color(value, value, value); // turn that value into a color     
                }
            }

            Color[] colors1D = new Color[200 * 200];

            // convert the 2d array into a 1d array - this code will normally be in your infrastructure 
            for (int x = 0; x < 200; x++)
                for (int y = 0; y < 200; y++)
                    colors1D[x + y * 200] = colors2D[x, y];

            temp.SetData(colors1D); // update the texture with our new values
            */
            base.Update(gameTime);
        }
        

       // public static Texture2D temp;
       // PerlinNoise noiseGen = new PerlinNoise();

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.RosyBrown);

            spriteBatch.Begin(SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                null, null, null, null, cam.Transform);
            // TODO: Add your drawing code here
            map.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
