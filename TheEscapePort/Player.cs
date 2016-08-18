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
    public class Player
    {
        public  float endurance = 10.0f;
        public Vector3 position = new Vector3(0);
        public bool run = false;
        public bool walk = false;
        public float speed = 0.04f;
        public float currspeed;
        public float run_multiplier = 1.5f;
        public float rotationSpeed = 0.004f;

        public float health = 5;

        //INVENTORY
        public int keys;

        public Player()
        {
            endurance = 10.0f;
            run = false;
            walk = false;
            speed = 0.04f;
            run_multiplier = 1.5f;
            rotationSpeed = 0.004f;

            health = 5;
            keys = 0;
        }

        public void runsound(bool active)
        {
            if (active == true)
            {
                if (run == false)
                {
                    Sounds.PlaySound(Sounds.stepSoundRunnningInstance);
                    run = true;
                }
            }
            else
            {
                Sounds.StopSound(Sounds.stepSoundRunnningInstance);
                run = false;
            }
        }
        public void walksound(bool active)
        {
            if (active == true)
            {
                if (walk == false)
                {
                    Sounds.PlaySound(Sounds.stepSoundWalkingInstance);
                    walk = true;
                }
            }
            else
            {
                Sounds.StopSound(Sounds.stepSoundWalkingInstance);
                walk = false;
            }
        }
        public void running(bool active)
        {
            if (active == true)
            {
                GameScreen.camera.projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(50f), Basic.gDevice.Viewport.AspectRatio, 0.1f, 1000f);
                speed = currspeed * run_multiplier;
                endurance -= 2f * (float)Basic.gameTime.ElapsedGameTime.TotalSeconds;
                runsound(true);
				walksound(false);
            }
            else
            {
                GameScreen.camera.projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45f), Basic.gDevice.Viewport.AspectRatio, 0.1f, 1000f);
                speed = currspeed;
                runsound(false);
            }
        }

        public void Update()
        {
            if (health <= 0)
                Basic.setScreen(new MenuScreen());
        }

        public void Damage(int dmg)
        {
            health -= dmg;
            if (health <= 0)
                health = 0;
            BloodyScreen.isActive = true;
        }
    }

}
