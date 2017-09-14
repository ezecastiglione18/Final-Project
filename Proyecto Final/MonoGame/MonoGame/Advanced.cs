using System;
using System.IO;
using System.Configuration;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace MonoGame
{
    class Advanced : Game
    {
        GraphicsDeviceManager graphics;
        GraphicsDevice device;
        SpriteBatch spriteBatch;
        private Texture2D background;
        private Texture2D salir;
        private Texture2D DSalir;
        private Texture2D ganarcuadro;
        private Texture2D columna;
        private Texture2D basket;
        Rectangle yes = new Rectangle(273, 305, 135, 117);
        Rectangle no = new Rectangle(491, 305, 87, 117);
        Rectangle boton = new Rectangle(395, 35, 105, 80);
        
        Random random = new Random();
        private SpriteFont Font;
        private SoundEffect quit;
        private SoundEffect incorrecto;
        private SoundEffect correcto;
        private SoundEffect select;
        private SoundEffect end;
        bool SalirBool = false;
        bool GanarBool = false;
        bool Dibujar = false;
        bool DibujarGanar = false;
        bool played = false;
        int j = 0;
        int i = 0;

        Texture2D[] Randoms = new Texture2D[5];

        public Advanced()
        {
            graphics = new GraphicsDeviceManager(this);
            device = graphics.GraphicsDevice;
            graphics.PreferredBackBufferWidth = 900;
            graphics.PreferredBackBufferHeight = 530;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsFixedTimeStep = false;
        }
        protected override void Initialize()
        {
            this.IsMouseVisible = false;
            base.Initialize();

        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("Advanced");
            salir = Content.Load<Texture2D>("salir");
            DSalir = Content.Load<Texture2D>("DSalir");
            Font = Content.Load<SpriteFont>("AgentOrange");
            ganarcuadro = Content.Load<Texture2D>("Ganar");
            columna = Content.Load<Texture2D>("columna");
            basket = Content.Load<Texture2D>("Sports/basket1");
         }
        protected override void UnloadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {
            this.IsMouseVisible = false;
            #region salir
            MouseState mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);
            if (mousePosition.X <= 880 && mousePosition.X >= 730 && mousePosition.Y <= 525 && mousePosition.Y >= 450)
            {
                this.IsMouseVisible = true;
                if (mouseState.LeftButton == ButtonState.Pressed && !DibujarGanar)
                {
                    SalirBool = true;
                    Dibujar = true;
                }
            }
            if (Dibujar)
            {
                this.IsMouseVisible = true;
                spriteBatch.Begin();
                if (!played)
                {
                    quit.Play();
                    played = true;
                }
                spriteBatch.Draw(DSalir, new Rectangle(10, 10, 890, 520), Color.White);
                spriteBatch.End();
            }
            if (SalirBool)
            {
                this.IsMouseVisible = true;
                mousePosition = new Point(mouseState.X, mouseState.Y);
                if (yes.Contains(mousePosition) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    Exit();
                }
                if (no.Contains(mousePosition) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    this.IsMouseVisible = false;
                    SalirBool = false;
                    Dibujar = false;
                    played = false;
                }
            }
            #endregion

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);
            if (!Dibujar && !DibujarGanar)
            {
                GraphicsDevice.Clear(Color.White);
                spriteBatch.Begin();
                spriteBatch.Draw(background, new Rectangle(0, 0, 900, 530), Color.White);
                spriteBatch.Draw(columna, new Rectangle(730, 30, 144, 430), Color.White);
                spriteBatch.Draw(basket, new Rectangle(mousePosition.X, 450, 120, 90), Color.White);
                played = true;
                #region caidas
                i++;
                spriteBatch.Draw(DSalir, new Rectangle(10, i/10 * 15, 20, 10), Color.White);
                #endregion
                spriteBatch.Draw(salir, new Rectangle(730, 450, 150, 75), Color.White);
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }

        private void Randomize()
        {
            int next = random.Next(0, 5);
            for (int i = 0; i < Randoms.Length-1; i++)
            {
                while (Randoms[i] != null)
                {
                    next = random.Next(0, 5);
                    Randoms[i] = //CAMBIAR
                }
            }
        }
    }
}
