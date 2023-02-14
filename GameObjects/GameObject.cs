using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TrainProject_;

namespace test.GameObjects
{
    public abstract class GameObject
    {
        public abstract ContentManager CM { get; set; }
        public abstract SpriteBatch SB { get; set; }

        public GameObject(ContentManager cm, SpriteBatch sb)
        {
            CM = cm;
            SB = sb;
            Game1.GameObjects.Add(this);
        }

        public abstract void Start();

        public abstract void Update();

        public abstract void Draw();

    }
}
