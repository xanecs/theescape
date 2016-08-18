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
    class GuiKey: GUIElement
    {
        int scale = 35;

        public GuiKey()
        {
            
        }

        public override void Update()
        {

            base.Update();
        }

        public override void Render()
        {
            for (int i = 1; i <= GameScreen.player.keys; i++)
            {
                Basic.spriteBatch.Draw(Textures.key, new Rectangle(Basic.gDevice.Viewport.Width - (Textures.key.Width / scale) - i * 5, 5, Textures.key.Width / scale, Textures.key.Height / scale), Color.Gold);
            }
            base.Render();
        }
    }
}
