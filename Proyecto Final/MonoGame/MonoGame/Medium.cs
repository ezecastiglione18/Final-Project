using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace MonoGame
{
    class Medium : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D background;
        public static Texture2D giraffe;
        private static Texture2D dolphin;
        private static Texture2D tiger;
        private static Texture2D snake;
        private static Texture2D dog;
        private static Texture2D hippo;
        private static SoundEffect giraffeSound;
        private static SoundEffect dolphinSound;
        private static SoundEffect tigerSound;
        private static SoundEffect snakeSound;
        private static SoundEffect dogSound;
        private static SoundEffect hippoSound;
        private Texture2D playSound;
        private Texture2D salir;
        private Texture2D DSalir;
        private Rectangle si = new Rectangle(298, 305, 87, 117);
        private Rectangle no = new Rectangle(491, 305, 87, 117);
        private Rectangle boton = new Rectangle(400, 35, 500, 45);

        private SpriteFont Font;
        Random random = new Random();
        Boolean Creado = false;
        Boolean SalirBool = false;
        Boolean Dibujar = true;
        int escuchar = 7;
        int i = 0;

        int[] vUsados = new int[6] { 7, 7, 7, 7, 7, 7 };
        public Texture2D[] Imagenes = new Texture2D[6];
        public SoundEffect[] sonidos = new SoundEffect[] { giraffeSound, dolphinSound, tigerSound, snakeSound, dogSound, hippoSound };

        public Medium()
        {
            graphics = new GraphicsDeviceManager(this);
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
            background = Content.Load<Texture2D>("Medium");
            giraffe = Content.Load<Texture2D>("Animals/giraffe");
            dolphin = Content.Load<Texture2D>("Animals/dolphin");
            tiger = Content.Load<Texture2D>("Animals/tiger");
            snake = Content.Load<Texture2D>("Animals/snake");
            dog = Content.Load<Texture2D>("Animals/dog");
            hippo = Content.Load<Texture2D>("Animals/hippo");
            Imagenes[0] = giraffe;
            Imagenes[1] = dolphin;
            Imagenes[2] = tiger;
            Imagenes[3] = snake;
            Imagenes[4] = dog;
            Imagenes[5] = hippo;
            playSound = Content.Load<Texture2D>("PlaySound");
            salir = Content.Load<Texture2D>("salir");
            DSalir = Content.Load<Texture2D>("DSalir");
            Font = Content.Load<SpriteFont>("AgentOrange");
            giraffeSound = Content.Load<SoundEffect>("Animals/giraffeSound");
            dolphinSound = Content.Load<SoundEffect>("Animals/dolphinSound");
            tigerSound = Content.Load<SoundEffect>("Animals/tigerSound");
            snakeSound = Content.Load<SoundEffect>("Animals/snakeSound");
            dogSound = Content.Load<SoundEffect>("Animals/dogSound");
            hippoSound = Content.Load<SoundEffect>("Animals/hippoSound");
            sonidos[0] = giraffeSound;
            sonidos[1] = dolphinSound;
            sonidos[2] = tigerSound;
            sonidos[3] = snakeSound;
            sonidos[4] = dogSound;
            sonidos[5] = hippoSound; 
        }
        protected override void UnloadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {
            //SALIR
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
                    Dibujar = false;
                    base.Update(gameTime);   
                }
            }

            if (boton.Contains(mousePosition) && mouseState.LeftButton == ButtonState.Pressed)
            {
                Randomize();
                sonidos[escuchar].Play();
            }


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            if (!Creado)
            {

                spriteBatch.Draw(background, new Rectangle(0, 0, 900, 530), Color.White);
                spriteBatch.Draw(playSound, new Rectangle(400, 35, 100, 80), Color.White);
                spriteBatch.Draw(salir, new Rectangle(730, 450, 150, 75), Color.White);
                spriteBatch.DrawString(Font, "Which animal did you hear?", new Vector2(170, 150), Color.Black);
                spriteBatch.Draw(giraffe, new Rectangle(40, 322, 100, 145), Color.White);
                spriteBatch.Draw(dolphin, new Rectangle(120, 340, 160, 130), Color.White);
                spriteBatch.Draw(tiger, new Rectangle(265, 330, 115, 140), Color.White);
                spriteBatch.Draw(snake, new Rectangle(380, 330, 110, 140), Color.White);
                spriteBatch.Draw(dog, new Rectangle(465, 350, 150, 120), Color.White);
                spriteBatch.Draw(hippo, new Rectangle(590, 375, 150, 100), Color.White);
                Creado = true;
            }
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
