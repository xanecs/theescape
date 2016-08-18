using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheEscape
{
    class NullBlock: Entity
    {
        public NullBlock(float x, float y, float z)
            : base(x, y, z)
        {
            BoundingBoxScale = new Microsoft.Xna.Framework.Vector3(1, 1, 1);
        }
    }
}
