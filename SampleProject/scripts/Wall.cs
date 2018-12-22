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

        private Rectangle drawRect;

        public Wall(ContentManager rootContent, SpriteBatch rootSpriteBatch, AABBPhysicsHandler physicsHandler, BoxCollider boxCollider) {
            content = rootContent;
            spriteBatch = rootSpriteBatch;
            this.physicsHandler = physicsHandler;
            transform = boxCollider;
        }

        public override void Initialize()
        {
            physicsHandler.AddBoxCollider(transform);
        }

        public override void LoadContent()
        {
            texture = content.Load<Texture2D>("grey");
            drawRect = new Rectangle(0, 0, 1, 1);
        }


        public override void Collide(GameObject otherObject)
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
