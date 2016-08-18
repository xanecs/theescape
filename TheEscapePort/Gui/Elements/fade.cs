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
    class fade: GUIElement
    {
        public Color fadeColor;
        public float fadeStep;
        public bool fading;
        public float rawOpacity = 0;
        public float Opacity = 0;
        public Rectangle fadeRec;
        public bool switchedLevel = false;

        public fade(Color color, float step)
        {
            fadeColor = color;
            fadeStep = step;
            fadeRec = new Rectangle(0, 0, Basic.gManager.PreferredBackBufferWidth, Basic.gManager.PreferredBackBufferHeight);
        }
        public void startFade(int level, bool startBlack = false)
        {
			if (startBlack)
			{
				rawOpacity = MathHelper.PiOver2;
			}
            fading = true;
            GameScreen.level.level = level;
        }
        public void stopFade()
        {
            fading = false;
            Opacity = 0;
            rawOpacity = 0;
            switchedLevel = false;
        }

        public override void Update()
        {
            if (fading)
            {
                if (rawOpacity <= Math.PI)
                {
                    rawOpacity += fadeStep;
                }
                else
                {
                    stopFade();
                }
                if (rawOpacity >= MathHelper.PiOver2 && !switchedLevel)
                {
                    Level.switchLevel();
                    switchedLevel = true;
                }
                
            }
            else
            {
                stopFade();
                
            }

            Opacity = (float)Math.Sin(rawOpacity);
        }
        public override void Render()
        {
            Basic.spriteBatch.Draw(Textures.blankTex, fadeRec, Color.Black * Opacity);
        }
    }
}
