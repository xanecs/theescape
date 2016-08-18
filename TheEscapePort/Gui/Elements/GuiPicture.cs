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
    class GuiPicture: GUIElement
    {
        public Texture2D Textur;
        public Vector2 Position;
        public Color Multiplier;

        float scale = 0.05f;

        public GuiPicture(Vector2 pos, Texture2D tex)
        {
            Position = pos;
            Textur = tex;
            Multiplier = new Color(0,0,0,100);
        }

        public override void Update()
        {
            scale = Basic.gDevice.Viewport.Height * 0.00005f;
            Position = new Vector2(Basic.gDevice.Viewport.Width / 2 - (Textur.Width * scale) / 2, Basic.gDevice.Viewport.Height / 2 - (Textur.Height * scale) / 2);

        }

        public override void Render()
        {
            Basic.spriteBatch.Draw(Textur, new Rectangle((int)Position.X, (int)Position.Y, (int)(Textur.Width * scale), (int)(Textur.Height*scale)), Multiplier);
        }
    }
}
