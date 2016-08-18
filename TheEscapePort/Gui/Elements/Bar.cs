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
    class Bar: GUIElement
    {
        public Vector2 position;
        public Texture2D texture;
        public int max_lenghth;
        float lenght;
        public int height;
        public Rectangle recBar;
        public Rectangle recBorder;
        public int border;
        public Color color;

        public int value;

        public Bar(Vector2 pos, Texture2D tex, int _lenght, int hei, int _border, Color clr)
        {
            position = pos;
            texture = tex;
            max_lenghth = _lenght;
            lenght = max_lenghth;
            height = hei;
            border = _border;
            recBorder.Height = hei + (2 * border);
            recBorder.Width = max_lenghth + (2 * border);
            color = clr;
        }

        public override void Update()
        {
            
            position = new Vector2(Basic.gDevice.Viewport.Width - this.max_lenghth - border * 2 - (Basic.gDevice.Viewport.Width / 70), Basic.gDevice.Viewport.Height - this.height - border * 2 - (Basic.gDevice.Viewport.Width / 70));
            max_lenghth = Basic.gDevice.Viewport.Width / 4 - 20;
            lenght = (max_lenghth / 100.0f) * value;
        }

        public override void Render()
        {
            recBorder.X = (int)position.X;
            recBorder.Y = (int)position.Y;
            recBorder.Width = this.max_lenghth + (border * 2);
            recBorder.Height = this.height + (border * 2);
            recBar = new Rectangle((int)position.X + border, (int)position.Y + border, (int)lenght, height);

            if (value < 100)
            {
                Basic.spriteBatch.Draw(Textures.bar_border, recBorder, new Color(0, 0, 0, 75));
                Basic.spriteBatch.Draw(Textures.bar_border, new Rectangle((int)position.X, (int)position.Y, max_lenghth + (border * 2), border), Color.Black);
                Basic.spriteBatch.Draw(Textures.bar_border, new Rectangle((int)position.X, (int)position.Y, border, height + (border * 2)), Color.Black);
                Basic.spriteBatch.Draw(Textures.bar_border, new Rectangle((int)position.X, (int)position.Y + height + border, max_lenghth + (border * 2), border), Color.Black);
                Basic.spriteBatch.Draw(Textures.bar_border, new Rectangle((int)position.X + max_lenghth + border, (int)position.Y, border, height + (border * 2)), Color.Black);
                Basic.spriteBatch.Draw(texture, recBar, color);
            }
        }
    }
}
