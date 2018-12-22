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

        public BoxCollider(float X, float Y, float Width, float Height)
        {
            position = new Vector2(X,Y);
            size = new Vector2(Width, Height);

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
            BoxCollider RayTracer = new BoxCollider(
                Self.position.X, 
                Self.position.Y + Self.size.Y,
                Self.size.X,
                Speed
            );

            float closestWall = float.NaN;

            foreach(BoxCollider Other in BoxColliders)
            {
                if (RayTracer.Left <= Other.Right && RayTracer.Right >= Other.Left &&
                    RayTracer.Bottom >= Other.Top)
                {
                    if(closestWall == float.NaN || Other.Top < closestWall)
                    {

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
