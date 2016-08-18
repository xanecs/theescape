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
    class DebugHelper
    {
        KeyboardState currstate;
        KeyboardState prevstate;
        KeyboardState kboard = Keyboard.GetState();
        public void Update()
        {
            if (Basic.debugMode)
            {
                currstate = Keyboard.GetState();
                if (KeypressTest(Keys.PageUp))
                {
                    Level.switchLevel();
                }

                if (KeypressTest(Keys.PageDown))
                    Level.switchLevel_back();

                if (KeypressTest(Keys.E))
                    GameScreen.player.endurance = 10.0f;

                if (KeypressTest(Keys.H))
                    GameScreen.player.health = 5;
                if (KeypressTest(Keys.V))
                    GameScreen.player.Damage(1);
                    

                prevstate = currstate;
                kboard = Keyboard.GetState();
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
