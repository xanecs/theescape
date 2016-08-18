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
    class FPS
    {
        KeyboardState currstate;
        KeyboardState prevstate;

        List<string> DebugItems = new List<string>();

        int i;
        public int print;
        float elapsed;

        public void Update(GameTime gameTime)
        {
            
            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsed >= 1000)
            {
                print = i;
                i = 0;
                elapsed = 0.0f;
            }
        }
        public void Render(SpriteBatch spriteBatch)
        {
            i++;
            currstate = Keyboard.GetState();
            if (KeypressTest(Keys.F3))
                Basic.debugMode = !Basic.debugMode;
            prevstate = currstate;
            if (Basic.debugMode)
            {
                DebugItems.Clear();
                DebugItems.Add(""); //FPS-Placeholder
                DebugItems.Add("Entities: " + GameScreen.level.entities.Count);
                DebugItems.Add("Level: " + GameScreen.level.level);
                DebugItems.Add("Map: " + GameScreen.level.mapHeight + "x" + GameScreen.level.mapWidth);
                DebugItems.Add("Health: " + GameScreen.player.health);
                DebugItems.Add("X: " + GameScreen.player.position.X);
                DebugItems.Add("Y: " + GameScreen.player.position.Y);
                DebugItems.Add("Z: " + GameScreen.player.position.Z);

                spriteBatch.Draw(Textures.blankTex, new Rectangle(5, 5, 200, (int)((Basic.debugFont.MeasureString("M").Y * (DebugItems.Count)) + 5)), new Color(0, 0, 0, 128));

                if (print > 50)
                    spriteBatch.DrawString(Basic.debugFont, "FPS: " + print.ToString(), new Vector2(10, 10), Color.LightGreen);
                else if (print >= 25 && print <= 50)
                    spriteBatch.DrawString(Basic.debugFont, "FPS: " + print.ToString(), new Vector2(10, 10), Color.Yellow);
                else if (print < 25)
                    spriteBatch.DrawString(Basic.debugFont, "FPS: " + print.ToString(), new Vector2(10, 10), Color.Red);

                int x = 0;
                foreach (string m in DebugItems)
                {
                    spriteBatch.DrawString(Basic.debugFont, m, new Vector2(10, Basic.debugFont.MeasureString("M").Y * x + 10), Color.White);
                    x++;
                }
            }
        }
        bool KeypressTest(Keys theKey)
        {
            if (currstate.IsKeyUp(theKey) && prevstate.IsKeyDown(theKey))
                return true;

            return false;
        }
    }
}
