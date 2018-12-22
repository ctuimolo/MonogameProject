using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace SampleProject.AABBPhysics
{

    public struct BoxCollider
    {
        public Vector2 position;
        public Vector2 size;

        public float Left, Right, Top, Bottom;
        public float Width, Height;

        public BoxCollider(Vector2 position, Vector2 size)
        {
            this.position = position;
            this.size = size;

            Left = position.X;
            Right = position.X + size.X;
            Top = position.Y;
            Bottom = position.Y + size.Y;
            Width = size.X;
            Height = size.Y;
        }
    }

    public class AABBPhysicsHandler
    {

        private List<BoxCollider> BoxColliders;

        public AABBPhysicsHandler()
        {
        }

        public void AddBoxCollider(BoxCollider newBoxCollider)
        {
            BoxColliders.Add(newBoxCollider);
        }
    }
}
