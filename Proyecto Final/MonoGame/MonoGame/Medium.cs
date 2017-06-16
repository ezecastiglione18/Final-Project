using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    class Medium : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D background;
        private Texture2D giraffe;
        private Texture2D dolphin;
        private Texture2D tiger;
        private Texture2D snake;
        private Texture2D dog;
        private Texture2D hippo;
        private Texture2D playSound;
        private Texture2D salir;
        private Texture2D DSalir;
        private Rectangle si = new Rectangle(298, 305, 87, 117);
        Boolean Creado = false;

        public Medium()
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
            background = Content.Load<Texture2D>("Medium");
            giraffe = Content.Load<Texture2D>("Animals/giraffe");
            dolphin = Content.Load<Texture2D>("Animals/dolphin");
            tiger = Content.Load<Texture2D>("Animals/tiger");
            snake = Content.Load<Texture2D>("Animals/snake");
            dog = Content.Load<Texture2D>("Animals/dog"); 
            hippo = Content.Load<Texture2D>("Animals/hippo");
            playSound = Content.Load<Texture2D>("PlaySound");
            salir = Content.Load<Texture2D>("salir");
            DSalir = Content.Load<Texture2D>("DSalir");
        }
        protected override void UnloadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);
            if (mousePosition.X <= 880 && mousePosition.X >= 730 && mousePosition.Y <= 525 && mousePosition.Y >= 450)
            {
                Boolean Dibujar = true;
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    spriteBatch.Begin();
                    spriteBatch.Draw(DSalir, new Rectangle(10, 10, 890, 520), Color.White);
                    if (si.Contains(mousePosition))
                    {
                        Exit();
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
            spriteBatch.Begin();
            if (!Creado)
            {
                spriteBatch.Draw(background, new Rectangle(0, 0, 900, 530), Color.White);
                spriteBatch.Draw(playSound, new Rectangle(400, 50, 120, 100), Color.White);
                spriteBatch.Draw(salir, new Rectangle(730, 450, 150, 75), Color.White);
                Creado = true;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }


    }
}
