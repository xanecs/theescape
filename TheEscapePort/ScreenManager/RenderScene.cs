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
    class RenderScene : Screen
    {
        private Screen oldScreen;
        private Rectangle output;

        public static void LoadContent()
        {
            Ending = new RenderScene("Content/Cutscenes/demo.wmv");
        }

        public static void UnloadContent()
        {
            Ending.player.Stop();
        }

        public RenderScene(String path)
        {
            player = new VideoPlayer(path, Basic.gDevice);
            player.OnVideoComplete += new EventHandler(onVideoCompleted);
        }

        public void StartScene()
        {
            oldScreen = Basic.currentScreen;
            Basic.setScreen(this);

            float AspRatio = player.VideoWidth * 1.0f / player.VideoHeight;
            output = new Rectangle(0, 0, Basic.gManager.PreferredBackBufferWidth, (int)(Basic.gManager.PreferredBackBufferWidth * (1 / AspRatio)));
            output.Y = Basic.gManager.PreferredBackBufferHeight / 2 - output.Height / 2;

            player.Rewind(); 
        }

        public override void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                player.Stop();
                onVideoCompleted(this, new EventArgs());
            }

            try
            {
                player.Update();
            }
            catch (Exception ex) { Console.Write(ex.StackTrace); }
            
        }

        public override void Render()
        {
            Basic.spriteBatch.Draw(player.OutputFrame, output, Color.White);
        }

        private void onVideoCompleted(Object sender, EventArgs args)
        {
            Basic.currentScreen = oldScreen;
            player.Stop();
        }
    }
}
