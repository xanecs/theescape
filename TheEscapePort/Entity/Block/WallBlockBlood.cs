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
    class WallBlockBlood: Entity
    {
        Texture2D Texture;
        public static int index;

        public WallBlockBlood(float x, float y, float z)
            : base(x, y, z)
        {
            if (index >= Textures.bloodies.GetLength(0))
                index = 0;
            index++;
            Texture = Textures.bloodies[index - 1];
        }

        public override void Render()
        {
            //GameScreen.mainEffect.Parameters["tex"].SetValue(Texture);
            GameScreen.effect.TextureEnabled = true;
            GameScreen.effect.Texture = Texture;
            Draw(TriangleModel.blockModel);
        }
    }
}
