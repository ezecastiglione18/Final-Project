using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    public class Difficult : Game //MEMOTEST
    {
        GraphicsDeviceManager graphics;
        public GraphicsDevice device;
        private Texture2D background;
        public Texture2D fichaMemo;
        public Texture2D DSalir;
        public Texture2D salir;
        private SpriteFont Font;
        public SpriteBatch spriteBatch;
        Rectangle yes = new Rectangle(273, 305, 135, 117);
        Rectangle no = new Rectangle(491, 305, 87, 117);
        public bool SalirBool = false;
        public bool Dibujar = false;
        bool played = false;
        ConexionBDSports Conexion = new ConexionBDSports();

        /*public Texture2D baseball;
        public Texture2D baseballBat;
        public Texture2D football;
        public Texture2D pingPong;
        public Texture2D rugby;
        public Texture2D tennis;
        public Texture2D racket;
        public Texture2D voley;
        public Texture2D vNet;
        public Texture2D fGoal;
        public Texture2D bowling;
        public Texture2D basketHoop;
        public Texture2D americanFootball;*/

        public static Texture2D[] Imagenes = new Texture2D[8];
        public int[,] PosicionesFichas = new int[4, 4];
        public Difficult()
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
            FileStream file1 = new FileStream(Properties.Settings.Default.RutaSport + "\\" + Conexion.ListaSports[0].Ruta, FileMode.Open);// Busco cada imagen que 
            FileStream file2 = new FileStream(Properties.Settings.Default.RutaSport + "\\" + Conexion.ListaSports[1].Ruta, FileMode.Open);// se selecciono al azar
            FileStream file3 = new FileStream(Properties.Settings.Default.RutaSport + "\\" + Conexion.ListaSports[2].Ruta, FileMode.Open);// y lo guardo en el vector
            FileStream file4 = new FileStream(Properties.Settings.Default.RutaSport + "\\" + Conexion.ListaSports[3].Ruta, FileMode.Open);// de imagenes
            FileStream file5 = new FileStream(Properties.Settings.Default.RutaSport + "\\" + Conexion.ListaSports[4].Ruta, FileMode.Open);
            FileStream file6 = new FileStream(Properties.Settings.Default.RutaSport + "\\" + Conexion.ListaSports[5].Ruta, FileMode.Open);
            FileStream file7 = new FileStream(Properties.Settings.Default.RutaSport + "\\" + Conexion.ListaSports[6].Ruta, FileMode.Open);
            FileStream file8 = new FileStream(Properties.Settings.Default.RutaSport + "\\" + Conexion.ListaSports[7].Ruta, FileMode.Open);
            Imagenes[0] = Texture2D.FromStream(GraphicsDevice, file1);
            Imagenes[1] = Texture2D.FromStream(GraphicsDevice, file2);
            Imagenes[2] = Texture2D.FromStream(GraphicsDevice, file3);
            Imagenes[3] = Texture2D.FromStream(GraphicsDevice, file4);
            Imagenes[4] = Texture2D.FromStream(GraphicsDevice, file5);
            Imagenes[5] = Texture2D.FromStream(GraphicsDevice, file6);
            Imagenes[6] = Texture2D.FromStream(GraphicsDevice, file7);
            Imagenes[7] = Texture2D.FromStream(GraphicsDevice, file8);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Font = Content.Load<SpriteFont>("AgentOrange");
            background = Content.Load<Texture2D>("Difficult");
            fichaMemo = Content.Load<Texture2D>("fichaMemotest");
            DSalir = Content.Load<Texture2D>("DSalir");
            salir = Content.Load<Texture2D>("salir");
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
                if (!played)
                {
                    played = true;
                }
                spriteBatch.Draw(DSalir, new Rectangle(10, 10, 890, 520), Color.White);
                spriteBatch.End();
            }
            if (SalirBool)
            {
                mousePosition = new Point(mouseState.X, mouseState.Y);
                if (yes.Contains(mousePosition) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    UnloadContent();
                    Exit();
                }
                if (no.Contains(mousePosition) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    SalirBool = false;
                    Dibujar = false;
                    played = false;
                }
            }
            #endregion

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            if (!Dibujar)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(background, new Rectangle(0, 0, 900, 530), Color.White);
                spriteBatch.DrawString(Font, "Search each word with its image!", new Vector2(20, 12), Color.Black);

                #region 16Cuadraditos 
                spriteBatch.Draw(fichaMemo, new Vector2(100/*EJE X*/, 75/*EJE Y*/), Color.White);
                spriteBatch.Draw(fichaMemo, new Vector2(100, 175), Color.White);
                spriteBatch.Draw(fichaMemo, new Vector2(100, 275), Color.White);
                spriteBatch.Draw(fichaMemo, new Vector2(100, 375), Color.White);
                spriteBatch.Draw(fichaMemo, new Vector2(300, 75), Color.White);
                spriteBatch.Draw(fichaMemo, new Vector2(300, 175), Color.White);
                spriteBatch.Draw(fichaMemo, new Vector2(300, 275), Color.White);
                spriteBatch.Draw(fichaMemo, new Vector2(300, 375), Color.White);
                spriteBatch.Draw(fichaMemo, new Vector2(500, 75), Color.White);
                spriteBatch.Draw(fichaMemo, new Vector2(500, 175), Color.White);
                spriteBatch.Draw(fichaMemo, new Vector2(500, 275), Color.White);
                spriteBatch.Draw(fichaMemo, new Vector2(500, 375), Color.White);
                spriteBatch.Draw(fichaMemo, new Vector2(700, 75), Color.White);
                spriteBatch.Draw(fichaMemo, new Vector2(700, 175), Color.White);
                spriteBatch.Draw(fichaMemo, new Vector2(700, 275), Color.White);
                spriteBatch.Draw(fichaMemo, new Vector2(700, 375), Color.White);
                #endregion

                spriteBatch.Draw(salir, new Rectangle(730, 450, 150, 75), Color.White);
                
            }



            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
