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
    class GridBlock: Entity
    {
        RasterizerState rs;
        RasterizerState old_rs;

        bool snd = true;
        bool orientated = false;

        public GridBlock(float x, float y, float z)
            : base(x, y, z)
        {
            rs = RasterizerState.CullNone;
            BoundingBoxScale = new Vector3(1f, 1f, 0.3f);


           // DrawBoundingBox = true;
        }

        public override void Update()
        {
            if (GameScreen.level.getEntity(position.X, 0, position.Z + 1) is Entity && GameScreen.level.getEntity(position.X, 0, position.Z - 1) is Entity)
            {
                rotation.Y = MathHelper.PiOver2;
                BoundingBoxScale = new Vector3(0.3f, 1f, 1f);
                box = new BoundingBox(Vector3.Transform(new Vector3(-0.5f), Matrix.CreateScale(BoundingBoxScale) * Matrix.CreateRotationY(rotation.Y) * Matrix.CreateTranslation(position)), Vector3.Transform(new Vector3(0.5f), Matrix.CreateScale(BoundingBoxScale) * Matrix.CreateRotationY(rotation.Y) * Matrix.CreateTranslation(position)));
            }

            if (CameraDistance <= 10f)
            {
                Nullable<float> result = box.Intersects(GameScreen.camera.createRay());
                if (result.HasValue && result.Value < 2.0f)
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        destroyed = true;
                    }

                    else
                    { destroyed = false; snd = true; }
                }

                if (enabled && destroyed && snd)
                {
                    Sounds.PlaySound(Sounds.scratchInstance);
                    snd = false;
                }

                if (enabled && destroyed && position.Y >= 0.8f)
                {
                    position.Y = 0.8f;
                    destroyed = false;
                    snd = false;
                    enabled = false;
                }

                if (enabled && destroyed && position.Y <= 1f)
                {
                    position.Y += 0.4f * (float)Basic.gameTime.ElapsedGameTime.TotalSeconds;
                    //snd = true;
                }
                if (enabled && !destroyed && position.Y > 0f)
                {
                    position.Y -= 0.4f * (float)Basic.gameTime.ElapsedGameTime.TotalSeconds;
                    //snd = true;
                }

                box = new BoundingBox(Vector3.Transform(new Vector3(-0.5f), Matrix.CreateScale(BoundingBoxScale) * Matrix.CreateRotationY(rotation.Y) * Matrix.CreateTranslation(position)), Vector3.Transform(new Vector3(0.5f), Matrix.CreateScale(BoundingBoxScale) * Matrix.CreateRotationY(rotation.Y) * Matrix.CreateTranslation(position)));
            }

            base.Update();
        }

        public override void Render()
        {
            old_rs = Basic.gDevice.RasterizerState;
            Basic.gDevice.RasterizerState = rs;

            //GameScreen.mainEffect.Parameters["tex"].SetValue(Textures.grid);
            //GameScreen.mainEffect.Parameters["ambient"].SetValue(Level.mapColors.GridColor.ToVector4());

            box = new BoundingBox(Vector3.Transform(new Vector3(-0.5f), Matrix.CreateScale(BoundingBoxScale) * Matrix.CreateRotationY(rotation.Y) * Matrix.CreateTranslation(position)), Vector3.Transform(new Vector3(0.5f), Matrix.CreateScale(BoundingBoxScale) * Matrix.CreateRotationY(rotation.Y) * Matrix.CreateTranslation(position)));

            GameScreen.effect.TextureEnabled = true;
            GameScreen.effect.Texture = Textures.grid;

            Draw(TriangleModel.spriteModel);
            //Draw(RenderModels.grid);
            base.Render();

            Basic.gDevice.RasterizerState = old_rs;
        }
    }
}
