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
    class DoorBlock: Entity
    {
        bool pressed = false;
        public bool locked = false;
        BoundingBox MouseBox;
        Vector3 MouseBoxScale;

        public DoorBlock(float x, float y, float z)
            :base(x, y, z)
        {
            //DrawBoundingBox = true;
            MouseBox = new BoundingBox(new Vector3(-1f), new Vector3(1f));
            MouseBoxScale = new Vector3(0.45f, 1f, 1f);
        }

        public override void Update()
        {
            if (CameraDistance <= 10f){
                Nullable<float> result = MouseBox.Intersects(GameScreen.camera.createRay());
                if (result.HasValue && result.Value < 2.0f && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    if (!locked && enabled && !pressed)
                    {
                        GameScreen.gui.screenBlack.startFade(GameScreen.level.level);
                        pressed = true;
                    }
                    if (locked && enabled)
                    {
                        if (GameScreen.player.keys > 0)
                        {
                            Sounds.Door.unlockInstance.Play();
                            GameScreen.player.keys--;
                            locked = false;
                        }
                        else
                        {
                            Sounds.Door.lockedInstance.Play();
                            GameScreen.gui.subtitle.AddSubtitle("It's locked!", 2f);
                        }
                    }
                    if (!enabled)
                    {
                        GameScreen.gui.subtitle.AddSubtitle("I wont go back!", 2f);
                    }
                }
                
            }

            base.Update();
        }

        public override void Render()
        {
            GameScreen.effect.TextureEnabled = true;
            GameScreen.effect.Texture = Textures.door;

            MouseBox = new BoundingBox(Vector3.Transform(new Vector3(-0.5f), Matrix.CreateScale(MouseBoxScale) * Matrix.CreateRotationY(rotation.Y) * Matrix.CreateTranslation(position)), Vector3.Transform(new Vector3(0.5f), Matrix.CreateScale(MouseBoxScale) * Matrix.CreateRotationY(rotation.Y) * Matrix.CreateTranslation(position)));

            Draw(TriangleModel.blockModel);
        }

    }
}
