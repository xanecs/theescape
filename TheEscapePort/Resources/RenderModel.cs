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
    class RenderModels
    {
        public static Model key;

        public static void loadModels()
        {
            key = loadModel("key");
        }

        private static Model loadModel(string path)
        {
            return Basic.content.Load<Model>("Models\\" + path);
        }
    }
}
