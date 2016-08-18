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
    class MenuSlider: MenuElement
    {
        public float value;
        public string Caption;

        Rectangle bg;
        Rectangle slider;
        float min;
        float max;

        public MenuSlider(int width, int height, float minimum, float maximum, string title, float defaultValue, int X, int Y)
        {
            value = defaultValue;
            Caption = title;
            bg = new Rectangle(X, Y, width, height);
            min = minimum;
            max = maximum;

        }

        public override void Update()
        {
            slider.Y = bg.Y;
            slider.X = (int)((max - min) / bg.Width * value);
            base.Update();
        }

        public override void Render()
        {
            Basic.spriteBatch.Draw(Textures.blankTex, bg, new Color(0, 0, 0, 50));
            Basic.spriteBatch.Draw(Textures.buttonbg, slider, Color.White);
            base.Render();
        }

        public override void UpdateForNewResolution()
        {
            base.UpdateForNewResolution();
        }
    }
}
