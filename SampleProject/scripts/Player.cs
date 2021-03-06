﻿using System.Collections.Generic;
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
        public ContentManager content;
        private AABBPhysicsHandler physicsHandler;
        public SpriteBatch spriteBatch;
        public BoxCollider transform;

        private List<Wall> walls;
        private float gravity = 1;
        private float maxSpeed = 10;
        private float moveSpeed = 3;
        private Rectangle drawRect;
        private float scale = 1;
        public bool grounded = false;

        public Player(ContentManager rootContent, SpriteBatch rootSpriteBatch, AABBPhysicsHandler physicsHandler)
        {
            content = rootContent;
            spriteBatch = rootSpriteBatch;
            this.physicsHandler = physicsHandler;
        }

        public override void LoadContent()
        {
            texture = content.Load<Texture2D>("white");
            transform = new BoxCollider(this, 50,50,30,30);
            physicsHandler.AddBoxCollider(transform);
            drawRect = new Rectangle(0, 0, 30, 30);
        }

        public override void Initialize()
        {
        }

        public override void Collide(BoxCollider collision)
        {
        }

        public override void Land(BoxCollider collision)
        {
            if (collision.owner.collisionType == CollisionType.wall)
            {
                grounded = true;
            }
        }

        public void SetWalls(List<Wall> rootWalls) 
        {
            walls = rootWalls;
        }

        public void ApplyGravity()
        {
            if(!grounded && transform.speed.Y < maxSpeed) {
                transform.speed.Y += gravity;
                if(transform.speed.Y > maxSpeed) {
                    transform.speed.Y = maxSpeed;
                }
            }
        }

        /*private void CheckCollisions() 
        {
            //transform.Y += ySpeed;
            //transform.X += xSpeed;
            transform.position.Y += ySpeed;
            transform.position.X += xSpeed;

            float wallLeft, wallRight, wallTop, wallBottom;
            int left = transform.X;
            int right = transform.Right;
            int top = transform.Y;
            int bottom = transform.Y + transform.Height;
            float left = transform.position.X;
            float right = transform.position.X + transform.size.X;
            float top = transform.position.Y;
            float bottom = transform.position.Y + transform.size.Y;

            // check cardinal collisions
            foreach (Wall wall in walls) 
            {
                wallLeft = wall.transform.position.X;
                wallRight = wall.transform.position.X + wall.transform.size.X;
                wallTop = wall.transform.position.Y;
                wallBottom = wall.transform.position.Y + wall.transform.size.Y;

                // check vertically aligned collisions
                if( left <= wallRight && right >= wallLeft) 
                {
                    // check downward
                    if( bottom >= wallTop && !grounded) 
                    {
                        // set downward collision true
                        ySpeed = 0;
                        transform.position.Y = wallTop - transform.size.Y;
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
            
        }*/

        private void CheckGrounded()
        {
            /*if (currentFloor != null &&
                transform.Left <= currentFloor.transform.Right && transform.Right >= currentFloor.transform.Left &&
                transform.Bottom + 1 <= currentFloor.transform.Bottom && transform.Bottom + 1 >= currentFloor.transform.Top)
            {
                grounded = true;
            } else
            {
                grounded = false;
            }*/
        }

        private void MoveDown()
        {

        }

        private void MoveUp()
        {

        }

        private void MoveRight()
        {
            transform.speed.X = moveSpeed;
        }

        private void MoveLeft()
        {
            transform.speed.X = -moveSpeed;
        }

        public override void Update()
        {
            //CheckGrounded();
            ApplyGravity();

            if (Keyboard.GetState().IsKeyDown(Keys.D) && !Keyboard.GetState().IsKeyDown(Keys.A))
            {
                MoveRight();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) && !Keyboard.GetState().IsKeyDown(Keys.D))
            {
                MoveLeft();
            }
            if (!Keyboard.GetState().IsKeyDown(Keys.A) && !Keyboard.GetState().IsKeyDown(Keys.D))
            {
                transform.speed.X = 0;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W) && grounded) {
                transform.speed.Y = -10;
                grounded = false;
            }

            //CheckGrounded();
            //ApplyGravity();
            //CheckCollisions();
            physicsHandler.UpdatePosition(transform);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture, transform, Color.White);
            spriteBatch.Draw(
                texture,
                transform.position,
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
