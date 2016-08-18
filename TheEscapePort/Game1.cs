using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TheEscape
{
	public class Game1 : Game
	{
		public GraphicsDeviceManager graphics;
		public SpriteBatch spriteBatch;

		public Game1 ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";
		}

		protected override void Initialize ()
		{
			Basic.Init (this);
			this.Window.Title = "TheEscape v0.3";
			base.Initialize ();
		}
			
		protected override void LoadContent ()
		{
			spriteBatch = new SpriteBatch (GraphicsDevice);

		}

		protected override void Update (GameTime gameTime)
		{

			#if !__IOS__ &&  !__TVOS__
			if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState ().IsKeyDown (Keys.Escape))
				Exit ();
			#endif
            
			Basic.Update (gameTime);
			base.Update (gameTime);
		}

		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.Black);
            
			Basic.Render ();

			base.Draw (gameTime);
		}
	}
}

