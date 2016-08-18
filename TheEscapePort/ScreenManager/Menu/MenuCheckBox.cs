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
    class MenuCheckBox: MenuElement
    {
        public Boolean isChecked;
        public String Caption = "";

        public int Border = 3;

        bool temp;

        public MenuCheckBox(Vector2 position, String caption)
        {
            Position = position;
            Caption = caption;
            SetUp();
        }

        public MenuCheckBox(Vector2 position, String caption, Boolean check)
        {
            isChecked = check;
            Position = position;
            Caption = caption;
            SetUp();
        }

        public override void Update()
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && new Rectangle((int)Mouse.GetState().X, (int)Mouse.GetState().Y, 1, 1).Intersects(new Rectangle((int)Position.X, (int)Position.Y, Width, Height)))
            {
                if (!temp)
                {
                    isChecked = !isChecked;
                    temp = true;
                }
            }
            else
            {
                temp = false;
            }
        }

        public override void Render()
        {
            //BOX with border
            Basic.spriteBatch.Draw(Textures.blankTex, new Rectangle((int)Position.X, (int)Position.Y, Width, Height), new Color(0, 0, 0, 128));
            Basic.spriteBatch.Draw(Textures.blankTex, new Rectangle((int)Position.X, (int)Position.Y, Width, Border), Color.Black);
            Basic.spriteBatch.Draw(Textures.blankTex, new Rectangle((int)Position.X, (int)Position.Y, Border, Height), Color.Black);
            Basic.spriteBatch.Draw(Textures.blankTex, new Rectangle((int)Position.X + Width - Border, (int)Position.Y, Border, Height), Color.Black);
            Basic.spriteBatch.Draw(Textures.blankTex, new Rectangle((int)Position.X, (int)Position.Y + Height - Border, Width, Border), Color.Black);
            
            //CAPTION
            Basic.spriteBatch.DrawString(Basic.subtitleFont, Caption, new Vector2(Position.X + Width + 10, Position.Y + Height / 2 - Basic.subtitleFont.MeasureString(Caption).Y / 2), Color.White);

            //CROSS
            if (isChecked)
            {
                Basic.spriteBatch.Draw(Textures.checkBoxCross, new Rectangle((int)Position.X, (int)Position.Y, Width, Height), Color.Red);
            }
        }

        private void SetUp()
        {
            this.Height = 30;
            this.Width = 30;

        }
    }
}
