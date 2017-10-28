using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

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
        private Texture2D Ganar;
        private SpriteFont Font;
        public SpriteBatch spriteBatch;
        Rectangle yes = new Rectangle(273, 305, 135, 117);
        Rectangle no = new Rectangle(491, 305, 87, 117);
        public bool SalirBool = false;
        public bool Dibujar = false;
        public bool drawed = false;
        bool DibujarSalir = false;
        bool GanarBool = false;
        bool DibujarGanar = false;
        bool YaSePuedeComparar = false;
        int ContadorGanaste = 0;
        int ContadorClicks = 0;
        bool played = false;
        Texture2D FichaCostado;
        Random random = new Random();
        ConexionBDSports Conexion = new ConexionBDSports();
        List<Texture2D> ListaTexturas = new List<Texture2D>();
        List<Sports> ListaElementos = new List<Sports>();

        public Texture2D[,] MatrizConImagenes = new Texture2D[16, 2];
        public int[,] PosicionesFichas = new int[16, 2] { { 100, 75 }, { 100, 175 }, { 100, 275 }, { 100, 375 }, { 300, 75 }, { 300, 175 }, { 300, 275 }, { 300, 375 }, { 500, 75 }, { 500, 175 }, { 500, 275 }, { 500, 375 }, { 700, 75 }, { 700, 175 }, { 700, 275 }, { 700, 375 } };
        public Rectangle[] Rectangulos = new Rectangle[16];
        public bool[] RectanguloClickeado = new bool[16];

        public Texture2D[] VectorGeneral = new Texture2D[16];
        public int[] PosicionesYaUsadas = new int[16];

        Sports FichaSeleccionada1 = new Sports();
        Sports FichaSeleccionada2 = new Sports();

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

            for (int i = 0; i < RectanguloClickeado.Length; i++)
            {
                RectanguloClickeado[i] = false;
            }
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
            Ganar = Content.Load<Texture2D>("Ganar");

            ListaElementos = Conexion.Seleccionar();


            //CARGA DE RECTANGULOS 
            int[] RandomNum = CalcularNumeros();
            for (int i = 0; i < Rectangulos.Length; i++)
            {
                Rectangulos[RandomNum[i] - 1] = new Rectangle(PosicionesFichas[RandomNum[i] - 1, 0], PosicionesFichas[RandomNum[i] - 1, 1], fichaMemo.Width, fichaMemo.Height);
                FileStream file = new FileStream(Properties.Settings.Default.RutaSport + "\\" + ListaElementos[RandomNum[i] - 1].Nombre, FileMode.Open);
                Texture2D hola = Texture2D.FromStream(GraphicsDevice, file);
                ListaTexturas.Add(hola);
            }

        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            spriteBatch.Begin();
            MouseState mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);

            if (GanarBool)
            {
                spriteBatch.Draw(Ganar, new Rectangle(10, 10, 890, 520), Color.White);

                mousePosition = new Point(mouseState.X, mouseState.Y);
                if (yes.Contains(mousePosition) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    var JugarDeNuevo = new Difficult();
                    JugarDeNuevo.Run();
                }
                if (no.Contains(mousePosition) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    //Que vuelva a eleccion de nivel
                    DibujarGanar = false;
                    DibujarSalir = false;
                }
            }
            else
            {
                ContadorClicks++;

                #region Comparacion
                for (int i = 0; i < ListaElementos.Count; i++)
                {
                    if (Rectangulos[i].Contains(mousePosition) && mouseState.LeftButton == ButtonState.Pressed)//Se pregunta si el mouse se clickeo sobre uno de los rectangulos que estan en la misma posicion que las fichas
                    {
                        RectanguloClickeado[i] = true;
                        ListaElementos[i].Clickeado = true;

                        if (ContadorClicks == 1 && ListaElementos[i].Clickeado == true)
                        {
                            FichaSeleccionada1.Nombre = ListaElementos[i].Nombre;
                            FichaSeleccionada1.Id = ListaElementos[i].Id;
                            FichaSeleccionada1.Identificador = ListaElementos[i].Identificador;
                        }

                        if (ContadorClicks == 2 && ListaElementos[i].Clickeado == true)
                        {
                            FichaSeleccionada2.Nombre = ListaElementos[i].Nombre;
                            FichaSeleccionada2.Id = ListaElementos[i].Id;
                            FichaSeleccionada2.Identificador = ListaElementos[i].Identificador;
                            //PROBLEMA: Se usan los dos ListaElementos[i] en ambos casos

                            if (FichaSeleccionada1.Identificador == FichaSeleccionada2.Identificador || FichaSeleccionada1.Id == FichaSeleccionada2.Id)
                            {
                                ContadorGanaste++;
                                //spriteBatch.Draw(ListaTexturas[i], new Vector2(PosicionesFichas[i,0], PosicionesFichas[i,1]), Color.Green);
                            }
                            else
                            {
                                //Que aparezcan las fichas de vuelta
                                //spriteBatch.Draw(fichaMemo, new Vector2(PosicionesFichas[i,0], PosicionesFichas[i,1]), Color.White);  ???
                                //Rectangle FichaErronea = new Rectangle(PosicionesFichas[i, 0], PosicionesFichas[i, 1], fichaMemo.Width, fichaMemo.Height); ???
                                ListaElementos[i].Clickeado = false;
                            }

                            ContadorClicks = 0;
                        }
                    }
                }
                #endregion

                YaSePuedeComparar = false;

            }

            #region ganar
            if (ContadorGanaste == 8)//Pregunta si se encontro todas
            {
                GanarBool = true;
                DibujarGanar = true;
            }
            #endregion

            #region salir
            MouseState mouseState2 = Mouse.GetState();
            var mousePosition2 = new Point(mouseState.X, mouseState.Y);
            if (mousePosition2.X <= 880 && mousePosition2.X >= 730 && mousePosition2.Y <= 525 && mousePosition2.Y >= 450)
            {
                if (mouseState2.LeftButton == ButtonState.Pressed)
                {
                    SalirBool = true;
                    Dibujar = true;
                }
            }
            if (Dibujar)
            {
                if (!played)
                {
                    played = true;
                }
                spriteBatch.Draw(DSalir, new Rectangle(10, 10, 890, 520), Color.White);
            }
            if (SalirBool)
            {
                mousePosition = new Point(mouseState.X, mouseState.Y);
                if (yes.Contains(mousePosition2) && mouseState2.LeftButton == ButtonState.Pressed)
                {
                    UnloadContent();
                    Exit();
                }
                if (no.Contains(mousePosition2) && mouseState2.LeftButton == ButtonState.Pressed)
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
                spriteBatch.Draw(ListaTexturas[0], new Rectangle(Rectangulos[0].X, Rectangulos[0].Y, ListaTexturas[0].Width, ListaTexturas[0].Height), Color.White);

                #region 16 Fichas/rectangulos
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

                for (int i = 0; i < VectorGeneral.Length; i++)
                {
                    if (/*RectanguloClickeado[i] == true &&*/ ListaElementos[i].Clickeado == true)
                    {
                        drawed = true;
                        spriteBatch.Draw(ListaTexturas[i], new Vector2(PosicionesFichas[i, 0], PosicionesFichas[i, 1]), Color.White);
                    }
                }

                spriteBatch.Draw(salir, new Rectangle(730, 450, 150, 75), Color.White);
            }

            drawed = false;
            spriteBatch.End();
            base.Draw(gameTime);
        }

        private int[] CalcularNumeros()
        {
            int[] numeros = new int[16];
            Random r = new Random();

            int auxiliar = 0;
            int contador = 0;

            for (int i = 0; i < 16; i++)
            {
                auxiliar = r.Next(0, 17);
                bool continuar = false;

                while (!continuar)
                {
                    for (int j = 0; j <= contador; j++)
                    {
                        if (auxiliar == numeros[j])
                        {
                            continuar = true;
                            j = contador;
                        }
                    }

                    if (continuar)
                    {
                        auxiliar = r.Next(0, 17);
                        continuar = false;
                    }
                    else
                    {
                        continuar = true;
                        numeros[contador] = auxiliar;
                        contador++;
                    }
                }
            }
            return numeros;
        }
    }
}

