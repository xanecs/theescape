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
    class GUI
    {
        public GuiPicture cross;
        public Bar endurance;
        public fade screenBlack;
        public GuiKey KeyDisplay;
		public BloodyScreen bloodyScreen;

        public List<GUIElement> elements = new List<GUIElement>();
        public Subtitle subtitle;

        public GUI()
        {
            endurance = new Bar(new Vector2(0,0), Textures.bar_alpha, Basic.gDevice.Viewport.Width / 4 - 20, Basic.gDevice.Viewport.Width / 40, 2, Color.Green);
            cross = new GuiPicture(new Vector2(0, 0), Textures.aim_cross);
            screenBlack = new fade(Color.Black, 0.05f);
            subtitle = new Subtitle("");
            KeyDisplay = new GuiKey();
			bloodyScreen = new BloodyScreen();

            elements.Add(screenBlack);
            elements.Add(KeyDisplay);
            elements.Add(endurance);
            elements.Add(subtitle);
            elements.Add(cross);
			elements.Add(bloodyScreen);
        }

        public void Update()
        {
            int endurancevalue = Convert.ToInt32(((GameScreen.player.endurance / 10) * 100));
            endurance.value = endurancevalue;
            endurance.max_lenghth = Basic.gDevice.Viewport.Width / 4 - 20;
            endurance.height = Basic.gDevice.Viewport.Height / 25;


            foreach (GUIElement element in elements)
            {
                try
                {
                    element.Update();
                }
                catch { }
            }

        }

        public void Render()
        {
            foreach (GUIElement element in elements)
            {
                try
                {
                    element.Render();
                }
                catch { }
            }
        }
    }
}
