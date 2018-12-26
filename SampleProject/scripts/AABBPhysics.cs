using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

using SampleProject.GameObjects;

namespace SampleProject.AABBPhysics
{
    public class BoxCollider
    {
        public Vector2 position;
        public Vector2 size;
        public Vector2 speed;

        public float Left, Right, Top, Bottom;
        public GameObject owner;

        public BoxCollider(GameObject owner, float X, float Y, float Width, float Height)
        {
            position = new Vector2(X,Y);
            size = new Vector2(Width, Height);
            speed = new Vector2(0, 0);
            this.owner = owner;

            Left = position.X;
            Right = position.X + size.X;
            Top = position.Y;
            Bottom = position.Y + size.Y;
        }
    }

    public class AABBPhysicsHandler
    {

        private List<BoxCollider> BoxColliders;

        public AABBPhysicsHandler()
        {
            BoxColliders = new List<BoxCollider>();
        }

        public void MoveDown(BoxCollider Self)
        {
            float RayTraceLeft = Self.position.X;
            float RayTraceRight = Self.position.X + Self.size.X;
            float RayTraceTop = Self.position.Y + Self.size.Y;
            float RayTraceBottom = RayTraceTop + Self.speed.Y;

            BoxCollider contactObject = null;

            foreach(BoxCollider Other in BoxColliders)
            {

                if (!ReferenceEquals(Other, Self))
                {
                    if (RayTraceLeft <= Other.Right && RayTraceRight >= Other.Left &&
                        RayTraceBottom >= Other.Top)
                    {
                        if (contactObject == null || Other.Top < contactObject.Top)
                        {
                            contactObject = Other;
                        }
                    }
                }
            }

            if (contactObject != null)
            {
                Self.owner.Collide(contactObject);
            } else
            {
                Self.position.Y += Self.speed.Y;
            }
        }

        public void MoveUp(BoxCollider Self)
        {
            float RayTraceLeft = Self.position.X;
            float RayTraceRight = Self.Right;
            float RayTraceTop = Self.Top - Self.speed.Y;
            float RayTraceBottom = Self.Top;

            BoxCollider contactObject = null;

            foreach (BoxCollider Other in BoxColliders)
            {

                if (!ReferenceEquals(Other, Self))
                {
                    if (RayTraceLeft <= Other.Right && RayTraceRight >= Other.Left &&
                        RayTraceTop <= Other.Bottom)
                    {
                        if (contactObject == null || Other.Bottom > contactObject.Top)
                        {
                            contactObject = Other;
                        }
                    }
                }
            }

            if (contactObject != null)
            {
                Debug.WriteLine("Collision Top");
                Self.owner.Collide(contactObject);
            }
            else
            {
                Debug.WriteLine("No colision Top");
                Self.position.Y -= Self.speed.Y;
            }
        }

        public void UpdatePosition(BoxCollider Self)
        {
            if (Self.speed.X == 0)
            {
                if (Self.speed.Y > 0)
                {
                    MoveDown(Self);
                } else if (Self.speed.Y < 0)
                {
                    MoveUp(Self);
                }
            } else if (Self.speed.Y == 0)
            {
                if (Self.speed.X > 0)
                {
                    //MoveRight(Self);
                } else if (Self.speed.X < 0)
                {
                    //MoveLeft(Self);
                }
            } else
            {
                if (Self.speed.X > 0)
                {
                    if (Self.speed.Y > 0)
                    {
                        //MoveDownRight(Self);
                    } else
                    {
                        //MoveUpRight(Self);
                    }
                } else
                {
                    if (Self.speed.Y > 0)
                    {
                        //moveDownLeft(Self);
                    } else
                    {
                        //MoveUpLeft(Self);
                    }
                }
            }
        }

        public void AddBoxCollider(BoxCollider newBoxCollider)
        {
            BoxColliders.Add(newBoxCollider);
        }
    }
}
