using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using SampleProject.GameObjects.Walls;

namespace SampleProject.GameObjects.Player
{
    public class Player : GameObject
    {
        public Texture2D texture;
        public Rectangle transform;
        public ContentManager content;
        public SpriteBatch spriteBatch;
        public int xPos, yPos, width, height;

        private List<Wall> walls;
        private Wall currentFloor;
        private int gravity = 1;
        private int maxSpeed = 10;
        private int moveSpeed = 3;
        private int xSpeed = 0;
        private int ySpeed = 0;
        private bool grounded = false;
        private bool topCollision = false;
        private bool bottomCollision = false;
        private bool leftCollision = false;
        private bool rightCollision = false;

        public Player(ContentManager rootContent, SpriteBatch rootSpriteBatch)
        {
            content = rootContent;
            spriteBatch = rootSpriteBatch;
            transform = new Rectangle(50, 50, 30, 30);
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
            ApplyGravity();
            transform.Y += ySpeed;
            transform.X += xSpeed;

            int wallLeft, wallRight, wallTop, wallBottom;
            int left = transform.X;
            int right = transform.Right;
            int top = transform.Y;
            int bottom = transform.Y + transform.Height;

            // check if grounded
            if (currentFloor != null && grounded &&
                left > currentFloor.transform.Right && right < currentFloor.transform.Left &&
                (bottom + 1 > currentFloor.transform.Bottom || bottom + 1 < currentFloor.transform.Top)) 
            {
                grounded = false;
            }

            // check cardinal collisions
            foreach (Wall wall in walls) 
            {
                wallLeft = wall.transform.X;
                wallRight = wall.transform.X + wall.transform.Width;
                wallTop = wall.transform.Y;
                wallBottom = wall.transform.Y + wall.transform.Height;

                // check vertically aligned collisions
                if( left <= wallRight && right >= wallLeft) 
                {
                    // check downward
                    if( bottom >= wallTop && !grounded) 
                    {
                        // set downward collision true
                        grounded = true;
                        ySpeed = 0;
                        transform.Y = wallTop - transform.Height;
                        currentFloor = wall;
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

        public override void Update()
        {

            if (Keyboard.GetState().IsKeyDown(Keys.D) && !Keyboard.GetState().IsKeyDown(Keys.A))
            {
                xSpeed = moveSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) && !Keyboard.GetState().IsKeyDown(Keys.D))
            {
                xSpeed = -moveSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W) && grounded) {
                ySpeed = -10;
                grounded = false;
                currentFloor = null;
            }

            CheckCollisions();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, transform, Color.White);
        }
    }
}
