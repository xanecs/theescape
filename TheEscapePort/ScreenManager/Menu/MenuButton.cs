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
    class MenuButton: MenuElement
    {
        public EventHandler Handler;
        public String Caption;
        public SpriteFont Font = Basic.subtitleFont;
        public Color ColorMultiplier;

        bool clicking = false;
        bool pressed = false;

        public MenuButton(Vector2 position, String caption)
        {
            this.Caption = caption;
            this.Position = position;
            this.Height = 70;
            this.Width = 200;
        }

        public override void Update()
        {
            this.Width = (int)(Basic.gDevice.Viewport.Width * 0.25f);
            this.Height = (int)(24.7f * Math.Log(Basic.gDevice.Viewport.Height) - 102.26f);

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && pressed == false && new Rectangle((int)Position.X, (int)Position.Y, Width, Height).Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1)))
                pressed = true;

            if (Mouse.GetState().LeftButton == ButtonState.Released && pressed == true && new Rectangle((int)Position.X, (int)Position.Y, Width, Height).Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1)))
            {
                Handler.Invoke(this, new EventArgs());
                pressed = false;
            }

            if (new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1).Intersects(new Rectangle((int)Position.X, (int)Position.Y, Width, Height)))
            {
                if (!clicking)
                {
                    Sounds.clickInstance.Play();
                    clicking = true;
                }

                ColorMultiplier = new Color(100, 0, 0, 200);
            }
            else
            {
                clicking = false;
                ColorMultiplier = new Color(50, 0, 0, 200);
            }

            base.Update();
        }

        public override void Render()
        {
            Basic.spriteBatch.Draw(Textures.blankTex, new Rectangle((int)Position.X, (int)Position.Y, Width, Height), new Color(0,0,0,100));
            Basic.spriteBatch.Draw(Textures.blankTex, new Rectangle((int)Position.X + 5, (int)Position.Y + 5, Width - 10, Height - 10), ColorMultiplier);

            Font = Basic.subtitleFont;
            Basic.spriteBatch.DrawString(Font, Caption, new Vector2(Position.X + (Width / 2 - Font.MeasureString(Caption).X / 2), Position.Y + (Height / 2 - Font.MeasureString(Caption).Y / 2)), Color.White);
            base.Render();
        }
    }
}
