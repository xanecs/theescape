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
    class Ceiling
    {
        int width, height;

        RasterizerState rs;
        RasterizerState old_rs;

        public Ceiling(int _width, int _height)
        {
            width = _width;
            height = _height;

            rs = new RasterizerState();
            rs.CullMode = CullMode.None;
        }

        public void Render()
        {
            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < height; z++)
                {
                    old_rs = Basic.gDevice.RasterizerState;

                    Basic.gDevice.RasterizerState = rs;

                    //GameScreen.mainEffect.Parameters["tex"].SetValue(Textures.ceiling);
                    ////GameScreen.mainEffect.Parameters["ambient"].SetValue(Level.mapColors.CeilingColor.ToVector4());
                    //Model.floorModel.Draw(Matrix.CreateTranslation(x, 1, z));

                    GameScreen.effect.TextureEnabled = true;
                    GameScreen.effect.Texture = Textures.ceiling;
                    TriangleModel.floorModel.Draw(Matrix.CreateTranslation(x, 1, z));
                    

                    Basic.gDevice.RasterizerState = old_rs;
                }
            }
        }
    }
}
