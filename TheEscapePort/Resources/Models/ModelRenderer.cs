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
    class ModelRenderer
    {
        public static void Render(Model m, Matrix world)
        {
            
            Matrix projection = GameScreen.camera.projection;
            Matrix view = GameScreen.camera.view;

            foreach (ModelMesh mesh in m.Meshes)
            {
                foreach (ModelMeshPart part in mesh.MeshParts)
                {
                    BasicEffect e = (BasicEffect)part.Effect;
                    e.World = world;
                    e.View = view;
                    e.Projection = projection;
                    e.EnableDefaultLighting();
                    foreach (EffectPass pass in e.CurrentTechnique.Passes)
                        pass.Apply();
                } 

                mesh.Draw();
            }
        }

    }
}
