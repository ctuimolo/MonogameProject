using Microsoft.Xna.Framework.Graphics;

namespace SampleProject.GameObjects
{
    public enum CollisionType
    {
        wall,
        enemy,
        water,
        whatever
    }

    public abstract class GameObject
    {
        public abstract void Initialize();
        public abstract void Draw(SpriteBatch rootSpriteBatch);
        public abstract void LoadContent();
        public abstract void Collide(GameObject otherObject);
        public abstract void Update();
        public CollisionType collisionType;
    }
}
