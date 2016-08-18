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
    class MenuBackground: MenuElement
    {
        public Texture2D Texture;

        public MenuBackground(Texture2D texture)
        {
            Texture = texture;
        }

        public override void Update()
        {
            Width = Basic.gDevice.Viewport.Width;
            //Height = Width / (Texture.Width / Texture.Height);
            Height = Basic.gDevice.Viewport.Height;
        }

        public override void Render()
        {
            Basic.spriteBatch.Draw(Texture, new Rectangle(0, 0, Width, Height), Color.White);
        }
    }
}
