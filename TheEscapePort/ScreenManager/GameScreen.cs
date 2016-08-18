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
   class GameScreen: Screen
    {
       public static Camera camera;
       public static BasicEffect effect;
       public static Level level;
       public static GUI gui;
       public static Player player;

       public override void Init()
       {
           Basic.game.IsMouseVisible = false;
           player = new Player();
           camera = new Camera();
           effect = new BasicEffect(Basic.gDevice);
           level = new Level(1);
           gui = new GUI();
       }

       public override void Update()
       {
           level.Update();
           camera.Update();
           player.Update();
           gui.Update();
       }

       public override void Render()
       {
           level.Render();

           //Ambience
           Basic.spriteBatch.Draw(Textures.blankTex, new Rectangle(0, 0, Basic.gDevice.Viewport.Width, Basic.gDevice.Viewport.Height), new Color(0, 0, 0, 20));
       
           gui.Render();

       }
    }
}
