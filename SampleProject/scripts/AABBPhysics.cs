using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

using SampleProject.GameObjects;

namespace SampleProject.AABBPhysics
{

    public struct BoxCollider
    {
        public Vector2 position;
        public Vector2 size;

        public float Left, Right, Top, Bottom;
        public float Width, Height;

        public GameObject owner;

        public BoxCollider(GameObject owner, float X, float Y, float Width, float Height)
        {
            position = new Vector2(X,Y);
            size = new Vector2(Width, Height);
            this.owner = owner;

            Left = position.X;
            Right = position.X + size.X;
            Top = position.Y;
            Bottom = position.Y + size.Y;
            this.Width = size.X;
            this.Height = size.Y;
        }
    }

    public class AABBPhysicsHandler
    {

        private List<BoxCollider> BoxColliders;

        public AABBPhysicsHandler()
        {
            BoxColliders = new List<BoxCollider>();
        }

        public void MoveDown(BoxCollider Self, List<CollisionType> CollisionCache, float Speed)
        {
            float RayTraceLeft = Self.position.X;
            float RayTraceRight = Self.position.X + Self.size.X;
            float RayTraceTop = Self.position.Y + Self.size.Y;
            float RayTraceBottom = RayTraceTop + Speed;

            BoxCollider contactObject;

            foreach(BoxCollider Other in BoxColliders)
            {
                if (RayTraceLeft <= Other.Right && RayTraceRight >= Other.Left &&
                    RayTraceBottom >= Other.Top)
                {
                    if(contactObject == || Other.Top < contactObject)
                    {
                        closestWall = Other.Top;
                    }
                }
            }

            if (closestWall != float.NaN)
            {
                Self.owner.Collide();
            }
        }

        public void AddBoxCollider(BoxCollider newBoxCollider)
        {
            BoxColliders.Add(newBoxCollider);
        }
    }
}
