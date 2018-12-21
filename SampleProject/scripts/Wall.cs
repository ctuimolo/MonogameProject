using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SampleProject.GameObjects.Walls
{
    public class Wall : GameObject
    {
        public Texture2D texture;
        public Rectangle transform;
        public ContentManager content;
        public SpriteBatch spriteBatch;
        public int xPos, yPos, width, height;

        private Vector2 position;
        private Rectangle drawRect;
        private Vector2 scale;

        public Wall(ContentManager rootContent, SpriteBatch rootSpriteBatch)
        {
            content = rootContent;
            spriteBatch = rootSpriteBatch;
            transform = new Rectangle(40, 300, 600, 50);
            position = new Vector2(40f, 300f);
            drawRect = new Rectangle(0, 0, 1, 1);
            scale = new Vector2(600,50);
            width = 600;
            height = 50;
        }

        public override void Initialize()
        {

        }

        public override void LoadContent()
        {
            texture = content.Load<Texture2D>("grey");
        }

        public override void Update()
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture, transform, Color.White);
            spriteBatch.Draw(
                texture,
                position,
                drawRect,
                Color.White,
                0f,                     // Rotation
                Vector2.Zero,           // Origin
                new Vector2(width,height),
                SpriteEffects.None,
                0                       // Layer depth
            );
        }
    }
}
