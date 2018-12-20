using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace SampleProject.GameObjects.Player
{
    public class Player : GameObject
    {
        public Texture2D texture;
        public Rectangle transform;
        public ContentManager content;
        public SpriteBatch spriteBatch;
        public int xPos, yPos, width, height;

        public Player(ContentManager rootContent, SpriteBatch rootSpriteBatch)
        {
            content = rootContent;
            spriteBatch = rootSpriteBatch;
            transform = new Rectangle(50, 50, 30, 30);
        }

        public override void LoadContent()
        {
            texture = content.Load<Texture2D>("white");
        }

        public override void Initialize()
        {

        }

        public override void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D) && !Keyboard.GetState().IsKeyDown(Keys.A))
            {
                transform.X += 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) && !Keyboard.GetState().IsKeyDown(Keys.D))
            {
                transform.X -= 1;
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, transform, Color.White);
        }
    }
}
