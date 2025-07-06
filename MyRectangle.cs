using MyGame;
using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    public class MyRectangle : Shape
    {
        // Fields: 

        private int _width;
        private int _height;

        //Constructor:

        public MyRectangle (Color clr, float x, float y, int width, int height) : base (clr)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public MyRectangle() : this (Color.Green, 0, 0, 100, 100) { }

        // Methods:

        public override void Draw() // Draws the shape 
        {
            if (Selected)
            {
                DrawOutline();
            }

            SplashKit.FillRectangle(Color, X, Y,
            _width, _height);
        }

        public override void DrawOutline()
        {
            SplashKit.FillRectangle(Color.Black, X - 2, Y - 2,
            _width + 4, _height + 4);
        }

        public override bool IsAt(Point2D pt) // Checks if a given Point2D falls in the range of the rectangle
        {
            return SplashKit.PointInRectangle(pt, SplashKit.RectangleFrom(X, Y, Width, Height)); 
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Rectangle");
            base.SaveTo(writer);
            writer.WriteLine(Width); 
            writer.WriteLine(Height);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Width = reader.ReadInteger();
            Height = reader.ReadInteger();
        }

        // Properties:

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }
    }
}
