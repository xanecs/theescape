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
    class LevelManager
    {
        public int level;

        public LevelManager(int _level)
        {
            level = _level;
        }

        public Color getWallColor()
        {
            if (level == 1)
                return Color.White;
            else
                return Color.White;
        }

        public Color getWallBloodColor()
        {
            if (level == 1)
                return Color.White;
            else
                return Color.White;
        }

        public Color getKnifeColor()
        {
            if (level == 1)
                return Color.White;
            else
                return Color.White;
        }

        public Color getGridColor()
        {
            if (level == 1)
                return Color.White;
            else
                return Color.White;
        }

        #region entities



        #endregion

        #region envirement

        public Color getFloorColor()
        {
            if (level == 1)
                return Color.White;
            else
                return Color.White;
        }

        public Color getCeilingColor()
        {
            if (level == 1)
                return Color.White;
            else
                return Color.White;
        }

        public bool hasCeiling = true;

        #endregion
    }
}
