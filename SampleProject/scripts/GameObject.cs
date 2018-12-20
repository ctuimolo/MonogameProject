using Microsoft.Xna.Framework.Graphics;

namespace SampleProject.GameObjects
{
    public abstract class GameObject
    {
        public abstract void Initialize();
        public abstract void Draw(SpriteBatch rootSpriteBatch);
        public abstract void LoadContent();
        public abstract void Update();
    }
}
