using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SampleProject.AABBPhysics
{

    public struct FloatRect
    {
        public float X;
        public float Y;
        public float Top;
        public float Bottom;
        public float Left;
        public float Right;
        public float Width;
        public float Height;

        public FloatRect(float Left, float Top, float Width, float Height)
        {
            this.Left = Left;
            this.Top = Top;
            this.Width = Width;
            this.Height = Height;
            this.X = Left;
            this.Y = Top;
            this.Right = Left + Width;
            this.Bottom = Top + Height;
        }
    }

    public class AABBPhysicsHandler
    {
        public AABBPhysicsHandler()
        {
            FloatRect floatRect;
            floatRect.X = 10;
        }
    }
}
