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
    class BloodyScreen: GUIElement
    {
        bool oldac;
        public static Boolean isActive;

        float elapsed;
        int opacity;

        public BloodyScreen()
        {
            elapsed = 0;
            opacity = 255;
            
        }

        public override void Update()
        {
            if (isActive && !oldac)
            {
                oldac = true;
                elapsed = 0;
                opacity = 255;
            }

            if (isActive)
                elapsed += (float)Basic.gameTime.ElapsedGameTime.TotalMilliseconds;

            if (elapsed >= 2000)
                opacity -= (int)((float)Basic.gameTime.ElapsedGameTime.TotalMilliseconds * 0.255f);

            if (opacity <= 0)
            {
                isActive = false;
                oldac = false;
            }

            oldac = isActive;
            base.Update();
        }

        public override void Render()
        {
            if (isActive)
                Basic.spriteBatch.Draw(Textures.bloody_screen, Basic.windowSize, new Color(255, 255, 255, opacity));
            
            base.Render();
        }

		public void clear()
		{
			isActive = false;
		}
    }
}
