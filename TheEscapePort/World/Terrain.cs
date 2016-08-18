using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TheEscape
{
    class Terrain
    {
        Random random;
        Int16 terrainWidth;
        Int16 terrainLength;

        Int16[] indices;
        VertexPositionNormalTexture[] vertices;

        public Terrain(Int16 width, Int16 height, int seed)
        {
            this.terrainWidth = width;
            this.terrainLength = height;

            this.random = new Random(seed);

            vertices = SetUpTerrainVertices();
            SetUpIndex();
        }

        private VertexPositionNormalTexture[] SetUpTerrainVertices()
        {
            VertexPositionNormalTexture[] terrainVertices = new VertexPositionNormalTexture[terrainWidth * terrainLength];

            for (int x = 0; x < terrainWidth; x++)
            {
                for (int y = 0; y < terrainLength; y++)
                {
                    terrainVertices[x + y * terrainWidth] = new VertexPositionNormalTexture();
                    terrainVertices[x + y * terrainWidth].Position = new Vector3(x, (float)random.NextDouble() * 0.01f, -y);
                    terrainVertices[x + y * terrainWidth].Normal = Vector3.Up;
                    terrainVertices[x + y * terrainWidth].TextureCoordinate.X = (float)x / 30.0f;
                    terrainVertices[x + y * terrainWidth].TextureCoordinate.Y = (float)y / 30.0f;
                }
            }

            return terrainVertices;
        }

        private void SetUpIndex()
        {
            indices = new Int16[(terrainWidth - 1) * (terrainLength - 1) * 3];
            Int16 counter = 0;
            for (Int16 y = 0; y < terrainLength - 1; y++)
            {
                for (Int16 x = 0; x < terrainWidth - 1; x++)
                {
                    Int16 lowerLeft = (Int16)(x + y * terrainWidth);
                    Int16 lowerRight = (Int16)((x + 1) + y * terrainWidth);
                    Int16 topLeft = (Int16)(x + (y + 1) * terrainWidth);
                    Int16 topRight = (Int16)((x + 1) + (y + 1) * terrainWidth);

                    indices[counter++] = topLeft;
                    indices[counter++] = lowerRight;
                    indices[counter++] = lowerLeft;
                }
            }
        }

        public void Render()
        {
            GameScreen.effect.EnableDefaultLighting();
            GameScreen.effect.TextureEnabled = true;
            GameScreen.effect.Texture = Textures.water;
            Basic.gDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, vertices, 0, vertices.Length, indices, 0, indices.Length / 3, VertexPositionColor.VertexDeclaration);
        }
    }
}
