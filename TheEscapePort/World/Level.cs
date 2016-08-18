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
    class Level
    {
        
        public Floor floor;
        public Ceiling ceiling;
        public int mapWidth, mapHeight;

        public Texture2D mapTexture;
        public Color[,] colorData;

        public List<Entity> entities = new List<Entity>();
        public LevelManager levelManager;

        public int level;

        public struct mapColors
        {
            public static Color WallColor;
            public static Color WallBloodColor;
            public static Color KnifeColor;
            public static Color GridColor;

            public static Color FloorColor;
            public static Color CeilingColor;
            public static bool hasCeiling;
        };

        public Level(int _level)
        {
            mapTexture = Basic.content.Load<Texture2D>("Levels\\Level" + _level);
            colorData = TextureToColor(mapTexture);

            levelManager = new LevelManager(_level);

            level = _level;

            mapHeight = mapTexture.Height;
            mapWidth = mapTexture.Width;

            #region mapColors
            mapColors.WallColor = levelManager.getWallColor();
            mapColors.WallBloodColor = levelManager.getWallBloodColor();
            mapColors.KnifeColor = levelManager.getKnifeColor();
            mapColors.GridColor = levelManager.getGridColor();

            mapColors.FloorColor = levelManager.getFloorColor();
            mapColors.CeilingColor = levelManager.getCeilingColor();
            mapColors.hasCeiling = levelManager.hasCeiling;
            #endregion

            floor = new Floor(this, mapWidth, mapHeight);
            if (mapColors.hasCeiling)
                ceiling = new Ceiling(mapWidth, mapHeight);

            SetUpMap();

            Sounds.PlayLoop(Sounds.background);
        }

        public static void switchLevel()
        {
            try
            {
                GameScreen.level = new Level(GameScreen.level.level + 1);
                
            }
            catch {}
        }
        public static void switchLevel_back()
        {
            try
            {
                GameScreen.level = new Level(GameScreen.level.level - 1);
            }
            catch { }
        }
        public void Update()
        {

            entities.Sort();

            for (int i = 0; i < entities.Count; i++)
            {
                try
                {
                    entities[i].CalculateCameraDistance();
                    entities[i].Update();
                }
                catch { }
            }
        }

        public void Render()
        {
            floor.Render();
            if (mapColors.hasCeiling)
                ceiling.Render();

            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].CameraDistance <= 10f)
                    entities[i].Render();
            }
        }

        public void SetUpMap()
        {
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    if (colorData[x, y] == Color.Black)                   //(000, 000, 000)   #000000   Black
                        entities.Add(new WallBlock(x, 0, y));

                    if (colorData[x, y] == Color.Blue)                    //(000, 000, 255)   #0000ff   Blue
                        entities.Add(new WallBlockBlood(x, 0, y));

                    if (colorData[x, y] == Color.Aqua)                    //(000, 255, 255)   #00ffff   Cyan
                        entities.Add(new DoorBlock(x, 0, y));

                    if (colorData[x, y] == new Color(0, 240, 240))        //(000, 240, 240)   #00f0f0   Cyan2
                    {
                        DoorBlock e = new DoorBlock(x, 0, y);
                        e.locked = true;
                        entities.Add(e);
                    }

                    if (colorData[x, y] == new Color(0, 230, 230))        //(000, 230, 230)   #000000   Cyan3
                    {
                        DoorBlock e = new DoorBlock(x, 0, y);
                        e.enabled = false;
                        entities.Add(e);
                    }

                    if (colorData[x, y] == Color.Purple)                  //(128, 000, 128)   #800080   Purple
                        entities.Add(new Key(x, 0, y));

                    if (colorData[x, y] == new Color(255, 128, 0))        //(255, 128, 000)   #ff8000   Orange
                        entities.Add(new GridBlock(x, 0, y));

                    if (colorData[x, y] == Color.Red)                     //(255, 000, 000)   #ff0000   Red
                    {
                        GameScreen.player.position.X = x;
                        GameScreen.player.position.Y = 0.15f;
                        GameScreen.player.position.Z = y;
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

        public Entity getEntity(float x, float y, float z)
        {
            foreach (Entity e in entities)
            {
                if (e.position.X  == x && e.position.Y == y && e.position.Z == z)
                {
                    return e;
                }
            }
            return null;
        }
    }
}
