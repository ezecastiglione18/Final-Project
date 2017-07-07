using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace MonoGame
{
    class Arrastrar
    {
        Medium medium = new Medium();
        public Texture2D ItemElegido { get; set; }
        static MouseState mouseState = Mouse.GetState();
        Point mousePosition = new Point(mouseState.X, mouseState.Y);
        public Texture2D SelectedItem()
        {
            for (int i = 0; i < Medium.Imagenes.Length-1; i++)
            {
                if (Medium.Imagenes[i].Bounds.Contains(mousePosition))
                {
                    ItemElegido = Medium.Imagenes[i];
                    return ItemElegido;
                }
            }
            return default(Texture2D);
        }


    }
}
