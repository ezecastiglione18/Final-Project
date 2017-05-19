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
        public Texture2D arm;
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
        string selected;
        int num;
        int posicion=1;
        int posx;
        int posy;
        private bool SopaCreada = false;
        Random random = new Random();


        string[,] matriz = new string[8, 8];
        string[] Palabras = { "arm", "leg", "eyes", "head", "elbow", "mouth" };
        Texture2D[] Imagenes = new Texture2D [6];
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
                    int PosSelecx = (mousePosition.X / 50)-1;
                    int PosSelecy = (mousePosition.Y / 50)-1;
                    spriteBatch.Begin();
                    spriteBatch.DrawString(Font, matriz[PosSelecx,PosSelecy], new Vector2((PosSelecx+1)*50+10, (PosSelecy+1)*50+10), Color.Red);
                    selected += matriz[PosSelecx, PosSelecy];
                    for (int i = 0; i < Palabras.Length; i++)
                    {
                        if (selected == Palabras[i])
                        {
                            Imagenes[i]
                        }
                    }
                    spriteBatch.End();
                }
            }
                
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
                spriteBatch.DrawString(fontsmall, "Find these body parts!", new Vector2(480, 60), Color.Black);
                spriteBatch.Draw(arm, new Vector2(520, 200),Color.White);
                spriteBatch.Draw(leg, new Vector2(660, 230),Color.White);
                spriteBatch.Draw(eyes, new Vector2(520, 130),Color.White);
                spriteBatch.Draw(head, new Vector2(610, 80),Color.White);
                spriteBatch.Draw(elbow, new Vector2(530, 350), Color.White);
                spriteBatch.Draw(mouth, new Vector2(730, 120), Color.White);



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
                int posxOri;
                int posyOri;
                foreach (string elemento in Palabras)
                {
                    posicion = random.Next(0,3);
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
                                posx = random.Next(0, 8-elemento.Length);
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
                         spriteBatch.DrawString(Font, matriz[fila,columna], new Vector2((fila + 1) * 50 + 10, (columna + 1) * 50 + 10), Color.Black);
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
