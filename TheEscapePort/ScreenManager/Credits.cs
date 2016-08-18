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

namespace TheEscape.ScreenManager
{
    class Credits
    {

        //---Noch nicht Implementiert---//

        public static List<string> names = new List<string>();
        public static Vector2 positionTranslation = new Vector2(0);

        public static void Update()
        {
            positionTranslation.Y += 0.5f * (float)Basic.gameTime.ElapsedGameTime.TotalSeconds;
        }

        public static void Render()
        {
            Basic.gDevice.Clear(Color.Black);

            float posY = 1.0f + positionTranslation.Y;
            foreach (String s in names)
            {
                Basic.spriteBatch.DrawString(Basic.debugFont, s, new Vector2(10, posY), Color.White);
                posY += 10;
            }
        }
    }
}
