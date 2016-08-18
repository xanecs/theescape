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
    class BlockModel: TriangleModel
    {
        public BlockModel()
        {
            //front side
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(-0.5f, -0.5f, 0.5f), new Vector3(0, 0, 1), new Vector2(0.0f, 1.0f)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(-0.5f, 0.5f, 0.5f), new Vector3(0, 0, 1), new Vector2(0.0f, 0.0f)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(0.5f, -0.5f, 0.5f), new Vector3(0, 0, 1), new Vector2(1.0f, 1.0f)));

            vertexData.Add(new VertexPositionNormalTexture(new Vector3(0.5f, -0.5f, 0.5f), new Vector3(0, 0, 1), new Vector2(1.0f, 1.0f)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(-0.5f, 0.5f, 0.5f), new Vector3(0, 0, 1), new Vector2(0.0f, 0.0f)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(0.5f, 0.5f, 0.5f), new Vector3(0, 0, 1), new Vector2(1.0f, 0.0f)));

            //right side
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(0.5f, -0.5f, 0.5f), new Vector3(1, 0, 0), new Vector2(0.0f, 1.0f)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(0.5f, 0.5f, 0.5f), new Vector3(1, 0, 0), new Vector2(0.0f, 0.0f)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(0.5f, -0.5f, -0.5f), new Vector3(1, 0, 0), new Vector2(1.0f, 1.0f)));

            vertexData.Add(new VertexPositionNormalTexture(new Vector3(0.5f, -0.5f, -0.5f), new Vector3(1, 0, 0), new Vector2(1.0f, 1.0f)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(0.5f, 0.5f, 0.5f), new Vector3(1, 0, 0), new Vector2(0.0f, 0.0f)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(0.5f, 0.5f, -0.5f), new Vector3(1, 0, 0), new Vector2(1.0f, 0.0f)));

            //left side

            vertexData.Add(new VertexPositionNormalTexture(new Vector3(-0.5f, 0.5f, 0.5f), new Vector3(-1, 0, 0), new Vector2(1.0f, 0.0f)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(-0.5f, -0.5f, 0.5f), new Vector3(-1, 0, 0), new Vector2(1.0f, 1.0f)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(-0.5f, -0.5f, -0.5f), new Vector3(-1, 0, 0), new Vector2(0.0f, 1.0f)));

            vertexData.Add(new VertexPositionNormalTexture(new Vector3(-0.5f, -0.5f, -0.5f), new Vector3(-1, 0, 0), new Vector2(0.0f, 1.0f)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(-0.5f, 0.5f, -0.5f), new Vector3(-1, 0, 0), new Vector2(0.0f, 0.0f)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(-0.5f, 0.5f, 0.5f), new Vector3(-1, 0, 0), new Vector2(1.0f, 0.0f)));

            // back side

            vertexData.Add(new VertexPositionNormalTexture(new Vector3(-0.5f, 0.5f, -0.5f), new Vector3(0, 0, -1), new Vector2(1.0f, 0.0f)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(-0.5f, -0.5f, -0.5f), new Vector3(0, 0, -1), new Vector2(1.0f, 1.0f)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(0.5f, -0.5f, -0.5f), new Vector3(0, 0, -1), new Vector2(0.0f, 1.0f)));

            vertexData.Add(new VertexPositionNormalTexture(new Vector3(0.5f, -0.5f, -0.5f), new Vector3(0, 0, -1), new Vector2(0.0f, 1.0f)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(0.5f, 0.5f, -0.5f), new Vector3(0, 0, -1), new Vector2(0.0f, 0.0f)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(-0.5f, 0.5f, -0.5f), new Vector3(0, 0, -1), new Vector2(1.0f, 0.0f)));

            SetUp();
        }
    }
}
