using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace MonoGame
{

    public class Easy : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D background;
        private Texture2D arm;
        private Texture2D leg;
        private Texture2D eyes;
        private Texture2D head;
        private Texture2D elbow;
        private Texture2D mouth;
        private SpriteFont Font;
        private SpriteFont fontsmall;
        private Texture2D grilla;
        private int ampera = 0;
        string elemento;
        int num;
        int posicionx;
        int posiciony;
        private bool SopaCreada = false;
        Random random = new Random();


        string[,] matriz = new string[8, 8];
        string[] Palabras = { "arm", "leg", "eyes", "head", "elbow", "mouth" };
        public Easy()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 900;  
            graphics.PreferredBackBufferHeight = 530;   
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("Easy");
            arm = Content.Load<Texture2D>("Body/arm");
            leg = Content.Load<Texture2D>("Body/leg");
            eyes = Content.Load<Texture2D>("Body/eyes");
            head = Content.Load<Texture2D>("Body/head");
            elbow = Content.Load<Texture2D>("Body/elbow");
            mouth = Content.Load<Texture2D>("Body/mouth");
            Font = Content.Load<SpriteFont>("AgentOrange");
            fontsmall = Content.Load<SpriteFont>("small");

        }
        protected override void UnloadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            if (!SopaCreada)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);

                spriteBatch.Begin();
                spriteBatch.Draw(background, new Rectangle(0, 0, 900, 530), Color.White);
                spriteBatch.DrawString(fontsmall, "Find these body parts!", new Vector2(500, 60), Color.Black);
                spriteBatch.Draw(arm, new Vector2(520, 200),Color.White);
                spriteBatch.Draw(leg, new Vector2(670, 230),Color.White);
                spriteBatch.Draw(eyes, new Vector2(520, 130),Color.White);
                spriteBatch.Draw(head, new Vector2(620, 80),Color.White);
                spriteBatch.Draw(elbow, new Vector2(530, 300), Color.White);



                grilla = new Texture2D(graphics.GraphicsDevice, 1, 1);
                grilla.SetData(new Color[] { Color.White });
                for (float x = -7; x < 7; x++)
                {
                    Rectangle rectangle = new Rectangle((int)(150 + x * 50 /*distancia*/), 50, 1, 400 /*Alto*/);
                    spriteBatch.Draw(grilla, rectangle, Color.Black);
                }
                for (float y = -7; y < 7; y++)
                {
                    Rectangle rectangle = new Rectangle(50/*posicion en x*/, (int)(150 + y * 50/*distancia*/), 400 /*ancho*/, 1);
                    spriteBatch.Draw(grilla, rectangle, Color.Black);
                }

                for (int fila = 0; fila <= 7; fila++)
                {
                    for (int columna = 0; columna <= 7; columna++)
                    {
                        num = random.Next(0, 26);
                        char let = (char)('a' + num);
                        spriteBatch.DrawString(Font, let.ToString(), new Vector2((fila+1)*50+10, (columna+1)*50+10), Color.Black);
                        matriz[fila, columna] = let.ToString();
                    }
                }

                for (int fila = 0; fila <= 7; fila++)
                {
                    for (int columna = 0; columna <= 7; columna++)
                    {
                        posicionx = random.Next(0, 7);
                        posiciony = random.Next(0, 7);
                        matriz[posicionx, posiciony] = "";
                        //spriteBatch.DrawString(Font, /*LLENAR*/, new Vector2(posicionx,posiciony), Color.Black);
                    }
                }

                spriteBatch.End();
                SopaCreada = true;
                base.Draw(gameTime);
            }

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
