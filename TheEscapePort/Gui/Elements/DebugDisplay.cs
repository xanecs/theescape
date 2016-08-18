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
    class DebugDisplay: GUIElement
    {
        public Vector2 position;
        public string name;
        public string value;
        public Color color;

        public DebugDisplay(Vector2 pos, string _name, float value)
        {
            position = pos;
            name = _name;
            color = Color.White;
            
        }

        public DebugDisplay(Vector2 pos, string _name, String value)
        {
            position = pos;
            name = _name;
            color = Color.White;
            
        }

        public override void Update()
        {
            this.position = new Vector2((Basic.gDevice.Viewport.Width) - (Basic.debugFont.MeasureString(this.name + ": " + this.value).X) - 5, (Basic.gDevice.Viewport.Height) - (Basic.debugFont.MeasureString(this.name + ": " + this.value).Y));
        }

        public override void Render()
        {
            Basic.spriteBatch.DrawString(Basic.debugFont, name + ": " + value, position, color);
        }
    }
}
