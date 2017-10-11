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
        public bool drawed = false;
        int rnd;
        int rndTexto;
        int rndImagen;
        int rndImgTxt;
        int ContadorGanaste;
        bool played = false;
        int PosSeleccionadaX;
        int PosSeleccionadaY;
        Texture2D FichaCostado;
        Texture2D GIFficha;
        Random random = new Random();
        Random randomImgTxt = new Random();
        Random randomImagen = new Random();
        Random randomTexto = new Random();
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
        public Texture2D[] Texto = new Texture2D[8];
        public Texture2D[,] MatrizConImagenes = new Texture2D[16,2];
        public int[,] PosicionesFichas = new int[16, 2] { { 100, 75 }, { 100, 175 }, { 100, 275 }, { 100, 375 }, { 300, 75 }, { 300, 175 }, { 300, 275 }, { 300, 375 }, { 500, 75 }, { 500, 175 }, { 500, 275 }, { 500, 375 }, { 700, 75 }, { 700, 175 }, { 700, 275 }, { 700, 375 } };
        public Rectangle[] Rectangulos = new Rectangle[16];
        //public Texture2D[] Fichas = new Texture2D[16];

        public Texture2D[] VectorGeneral = new Texture2D[16];
        public int[] PosicionesYaUsadas = new int[16];



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
            spriteBatch.Begin();

            #region Guardado de Imagenes
            Conexion.Seleccionar();
            FileStream file1 = new FileStream(Properties.Settings.Default.RutaSport + "\\" + Conexion.ListaSports[0].Ruta, FileMode.Open);// Busco cada imagen que 
            FileStream file2 = new FileStream(Properties.Settings.Default.RutaSport + "\\" + Conexion.ListaSports[1].Ruta, FileMode.Open);// se selecciono al azar
            FileStream file3 = new FileStream(Properties.Settings.Default.RutaSport + "\\" + Conexion.ListaSports[2].Ruta, FileMode.Open);// y lo guardo en el vector
            FileStream file4 = new FileStream(Properties.Settings.Default.RutaSport + "\\" + Conexion.ListaSports[3].Ruta, FileMode.Open);// de imagenes
            FileStream file5 = new FileStream(Properties.Settings.Default.RutaSport + "\\" + Conexion.ListaSports[4].Ruta, FileMode.Open);
            FileStream file6 = new FileStream(Properties.Settings.Default.RutaSport + "\\" + Conexion.ListaSports[5].Ruta, FileMode.Open);
            FileStream file7 = new FileStream(Properties.Settings.Default.RutaSport + "\\" + Conexion.ListaSports[6].Ruta, FileMode.Open);
            FileStream file8 = new FileStream(Properties.Settings.Default.RutaSport + "\\" + Conexion.ListaSports[7].Ruta, FileMode.Open);

            VectorGeneral[0] = Texture2D.FromStream(GraphicsDevice, file1);  //Busco cada imagen que se selecciono al azar y lo guardo
            VectorGeneral[2] = Texture2D.FromStream(GraphicsDevice, file2);  //en el vector de imagenes
            VectorGeneral[4] = Texture2D.FromStream(GraphicsDevice, file3);
            VectorGeneral[6] = Texture2D.FromStream(GraphicsDevice, file4);
            VectorGeneral[8] = Texture2D.FromStream(GraphicsDevice, file5);
            VectorGeneral[10] = Texture2D.FromStream(GraphicsDevice, file6);
            VectorGeneral[12] = Texture2D.FromStream(GraphicsDevice, file7);
            VectorGeneral[14] = Texture2D.FromStream(GraphicsDevice, file8);

            //CARGA DE RECTANGULOS 
            for (int i = 0; i < Rectangulos.Length; i++)
            {
                Rectangulos[i] = new Rectangle(PosicionesFichas[i, 0], PosicionesFichas[i, 1], fichaMemo.Width, fichaMemo.Height);
            }

            #endregion

            #region Guardado de Texto en formato PNG
            Conexion.Seleccionar();
            FileStream file1s = new FileStream(Properties.Settings.Default.RutaSport + "\\" + Conexion.ListaSports[0].Nombre, FileMode.Open);// Busco cada imagen que 
            FileStream file2s = new FileStream(Properties.Settings.Default.RutaSport + "\\" + Conexion.ListaSports[1].Nombre, FileMode.Open);// se selecciono al azar
            FileStream file3s = new FileStream(Properties.Settings.Default.RutaSport + "\\" + Conexion.ListaSports[2].Nombre, FileMode.Open);// y lo guardo en el vector
            FileStream file4s = new FileStream(Properties.Settings.Default.RutaSport + "\\" + Conexion.ListaSports[3].Nombre, FileMode.Open);// de imagenes
            FileStream file5s = new FileStream(Properties.Settings.Default.RutaSport + "\\" + Conexion.ListaSports[4].Nombre, FileMode.Open);
            FileStream file6s = new FileStream(Properties.Settings.Default.RutaSport + "\\" + Conexion.ListaSports[5].Nombre, FileMode.Open);
            FileStream file7s = new FileStream(Properties.Settings.Default.RutaSport + "\\" + Conexion.ListaSports[6].Nombre, FileMode.Open);
            FileStream file8s = new FileStream(Properties.Settings.Default.RutaSport + "\\" + Conexion.ListaSports[7].Nombre, FileMode.Open);

            VectorGeneral[1] = Texture2D.FromStream(GraphicsDevice, file1s);
            VectorGeneral[3] = Texture2D.FromStream(GraphicsDevice, file2s);  
            VectorGeneral[5] = Texture2D.FromStream(GraphicsDevice, file3s);
            VectorGeneral[7] = Texture2D.FromStream(GraphicsDevice, file4s);
            VectorGeneral[9] = Texture2D.FromStream(GraphicsDevice, file5s);
            VectorGeneral[11] = Texture2D.FromStream(GraphicsDevice, file6s);
            VectorGeneral[13] = Texture2D.FromStream(GraphicsDevice, file7s);
            VectorGeneral[15] = Texture2D.FromStream(GraphicsDevice, file8s);
            #endregion

            Sports Ficha1 = new Sports();
            Sports Ficha2 = new Sports();
           

            
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Font = Content.Load<SpriteFont>("AgentOrange");
            background = Content.Load<Texture2D>("Difficult");
            fichaMemo = Content.Load<Texture2D>("fichaMemotest");
            DSalir = Content.Load<Texture2D>("DSalir");
            salir = Content.Load<Texture2D>("salir");
            FichaCostado = Content.Load<Texture2D>("ParteCostado");
        }

        protected override void UnloadContent()
        {
            Content.Unload();
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
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            spriteBatch.End();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            MouseState mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);

            if (!Dibujar)
            {                
                spriteBatch.Draw(background, new Rectangle(0, 0, 900, 530), Color.White);
                spriteBatch.DrawString(Font, "Memotest! Search each word with its image!", new Vector2(20, 12), Color.Black);


                #region 16 Cuadraditos 
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

                #region Animacion de Ficha
                for (int i = 0; i < VectorGeneral.Length; i++)
                {
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        if (Rectangulos[i].Contains(mousePosition) && mouseState.LeftButton == ButtonState.Pressed)//Se pregunta si el mouse se clickeo sobre uno de los rectangulos que estan en la misma posicion que las fichas
                        {
                            if (!drawed)
                            {
                                spriteBatch.Draw(FichaCostado, new Vector2(PosicionesFichas[i, 0], PosicionesFichas[i, 1]), Color.White);
                                drawed = true;    
                                if (drawed == true)
                                {
                                    spriteBatch.Draw(VectorGeneral[i], new Vector2(PosicionesFichas[i, 0], PosicionesFichas[i, 1]), Color.White);
                                }
                            }                            
                        }                        
                    }                    

                    //int rnd = random.Next(0, 16);
                    //spriteBatch.Draw(VectorGeneral[/*rnd*/i], new Vector2(PosicionesFichas[i, 0], PosicionesFichas[i, 1]), Color.White);

                }
                #endregion

                spriteBatch.Draw(salir, new Rectangle(730, 450, 150, 75), Color.White);
                
            }
            drawed = false;
            spriteBatch.End();
            base.Draw(gameTime);
        }        
    }
}
