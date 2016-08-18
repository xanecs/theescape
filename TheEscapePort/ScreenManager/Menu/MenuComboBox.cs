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
    class MenuComboBox: MenuElement
    {
        public List<String> Items = new List<String>();
        public String Caption = "";
        public int Border;

        public int selectedIndex;
        public String selectedItem;

        Rectangle Button;

        bool extended;

        public MenuComboBox(Vector2 position, String caption)
        {
            this.Position = position;
            this.Height = 40;
            this.Width = 200;
            this.Border = 3;

            Button = new Rectangle(0, 0, Width / 5, Height / 5);
            Button.X = Convert.ToInt16(Position.X + Width - Button.Width);
            Button.Y = Convert.ToInt16(Position.Y + Height - Button.Height);

            Caption = caption;

            selectedIndex = 0;
            selectedItem = "";
        }

        public override void Update()
        {
            selectedItem = Items[selectedIndex];

            //BUTTON
            Button = new Rectangle(Convert.ToInt16(Position.X + Width - Height - 2 * Border), Convert.ToInt16(Position.Y + Height - Height - Border), Height - Border, Height - Border);
            Button.X = Convert.ToInt16(Position.X + Width - Button.Width - Border);
            Button.Y = Convert.ToInt16(Position.Y + Height - Button.Height);
            Button.Height -= Border;

            #region Click
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                bool temp = false;
                Rectangle mouse = new Rectangle((int)Mouse.GetState().X, (int)Mouse.GetState().Y, 1, 1);

                if (mouse.Intersects(Button))
                {
                    extended = true;
                    temp = true;
                }
            
                if (extended)
                {
                    for (int i = 0; i < Items.Count; i++)
                    {
                        if (mouse.Intersects(new Rectangle((int)Position.X, (int)Position.Y + Height + i * Height, Width, Height)))
                        {
                            selectedIndex = i;
                            extended = false;
                            temp = true;
                        }
                    }
                }

                if (!temp)
                    extended = false;
            }
            #endregion

        }

        public override void Render()
        {
            #region NORMAL

            //BOX with BORDER
            Basic.spriteBatch.Draw(Textures.blankTex, new Rectangle((int)Position.X, (int)Position.Y, Width, Height), new Color(0, 0, 0, 100));
            Basic.spriteBatch.Draw(Textures.blankTex, new Rectangle((int)Position.X, (int)Position.Y, Border, Height), Color.Black);
            Basic.spriteBatch.Draw(Textures.blankTex, new Rectangle((int)Position.X + Width - Border, (int)Position.Y, Border, Height), Color.Black);
            Basic.spriteBatch.Draw(Textures.blankTex, new Rectangle((int)Position.X, (int)Position.Y, Width, Border), Color.Black);
            Basic.spriteBatch.Draw(Textures.blankTex, new Rectangle((int)Position.X, (int)Position.Y + Height - Border, Width, Border), Color.Black);
            
            //CAPTION
            Basic.spriteBatch.DrawString(Basic.subtitleFont, Items[selectedIndex], Position + new Vector2(10, Height / 2 - Basic.subtitleFont.MeasureString(Items[0]).Y / 2), Color.White);

            //BUTTON
            Basic.spriteBatch.Draw(Textures.blankTex, Button, new Color(0, 0, 0, 220));
            Basic.spriteBatch.Draw(Textures.comboBoxArrow, Button, new Color (255, 255, 255, 128));

            #endregion

            if (extended)
            {
                #region EXTENDED

                Basic.spriteBatch.Draw(Textures.blankTex, new Rectangle((int)Position.X, (int)Position.Y + Height, Width, Height * (Items.Count)), new Color(0, 0, 0, 128));

                for (int i = 0; i <= Items.Count; i++)
                {
                    Basic.spriteBatch.DrawString(Basic.subtitleFont, Items[i], Position + new Vector2(10, 10 + Height * (i + 1)), Color.White);
                }

                #endregion
            }
        }
    }
}
