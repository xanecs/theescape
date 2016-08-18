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
    class MenuSprite: MenuElement
    {
        public Texture2D Texture;
        public Color ColorMultiplier = Color.White;

        public MenuSprite(Vector2 position, Texture2D texture)
        {
            Position = position;
            Texture = texture;
            this.Height = texture.Height;
            this.Width = texture.Width;
        }

        public MenuSprite(Vector2 position, Texture2D texture, Vector2 scale)
        {
            Position = position;
            Texture = texture;
            this.Height = Convert.ToInt16(texture.Height * scale.Y);
            this.Width = Convert.ToInt16(texture.Width * scale.X);
        }

        public override void Render()
        {
            Basic.spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, Width, Height), ColorMultiplier);
        }
    }
}
