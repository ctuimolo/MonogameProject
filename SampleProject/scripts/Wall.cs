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

        public Wall(ContentManager rootContent, SpriteBatch rootSpriteBatch)
        {
            content = rootContent;
            spriteBatch = rootSpriteBatch;
            transform = new Rectangle(40, 300, 600, 50);
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
            spriteBatch.Draw(texture, transform, Color.White);
        }
    }
}
