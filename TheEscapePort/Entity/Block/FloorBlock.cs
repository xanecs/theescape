using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheEscape
{
    class FloorBlock:Entity
    {
        public FloorBlock(float x, float y, float z)
            : base(x, y, z)
        {
            
        }

        public override void Render()
        {
            GameScreen.effect.TextureEnabled = true;
            GameScreen.effect.Texture = Textures.floor;
            Draw(TriangleModel.blockModel);
        }
    }
}
