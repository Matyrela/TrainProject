using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace test.GameObjects
{
    public class Rail : GameObject
    {
        public Rail(ContentManager cm, SpriteBatch sb, Vector2 startPoint, Vector2 endPoint, int state) : base(cm, sb)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            State = state;
            RailManager.Rails.Add(this);
        }

        public Vector2 StartPoint { get; set; }
        public Vector2 EndPoint { get; set; }
        public int State { get; set; }

        public override ContentManager CM { get; set; }
        public override SpriteBatch SB { get; set; }

        

        public override void Start(){
            
        }

        public override void Update(){}

        public Vector2 EnterRange(Vector2 Mouse)
        {
            Vector2 CheckPoint = EndPoint - new Vector2(16, 16);
            for (float i = CheckPoint.X; i <= CheckPoint.X + 31; i = i + 1)
            {
                for (float j = CheckPoint.Y; j <= CheckPoint.Y + 31; j = j + 1)
                {
                    SB.Draw(RailPreview.Pixel, new Vector2(i, j), null, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);
                }
            }

            SB.Draw(RailPreview.Pixel, CheckPoint + new Vector2(16, 16), null, Color.ForestGreen, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);
            return CheckPoint + new Vector2(16, 16);
        }

        public override void Draw()
        {
            switch (State)
            {
                case 0:
                    SB.Draw(RailPreview.Rail, StartPoint, null, Color.White, 0.785f * 0, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    for (float i = StartPoint.Y - 16; i >= EndPoint.Y; i = i - 16)
                    {
                        SB.Draw(RailPreview.Rail, new Vector2(StartPoint.X, i + 16), null, Color.White, 0, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    }
                    break;
                case 1:
                    SB.Draw(RailPreview.Rail, StartPoint, null, Color.White, 0.785f * 1, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    for (float i = StartPoint.Y - 8; i >= EndPoint.Y; i = i - 8)
                    {
                        SB.Draw(RailPreview.Rail, new Vector2(StartPoint.Y + StartPoint.X - i, i), null, Color.White, 0.785f, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    }
                    break;

                case 2:
                    SB.Draw(RailPreview.Rail, StartPoint, null, Color.White, 0.785f * 2, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    for (float i = StartPoint.X + 16; i <= EndPoint.X; i = i + 16)
                    {
                        SB.Draw(RailPreview.Rail, new Vector2(i - 16, StartPoint.Y), null, Color.White, 1.55f, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    }
                    break;


                case 3:
                    SB.Draw(RailPreview.Rail, StartPoint, null, Color.White, 0.785f * 3, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    for (float i = StartPoint.Y + 8; i <= EndPoint.Y; i = i + 8)
                    {
                        SB.Draw(RailPreview.Rail, new Vector2(i - StartPoint.Y + StartPoint.X, i), null, Color.White, 2.355f, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    }
                    break;

                case 4:
                    SB.Draw(RailPreview.Rail, StartPoint, null, Color.White, 0.785f * 4, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    for (float i = StartPoint.Y + 16; i <= EndPoint.Y; i = i + 16)
                    {
                        SB.Draw(RailPreview.Rail, new Vector2(StartPoint.X, i - 16 ), null, Color.White, 0, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    }
                    break;

                case 5:
                    SB.Draw(RailPreview.Rail, StartPoint, null, Color.White, 0.785f * 5, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    for (float i = StartPoint.Y + 8; i <= EndPoint.Y; i = i + 8)
                    {
                        SB.Draw(RailPreview.Rail, new Vector2(StartPoint.Y - i + StartPoint.X, i), null, Color.White, 3.925f, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    }
                    break;

                case 7:
                    SB.Draw(RailPreview.Rail, StartPoint, null, Color.White, 0.785f * 7, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    for (float i = StartPoint.Y; i >= EndPoint.Y; i = i - 8)
                    {
                        SB.Draw(RailPreview.Rail, new Vector2(i - StartPoint.Y + StartPoint.X, i), null, Color.White, 2.355f, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    }
                    break;

                case 6:
                    SB.Draw(RailPreview.Rail, StartPoint, null, Color.White, 0.785f * 6, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    for (float i = StartPoint.X - 16; i >= EndPoint.X; i = i - 16)
                    {
                        SB.Draw(RailPreview.Rail, new Vector2(i + 16, StartPoint.Y), null, Color.White, 1.55f, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    }
                    break;
            }
        }
    }
}
