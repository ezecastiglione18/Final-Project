using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Threading;

namespace MonoGame
{
    public class Difficult : Game
    {
        GraphicsDeviceManager graphics;
        public GraphicsDevice device;
        private Texture2D background;
        public Texture2D fichaMemo;
        public Texture2D DSalir;
        public Texture2D salir;
        private Texture2D Ganar;
        private SpriteFont Font;
        private SoundEffect incorrecto;
        private SoundEffect correcto;
        public SpriteBatch spriteBatch;
        Rectangle yes = new Rectangle(273, 305, 135, 117);
        Rectangle no = new Rectangle(491, 305, 87, 117);
        public bool SalirBool = false;
        public bool Dibujar = false;
        bool GanarBool = false;
        int ContadorClicks = 0;
        bool played = false;
        Texture2D FichaCostado;
        Random random = new Random();
        ConexionBDSports Conexion = new ConexionBDSports();
        Sports FichaSeleccionada1 = new Sports();
        Sports FichaSeleccionada2 = new Sports();

        List<Texture2D> ListaTexturas = new List<Texture2D>();
        List<Sports> ListaElementos = new List<Sports>();
        public int[,] PosicionesFichas = new int[16, 2] { { 100, 75 }, { 100, 175 }, { 100, 275 }, { 100, 375 }, { 300, 75 }, { 300, 175 }, { 300, 275 }, { 300, 375 }, { 500, 75 }, { 500, 175 }, { 500, 275 }, { 500, 375 }, { 700, 75 }, { 700, 175 }, { 700, 275 }, { 700, 375 } };
        public Rectangle[] Rectangulos = new Rectangle[16];
       
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
            correcto = Content.Load<SoundEffect>("Sonidos/Correcto");
            incorrecto = Content.Load<SoundEffect>("Sonidos/Incorrecto");

            ListaElementos = Conexion.Seleccionar();

            #region Carga de Texturas a Rectangulos            
            int[] RandomNum = CalcularNumeros();
            for (int i = 0; i < RandomNum.Length; i++)
            {
                Rectangulos[i] = new Rectangle(PosicionesFichas[i,0], 
                PosicionesFichas[i, 1], fichaMemo.Width, fichaMemo.Height);

                ListaElementos[i].IdentificadorRandom = ListaElementos[RandomNum[i] - 1].Identificador;

                FileStream file = new FileStream(Properties.Settings.Default.RutaSport + "\\" +
                    ListaElementos[RandomNum[i] - 1].Nombre, FileMode.Open);
                //ListaElementos[i].Nombre, FileMode.Open);

            Texture2D hola = Texture2D.FromStream(GraphicsDevice, file);
                ListaTexturas.Add(hola);
            }
            #endregion

        }

        protected override void UnloadContent()
        {
            //Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            spriteBatch.Begin();
            MouseState mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);

            #region Comparacion y Asignacion de Variables a FichaSeleccionada
            if (ListaElementos.FindAll(s => s.Clickeado == true).Count < 2)
            {
                for (int i = 0; i < ListaElementos.Count; i++)
                {
                    if (Rectangulos[i].Contains(mousePosition) && mouseState.LeftButton == ButtonState.Pressed)
                    {
                        if (ListaElementos[i].Clickeado == false)
                        {
                            ListaElementos[i].Clickeado = true;
                            ContadorClicks++;

                            if (ContadorClicks == 1 && ListaElementos[i].Clickeado == true)
                            {
                                FichaSeleccionada1 = new Sports();

                                FichaSeleccionada1.Nombre = ListaElementos[i].Nombre;
                                FichaSeleccionada1.Id = ListaElementos[i].Id;
                                FichaSeleccionada1.Identificador = ListaElementos[i].Identificador;
                                FichaSeleccionada1.IdentificadorRandom = ListaElementos[i].IdentificadorRandom;
                            }

                            if (ContadorClicks == 2 && ListaElementos[i].Clickeado == true)
                            {
                                FichaSeleccionada2 = new Sports();

                                FichaSeleccionada2.Nombre = ListaElementos[i].Nombre;
                                FichaSeleccionada2.Id = ListaElementos[i].Id;
                                FichaSeleccionada2.Identificador = ListaElementos[i].Identificador;
                                FichaSeleccionada2.IdentificadorRandom = ListaElementos[i].IdentificadorRandom;
                            }
                        }
                    }
                }
            }
            else
            {
                if (FichaSeleccionada1.IdentificadorRandom == FichaSeleccionada2.IdentificadorRandom)
                {
                    FichaSeleccionada1.SeEncontroConPareja = true;
                    FichaSeleccionada2.SeEncontroConPareja = true;

                    ListaElementos.FindAll(s => s.IdentificadorRandom == FichaSeleccionada1.IdentificadorRandom).ForEach(s => s.SeEncontroConPareja = true);                    

                    correcto.Play();
                }
                else
                {
                    ListaElementos.FindAll(s => s.IdentificadorRandom == FichaSeleccionada1.IdentificadorRandom).ForEach(s => s.Clickeado = false);
                    ListaElementos.FindAll(s => s.IdentificadorRandom == FichaSeleccionada2.IdentificadorRandom).ForEach(s => s.Clickeado = false);

                    incorrecto.Play();
                }

                ContadorClicks = 0;
                Thread.Sleep(500);
            }
            #endregion


            #region Salir
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

                for (int i = 0; i < ListaElementos.Count; i++)
                {
                    if (ListaElementos[i].Clickeado == true)
                    {
                        spriteBatch.Draw(ListaTexturas[i], new Vector2(PosicionesFichas[i, 0], PosicionesFichas[i, 1]), Color.White);
                    }
                    else
                    {
                        //Que aparezca la ficha de vuelta
                        spriteBatch.Draw(fichaMemo, new Vector2(PosicionesFichas[i, 0], PosicionesFichas[i, 1]), Color.White);
                    }

                    if (ListaElementos[i].SeEncontroConPareja == true)
                    {
                        spriteBatch.Draw(ListaTexturas[i], new Vector2(PosicionesFichas[i, 0], PosicionesFichas[i, 1]), Color.LightSeaGreen);
                        ListaElementos[i].Clickeado = false;
                        ListaElementos[i].Lista = true;
                    }
                }

                #region If que verifica si gano
                if (ListaElementos.FindAll(s => s.Lista == true).Count == 16)
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
                        //var VolverMenu = new Main();
                        //VolverMenu.Run();
                    }
                }
                #endregion

                spriteBatch.Draw(salir, new Rectangle(730, 450, 150, 75), Color.White);
            }

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