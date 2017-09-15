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

        Rectangle yes = new Rectangle(273, 305, 135, 117);
        Rectangle no = new Rectangle(491, 305, 87, 117);
        Rectangle boton = new Rectangle(395, 35, 105, 80);
        
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
        int j = 0;
        int i = 0;
        int k = 0;
        int next;
        int nextToFall;
        int whereToFall;

        int[] Randoms = new int [5]{9,9,9,9,9};
        int[] xPositions = new int[9] { 10, 100, 197, 291, 389, 448, 517, 585, 662 };
        Food[] Foods = new Food[17];
        int [,] sizes = new int[17, 2] { { 40, 45}, { 50, 25 }, { 40, 40}, { 35, 37 }, { 40, 33 }, { 40, 45 }, { 40, 43}, { 30, 35 }, { 45, 35}, { 50, 43}, { 40, 23 }, { 50, 21}, { 40, 40}, { 35, 53 }, { 50, 28}, { 30, 40}, { 40, 32} };

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
           for (int i = 0; i < Foods.Length; i++)
           {
               Foods[i] = new Food();
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
           Foods[10].textura =cheese = Content.Load<Texture2D>("Food/cheese");
           Foods[11].textura =chicken = Content.Load<Texture2D>("Food/chicken");
           Foods[12].textura =donut = Content.Load<Texture2D>("Food/donut");
           Foods[13].textura =fries = Content.Load<Texture2D>("Food/fries");
           Foods[14].textura =hotdog = Content.Load<Texture2D>("Food/hotdog");
           Foods[15].textura =icecream = Content.Load<Texture2D>("Food/ice cream");
           Foods[16].textura =pizza = Content.Load<Texture2D>("Food/pizza");
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
                if (mousePosition.X > 610)
                {
                    spriteBatch.Draw(basket, new Rectangle(610, 450, 120, 90), Color.White);
                }
                else
                {
                    spriteBatch.Draw(basket, new Rectangle(mousePosition.X, 450, 120, 90), Color.White);
                    string hola = basket.Name;
                }
                played = true;
                #region caidas
                whereToFall = random.Next(0, 9);
                whereToFall = xPositions[whereToFall];
                i++;
                if (i > 330)
                {
                    nextToFall = random.Next(0, 16);
                    i = 0;
                }
                spriteBatch.Draw(Foods[nextToFall].textura, new Rectangle(10, i/10 * 15, sizes[nextToFall,0], sizes[nextToFall,1]), Color.White);
                #endregion
                spriteBatch.Draw(salir, new Rectangle(730, 450, 150, 75), Color.White);
                if (!obj)
                {
                    SelecObjetivos();
                    obj = true;
                }
                string name;
                for (int i = 0; i < Randoms.Length - 1; i++)
                {
                    name = Foods[Randoms[i]].textura.Name.Substring(5, Foods[Randoms[i]].textura.Name.Length - 5);
                    spriteBatch.DrawString(smallfont, "5 " + name, new Vector2(735, (i + 1) * 100), Color.White);
                }
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }

        private void SelecObjetivos()
        {
            for (int i = 0; i < Randoms.Length - 1; i++)
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
