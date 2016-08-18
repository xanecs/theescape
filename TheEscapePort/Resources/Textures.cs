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
    class Textures
    {
        public static Texture2D[] bloodies;

        public static Texture2D floor;
        public static Texture2D wall;
        public static Texture2D door;
        public static Texture2D ceiling;
        public static Texture2D water;

        public static Texture2D aim_cross;
        public static Texture2D bar_alpha;
        public static Texture2D bar_border;
        public static Texture2D bloody_screen;

        public static Texture2D weapon_knife;
        public static Texture2D grid;
        public static Texture2D broken_grid;

        public static Texture2D key;

        public static Texture2D blankTex;

        //MENU
        public static Texture2D bg;
        public static Texture2D buttonbg;
        public static Texture2D logo;
        public static Texture2D comboBoxArrow;
        public static Texture2D checkBoxCross;

        public static void loadTextures()
        {
            floor = loadTex("Textures\\Blocks\\floor");
            wall = loadTex("Textures\\Blocks\\wall");
            door = loadTex("Textures\\Blocks\\door");
            water = loadTex("Textures\\Sprites\\water");

            ceiling = loadTex("Textures\\Blocks\\ceiling");

            aim_cross = loadTex("Gui\\cross");
            bar_alpha = loadTex("Gui\\Bars\\alpha");
            bar_border = loadTex("Gui\\Bars\\border");
            key = loadTex("Gui\\key");

            weapon_knife = loadTex("Textures\\Items\\knife");

            grid = loadTex("Textures\\Sprites\\grid");
            broken_grid = loadTex("Textures\\Sprites\\grid_broke");

            bloodies = new Texture2D[7];
            bloodies[0] = loadTex("Textures\\Blocks\\wall_blood");
            bloodies[1] = loadTex("Textures\\Blocks\\wall_blood2");
            bloodies[2] = loadTex("Textures\\Blocks\\wall_blood3");
            bloodies[3] = loadTex("Textures\\Blocks\\wall_blood4");
            bloodies[4] = loadTex("Textures\\Blocks\\wall_blood5");
            bloodies[5] = loadTex("Textures\\Blocks\\wall_blood6");
            bloodies[6] = loadTex("Textures\\Blocks\\wall_blood7");

            blankTex = loadTex("Gui\\blank");

            bloody_screen = loadTex("Textures\\bloody");

            //MENU
            bg = loadTex("Menu\\bg_alternative");
            buttonbg = loadTex("Menu\\button");
            logo = loadTex("Menu\\logo");
            comboBoxArrow = loadTex("Menu\\ComboBox\\arrow");
            checkBoxCross = loadTex("Menu\\CheckBox\\cross");
        }

        private static Texture2D loadTex(string path)
        {
            return Basic.content.Load<Texture2D>(path);
        }
    }
}
