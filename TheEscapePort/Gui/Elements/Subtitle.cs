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
    class Subtitle: GUIElement
    {
        public string Text;

        public Vector2 Position;
        public Color fontColor = new Color(255, 0, 0);

        float elapsed;
        float duration;

        public Subtitle(string txt)
        {
            Text = txt;
            Position = new Vector2(0, 0);
            fontColor = new Color(255, 10, 10, 0);
        }

        public void AddSubtitle(string text, float _duration)
        {
            Text = text;
            elapsed = 0.0f;
            duration = _duration;
        }

        public override void Update()
        {
            elapsed += (float)Basic.gameTime.ElapsedGameTime.TotalSeconds;

            if (elapsed < duration)
                Position = new Vector2(Basic.gDevice.Viewport.Width / 20 * 19 - Basic.subtitleFont.MeasureString(Text).X / 20 * 19, Basic.gDevice.Viewport.Height / 20 - Basic.subtitleFont.MeasureString(Text).Y / 20);
            if (elapsed >= duration && Position.Y <= Basic.gDevice.Viewport.Height + 20)
                Position.Y -= 4;
            if (Position.Y >= Basic.gDevice.Viewport.Height + 20)
                Text = "";
            
            base.Update();
        }

        public override void Render()
        {
            Basic.spriteBatch.Draw(Textures.blankTex, new Rectangle((int)Position.X - 5, (int)Position.Y - 5, (int)Basic.subtitleFont.MeasureString(Text).X + 10, (int)Basic.subtitleFont.MeasureString(Text).Y + 10), new Color(0, 0, 0, 50));
            Basic.spriteBatch.DrawString(Basic.subtitleFont, Text, Position, Color.White);
            base.Render();
        }
    }
}
