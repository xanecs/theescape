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
    class TriangleModel
    {
        public List<VertexPositionNormalTexture> vertexData = new List<VertexPositionNormalTexture>();
        public VertexBuffer vertexBuffer;

        public static Boolean isDirectionalLightning = false;

        public void SetUp()
        {
            vertexBuffer = new VertexBuffer(Basic.gDevice, typeof(VertexPositionNormalTexture), vertexData.Count, BufferUsage.WriteOnly);
            vertexBuffer.SetData(vertexData.ToArray());
        }

        public static void DrawTriangles(List<VertexPositionNormalTexture> _vertexData)
        {
            if (_vertexData == null)
                return;

            VertexBuffer _vertexBuffer = new VertexBuffer(Basic.gDevice, typeof(VertexPositionNormalTexture), _vertexData.Count, BufferUsage.WriteOnly);
            _vertexBuffer.SetData(_vertexData.ToArray());

            GameScreen.effect.View = GameScreen.camera.view;
            GameScreen.effect.Projection = GameScreen.camera.projection;
            GameScreen.effect.World = Matrix.Identity;
            GameScreen.effect.EnableDefaultLighting();

            GameScreen.effect.FogEnabled = true;
            GameScreen.effect.FogStart = 2;
            GameScreen.effect.FogEnd = 10;
            GameScreen.effect.FogColor = new Vector3(0, 0, 0);

            foreach (EffectPass pass in GameScreen.effect.CurrentTechnique.Passes)
                pass.Apply();

            Basic.gDevice.SetVertexBuffer(_vertexBuffer);
            Basic.gDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, _vertexBuffer.VertexCount / 3);
        }

        public void Draw(Matrix world)
        {
            GameScreen.effect.View = GameScreen.camera.view;
            GameScreen.effect.Projection = GameScreen.camera.projection;
            GameScreen.effect.World = world;

            //Light
            if (isDirectionalLightning)
            {
                if (Mouse.GetState().RightButton == ButtonState.Pressed)
                {
                    GameScreen.effect.EmissiveColor = new Vector3(0.3f);
                    FlashLight();
                }
                else
                {
                    GameScreen.effect.EmissiveColor = new Vector3(0.9f);
                    ConfigureLight0();
                }
            }
            else
                GameScreen.effect.EnableDefaultLighting();

            GameScreen.effect.FogEnabled = true;
            GameScreen.effect.FogStart = 2;
            GameScreen.effect.FogEnd = 10;
            GameScreen.effect.FogColor = new Vector3(0, 0, 0);

            foreach (EffectPass pass in GameScreen.effect.CurrentTechnique.Passes)
                pass.Apply();

            Basic.gDevice.SetVertexBuffer(vertexBuffer);
            Basic.gDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, vertexBuffer.VertexCount / 3);
        }

        private Vector3 CameraDirection()
        {
            int centerX = Basic.windowSize.Width / 2;
            int centerY = Basic.windowSize.Height / 2;

            Vector3 nearSource = new Vector3(centerX, centerY, 0);
            Vector3 farSource = new Vector3(centerX, centerY, 1);

            Vector3 nearPoint = Basic.gDevice.Viewport.Unproject(nearSource, GameScreen.camera.projection, GameScreen.camera.view, Matrix.Identity);
            Vector3 farPoint = Basic.gDevice.Viewport.Unproject(farSource, GameScreen.camera.projection, GameScreen.camera.view, Matrix.Identity);

            Vector3 direction = farPoint - nearPoint;
            direction.Normalize();
            return direction;
        }

        private void ConfigureLight0()
        {
            GameScreen.effect.LightingEnabled = true;
            GameScreen.effect.DirectionalLight0.Enabled = true;
            GameScreen.effect.DirectionalLight0.Direction = CameraDirection();
            GameScreen.effect.DirectionalLight0.Direction.Normalize();
            GameScreen.effect.DirectionalLight0.DiffuseColor = new Vector3(0.3f);
            GameScreen.effect.DirectionalLight0.SpecularColor = new Vector3(1.0f);
        }

        private void FlashLight()
        {
            GameScreen.effect.LightingEnabled = true;
            GameScreen.effect.DirectionalLight0.Enabled = true;
            GameScreen.effect.DirectionalLight0.Direction = CameraDirection();
            GameScreen.effect.DirectionalLight0.DiffuseColor = new Vector3(0.1f);
            GameScreen.effect.DirectionalLight0.SpecularColor = new Vector3(0.5f);
        }
        
        public static TriangleModel blockModel = new BlockModel();
        public static TriangleModel floorModel = new FloorFace();
        public static TriangleModel spriteModel = new SpriteFace();
        public static TriangleModel waterModel = new WaterFace();
    }
}
