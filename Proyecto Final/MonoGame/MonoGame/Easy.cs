using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System;
namespace MonoGame
{
    public class Easy : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D background;
        public static Texture2D arm;
        private static Texture2D leg;
        private static Texture2D eyes;
        private static Texture2D head;
        private static Texture2D elbow;
        private static Texture2D mouth;
        private SpriteFont Font;
        private SpriteFont fontsmall;
        private Texture2D grilla;
        private Texture2D salir;
        private Texture2D DSalir;
        private Texture2D Ganar;
        private SoundEffect incorrecto;
        private SoundEffect correcto;
        int num;
        int ImagenABorrar = -1;
        int cont = 0;
        int posicion = 1;
        int posx;
        int UltimaY;
        int UltimaX;
        int posy;
        int posxOri;
        int posyOri;
        int ContEncontradas = 0;
        string PosicionPalabra = "";    // Para guardar las posiciones de la palabra seleccionada.
        bool EncontradaOno = false;
        private bool SopaCreada = false;
        private bool ImagenesCreadas = false;
        private bool PalabraEncontrada = false;
        private Rectangle si = new Rectangle(298, 305, 87, 117);
        private Rectangle no = new Rectangle(491, 578, 87, 117);
        bool SalirBool = false;
        bool DibujarSalir = false;
        bool GanarBool = false;
        bool DibujarGanar = false;
        string ABuscar = "";
        Random random = new Random();


        string[,] matriz = new string[8, 8];
        string[,] matrizOK = new string[8, 8];
        int[,] selected = new int[64, 64];
        string[,] PalabrasQueSeMarcaron = new string[8,8];
        int[,] posiciones = new int[6, 2] { { 520, 200 }, { 660, 230 }, { 520, 130 }, { 610, 80 }, { 530, 350 }, { 730, 120 } };
        string[] Palabras = { "arm", "leg", "eyes", "head", "elbow", "mouth" };
        bool[] PalabraYaSeEncontro = { false, false, false, false, false, false }; //LO NUEVO PARTE 1
        Texture2D[] Imagenes = new Texture2D[6];
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
            foreach (string elemento in Palabras)
            {
                posicion = random.Next(0, 2);
                switch (posicion)
                {
                    case 0:
                        bool PalabraOK = false;
                        posxOri = 0;
                        while (!PalabraOK)
                        {
                            posx = random.Next(0, 8 - elemento.Length);
                            posxOri = posx;
                            posy = random.Next(0, 8);
                            PalabraOK = true;
                            foreach (char Letra in elemento)
                            {
                                if (matriz[posx, posy] != null && matriz[posx, posy] != Letra.ToString())
                                {
                                    PalabraOK = false;
                                }
                                posx++;
                            }
                            if (PalabraOK)
                            {
                                posx = posxOri;
                                foreach (char Letra in elemento)
                                {
                                    matriz[posx, posy] = Letra.ToString();
                                    posx++;
                                }
                            }
                        }
                        break;
                    case 1:
                        PalabraOK = false;
                        posyOri = 0;
                        while (!PalabraOK)
                        {
                            posx = random.Next(0, 8);
                            posxOri = posx;
                            posy = random.Next(0, 8 - elemento.Length);
                            PalabraOK = true;
                            foreach (char Letra in elemento)
                            {
                                if (matriz[posx, posy] != null && matriz[posx, posy] != Letra.ToString())
                                {
                                    PalabraOK = false;
                                }
                                posy++;
                            }
                            if (PalabraOK)
                            {
                                posy = posyOri;
                                foreach (char Letra in elemento)
                                {
                                    matriz[posx, posy] = Letra.ToString();
                                    posy++;
                                }
                            }
                        }
                        break;
                }
            }

            //LETRAS RANDOM
            for (int fila = 0; fila <= 7; fila++)
            {
                for (int columna = 0; columna <= 7; columna++)
                {
                    if (matriz[fila, columna] == null)
                    {
                        num = random.Next(0, 26);
                        char let = (char)('a' + num);
                        matriz[fila, columna] = let.ToString();
                    }
                }
            }
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
            Imagenes[0] = arm;
            Imagenes[1] = leg;
            Imagenes[2] = eyes;
            Imagenes[3] = head;
            Imagenes[4] = elbow;
            Imagenes[5] = mouth;
            Font = Content.Load<SpriteFont>("AgentOrange");
            fontsmall = Content.Load<SpriteFont>("small");
            correcto = Content.Load<SoundEffect>("Sonidos/Correcto");
            incorrecto = Content.Load<SoundEffect>("Sonidos/Incorrecto");
            salir = Content.Load<Texture2D>("salir");
            DSalir = Content.Load<Texture2D>("DSalir");
            Ganar = Content.Load<Texture2D>("Ganar");

        }
        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);

            if (GanarBool)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(Ganar, new Rectangle(10, 10, 890, 520), Color.White);
                spriteBatch.End();

                mousePosition = new Point(mouseState.X, mouseState.Y);
                if (si.Contains(mousePosition) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    var JugarDeNuevo = new Easy();
                    JugarDeNuevo.Run();//Vuelve a jugar el nivel
                }
                if (no.Contains(mousePosition) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    //Seleccionar nivel
                    DibujarGanar = false;
                    DibujarSalir = false;
                }
            }
            else
            {
                if (mousePosition.X <= 450 && mousePosition.X >= 50 && mousePosition.Y <= 450 && mousePosition.Y >= 50)
                {
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        int PosSelecx = (mousePosition.X / 50) - 1;
                        int PosSelecy = (mousePosition.Y / 50) - 1;

                        UltimaY = PosSelecy;
                        UltimaX = PosSelecx;
                        while (PosSelecy == UltimaY || PosSelecx == UltimaX)
                        {
                            if (mousePosition.X <= 450 && mousePosition.Y <= 450 && mousePosition.X >= 50 && mousePosition.Y >= 50)
                            {
                                spriteBatch.Begin();
                                spriteBatch.DrawString(Font, matriz[PosSelecx, PosSelecy], new Vector2((PosSelecx + 1) * 50 + 10, (PosSelecy + 1) * 50 + 10), Color.Red);
                                matrizOK[PosSelecx, PosSelecy] = matriz[PosSelecx, PosSelecy];
                                ABuscar = BuscarPalabraMatrizOK();
                                spriteBatch.End();
                            }
                            UltimaY = mousePosition.Y;
                            UltimaX = mousePosition.X;
                        }
                    }
                    else
                    {
                        int i = 0;
                        while (i < Palabras.Length && PalabraEncontrada == false)
                        {
                            if (ABuscar == Palabras[i])
                            {
                                ImagenABorrar = i;
                                PalabraYaSeEncontro[i] = true;
                                EncontradaOno = true;
                                //Si varia la X o la Y, que tire error(corte seleccion)
                                PalabraEncontrada = true;
                                ImagenesCreadas = false;

                                if (PalabraYaSeEncontro[i] == true)//LO que pasaba es que si seleccionabas la misma palabras dos veces, conencontradas = 2
                                {
                                    ContEncontradas++;
                                }
                            }
                            i++;
                        }

                        LimpiarMatrizOK();
                        LimpiarSelected();
                        cont = 0;
                        PalabraEncontrada = false;
                    }
                }
            }

            #region ganar
            if (PalabraYaSeEncontro[0] && PalabraYaSeEncontro[1] && PalabraYaSeEncontro[2] && PalabraYaSeEncontro[3] && PalabraYaSeEncontro[4] && PalabraYaSeEncontro[5])//Pregunta si se encontro todas
            {
                //EFECTOS DE GANASTE
                GanarBool = true;
                DibujarGanar = true;
               /* spriteBatch.Begin();
                spriteBatch.Draw(Ganar, new Rectangle(10, 10, 890, 520), Color.White);
                spriteBatch.End();*/
            }
            #endregion


            #region salir
            if (mousePosition.X <= 880 && mousePosition.X >= 730 && mousePosition.Y <= 525 && mousePosition.Y >= 450)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    SalirBool = true;
                    DibujarSalir = true;
                }
            }
            if (DibujarSalir)
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
                    //Ocultar spritebatch del cartel
                    DibujarSalir = false;
                    DibujarGanar = false;
                }
            }
            #endregion

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            

            base.Update(gameTime);
        }

        public string BuscarPalabraMatrizOK()
        {
            string Palabra = "";
            cont = 0;
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    if (matrizOK[i, j] != null)
                    {
                        Palabra += matrizOK[i, j];
                        if (PosicionPalabra.IndexOf(i.ToString() + "," + j.ToString()) == -1)
                        {
                            PosicionPalabra += i.ToString() + "," + j.ToString() + "|";
                        }
                        selected[cont, 0] = i;
                        selected[cont, 1] = j;
                        cont++;
                    }
                }
            }
            return Palabra;
        }

        public void ReproducirSonido(bool correctoONo)
        {
            if (correctoONo == true)
            {
                correcto.Play();
            }
            else
            {
                incorrecto.Play();
            }
        }
        public void LimpiarMatrizOK()
        {
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    matrizOK[i, j] = null;                   
                }
            }
        }

        public void LimpiarSelected()
        {
            for (int j = 0; j < 5; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    selected[j, k] = 0;
                }
            }
        }
        
        protected override void Draw(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);

            if (!DibujarSalir && !DibujarGanar)
            {
                GraphicsDevice.Clear(Color.White);
                spriteBatch.Begin();

                spriteBatch.Draw(background, new Rectangle(0, 0, 900, 530), Color.White);
                spriteBatch.Draw(salir, new Rectangle(730, 450, 150, 75), Color.White);
                grilla = new Texture2D(graphics.GraphicsDevice, 1, 1);
                grilla.SetData(new Color[] { Color.White });
                for (float x = -7; x < 7; x++)
                {
                    Rectangle rectangle = new Rectangle((int)(150 + x * 50), 50, 1, 400);
                    spriteBatch.Draw(grilla, rectangle, Color.Black);
                }
                for (float y = -7; y < 7; y++)
                {
                    Rectangle rectangle = new Rectangle(50, (int)(150 + y * 50), 400, 1);
                    spriteBatch.Draw(grilla, rectangle, Color.Black);
                }

                spriteBatch.Draw(head, no, Color.PaleVioletRed);
                for (int fila = 0; fila <= 7; fila++)
                {
                    for (int columna = 0; columna <= 7; columna++)
                    {
                        if (matrizOK[fila, columna] != null && (matrizOK[fila, columna] != mousePosition.X.ToString() && matrizOK[fila, columna] != mousePosition.Y.ToString()))
                        {
                            spriteBatch.DrawString(Font, matriz[fila, columna], new Vector2((fila + 1) * 50 + 10, (columna + 1) * 50 + 10), Color.Red/*color Seleccionado actual*/);
                        }
                        else
                        {
                            if (PosicionPalabra.IndexOf(fila.ToString() + "," + columna.ToString()) > -1)
                            {                                                      
                                spriteBatch.DrawString(Font, matriz[fila, columna], new Vector2((fila + 1) * 50 + 10, (columna + 1) * 50 + 10), Color.Green/*Color Palabra Ya encontrada*/);
                                ReproducirSonido(true);//reproduce el sonido de correcto
                            }
                            else
                            {
                                spriteBatch.DrawString(Font, matriz[fila, columna], new Vector2((fila + 1) * 50 + 10, (columna + 1) * 50 + 10), Color.Black/*Color Letras default*/);
                                ReproducirSonido(false);//reproduce el sonido de incorrecto
                            }
                        }
                    }
                }
                EncontradaOno = false;
                SopaCreada = true;
                spriteBatch.DrawString(fontsmall, "Find these body parts!", new Vector2(480, 60), Color.Black);
                for (int i = 0; i <= Imagenes.Length - 1; i++)
                {
                    if (i != ImagenABorrar)
                    {
                        if (PalabraYaSeEncontro[i] != true)
                        {
                            spriteBatch.Draw(Imagenes[i], new Vector2(posiciones[i, 0], posiciones[i, 1]), Color.White);                            
                        }
                    }
                }
                spriteBatch.End();
            }
            /*else
            {
                spriteBatch.Begin();
                spriteBatch.Draw(Ganar, new Rectangle(10, 10, 890, 520), Color.White);
                spriteBatch.End();
            }*/
            base.Draw(gameTime);
        }
    }
}
