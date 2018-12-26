using Microsoft.Xna.Framework.Graphics;
using SampleProject.AABBPhysics;

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
        public abstract void Collide(BoxCollider otherObject);
        public abstract void Update();
        public CollisionType collisionType;
    }
}
