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
    class MenuBox: MenuElement
    {
        Rectangle rect;
        Color coll;

        public MenuBox(Rectangle rec, Color col)
        {
            Position.X = rec.X;
            Position.Y = rec.Y;
            rect = rec;
            coll = col;
        }

        public override void Render()
        {
            Basic.spriteBatch.Draw(Textures.blankTex, rect, coll);
        }
    }
}
