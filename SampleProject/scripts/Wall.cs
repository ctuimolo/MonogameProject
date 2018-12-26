using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;

using SampleProject.AABBPhysics;

namespace SampleProject.GameObjects.Walls
{
    public class Wall : GameObject
    {
        private AABBPhysicsHandler physicsHandler;

        public Texture2D texture;
        public ContentManager content;
        public SpriteBatch spriteBatch;

        public BoxCollider transform;

        readonly float X, Y, Width, Height;

        private Rectangle drawRect;

        public Wall(ContentManager rootContent, SpriteBatch rootSpriteBatch, AABBPhysicsHandler physicsHandler, float X, float Y, float Width, float Height) {
            content = rootContent;
            spriteBatch = rootSpriteBatch;
            this.physicsHandler = physicsHandler;
            this.X = X;
            this.Y = Y;
            this.Height = Height;
            this.Width = Width;
            collisionType = CollisionType.wall;
        }

        public override void Initialize()
        {
        }

        public override void LoadContent()
        {
            texture = content.Load<Texture2D>("grey");
            drawRect = new Rectangle(0, 0, 1, 1);
            transform = new BoxCollider(this, X, Y, Width, Height);
            physicsHandler.AddBoxCollider(transform);
        }

        public override void Collide(BoxCollider otherObject)
        {

        }

        public override void Update()
        {

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
                transform.size,
                SpriteEffects.None,
                0                       // Layer depth
            );
        }
    }
}
