using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace MonoGame
{
    class Medium : Game
    {
        GraphicsDevice graphicsDevice;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D background;
        private Texture2D playSound;
        private Texture2D salir;
        private Texture2D DSalir;
        private Rectangle si = new Rectangle(298, 305, 87, 117);
        private Rectangle no = new Rectangle(491, 305, 87, 117);
        private Rectangle boton = new Rectangle(400, 35, 500, 45);

        private SpriteFont Font;
        Random random = new Random();
        bool Creado = false;
        bool SalirBool = false;
        bool Dibujar = false;
        bool escuchado = false;
        int escuchar = 7;
        int i = 0;

        int[] vUsados = new int[6] { 7, 7, 7, 7, 7, 7 };
        public static Texture2D[] Imagenes = new Texture2D[6];
        public SoundEffect[] sonidos = new SoundEffect [6];
        dbConexion Conexion = new dbConexion();

        public Medium()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 900;
            graphics.PreferredBackBufferHeight = 530;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsFixedTimeStep = false;
        }
        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("Medium");
            playSound = Content.Load<Texture2D>("PlaySound");
            salir = Content.Load<Texture2D>("salir");
            DSalir = Content.Load<Texture2D>("DSalir");
            Font = Content.Load<SpriteFont>("AgentOrange");
        }
        protected override void UnloadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {
            #region salir
            MouseState mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);
            if (mousePosition.X <= 880 && mousePosition.X >= 730 && mousePosition.Y <= 525 && mousePosition.Y >= 450)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    SalirBool = true;
                    Dibujar = true; 
                }
            }
            if (Dibujar)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(DSalir, new Rectangle(10, 10, 890, 520), Color.White);
                spriteBatch.End();
            }
            if (SalirBool)
            {
                mousePosition = new Point(mouseState.X, mouseState.Y);
                if (si.Contains(mousePosition) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    Exit();
                }
                if (no.Contains(mousePosition) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    Dibujar = false;
                }
            }

            #endregion

            /*Conexion.Seleccionar();

            FileStream file = new FileStream(Conexion.listAnimales[0].imagen, FileMode.Open);
            Texture2D Hola = Texture2D.FromStream(graphicsDevice, file);
            spriteBatch.Draw(Hola, new Rectangle(100, 100, 100, 100), Color.White);*/
            if (boton.Contains(mousePosition) && mouseState.LeftButton == ButtonState.Pressed && !escuchado)
            {
                Randomize();
                sonidos[escuchar].Play();
                escuchado = true;
            }

            if (escuchado && boton.Contains(mousePosition) && mouseState.LeftButton == ButtonState.Released)
            {
                escuchado = false;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            if (!Dibujar)
            {
                GraphicsDevice.Clear(Color.White);
                spriteBatch.Begin();
                spriteBatch.Draw(background, new Rectangle(0, 0, 900, 530), Color.White);
                spriteBatch.Draw(playSound, new Rectangle(400, 35, 100, 80), Color.White);
                spriteBatch.Draw(salir, new Rectangle(730, 450, 150, 75), Color.White);
                spriteBatch.DrawString(Font, "Which animal did you hear?", new Vector2(170, 150), Color.Black);
                spriteBatch.End();
            }
            base.Draw(gameTime);
        }

        public void Randomize()
        {
            escuchar = random.Next(0, 5);
            while (vUsados[i] == escuchar || i > 5)
            {
                escuchar = random.Next(0, 5);
                i++;
            }        
        }

    }
}
