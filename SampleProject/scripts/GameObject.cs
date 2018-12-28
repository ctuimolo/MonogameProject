using Microsoft.Xna.Framework.Graphics;
using SampleProject.AABBPhysics;

namespace SampleProject.GameObjects
{

    public abstract class GameObject
    {
        public abstract void Initialize();
        public abstract void Draw(SpriteBatch rootSpriteBatch);
        public abstract void LoadContent();
        public abstract void Collide(BoxCollider otherObject);
        public abstract void Land(BoxCollider boxCollider);
        public abstract void Update();
        public CollisionType collisionType;
    }
}
