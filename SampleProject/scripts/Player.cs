using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using SampleProject.GameObjects.Walls;
using SampleProject.AABBPhysics;

namespace SampleProject.GameObjects.Player
{
    public class Player : GameObject
    {
        public Texture2D texture;
        public Rectangle transform;
        public ContentManager content;
        public SpriteBatch spriteBatch;
        public int width, height;

        private List<Wall> walls;
        private Wall currentFloor;
        private int gravity = 1;
        private int maxSpeed = 10;
        private int moveSpeed = 3;
        private int xSpeed, ySpeed;
        private Vector2 position;
        private Rectangle drawRect;
        private float scale;
        private bool grounded = false;

        public Player(ContentManager rootContent, SpriteBatch rootSpriteBatch)
        {
            content = rootContent;
            spriteBatch = rootSpriteBatch;
            //transform = new Rectangle(50, 50, 30, 30);
            position = new Vector2(50f, 50f);
            drawRect = new Rectangle(0,0,30,30);
            scale = 1;
            width = 30;
            height = 30;
        }

        public override void LoadContent()
        {
            texture = content.Load<Texture2D>("white");
        }

        public override void Initialize()
        {

        }

        public void SetWalls(List<Wall> rootWalls) 
        {
            walls = rootWalls;
        }

        public void ApplyGravity() {

            if(!grounded && ySpeed < maxSpeed) {
                ySpeed += gravity;
                if(ySpeed > maxSpeed) {
                    ySpeed = maxSpeed;
                }
            }
        }

        private void CheckCollisions() 
        {
            //transform.Y += ySpeed;
            //transform.X += xSpeed;
            position.Y += ySpeed;
            position.X += xSpeed;

            float wallLeft, wallRight, wallTop, wallBottom;
            /*int left = transform.X;
            int right = transform.Right;
            int top = transform.Y;
            int bottom = transform.Y + transform.Height;*/
            float left = position.X;
            float right = position.X + width;
            float top = position.Y;
            float bottom = position.Y + height;

            // check cardinal collisions
            foreach (Wall wall in walls) 
            {
                wallLeft = wall.position.X;
                wallRight = wall.position.X + wall.width;
                wallTop = wall.position.Y;
                wallBottom = wall.position.Y + wall.height;

                // check vertically aligned collisions
                if( left <= wallRight && right >= wallLeft) 
                {
                    // check downward
                    if( bottom >= wallTop && !grounded) 
                    {
                        // set downward collision true
                        ySpeed = 0;
                        position.Y = wallTop - height;
                        currentFloor = wall;
                        grounded = true;
                    }

                    // check upward
                    if ( top <= wallBottom) 
                    {
                        // set upward collision true
                    }
                }

                // check horizontally aligned collisions
                if (top <= wallBottom && bottom >= wallTop) {
                    // check right
                    if (right >= wallLeft) {
                        // set rightward collision true
                    }

                    // check left
                    if (left <= wallRight) {
                        // set leftward collision true
                    }
                }
            }

            xSpeed = 0;
            
        }

        private void CheckGrounded()
        {
            if (currentFloor != null &&
                transform.Left <= currentFloor.transform.Right && transform.Right >= currentFloor.transform.Left &&
                transform.Bottom + 1 <= currentFloor.transform.Bottom && transform.Bottom + 1 >= currentFloor.transform.Top)
            {
                grounded = true;
            } else
            {
                grounded = false;
            }
        }

        private void MoveDown()
        {

        }

        private void MoveUp()
        {

        }

        private void MoveRight()
        {
            xSpeed = moveSpeed;
        }

        private void MoveLeft()
        {
            xSpeed = -moveSpeed;
        }

        public override void Update()
        {

            if (Keyboard.GetState().IsKeyDown(Keys.D) && !Keyboard.GetState().IsKeyDown(Keys.A))
            {
                MoveRight();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) && !Keyboard.GetState().IsKeyDown(Keys.D))
            {
                MoveLeft();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W) && grounded) {
                ySpeed = -10;
                grounded = false;
                currentFloor = null;
            }

            CheckGrounded();
            ApplyGravity();
            CheckCollisions();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture, transform, Color.White);
            spriteBatch.Draw(
                texture,
                position,
                drawRect,
                Color.White,
                0f,                     // Rotation
                Vector2.Zero,           // Origin
                scale,
                SpriteEffects.None,
                0                       // Layer depth
            );
        }
    }
}
