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
    class Camera
    {
        public Matrix view, projection;

        

        float walk_animation;

        float yaw, pitch;

        int oldX, oldY;

        public Camera()
        {
            GameScreen.player.position = new Vector3(0, 0.1f, 5);

            GameScreen.player.currspeed = GameScreen.player.speed;
            view = Matrix.CreateLookAt(GameScreen.player.position, Vector3.Zero, Vector3.Up);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, Basic.gDevice.Viewport.AspectRatio, 0.1f, 20.0f);
        }

        
        public void Update()
        {
            KeyboardState kBoard = Keyboard.GetState();

            running = 0;

            walk_animation += 15.0f * (float)Basic.gameTime.ElapsedGameTime.TotalSeconds;
            if (walk_animation > 360)
                walk_animation = 0;

            if (kBoard.IsKeyDown(Keys.W) || kBoard.IsKeyDown(Keys.A) || kBoard.IsKeyDown(Keys.S) || kBoard.IsKeyDown(Keys.D))
            {
                if (kBoard.IsKeyDown(Keys.LeftShift) && GameScreen.player.endurance > 0)
                {
                    GameScreen.player.running(true);
                    GameScreen.player.walksound(false);
                }
                else
                {
                    GameScreen.player.walksound(true);
                    GameScreen.player.running(false);
                }
            }
            else
            {
                GameScreen.player.running(false);
                GameScreen.player.walksound(false);
            }

            if (!kBoard.IsKeyDown(Keys.LeftShift))
            {
                if (GameScreen.player.endurance < 10.0f)
                    GameScreen.player.endurance += 1.2f * (float)Basic.gameTime.ElapsedGameTime.TotalSeconds;
            }

            

            if (kBoard.IsKeyDown(Keys.W))
            {
                Vector3 v = new Vector3(0, 0, -1) * GameScreen.player.speed;
                move(v);
            }

            if (kBoard.IsKeyDown(Keys.S))
            {
                Vector3 v = new Vector3(0, 0, 1) * GameScreen.player.speed;
                move(v);
            }

            if (kBoard.IsKeyDown(Keys.A))
            {
                Vector3 v = new Vector3(-1, 0, 0) * GameScreen.player.speed;
                move(v);
            }

            if (kBoard.IsKeyDown(Keys.D))
            {
                Vector3 v = new Vector3(1, 0, 0) * GameScreen.player.speed;
                move(v);
            }

            move(new Vector3(0, -1, 0) * GameScreen.player.speed/ 2);

            if (GameScreen.player.position.Y <= -1)
                Basic.setScreen(new MenuScreen());

            MouseState mState = Mouse.GetState();

            int dx = mState.X - oldX;
            int dy = mState.Y - oldY;

            yaw += -GameScreen.player.rotationSpeed * dx;
            pitch += -GameScreen.player.rotationSpeed * dy;

            pitch = MathHelper.Clamp(pitch, -1.5f, 1.5f);

            UpdateMatrices();
            ResetCursor();
        }

        private void ResetCursor()
        {
            if (Basic.game.IsActive)
            {
                Mouse.SetPosition(Basic.windowSize.Width / 2, Basic.windowSize.Height / 2);
                oldX = Basic.windowSize.Width / 2;
                oldY = Basic.windowSize.Height / 2;
            }
        }

        float running;
        public void move(Vector3 v)
        {
            Vector3 forward = Vector3.Transform(v, Matrix.CreateRotationY(yaw));

            running = 0.0f;
            if (GameScreen.player.run)
            {
                running += (float)((Math.Sin(walk_animation) + 0) * 0.01);
            }
            else if (v.X != 0|| v.Z != 0)
            {
                running += (float)((Math.Sin(walk_animation) + 0) * 0.0015);
            }

            if (!contains(new Vector3(GameScreen.player.position.X + forward.X, GameScreen.player.position.Y, GameScreen.player.position.Z)))
                GameScreen.player.position.X += forward.X;
            if (!contains(new Vector3(GameScreen.player.position.X, GameScreen.player.position.Y, GameScreen.player.position.Z + forward.Z)))
                GameScreen.player.position.Z += forward.Z;
            if (!contains(new Vector3(GameScreen.player.position.X, GameScreen.player.position.Y + forward.Y, GameScreen.player.position.Z)))
                GameScreen.player.position.Y += forward.Y;
        }

        public bool contains(Vector3 v)
        {
            foreach (Entity e in GameScreen.level.entities)
            {
                if (e.collision && e.box.Contains(v) == ContainmentType.Contains)
                {
                    if (e.isDeadly && GameScreen.player.health > 0)
                    {
                        GameScreen.player.health -= (float)Basic.gameTime.ElapsedGameTime.TotalMilliseconds * 0.005f;
                        BloodyScreen.isActive = true;
                    }

                    return true;
                }
            }
            return false;
        }

        public void UpdateMatrices()
        {
            Matrix rotation = Matrix.CreateRotationX(pitch) * Matrix.CreateRotationY(yaw);

            Vector3 transformed = Vector3.Transform(new Vector3(0, 0, -1), rotation);
            Vector3 lookAt = new Vector3(GameScreen.player.position.X, GameScreen.player.position.Y + running, GameScreen.player.position.Z) + transformed;

            view = Matrix.CreateLookAt(new Vector3(GameScreen.player.position.X, GameScreen.player.position.Y + running, GameScreen.player.position.Z), lookAt, Vector3.Up);
        }

        public Ray createRay()
        {
            int centerX = Basic.windowSize.Width / 2;
            int centerY = Basic.windowSize.Height / 2;

            Vector3 nearSource = new Vector3(centerX, centerY, 0);
            Vector3 farSource = new Vector3(centerX, centerY, 1);

            Vector3 nearPoint = Basic.gDevice.Viewport.Unproject(nearSource, projection, view, Matrix.Identity);
            Vector3 farPoint = Basic.gDevice.Viewport.Unproject(farSource, projection, view, Matrix.Identity);

            Vector3 direction = farPoint - nearPoint;
            direction.Normalize();

            return new Ray(nearPoint, direction);
        }
    }
}
