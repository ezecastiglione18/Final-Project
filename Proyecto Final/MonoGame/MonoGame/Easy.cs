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
        int posy;
        int posxOri;
        int posyOri;
        int ContEncontradas = 0;
        private bool SopaCreada = false;
        private bool ImagenesCreadas = false;
        private bool PalabraEncontrada;
        private Rectangle si = new Rectangle(298, 305, 87, 117);
        private Rectangle no = new Rectangle(491, 578, 87, 117);
        bool SalirBool = false;
        bool Dibujar = true;
        string ABuscar = "";
        Random random = new Random();


        string[,] matriz = new string[8, 8];
        string[,] matrizOK = new string[8, 8];
        int[,] selected = new int[5, 2];
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

            if (mousePosition.X <= 450 && mousePosition.X >= 50 && mousePosition.Y <= 450 && mousePosition.Y >= 50)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    int PosSelecx = (mousePosition.X / 50) - 1;
                    int PosSelecy = (mousePosition.Y / 50) - 1;
                    spriteBatch.Begin();
                    spriteBatch.DrawString(Font, matriz[PosSelecx, PosSelecy], new Vector2((PosSelecx + 1) * 50 + 10, (PosSelecy + 1) * 50 + 10), Color.Red);
                    matrizOK[PosSelecx, PosSelecy] = matriz[PosSelecx, PosSelecy];
                    ABuscar = BuscarPalabraMatrizOK();
                    spriteBatch.End();
                }
                else
                {
                    for (int i = 0; i < Palabras.Length; i++)
                    {
                        if (ABuscar == Palabras[i])
                        {
                            ImagenABorrar = i;
                            PalabraYaSeEncontro[i] = true;//LO NUEVO PARTE 2
                            ImagenesCreadas = false;
                            PalabraEncontrada = true;
                            Colorear(true, ABuscar);
                            correcto.Play();
                            ContEncontradas++;
                        }
                    }
                    /*if (!PalabraEncontrada)
                    {
                        Colorear(false, ABuscar);
                        incorrecto.Play();
                    }*/
                    cont = 0;
                    LimpiarMatrizOK();
                    LimpiarSelected();
                }
            }

            if (ContEncontradas == 6 /*&& PalabraYaSeEncontro[0] == true && PalabraYaSeEncontro[] == true && PalabraYaSeEncontro[2] == true && PalabraYaSeEncontro[3] == true && PalabraYaSeEncontro[4] == true && PalabraYaSeEncontro[5] == true*/)
            {
                spriteBatch.Draw(Ganar, new Rectangle(10, 10, 890, 520), Color.White);
                if (si.Contains(mousePosition) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    //JUGAR DE NUEVO
                }
                if (mousePosition.X >= 491 && mousePosition.X <= 578 && mousePosition.Y >= 305 && mousePosition.Y <= 422)
                {
                    Exit();
                }
            }

            Salir();


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
                        selected[cont, 0] = i;
                        selected[cont, 1] = j;
                        cont++;
                    }
                }
            }
            return Palabra;
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

        public void Colorear(bool color, string Palabra)
        {
            if (color)
            {
                for (int i = 0; i < Palabra.Length; i++)
                {
                    spriteBatch.Begin();
                    spriteBatch.DrawString(Font, Palabra[i].ToString(), new Vector2((selected[i, 0] + 1) * 50 + 10, (selected[i, 1] + 1) * 50 + 10), Color.LightGreen);
                    spriteBatch.End();
                }
            }
            else
            {
                for (int i = 0; i < Palabra.Length; i++)
                {
                    spriteBatch.Begin();
                    spriteBatch.DrawString(Font, matriz[selected[i, 0], selected[i, 1]], new Vector2((selected[i, 0] + 1) * 50 + 10, (selected[i, 1] + 1) * 50 + 10), Color.Black);
                    spriteBatch.End();
                }
            }
            Palabra = "";
            ABuscar = "";
        }

        public void Salir()
        {
            MouseState mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);
            if (mousePosition.X <= 880 && mousePosition.X >= 730 && mousePosition.Y <= 525 && mousePosition.Y >= 450)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    SalirBool = true;
                    spriteBatch.Begin();
                    if (Dibujar)
                    {
                        spriteBatch.Draw(DSalir, new Rectangle(10, 10, 890, 520), Color.White);
                    }
                    spriteBatch.End();
                }
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
                    //LLENAR
                }
            }
        }
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            if (!SopaCreada)
            {
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
                foreach (string elemento in Palabras)
                {
                    posicion = random.Next(0, 3);
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
                        case 2:
                            PalabraOK = false;
                            posyOri = 0;
                            posxOri = 0;
                            while (!PalabraOK)
                            {
                                posx = random.Next(0, 8 - elemento.Length);
                                posxOri = posx;
                                posy = random.Next(0, 8 - elemento.Length);
                                posyOri = posy;
                                PalabraOK = true;
                                foreach (char Letra in elemento)
                                {
                                    if (matriz[posx, posy] != null && matriz[posx, posy] != Letra.ToString())
                                    {
                                        PalabraOK = false;
                                    }
                                    posy++;
                                    posx++;
                                }
                                if (PalabraOK)
                                {
                                    posx = posxOri;
                                    posy = posyOri;
                                    foreach (char Letra in elemento)
                                    {
                                        matriz[posx, posy] = Letra.ToString();
                                        posy++;
                                        posx++;
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
                for (int fila = 0; fila <= 7; fila++)
                {
                    for (int columna = 0; columna <= 7; columna++)
                    {
                        spriteBatch.DrawString(Font, matriz[fila, columna], new Vector2((fila + 1) * 50 + 10, (columna + 1) * 50 + 10), Color.Black);
                    }
                }

                SopaCreada = true;
            }

            //CORREGIR
            if (!ImagenesCreadas)
            {
                spriteBatch.DrawString(fontsmall, "Find these body parts!", new Vector2(480, 60), Color.Black);
                for (int i = 0; i <= Imagenes.Length - 1; i++)
                {
                    if (i != ImagenABorrar)
                    {
                        //spriteBatch.Draw(Imagenes[i], new Vector2(posiciones[i, 0], posiciones[i, 1]), Color.White);
                        if (PalabraYaSeEncontro[i] != true)//LO NUEVO PARTE 3
                        {
                            spriteBatch.Draw(Imagenes[i], new Vector2(posiciones[i, 0], posiciones[i, 1]), Color.White);
                            ImagenesCreadas = false;
                        }
                        else
                        {
                            spriteBatch.Draw(Imagenes[ImagenABorrar], new Vector2(posiciones[ImagenABorrar, 0], posiciones[ImagenABorrar, 1]), Color.Green);
                            ImagenesCreadas = true;
                        }
                    }
                }
                
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
