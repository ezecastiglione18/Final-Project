using System;
using System.IO;
using System.Configuration;
using System.Timers;
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
        private Texture2D apple;
        private Texture2D banana;
        private Texture2D broccoli;
        private Texture2D burger;
        private Texture2D carrot;
        private Texture2D cheese;
        private Texture2D chicken;
        private Texture2D donut;
        private Texture2D fries;
        private Texture2D hotdog;
        private Texture2D icecream;
        private Texture2D lemon;
        private Texture2D orange;
        private Texture2D peach;
        private Texture2D pizza;
        private Texture2D strawberry;
        private Texture2D watermelon;
        private Texture2D empty;

        Rectangle yes = new Rectangle(273, 305, 135, 117);
        Rectangle no = new Rectangle(491, 305, 87, 117);
        Rectangle boton = new Rectangle(395, 35, 105, 80);
        Rectangle canasta = new Rectangle();

        Random random = new Random();
        private SpriteFont Font;
        private SpriteFont smallfont;
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
        bool obj = false;
        bool play = false;
        int j = 0;
        int i = 0;
        int k = 0;
        int m = 0;
        int cont = 0;
        int next;

        int[] Randoms = new int[5] { 9, 9, 9, 9, 9 };
        int[] xPositions = new int[9] { 10, 100, 197, 291, 389, 448, 517, 585, 662 };
        int[] yPositions = new int[6];
        int[] whereToFall = new int[6];
        int[] nextToFall = new int[6];
        bool[] start = new bool[6] { false, false, false, false, false, false };
        Rectangle[] rectangles = new Rectangle[6];
        int[] objCount = new int[5] {5,5,5,5,5};
        Food[] Foods = new Food[17];
        int [,] sizes = new int[17, 2] { { 40, 45}, { 50, 25 }, { 40, 40}, { 35, 37 }, { 40, 33 }, { 40, 45 }, { 40, 43}, { 30, 35 }, { 45, 35}, { 50, 43}, { 40, 23 }, { 50, 21}, { 40, 40}, { 35, 53 }, { 50, 28}, { 30, 40}, { 40, 32} };
        Texture2D[] toDraw = new Texture2D[6];

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
            smallfont = Content.Load<SpriteFont>("small");
            ganarcuadro = Content.Load<Texture2D>("Ganar");
            columna = Content.Load<Texture2D>("columna");
            basket = Content.Load<Texture2D>("Food/basket1");
            empty = Content.Load<Texture2D>("empty");
            correcto = Content.Load<SoundEffect>("Sonidos/Correcto_Adv");
            incorrecto = Content.Load<SoundEffect>("Sonidos/Incorrecto_Adv");
            for (int i = 0; i < Foods.Length; i++)
            {
                Foods[i] = new Food();
                Foods[i].id = i;
            }
            Foods[0].textura = apple = Content.Load<Texture2D>("Food/apples");
            Foods[1].textura = banana = Content.Load<Texture2D>("Food/bananas");
            Foods[2].textura = broccoli = Content.Load<Texture2D>("Food/broccoli");
            Foods[3].textura = carrot = Content.Load<Texture2D>("Food/carrots");
            Foods[4].textura = lemon = Content.Load<Texture2D>("Food/lemons");
            Foods[5].textura = orange = Content.Load<Texture2D>("Food/oranges");
            Foods[6].textura = peach = Content.Load<Texture2D>("Food/peaches");
            Foods[7].textura = strawberry = Content.Load<Texture2D>("Food/strawberries");
            Foods[8].textura = watermelon = Content.Load<Texture2D>("Food/watermelons");
            Foods[9].textura = burger = Content.Load<Texture2D>("Food/burger");
            Foods[10].textura = cheese = Content.Load<Texture2D>("Food/cheese");
            Foods[11].textura = chicken = Content.Load<Texture2D>("Food/chicken");
            Foods[12].textura = donut = Content.Load<Texture2D>("Food/donut");
            Foods[13].textura = fries = Content.Load<Texture2D>("Food/fries");
            Foods[14].textura = hotdog = Content.Load<Texture2D>("Food/hotdog");
            Foods[15].textura = icecream = Content.Load<Texture2D>("Food/ice cream");
            Foods[16].textura = pizza = Content.Load<Texture2D>("Food/pizza");
            for (int i = 0; i < toDraw.Length; i++)
            {
                toDraw[i] = empty;
            }
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
                canasta.Y = 450;
                canasta.Width = basket.Width;
                canasta.Height = basket.Height;
                if (mousePosition.X > 610)
                {
                    spriteBatch.Draw(basket, new Rectangle(610, 450, 120, 90), Color.White);
                    canasta.X = 610;
                }
                else
                {
                    spriteBatch.Draw(basket, new Rectangle(mousePosition.X, 450, 120, 90), Color.White);
                    canasta.X = mousePosition.X;
                }
                played = true;
                #region caidas
                i++;
                if (i % 60 == 0)
                {
                    if (j > 5)
                    {
                        j = 0;
                    }
                    cont++;
                    nextToFall[j] = random.Next(0, 17);
                    whereToFall[j] = xPositions[random.Next(0, 9)];
                    toDraw[j] = Foods[nextToFall[j]].textura;
                    start[j] = true;
                    yPositions[j] = 0 - Foods[nextToFall[j]].textura.Height;
                    rectangles[j] = new Rectangle(whereToFall[j], yPositions[j], Foods[nextToFall[j]].textura.Width, Foods[nextToFall[j]].textura.Height);
                    j++;
                } 

                for (int a = 0; a < yPositions.Length; a++)
                {
                    if (start[a])
                    {
                        yPositions[a]+= 2;
                    }
                    if (yPositions[a] > 530)
                    {
                        yPositions[a] = -50;
                        start[a] = false;
                    }
                    rectangles[a].Location = new Point(whereToFall[a], yPositions[a]);
                }

                spriteBatch.DrawString(Font, cont.ToString(), new Vector2(300, 300), Color.Red);
                spriteBatch.Draw(toDraw[0], new Rectangle(whereToFall[0], yPositions[0], sizes[nextToFall[0], 0], sizes[nextToFall[0], 1]), Color.White);
                spriteBatch.Draw(toDraw[1], new Rectangle(whereToFall[1], yPositions[1], sizes[nextToFall[1], 0], sizes[nextToFall[1], 1]), Color.White);
                spriteBatch.Draw(toDraw[2], new Rectangle(whereToFall[2], yPositions[2], sizes[nextToFall[2], 0], sizes[nextToFall[2], 1]), Color.White);
                spriteBatch.Draw(toDraw[3], new Rectangle(whereToFall[3], yPositions[3], sizes[nextToFall[3], 0], sizes[nextToFall[3], 1]), Color.White);
                spriteBatch.Draw(toDraw[4], new Rectangle(whereToFall[4], yPositions[4], sizes[nextToFall[4], 0], sizes[nextToFall[4], 1]), Color.White);
                spriteBatch.Draw(toDraw[5], new Rectangle(whereToFall[5], yPositions[5], sizes[nextToFall[5], 0], sizes[nextToFall[5], 1]), Color.White);
                for (int k = 0; k < rectangles.Length; k++)
                {
                    if (canasta.Contains(rectangles[k]))
                    {
                        if (Foods[nextToFall[k]].id > 8)
                        {
                            if (yPositions[k] > 470)
                            {
                                yPositions[k] = 540;
                            }
                            if (mousePosition.X > 610)
                            {
                                spriteBatch.Draw(basket, new Rectangle(610, 450, 120, 90), Color.Red * 0.5f);
                            }
                            else
                            {
                                spriteBatch.Draw(basket, new Rectangle(mousePosition.X, 450, 120, 90), Color.Red * 0.5f);
                            }
                        }
                        else
                        {
                           //if (Foods[nextToFall[k]].id == Randoms[k] && mouseState.LeftButton == ButtonState.Pressed)
                           //{
                           //    objCount[Foods[nextToFall[k]].id]--;
                           //for (int b = 0; b < objCount.Length; b++)
                           //{
                           //    if (objCount[b] == 0)
                           //    {
                           //        int contGanar++;
                           //    }
                           //}
                           //}

                        }
                        
                    }
                }
                #endregion
                spriteBatch.Draw(salir, new Rectangle(730, 450, 150, 75), Color.White);
                if (!obj)
                {
                    SelecObjetivos();
                    obj = true;
                }
                string name;
                for (int i = 0; i < Randoms.Length; i++)
                {
                    name = Foods[Randoms[i]].textura.Name.Substring(5, Foods[Randoms[i]].textura.Name.Length - 5);
                    spriteBatch.DrawString(smallfont, objCount[i]+ " " + name, new Vector2(745, (i + 1) * 70), Color.White);
                }
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }

        private void SelecObjetivos()
        {
            for (int i = 0; i < Randoms.Length; i++)
            {
                next = random.Next(0, 9);
                for (int j = 0; j < Randoms.Length; j++)
                {
                    while (Randoms[j] == next)
                    {
                        next = random.Next(0, 9);
                        j = 0;
                    }
                }
                Randoms[i] = next;
            }
        }

    }
}
