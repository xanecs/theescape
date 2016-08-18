using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TheEscape
{
    
    class Basic
    {
        public static bool debugMode = false;
        public static SpriteBatch spriteBatch;
        public static GraphicsDevice gDevice;
        public static GraphicsDeviceManager gManager;
        public static ContentManager content;
        public static GameTime gameTime;
        public static Game1 game;

        public static GameWindow window;
        public static Rectangle windowSize = new Rectangle(0, 0, 854, 480);
        public static Rectangle fullScreenSize = new Rectangle(0, 0, 1280, 720);

        public static Screen currentScreen;
        public static SpriteFont debugFont;
        public static SpriteFont subtitleFont;

        public static FPS fps = new FPS();
        public static DebugHelper debughelper = new DebugHelper();

        public static void Init(Game1 _game)
        {
            game = _game;
            gManager = _game.graphics;
            gDevice = game.GraphicsDevice;
            content = game.Content;
            spriteBatch = new SpriteBatch(gDevice);
            window = _game.Window;

            gManager.PreferredBackBufferHeight = windowSize.Height;
            gManager.PreferredBackBufferWidth = windowSize.Width;
            gManager.IsFullScreen = false;
            gManager.ApplyChanges();

            Textures.loadTextures();
            Sounds.loadSounds();
            RenderModels.loadModels();

            setScreen(new MenuScreen());

            debugFont = content.Load<SpriteFont>("Font");
            subtitleFont = content.Load<SpriteFont>("Subtitle");
        }

        

        public static void Update(GameTime _gameTime)
        {
            gameTime = _gameTime;

            if(Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                game.Exit();
            }
            if(Keyboard.GetState().IsKeyDown(Keys.F11))
            {
                gManager.PreferredBackBufferWidth = fullScreenSize.Width;
                gManager.PreferredBackBufferHeight = fullScreenSize.Height;
                gManager.IsFullScreen = true;
                gManager.ApplyChanges();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F10))
            {
                gManager.PreferredBackBufferWidth = windowSize.Width;
                gManager.PreferredBackBufferHeight = windowSize.Height;
                gManager.IsFullScreen = false;
                gManager.ApplyChanges();
            }

            currentScreen.Update();
            fps.Update(gameTime);
            debughelper.Update();

        }

        public static void Render()
        {
            spriteBatch.Begin();

            gDevice.DepthStencilState = DepthStencilState.Default;

            currentScreen.Render();

            fps.Render(spriteBatch);

            spriteBatch.End();
        }

        public static void setScreen(Screen screen)
        {
            currentScreen = screen;
            currentScreen.Init();
        }
    }
}
