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
    class Entity: IComparable
    {
        public Vector3 position;
        public Vector3 rotation = new Vector3(0);
        public Vector3 scale = new Vector3(1);

        public bool DrawBoundingBox = false;
        public bool collision = true;
        public bool enabled = true;

        public float CameraDistance;

        public bool isDeadly = false;
        public bool destroyed;

        public Vector3 BoundingBoxScale = new Vector3(1.4f);
        public BoundingBox box = new BoundingBox(new Vector3(-0.5f), new Vector3(0.5f));

        Matrix world;

        public Entity(float x, float y, float z)
        {
            position = new Vector3(x, y, z);
        }

        public virtual void Update() 
        {
            world = Matrix.CreateScale(scale) * Matrix.CreateFromYawPitchRoll(rotation.Y, rotation.X, rotation.Z) * Matrix.CreateTranslation(position);
            box = new BoundingBox(Vector3.Transform(new Vector3(-0.5f), Matrix.CreateScale(BoundingBoxScale) * Matrix.CreateTranslation(position)), Vector3.Transform(new Vector3(0.5f), Matrix.CreateScale(BoundingBoxScale) * Matrix.CreateTranslation(position)));

            
        }

        public void CalculateCameraDistance()
        {
            CameraDistance = Vector3.Distance(position, GameScreen.player.position);
        }

        public void Draw(TriangleModel model)
        {
            model.Draw(world);

            if (DrawBoundingBox)
                BoundingBoxRenderer.Render(box, Basic.gDevice, GameScreen.camera.view, GameScreen.camera.projection, Matrix.CreateScale(scale) * Matrix.CreateFromYawPitchRoll(rotation.Y, rotation.X, rotation.Z) * Matrix.CreateTranslation(position),  Color.Red);
        }

        public void Draw(Model model)
        {
            ModelRenderer.Render(model, world);

            if (DrawBoundingBox)
                BoundingBoxRenderer.Render(box, Basic.gDevice, GameScreen.camera.view, GameScreen.camera.projection, Matrix.CreateScale(scale) * Matrix.CreateFromYawPitchRoll(rotation.Y, rotation.X, rotation.Z) * Matrix.CreateTranslation(position), Color.Red);
        }

        public virtual void Render()
        {

        }

        public int CompareTo(object obj)
        {
            Entity e = (Entity)obj;

            return (int)((e.CameraDistance * 1000) - (this.CameraDistance * 1000));
        }
    }
}
