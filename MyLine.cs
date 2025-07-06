using MyGame;
using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        //Fields:

        private int _length;

        // Constructors:

        public MyLine(Color clr, int length) : base(clr)
        {
            _length = length;
        }
        public MyLine() : this (Color.Red, 100) { }

        // Methods:

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }

            SplashKit.DrawLine(Color, X, Y, X + _length, Y); 
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(_length);

        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _length = reader.ReadInteger();
        }

        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, 4);
            SplashKit.DrawCircle(Color.Black, X + _length, Y, 4);
        }

        // Properties:

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointOnLine(pt, SplashKit.LineFrom(X, Y, X + _length, Y));
        }
    }
}
