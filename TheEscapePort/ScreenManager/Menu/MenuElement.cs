using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TheEscape
{
    class MenuElement : IComparable
    {
        public Vector2 Position;
        public int Height;
        public int Width;

        public int Layer;

        public virtual void Update()
        {     
        }
        public virtual void Render()
        {
        }
        public virtual void UpdateForNewResolution()
        {
        }

        public int CompareTo(object obj)
        {
            MenuElement e = (MenuElement)obj;
            return Layer - e.Layer;
        }
    }
}
