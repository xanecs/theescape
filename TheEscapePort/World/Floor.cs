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
    class Floor
    {
        int level, width, height;
        Texture2D texture;

        Color[,] colorData;
        public enum FloorType { NORMAL, WATER };
        public FloorType[,] Floortypes;

        List<VertexPositionNormalTexture> WaterVertexList = new List<VertexPositionNormalTexture>();

        public Floor(Level level, int _width, int _height)
        {
            width = _width;
            height = _height;
            this.level = level.level;

            texture = Basic.content.Load<Texture2D>("Levels\\Level" + this.level + "_floor");
            colorData = TextureToColor(texture);

            Floortypes = new FloorType[_width, _height];

            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < height; z++)
                {
                    if (colorData[x, z] == Color.Blue)
                    {
                        Floortypes[x, z] = FloorType.WATER;
                        NullBlock b = new NullBlock(x, -1f, z);
                        b.isDeadly = true;
                        level.entities.Add(b);
                    }
                    else if (colorData[x, z] == Color.Black)
                    {
                        Floortypes[x, z] = FloorType.NORMAL;
                        level.entities.Add(new FloorBlock(x, -1f, z));
                        level.entities.Add(new NullBlock(x, -0.5f, z));
                    }
                    else
                    {
                        Floortypes[x, z] = FloorType.NORMAL;
                        level.entities.Add(new NullBlock(x, -0.5f, z));
                    }
                }
            }
                texture = null;
        }

        public void Render()
        {

            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < height; z++)
                {
                    GameScreen.effect.TextureEnabled = true;

                    if (Floortypes[x, z] == FloorType.WATER)
                    {
                        GameScreen.effect.Texture = Textures.water;
                        TriangleModel.waterModel.Draw(Matrix.CreateTranslation(x, -0.2f - (0.01f * (float)Math.Sin(Basic.gameTime.TotalGameTime.TotalMilliseconds * 0.001f)), z));
                    }

                    if (Floortypes[x, z] == FloorType.NORMAL)
                    {
                        GameScreen.effect.Texture = Textures.floor;
                        TriangleModel.floorModel.Draw(Matrix.CreateTranslation(x, 0, z));
                    }
                }
            }
        }

        public Color[,] TextureToColor(Texture2D tex)
        {
            Color[] col1d = new Color[tex.Width * tex.Height];
            tex.GetData(col1d);

            Color[,] data = new Color[tex.Width, tex.Height];
            for (int i = 0; i < tex.Width; i++)
            {
                for (int j = 0; j < tex.Height; j++)
                {
                    data[i, j] = col1d[i + j * tex.Width];
                }
            }
            return data;
        }
    }
}
