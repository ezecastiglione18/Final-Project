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
        private Texture2D basketball;
        private Texture2D rugby;
        private Texture2D football;

        public Medium()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 900;
            graphics.PreferredBackBufferHeight = 530;
            graphics.ApplyChanges();
            Content.RootDirectory = "Medium";
        }
        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            base.Initialize();
        }
        protected override void LoadContent()
        {
            background = Content.Load<Texture2D>("Medium");
            basketball = Content.Load<Texture2D>("Sports/Basketball");
            rugby = Content.Load<Texture2D>("Sports/Rugby");
            football = Content.Load<Texture2D>("Sports/Football");
        }
        protected override void UnloadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(background, new Rectangle(0, 0, 900, 530), Color.White);
            base.Draw(gameTime);
        }
    }
}
