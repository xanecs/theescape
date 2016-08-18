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
    class MenuLabel: MenuElement
    {
        public String Caption;
        public enum LabelMode{ LABEL, LINKLABEL };
        public LabelMode Mode = LabelMode.LABEL;
        public Color ColorMultiplier;

        public EventHandler Handler;

        public SpriteFont Font;

        public MenuLabel(Vector2 position, String caption, LabelMode mode)
        {
            Caption = caption;
            Position = position;
            Mode = mode;
            Font = Basic.debugFont;
        }

        public override void Update()
        {
            if (Mode == LabelMode.LINKLABEL)
                ColorMultiplier = new Color(0, 0, 255, 255);
            else
                ColorMultiplier = new Color(255, 255, 255, 255);

            Rectangle box = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
            Rectangle mouse = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1);
            if (Mode == LabelMode.LINKLABEL && Mouse.GetState().LeftButton == ButtonState.Pressed && box.Intersects(mouse))
                Handler.Invoke(this, new EventArgs());
            if (box.Intersects(mouse) && Mode == LabelMode.LINKLABEL && box.Intersects(mouse))
            {
                ColorMultiplier = new Color(255, 255, 255, 250);
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    Handler.Invoke(this, new EventArgs());
            }

            this.Width = (int)Basic.subtitleFont.MeasureString(Caption).X;
            this.Height = (int)Basic.subtitleFont.MeasureString(Caption).Y;
        }

        public override void Render()
        {
            Basic.spriteBatch.DrawString(Font, Caption, Position, ColorMultiplier);
        }
    }
}
