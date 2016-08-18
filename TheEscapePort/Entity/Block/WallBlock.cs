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
    class WallBlock: Entity
    {
        public WallBlock(float x, float y, float z)
            : base(x, y, z)
        {
            
        }

        public override void Render()
        {
            GameScreen.effect.TextureEnabled = true;
            GameScreen.effect.Texture = Textures.wall;
            Draw(TriangleModel.blockModel);
        }
    }
}
