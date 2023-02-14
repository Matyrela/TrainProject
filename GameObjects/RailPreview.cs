using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TrainProject_;

namespace test.GameObjects
{
    public class RailPreview : GameObject
    {
        public RailPreview(ContentManager cm, SpriteBatch sb) : base(cm, sb)
        {
            IsConstructing = false;

        }

        public static Texture2D Rail { get; set; }
        public static Texture2D Curve { get; set; }
        public static Texture2D Line { get; set; }
        public static Texture2D Pixel { get; set; }



        public bool IsConstructing { get; set; }
        public bool IsPreview { get; set; }
        public bool ClickLock { get; set; }

        public Vector2 StartPoint { get; set; }
        public Vector2 EndPoint { get; set; }
        public Vector2 RealEndPoint { get; set; }
        public override ContentManager CM { get; set; }
        public override SpriteBatch SB { get; set; }

        public static SpriteFont font;

        float angle;

        public override void Start()
        {
            Rail = CM.Load<Texture2D>("Rail");
            Curve = CM.Load<Texture2D>("RailUnion");
            Line = CM.Load<Texture2D>("Line");
            Pixel = CM.Load<Texture2D>("pixel");
            font = CM.Load<SpriteFont>("Arial");
        }

        public override void Update()
        {
            if(IsPreview && !IsConstructing)
            {
                this.StartPoint = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
                this.EndPoint = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            }

            if (IsConstructing)
            {
                this.EndPoint = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && !ClickLock && IsConstructing)
            {
                Rail addRail;
                if (angle > -0.35f && angle < 0.435f)
                {
                    addRail = new Rail(CM, SB, StartPoint, RealEndPoint, 0);
                }
                else if (angle > 0.435f && angle < 1.22f)
                {
                    addRail = new Rail(CM, SB, StartPoint, EndPoint, 1);
                }
                else if (angle > 1.22f && angle < 2.005f)
                {
                    addRail = new Rail(CM, SB, StartPoint, RealEndPoint, 2);
                }
                else if (angle > 2.005f && angle < 2.79f)
                {
                    addRail = new Rail(CM, SB, StartPoint, EndPoint, 3);
                }
                else if (angle > 2.79f && angle < 3.575f)
                {
                    addRail = new Rail(CM, SB, StartPoint, RealEndPoint, 4);
                }
                else if (angle > 3.575f && angle < 4.36f)
                {
                    addRail = new Rail(CM, SB, StartPoint, EndPoint, 5);
                }
                else if (angle > -1.135 && angle < -0.35f)
                {
                    addRail = new Rail(CM, SB, StartPoint, EndPoint, 7);
                }
                else
                {
                    addRail = new Rail(CM, SB, StartPoint, RealEndPoint, 6);
                }

                this.IsPreview = false;
                this.IsConstructing = false;
                this.ClickLock = true;
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && !ClickLock)
            {

                if (IsPreview)
                {
                    ClickLock = true;
                    this.IsConstructing = true;
                    this.StartPoint = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
                }
                else if (!IsPreview)
                {
                    ClickLock = true;
                    this.IsPreview = true;
                }
                else if (IsConstructing)
                {
                    ClickLock = true;
                    this.IsConstructing = false;
                    this.EndPoint = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
                }
                else if (!IsConstructing)
                {
                    this.IsConstructing = true;
                    this.StartPoint = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
                }
            }

            if (Mouse.GetState().LeftButton == ButtonState.Released)
            {
                ClickLock = false;
            }
        }

        public override void Draw()
        {
            foreach (Rail r in RailManager.Rails)
            {
                r.EnterRange(new Vector2(Mouse.GetState().X, Mouse.GetState().Y));
            }

            if (IsPreview && !IsConstructing)
            {
                SB.Draw(Rail, StartPoint, null, Color.White, 0.785f * 0, new Vector2(8, 8), 1, SpriteEffects.None, 0);
            }
            
            if (IsConstructing)
            {
                angle = (float)Angle(StartPoint, StartPoint, EndPoint);

                /*
                SB.Draw(Line, StartPoint, null, Color.White, 0.435f, new Vector2(1, 0), 1, SpriteEffects.None, 0);
                SB.Draw(Line, StartPoint, null, Color.White, 1.22f, new Vector2(1, 0), 1, SpriteEffects.None, 0);
                SB.Draw(Line, StartPoint, null, Color.White, 2.005f, new Vector2(1, 0), 1, SpriteEffects.None, 0);
                SB.Draw(Line, StartPoint, null, Color.White, 2.79f, new Vector2(1, 0), 1, SpriteEffects.None, 0);
                SB.Draw(Line, StartPoint, null, Color.White, 3.575f, new Vector2(1, 0), 1, SpriteEffects.None, 0);
                SB.Draw(Line, StartPoint, null, Color.White, 4.36f, new Vector2(1, 0), 1, SpriteEffects.None, 0);
                SB.Draw(Line, StartPoint, null, Color.White, 5.145f, new Vector2(1, 0), 1, SpriteEffects.None, 0);
                SB.Draw(Line, StartPoint, null, Color.White, 5.93f, new Vector2(1, 0), 1, SpriteEffects.None, 0);

                0.785 Diff
                */

                if (angle > -0.35f && angle < 0.435f)
                {
                    SB.Draw(Rail, StartPoint, null, Color.White, 0.785f * 0, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    for (float i = StartPoint.Y - 16; i >= EndPoint.Y; i = i - 16)
                    {
                        RealEndPoint = new Vector2(StartPoint.X, i - 16);
                        SB.Draw(Rail, new Vector2(StartPoint.X, i), null, Color.White, 0, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    }
                }
                else if (angle > 0.435f && angle < 1.22f)
                {
                    SB.Draw(Rail, StartPoint, null, Color.White, 0.785f * 1, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    for (float i = StartPoint.Y - 8; i >= EndPoint.Y; i = i - 8)
                    {
                        SB.Draw(Rail, new Vector2(StartPoint.Y + StartPoint.X - i, i), null, Color.White, 0.785f, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    }
                }
                else if (angle > 1.22f && angle < 2.005f)
                {
                    SB.Draw(Rail, StartPoint, null, Color.White, 0.785f * 2, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    for (float i = StartPoint.X + 16; i <= EndPoint.X; i = i + 16)
                    {
                        RealEndPoint = new Vector2(i + 16, StartPoint.Y);
                        SB.Draw(Rail, new Vector2(i, StartPoint.Y), null, Color.White, 1.55f, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    }
                }
                else if (angle > 2.005f && angle < 2.79f)
                {
                    SB.Draw(Rail, StartPoint, null, Color.White, 0.785f * 3, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    for (float i = StartPoint.Y + 8; i <= EndPoint.Y; i = i + 8)
                    {
                        SB.Draw(Rail, new Vector2(i - StartPoint.Y + StartPoint.X, i), null, Color.White, 2.355f, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    }
                }
                else if (angle > 2.79f && angle < 3.575f)
                {
                    SB.Draw(Rail, StartPoint, null, Color.White, 0.785f * 4, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    for (float i = StartPoint.Y + 16; i <= EndPoint.Y; i = i + 16)
                    {
                        RealEndPoint = new Vector2(StartPoint.X, i + 16);
                        SB.Draw(Rail, new Vector2(StartPoint.X, i), null, Color.White, 0, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    }
                }
                else if (angle > 3.575f && angle < 4.36f)
                {
                    SB.Draw(Rail, StartPoint, null, Color.White, 0.785f * 5, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    for (float i = StartPoint.Y + 8; i <= EndPoint.Y; i = i + 8)
                    {
                        SB.Draw(Rail, new Vector2(StartPoint.Y - i + StartPoint.X, i), null, Color.White, 3.925f, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    }
                }
                else if(angle > -1.135 && angle < -0.35f)
                {
                    SB.Draw(Rail, StartPoint, null, Color.White, 0.785f * 7, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    for (float i = StartPoint.Y; i >= EndPoint.Y; i = i - 8)
                    {
                        SB.Draw(Rail, new Vector2(i - StartPoint.Y + StartPoint.X , i), null, Color.White, 2.355f, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    }
                }
                else
                {
                    SB.Draw(Rail, StartPoint, null, Color.White, 0.785f * 6, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    for (float i = StartPoint.X - 16; i >= EndPoint.X; i = i - 16)
                    {
                        RealEndPoint = new Vector2(i - 16, StartPoint.Y);
                        SB.Draw(Rail, new Vector2(i, StartPoint.Y), null, Color.White, 1.55f, new Vector2(8, 8), 1, SpriteEffects.None, 0);
                    }
                }
            }
        }

        public static double Angle(Vector2 p1, Vector2 center, Vector2 p2)
        {
            Vector2 transformedP1 = new Vector2(p1.X - center.X, p1.Y - center.Y);
            Vector2 transformedP2 = new Vector2(p2.X - center.X, p2.Y - center.Y);
            double angleToP1 = Math.Atan2(transformedP1.Y, transformedP1.X);
            double angleToP2 = Math.Atan2(transformedP2.Y, transformedP2.X);
            return (angleToP2 - angleToP1) + 1.57d;
        }
    }
}

/*
0.00 ~ 0°
1.57 ~ 90°
3.14 ~ 180°
4,71 ~ 270°
6.28 ~ 360
*/
