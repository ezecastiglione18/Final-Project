using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace MonoGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Easy : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D background;
        private Texture2D sopa;
        private SpriteFont font;
        private Texture2D grilla;
        private int meatloaf = 0;
        private int ampera = 0;
        Random random = new Random();

        string[,] matriz = new string[8, 8];
        string[] Palabras = { "arm", "leg", "eyes", "head", "elbow", "mouth" };
        char[] letras = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        public Easy()
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
           /* Form MyGameForm = (Form)Form.FromHandle(Window.Handle);
            MyGameForm.FormBorderStyle = FormBorderStyle.None;*/
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("Easy");
            sopa = Content.Load<Texture2D>("Sopa1");
            font = Content.Load<SpriteFont>("meatloaf");
        }
        protected override void UnloadContent()
        {

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

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
            

            grilla = new Texture2D(graphics.GraphicsDevice,1,1);
            grilla.SetData(new Color[] { Color.White });
            for (float x = -7; x < 7; x++)
            {
                Rectangle rectangle = new Rectangle((int)(100 + x * 50 /*distancia*/),0,1, 400 /*Alto*/);
                spriteBatch.Draw(grilla, rectangle, Color.Black);
            }
            for (float y = -7; y < 7; y++)
            {
                Rectangle rectangle = new Rectangle(0/*posicion en x*/, (int)(100 + y *50/*distancia*/), 400 /*ancho*/, 1);
                spriteBatch.Draw(grilla, rectangle, Color.Black);
            }

            
            int num = random.Next(0, 26);
            char let = (char)('a' + num);
            int k = 50;
            for (int i = 0; i <=7; i++)
            { 
                for (int j = 0; j <7 ; j++)
                {
                    spriteBatch.DrawString(font, let.ToString(), new Vector2(j,k), Color.Black);
                    k += 50;
                    if (k > 400)
                    {
                        k = 50;
                    }
                }
            }

            spriteBatch.End();
            base.Draw(gameTime);

        }

        internal class Size
        {
            private int v1;
            private int v2;

            public Size(int v1, int v2)
            {
                this.v1 = v1;
                this.v2 = v2;
            }
        }
    }
}
