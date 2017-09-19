using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    class Food
    {
        public Point posicion { get; set; }
        public Texture2D textura { get; set; }
        public bool start { get; set; }
        public int id { get; set; }
    }
}
