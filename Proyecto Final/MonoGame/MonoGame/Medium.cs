using System;
using System.IO;
using System.Configuration;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace MonoGame
{
    class Medium : Game
    {
        GraphicsDeviceManager graphics;
        GraphicsDevice device;
        SpriteBatch spriteBatch;
        private Texture2D background;
        private Texture2D playSound;
        private Texture2D salir;
        private Texture2D DSalir;
        private Texture2D ToDrag;
        private Texture2D nube;
        private Texture2D ganarcuadro;
        Rectangle yes = new Rectangle(273, 305, 135, 117);
        Rectangle no = new Rectangle(491, 305, 87, 117);
        Rectangle boton = new Rectangle(395, 35, 105, 80);
        Rectangle cloud = new Rectangle(330, 150, 250, 170);

        Random random = new Random();
        private SpriteFont Font;
        private SoundEffect quit;
        private SoundEffect incorrecto;
        private SoundEffect correcto;
        private SoundEffect select;
        private SoundEffect end;
        bool SalirBool = false;
        bool GanarBool = false;
        bool Dibujar = false;
        bool DibujarGanar = false;
        bool escuchado = false;
        bool played = false;
        bool contained = false;
        bool dragging = false;
        bool acierto = false;
        bool ganar;
        bool rand = false;
        bool primeravez= true;
        int escuchar = 7;
        int i = 0;
        int j = 0;
        int lastx;
        int lasty;
        int ToDragIndex;
        int contAciertos = 0;

        bool [] vUsados = new bool[6] { false, false, false, false, false, false};
        public static Texture2D[] Imagenes = new Texture2D[6];
        public SoundEffect[] sonidos = new SoundEffect [6];
        int[] posiciones = new int[6];
        Texture2D[] win = new Texture2D[9];
        Rectangle[] areas = new Rectangle[6];
        dbConexion Conexion = new dbConexion();

        public Medium()
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
            Conexion.Seleccionar();

            FileStream file1 = new FileStream(Properties.Settings.Default.Ruta + "\\" + Conexion.listAnimales[0].imagen, FileMode.Open);
            FileStream file2 = new FileStream(Properties.Settings.Default.Ruta + "\\" + Conexion.listAnimales[1].imagen, FileMode.Open);
            FileStream file3 = new FileStream(Properties.Settings.Default.Ruta + "\\" + Conexion.listAnimales[2].imagen, FileMode.Open);
            FileStream file4 = new FileStream(Properties.Settings.Default.Ruta + "\\" + Conexion.listAnimales[3].imagen, FileMode.Open);
            FileStream file5 = new FileStream(Properties.Settings.Default.Ruta + "\\" + Conexion.listAnimales[4].imagen, FileMode.Open);
            FileStream file6 = new FileStream(Properties.Settings.Default.Ruta + "\\" + Conexion.listAnimales[5].imagen, FileMode.Open);
            Imagenes[0] = Texture2D.FromStream(GraphicsDevice, file1);
            Imagenes[1] = Texture2D.FromStream(GraphicsDevice, file2);
            Imagenes[2] = Texture2D.FromStream(GraphicsDevice, file3);
            Imagenes[3] = Texture2D.FromStream(GraphicsDevice, file4);
            Imagenes[4] = Texture2D.FromStream(GraphicsDevice, file5);
            Imagenes[5] = Texture2D.FromStream(GraphicsDevice, file6);
            FileStream snd1 = new FileStream(Properties.Settings.Default.Ruta + "\\" + Conexion.listAnimales[0].sonido, FileMode.Open);
            FileStream snd2 = new FileStream(Properties.Settings.Default.Ruta + "\\" + Conexion.listAnimales[1].sonido, FileMode.Open);
            FileStream snd3 = new FileStream(Properties.Settings.Default.Ruta + "\\" + Conexion.listAnimales[2].sonido, FileMode.Open);
            FileStream snd4 = new FileStream(Properties.Settings.Default.Ruta + "\\" + Conexion.listAnimales[3].sonido, FileMode.Open);
            FileStream snd5 = new FileStream(Properties.Settings.Default.Ruta + "\\" + Conexion.listAnimales[4].sonido, FileMode.Open);
            FileStream snd6 = new FileStream(Properties.Settings.Default.Ruta + "\\" + Conexion.listAnimales[5].sonido, FileMode.Open);
            sonidos[0] = SoundEffect.FromStream(snd1);
            sonidos[1] = SoundEffect.FromStream(snd2);
            sonidos[2] = SoundEffect.FromStream(snd3);
            sonidos[3] = SoundEffect.FromStream(snd4);
            sonidos[4] = SoundEffect.FromStream(snd5);
            sonidos[5] = SoundEffect.FromStream(snd6);

        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("Medium");
            playSound = Content.Load<Texture2D>("PlaySound");
            salir = Content.Load<Texture2D>("salir");
            DSalir = Content.Load<Texture2D>("DSalir");
            Font = Content.Load<SpriteFont>("AgentOrange");
            nube = Content.Load<Texture2D>("nube");
            ganarcuadro = Content.Load<Texture2D>("Ganar");
            quit = Content.Load<SoundEffect>("Sonidos/Agarrar");
            incorrecto = Content.Load<SoundEffect>("Sonidos/Incorrecto_Medium");
            correcto = Content.Load<SoundEffect>("Sonidos/Correcto_Medium");
            select = Content.Load<SoundEffect>("Sonidos/Select");
            end = Content.Load<SoundEffect>("Sonidos/Correcto");
            win[0] = Content.Load<Texture2D>("Animation/1");
            win[1] = Content.Load<Texture2D>("Animation/2");
            win[2] = Content.Load<Texture2D>("Animation/3");
            win[3] = Content.Load<Texture2D>("Animation/4");
            win[4] = Content.Load<Texture2D>("Animation/5");
            win[5] = Content.Load<Texture2D>("Animation/6");
            win[6] = Content.Load<Texture2D>("Animation/7");
            win[7] = Content.Load<Texture2D>("Animation/8");
            win[8] = Content.Load<Texture2D>("Animation/9");
        }
        protected override void UnloadContent()
        {
            Content.Unload();
        }
        protected override void Update(GameTime gameTime)
        {
            #region salir
            MouseState mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);
            if (mousePosition.X <= 880 && mousePosition.X >= 730 && mousePosition.Y <= 525 && mousePosition.Y >= 450)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && !dragging && !DibujarGanar)
                {
                    SalirBool = true;
                    Dibujar = true;
                }
            }
            if (Dibujar)
            {
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
                mousePosition = new Point(mouseState.X, mouseState.Y);
                if (yes.Contains(mousePosition) && mouseState.LeftButton == ButtonState.Pressed && !dragging)
                {
                    UnloadContent();
                    Exit();
                }
                if (no.Contains(mousePosition) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    SalirBool = false;
                    Dibujar = false;
                    played = false;
                }
            }
            #endregion

            if (contAciertos == 1)
            {
                ganar = true; 
            }  

            if (boton.Contains(mousePosition) && mouseState.LeftButton == ButtonState.Pressed && !escuchado && !dragging && !Dibujar &&!DibujarGanar )
            {
                if (rand || primeravez)
                {
                    Randomize();
                }
                primeravez = false;
                sonidos[escuchar].Play();
                vUsados[escuchar] = true;
                escuchado = true;
                rand = false;
            }

            if (escuchado && boton.Contains(mousePosition) && mouseState.LeftButton == ButtonState.Released)
            {
                escuchado = false;
            }

            if (cloud.Contains(mousePosition) && dragging)
            {
                if (mouseState.LeftButton == ButtonState.Released)
                {
                    if (ToDragIndex == escuchar)
                    {
                        acierto = true;
                        Conexion.listAnimales[ToDragIndex].ok = true;
                    }
                    else
                    {
                        incorrecto.Play();
                    }
                }
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            if (!Dibujar && !DibujarGanar)
            {
                GraphicsDevice.Clear(Color.White);
                spriteBatch.Begin();
                spriteBatch.Draw(background, new Rectangle(0, 0, 900, 530), Color.White);
                spriteBatch.Draw(playSound, new Rectangle(400, 35, 100, 80), Color.White);
                spriteBatch.Draw(nube, new Rectangle(330, 150, 250, 170), Color.White);
                spriteBatch.DrawString(Font, "Which animal do \n \nyou hear?", new Vector2(30, 30), Color.Black);
                if (acierto)
                {
                    contAciertos++;
                    if (contAciertos == 6)
                    {
                        end.Play();
                    }
                    else
                    {
                        correcto.Play();
                    }
                    for (int i = 9; i > -1; i--)
                    {
                        spriteBatch.Draw(ToDrag, new Rectangle(lastx, lasty, Conexion.listAnimales[ToDragIndex].ancho, Conexion.listAnimales[ToDragIndex].alto * (i / 10)), Color.White);
                    }
                    rand = true;
                    acierto = false;
                }
                if (!dragging)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        Animal oAnimal = Conexion.listAnimales[i];
                        if (!oAnimal.ok)
                        {
                            if (i > 0)
                            {
                                spriteBatch.Draw(Imagenes[i], new Rectangle(posiciones[i - 1] + 20, 465 - Conexion.listAnimales[i].alto, Conexion.listAnimales[i].ancho, Conexion.listAnimales[i].alto), Color.White);
                                posiciones[i] = posiciones[i - 1] + 20 + Conexion.listAnimales[i].ancho;
                                areas[i] = new Rectangle(posiciones[i - 1] + 20, 465 - Conexion.listAnimales[i].alto, Conexion.listAnimales[i].ancho, Conexion.listAnimales[i].alto);
                            }
                            else
                            {
                                spriteBatch.Draw(Imagenes[i], new Rectangle(10, 465 - Conexion.listAnimales[i].alto, Conexion.listAnimales[i].ancho, Conexion.listAnimales[i].alto), Color.White);
                                posiciones[0] = 10 + Conexion.listAnimales[0].ancho;
                                areas[0] = new Rectangle(10, 465 - Conexion.listAnimales[i].alto, Conexion.listAnimales[i].ancho, Conexion.listAnimales[i].alto);
                            }
                        }
                        
                    }
                }
                else
                {
                    for (int i = 0; i < 6; i++)
                    {
                        Animal oAnimal = Conexion.listAnimales[i];
                        if (!oAnimal.ok && !oAnimal.dragging)
                        {
                            if (i > 0)
                            {
                                spriteBatch.Draw(Imagenes[i], new Rectangle(posiciones[i - 1] + 20, 465 - Conexion.listAnimales[i].alto, Conexion.listAnimales[i].ancho, Conexion.listAnimales[i].alto), Color.White);
                            }
                            else
                            {
                                spriteBatch.Draw(Imagenes[i], new Rectangle(10, 465 - Conexion.listAnimales[i].alto, Conexion.listAnimales[i].ancho, Conexion.listAnimales[i].alto), Color.White);   
                            }
                        }
                    }
                }
                spriteBatch.Draw(salir, new Rectangle(730, 450, 150, 75), Color.White);
            }
            spriteBatch.End();

            MouseState mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);

            #region ganar
            if (ganar)
            {
                j++;
                Vector2 origin;
                origin = new Vector2(win[i].Width / 2, win[i].Height / 2);
                spriteBatch.Begin();
                spriteBatch.Draw(win[i], new Rectangle(Convert.ToInt32(450 - origin.X), Convert.ToInt32(265 - origin.Y), win[i].Width, win[i].Height), Color.White);
                spriteBatch.End();
                contAciertos = 0;
                if (j % 6 == 0)
                {
                    i++;
                    if (i == 9)
                    {
                        ganar = false;
                        GanarBool = true;
                        DibujarGanar = true;
                    }
                }
            }

            if (DibujarGanar)
            {
                spriteBatch.Begin();
                if (!played)
                {
                    quit.Play();
                    played = true;
                }
                spriteBatch.Draw(ganarcuadro, new Rectangle(10, 10, 890, 520), Color.White);
                spriteBatch.End();
            }
            if (GanarBool)
            {
                mousePosition = new Point(mouseState.X, mouseState.Y);
                if (yes.Contains(mousePosition) && mouseState.LeftButton == ButtonState.Pressed && !dragging)
                {
                    GanarBool = false;
                    DibujarGanar = false;
                    played = false;
                    SalirBool = false;
                    GanarBool = false;
                    Dibujar = false;
                    DibujarGanar = false;
                    escuchado = false;
                    played = false;
                    contained = false;
                    dragging = false;
                    acierto = false;
                    rand = false;
                    primeravez = true;
                    escuchar = 7;
                    i = 0;
                    j = 0;
                    contAciertos = 0;
                    Initialize();
                    LoadContent();
                }
                if (no.Contains(mousePosition) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    UnloadContent();
                    Exit();
                }
            }

            #endregion

            #region drag
            for (int i = 0; i < 6; i++)
            {
                if (areas[i].Contains(mousePosition) && !dragging)
                {
                    ToDragIndex = i;
                    contained = true;
                }
            }
            if (contained && !Dibujar && !DibujarGanar)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    if (!Conexion.listAnimales[ToDragIndex].ok)
                    {
                        Conexion.listAnimales[ToDragIndex].dragging = true;
                        ToDrag = Imagenes[ToDragIndex];
                        dragging = true;
                        if (!played && !SalirBool && !GanarBool)
                        {
                            select.Play();
                            played = true;
                        }
                        spriteBatch.Begin();
                        spriteBatch.Draw(ToDrag, new Rectangle(mousePosition.X - (ToDrag.Width / 2), mousePosition.Y - (ToDrag.Height / 2), Conexion.listAnimales[ToDragIndex].ancho, Conexion.listAnimales[ToDragIndex].alto), Color.White);
                        lastx = mousePosition.X;
                        lasty = mousePosition.Y;
                        spriteBatch.End();
                    }
                }
                else
                {
                    Conexion.listAnimales[ToDragIndex].dragging = false;
                    ToDrag = null;
                    ToDragIndex = 7;
                    dragging = false;
                    contained = false;
                    played = false;
                }
            }

            #endregion

            base.Draw(gameTime);
        }

        public void Randomize()
        {
            escuchar = random.Next(0, 6);
            while (vUsados[escuchar] == true && contAciertos<6)
            {
                 escuchar = random.Next(0, 6);
            }        
        }
    }
}
