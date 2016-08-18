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
    class Key: Entity
    {
        RasterizerState rs;
        RasterizerState old_rs;

        float tempf;

        public Key(float x, float y, float z) 
            :base(x, y, z)
        {
            collision = false;
            DrawBoundingBox = false;

            scale = new Vector3(0.0005f);
            rotation.X = MathHelper.ToRadians(60f);
            BoundingBoxScale = new Vector3(1f);

            DrawBoundingBox = false;

            rs = RasterizerState.CullNone;
        }

        public override void Update()
        {
            if (CameraDistance <= 10f)
            {
                rotation.Y += 0.4f * (float)Basic.gameTime.ElapsedGameTime.TotalSeconds;
                tempf += 1.5f * (float)Basic.gameTime.ElapsedGameTime.TotalSeconds;
                if (tempf >= 36.0f)
                    tempf = 0;
                position.Y = ((float)Math.Sin(tempf) * 0.1f) - 0.2f;


                box = new BoundingBox(Vector3.Transform(new Vector3(-0.5f), Matrix.CreateScale(BoundingBoxScale) * Matrix.CreateTranslation(position)), Vector3.Transform(new Vector3(0.5f), Matrix.CreateScale(BoundingBoxScale) * Matrix.CreateTranslation(position)));

                if (box.Contains(GameScreen.player.position) == ContainmentType.Contains)
                {
                    this.enabled = false;
                    GameScreen.player.keys++;
                    GameScreen.level.entities.Remove(this);
                }
            }
            base.Update();

        }

        public override void Render()
        {
            old_rs = Basic.gDevice.RasterizerState;
            Basic.gDevice.RasterizerState = rs;

            //GameScreen.mainEffect.Parameters["tex"].SetValue(Textures.weapon_knife);
            //GameScreen.mainEffect.Parameters["ambient"].SetValue(Level.mapColors.KnifeColor.ToVector4());
            //GameScreen.effect.TextureEnabled = true;
            //GameScreen.effect.Texture = Textures.weapon_knife;

            if (enabled)
                Draw(RenderModels.key);
            base.Render();

            Basic.gDevice.RasterizerState = old_rs;
        }
    }
}
