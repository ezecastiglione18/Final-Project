using System;
using System.IO;
using System.Configuration;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace MonoGame
{
    class Medium : Game
    {
        GraphicsDeviceManager graphics;
        public GraphicsDevice device;
        SpriteBatch spriteBatch;
        private Texture2D background;
        private Texture2D playSound;
        private Texture2D salir;
        private Texture2D DSalir;
        private Texture2D Text1;
        private Texture2D Text2;
        private Texture2D Text3;
        private Texture2D Text4;
        private Texture2D Text5;
        private Texture2D Text6;
        private Rectangle si = new Rectangle(298, 305, 87, 117);
        private Rectangle no = new Rectangle(491, 305, 87, 117);
        private Rectangle boton = new Rectangle(400, 35, 500, 45);

        private SpriteFont Font;
        Random random = new Random();
        bool SalirBool = false;
        bool Dibujar = false;
        bool escuchado = false;
        int escuchar = 7;
        int i = 0;

        int[] vUsados = new int[6] { 7, 7, 7, 7, 7, 7 };
        public static Texture2D[] Imagenes = new Texture2D[6];
        public FileStream[] sonidos = new FileStream [6];
        dbConexion Conexion = new dbConexion();

        public Medium()
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
            this.IsMouseVisible = true;
            base.Initialize();
            Conexion.Seleccionar();

            #region inicializar_texturas
            FileStream file1 = new FileStream(Properties.Settings.Default.Ruta + "\\" + Conexion.listAnimales[0].imagen, FileMode.Open);
            FileStream file2 = new FileStream(Properties.Settings.Default.Ruta + "\\" + Conexion.listAnimales[1].imagen, FileMode.Open);
            FileStream file3 = new FileStream(Properties.Settings.Default.Ruta + "\\" + Conexion.listAnimales[2].imagen, FileMode.Open);
            FileStream file4 = new FileStream(Properties.Settings.Default.Ruta + "\\" + Conexion.listAnimales[3].imagen, FileMode.Open);
            FileStream file5 = new FileStream(Properties.Settings.Default.Ruta + "\\" + Conexion.listAnimales[4].imagen, FileMode.Open);
            FileStream file6 = new FileStream(Properties.Settings.Default.Ruta + "\\" + Conexion.listAnimales[5].imagen, FileMode.Open);
            Text1 = Texture2D.FromStream(GraphicsDevice, file1);
            Text2 = Texture2D.FromStream(GraphicsDevice, file2);
            Text3 = Texture2D.FromStream(GraphicsDevice, file3);
            Text4 = Texture2D.FromStream(GraphicsDevice, file4);
            Text5 = Texture2D.FromStream(GraphicsDevice, file5);
            Text6 = Texture2D.FromStream(GraphicsDevice, file6);
            //FileStream sonido = new FileStream(Properties.Settings.Default.Ruta + "\\" + Conexion.listAnimales[i].sonido, FileMode.Open);
            //sonido = SoundEffect.FromStream(sonido);
            #endregion


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

            if (boton.Contains(mousePosition) && mouseState.LeftButton == ButtonState.Pressed && !escuchado)
            {
                Randomize();
                //sonidos[escuchar].Play();
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
                spriteBatch.Draw(Text1, new Rectangle(100, 350, Conexion.listAnimales[0].ancho, 75), Color.White);
                spriteBatch.End();
            }

            spriteBatch.Begin();
            spriteBatch.End();
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
