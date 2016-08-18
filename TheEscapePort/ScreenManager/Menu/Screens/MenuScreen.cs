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
    class MenuScreen: Screen
    {
        List<MenuElement> elements = new List<MenuElement>();
        MenuBackground background;
        MenuButton startgame;
        MenuButton endgame;
        MenuButton options;
        MenuSprite logo;

        MenuLabel version;

        public override void Init()
        {
            Basic.game.IsMouseVisible = true;

            //BACKGROUND
            background = new MenuBackground(Textures.bg);
            background.Layer = 1;
            elements.Add(background);

            //LOGO
            logo = new MenuSprite(new Vector2(0, 0), Textures.logo);
            logo.Width = Basic.gDevice.Viewport.Width / 2;
            logo.Height = (int)(logo.Width / (logo.Texture.Width / logo.Texture.Height));
            logo.Position = new Vector2(Basic.gDevice.Viewport.Width / 2 - logo.Width / 2, Basic.gDevice.Viewport.Height / 10);
            logo.ColorMultiplier = new Color(255, 255, 255, 200);
            logo.Layer = 2;
            elements.Add(logo);

            //START GAME
            startgame = new MenuButton(new Vector2(Basic.gDevice.Viewport.Width / 2, Basic.gDevice.Viewport.Height / 2), "New Game");
            startgame.Position = new Vector2(Basic.gDevice.Viewport.Width / 2 - startgame.Width / 2, Basic.gDevice.Viewport.Height / 10 * 5);
            startgame.ColorMultiplier = new Color(50, 0, 0, 200);
            startgame.Layer = 3;
            startgame.Handler += onClick_startGame;
            elements.Add(startgame);

            //OPTIONS
            options = new MenuButton(new Vector2(0, 0), "Options");
            options.Position = new Vector2(Basic.gDevice.Viewport.Width / 2 - startgame.Width / 2, Basic.gDevice.Viewport.Height / 10 * 6);
            options.Layer = 4;
            options.Handler += onClick_options;
            elements.Add(options);

            //END GAME
            endgame = new MenuButton(new Vector2(0), "End Game");
            endgame.Position = new Vector2(Basic.gDevice.Viewport.Width / 2 - startgame.Width / 2, Basic.gDevice.Viewport.Height / 10 * 7);
            endgame.ColorMultiplier = new Color(50, 0, 0, 200);
            endgame.Layer = 5;
            endgame.Handler += onClick_endGame;
            elements.Add(endgame);

            //VERSION
            version = new MenuLabel(new Vector2(0, 0), "Alpha 0.3", MenuLabel.LabelMode.LABEL);
            version.Layer = 6;
            elements.Add(version);
        }

        public override void Update()
        {
            UpdateResolution();

            elements.Sort();
            foreach (MenuElement e in elements)
            {
                try {
                    e.Update();
                }
                catch { }
            }
        }

        public override void Render()
        {
            Basic.gDevice.Clear(Color.Black);

            foreach (MenuElement e in elements)
            {
                try
                {
                    e.Render();
                }
                catch { }
            }
        }

        public void onClick_startGame(Object sender, EventArgs e)
        {
            Basic.setScreen(new GameScreen());
            GameScreen.gui.screenBlack.startFade(0, true);
			GameScreen.gui.bloodyScreen.clear();
        }

        public void onClick_endGame(Object sender, EventArgs e)
        {
            Basic.game.Exit();
        }

        public void onClick_options(Object sender, EventArgs e)
        {
            Basic.setScreen(new OptionsScreen());
            //this.elements.Clear();
        }

        public void UpdateResolution()
        {
            //LOGO
            logo.Width = Basic.gDevice.Viewport.Width / 2;
            logo.Height = (int)(logo.Width / (logo.Texture.Width / logo.Texture.Height));
            logo.Position = new Vector2(Basic.gDevice.Viewport.Width / 2 - logo.Width / 2, Basic.gDevice.Viewport.Height / 10);
            
            //START GAME
            startgame.Position = new Vector2(Basic.gDevice.Viewport.Width / 2 - startgame.Width / 2, Basic.gDevice.Viewport.Height / 10 * 5);

            //OPTIONS
            options.Position = new Vector2(Basic.gDevice.Viewport.Width / 2 - startgame.Width / 2, Basic.gDevice.Viewport.Height / 10 * 6);
            
            //END GAME
            endgame.Position = new Vector2(Basic.gDevice.Viewport.Width / 2 - startgame.Width / 2, Basic.gDevice.Viewport.Height / 10 * 7);
        }
    }
}
