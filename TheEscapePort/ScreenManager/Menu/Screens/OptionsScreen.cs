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
    class OptionsScreen: Screen
    {
        public List<MenuElement> elements = new List<MenuElement>();
        public MenuBackground background;
        public MenuComboBox resolution;
        public MenuLabel resolutionlabel;
        public MenuCheckBox fullscreen;
        public MenuBox backgroundbox;
        public MenuButton buttonapply;

        public override void Init()
        {
            Basic.game.IsMouseVisible = true;

            //BACKGROUND
            background = new MenuBackground(Textures.bg);
            background.Layer = 0;
            elements.Add(background);

            //RESOLUTION
            resolution = new MenuComboBox(new Vector2(Basic.gDevice.Viewport.Width / 2, Basic.gDevice.Viewport.Height / 20 * 4), "Resolution: ");
            resolution.Items.Add("840x480 (16:9)");
            resolution.Items.Add("1024x768 (4:3)");
            resolution.Items.Add("1280x720 (16:9)");
            resolution.Items.Add("1280x800 (16:10)");
            resolution.Items.Add("1920x1080 (16:9)");
            resolution.Layer = 3;
            elements.Add(resolution);

            resolutionlabel = new MenuLabel(new Vector2(Basic.gDevice.Viewport.Width / 4, Basic.gDevice.Viewport.Height / 20 * 4), "Resolution: ", MenuLabel.LabelMode.LABEL);
            resolutionlabel.Position = new Vector2(Basic.gDevice.Viewport.Width / 3, Basic.gDevice.Viewport.Height / 20 * 4 + resolution.Height / 2 - Basic.subtitleFont.MeasureString("Resolution: ").Y / 2);
            resolutionlabel.Font = Basic.subtitleFont;
            resolutionlabel.Layer = 2;
            elements.Add(resolutionlabel);

            //FULLSCREEN
            fullscreen = new MenuCheckBox(new Vector2(0, 0), "Fullscreen");
            fullscreen.Position = new Vector2(Basic.gDevice.Viewport.Width / 2, Basic.gDevice.Viewport.Height / 20 * 6);
            fullscreen.isChecked = Basic.gManager.IsFullScreen;
            fullscreen.Layer = 2;
            elements.Add(fullscreen);

            //BOX
            backgroundbox = new MenuBox(new Rectangle(Basic.gDevice.Viewport.Width / 6, Basic.gDevice.Viewport.Height / 6, Basic.gDevice.Viewport.Width / 6 * 4, Basic.gDevice.Viewport.Height / 6 * 4), new Color(0, 0, 0, 128));
            backgroundbox.Layer = 1;
            elements.Add(backgroundbox);

            //APPLY
            buttonapply = new MenuButton(new Vector2(0, 0), "Apply");
            buttonapply.Position = new Vector2(Basic.gDevice.Viewport.Width / 3 - buttonapply.Width / 2, Basic.gDevice.Viewport.Height / 20 * 15 - buttonapply.Height / 2);
            buttonapply.Handler += onApply;
            buttonapply.Layer = 2;
            elements.Add(buttonapply);

            //CANCEL
            buttonapply = new MenuButton(new Vector2(0, 0), "Cancel");
            buttonapply.Position = new Vector2(Basic.gDevice.Viewport.Width / 3 * 2 - buttonapply.Width / 2, Basic.gDevice.Viewport.Height / 20 * 15 - buttonapply.Height / 2);
            buttonapply.Handler += onCancel;
            buttonapply.Layer = 2;
            elements.Add(buttonapply);
        }

        public override void Update()
        {
            elements.Sort();
            foreach (MenuElement e in elements) { try { e.Update(); } catch { } }
        }

        public override void Render()
        {
            Basic.gDevice.Clear(Color.CornflowerBlue);
            foreach (MenuElement e in elements) { try { e.Render(); } catch { } }
        }

        private void onApply(object sender, EventArgs e)
        {
            //APPLY
            Basic.gManager.IsFullScreen = fullscreen.isChecked;

            switch (resolution.selectedItem)
            {
                case "1920x1080 (16:9)":
                    Basic.gManager.PreferredBackBufferHeight = 1080;
                    Basic.gManager.PreferredBackBufferWidth = 1920;
                    break;

                case "1024x768 (4:3)":
                    Basic.gManager.PreferredBackBufferHeight = 768;
                    Basic.gManager.PreferredBackBufferWidth = 1024;
                    break;

                case "1280x720 (16:9)":
                    Basic.gManager.PreferredBackBufferHeight = 720;
                    Basic.gManager.PreferredBackBufferWidth = 1280;
                    break;

                case "1280x800 (16:10)":
                    Basic.gManager.PreferredBackBufferHeight = 800;
                    Basic.gManager.PreferredBackBufferWidth = 1280;
                    break;

                case "840x480 (16:9)":
                    Basic.gManager.PreferredBackBufferHeight = 480;
                    Basic.gManager.PreferredBackBufferWidth = 840;
                    break;
            }
            Basic.gManager.ApplyChanges();

            Basic.windowSize = new Rectangle(0, 0, Basic.gManager.PreferredBackBufferWidth, Basic.gManager.PreferredBackBufferHeight);

            Basic.setScreen(new MenuScreen());
        }

        private void onCancel(object sender, EventArgs e)
        {
            //CANCEL
            Basic.setScreen(new MenuScreen());
        }
    }
}
