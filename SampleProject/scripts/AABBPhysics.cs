using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

using SampleProject.GameObjects;

namespace SampleProject.AABBPhysics
{
    public enum CollisionType
    {
        wall,
        enemy,
        water,
        whatever
    }

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
            float RayTraceLeft = Self.position.X + 1;
            float RayTraceRight = RayTraceLeft + Self.size.X - 2;
            float RayTraceTop = Self.position.Y + Self.size.Y;
            float RayTraceBottom = RayTraceTop + Self.speed.Y - 1;

            BoxCollider contactObject = null;

            foreach(BoxCollider Other in BoxColliders)
            {

                if (!ReferenceEquals(Other, Self))
                {
                    if (RayTraceLeft <= Other.Right && RayTraceRight >= Other.Left &&
                        RayTraceBottom >= Other.Top && RayTraceTop <= Other.Top)
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
                //Self.owner.Collide(contactObject);
                if (contactObject.owner.collisionType == CollisionType.wall)
                {
                    Self.position.Y = contactObject.position.Y - Self.size.Y;
                    Self.speed.Y = 0;
                }
                Self.owner.Land(contactObject);
            } else
            {
                Self.position.Y += Self.speed.Y;
            }
        }

        public void MoveUp(BoxCollider Self)
        {
            float RayTraceLeft = Self.position.X + 1;
            float RayTraceRight = RayTraceLeft + Self.size.X - 2;
            float RayTraceTop = Self.position.Y + Self.speed.Y;
            float RayTraceBottom = Self.position.Y - 1;

            BoxCollider contactObject = null;

            foreach (BoxCollider Other in BoxColliders)
            {

                if (!ReferenceEquals(Other, Self))
                {
                    if (RayTraceLeft <= Other.Right && RayTraceRight >= Other.Left &&
                        RayTraceTop <= Other.Bottom && RayTraceBottom >= Other.Bottom)
                    {
                        if (contactObject == null || Other.Bottom > contactObject.Bottom)
                        {
                            contactObject = Other;
                        }
                    }
                }
            }

            if (contactObject != null)
            {
                if (contactObject.owner.collisionType == CollisionType.wall)
                {
                    Self.position.Y = contactObject.Bottom;
                    Self.speed.Y = 0;
                }
                Self.owner.Collide(contactObject);
            }
            else
            {
                Self.position.Y += Self.speed.Y;
            }
        }

        public void MoveRight(BoxCollider Self)
        {
            float RayTraceLeft = Self.position.X + Self.size.X;
            float RayTraceRight = RayTraceLeft + Self.speed.X - 1;
            float RayTraceTop = Self.position.X;
            float RayTraceBottom = Self.position.Y + Self.size.Y - 1;

            BoxCollider contactObject = null;

            foreach (BoxCollider Other in BoxColliders)
            {

                if (!ReferenceEquals(Other, Self))
                {
                    if (RayTraceLeft <= Other.Left && RayTraceRight >= Other.Left &&
                        RayTraceTop <= Other.Bottom && RayTraceBottom >= Other.Top)
                    {
                        if (contactObject == null || Other.Bottom > contactObject.Bottom)
                        {
                            contactObject = Other;
                        }
                    }
                }
            }

            if (contactObject != null)
            {
                if (contactObject.owner.collisionType == CollisionType.wall)
                {
                    Self.position.X = contactObject.Left - Self.size.X;
                    Self.speed.X = 0;
                }
                Self.owner.Collide(contactObject);
            }
            else
            {
                Self.position.X += Self.speed.X;
            }
        }

        public void MoveLeft(BoxCollider Self)
        {
            float RayTraceLeft = Self.position.X + Self.speed.X;
            float RayTraceRight = Self.position.X;
            float RayTraceTop = Self.position.Y;
            float RayTraceBottom = Self.position.Y + Self.size.Y - 1;

            BoxCollider contactObject = null;

            foreach (BoxCollider Other in BoxColliders)
            {

                if (!ReferenceEquals(Other, Self))
                {
                    if (RayTraceLeft <= Other.Right && RayTraceRight >= Other.Right &&
                        RayTraceTop <= Other.Bottom && RayTraceBottom >= Other.Top)
                    {
                        if (contactObject == null || Other.Bottom > contactObject.Bottom)
                        {
                            contactObject = Other;
                        }
                    }
                }
            }

            if (contactObject != null)
            {
                if (contactObject.owner.collisionType == CollisionType.wall)
                {
                    Self.position.X = contactObject.Right;
                    Self.speed.X = 0;
                }
                Self.owner.Collide(contactObject);
            }
            else
            {
                Self.position.X += Self.speed.X;
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
                    MoveRight(Self);
                } else if (Self.speed.X < 0)
                {
                    MoveLeft(Self);
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
