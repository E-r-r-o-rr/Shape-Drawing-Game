﻿using MyGame;
using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace ShapeDrawer
{
    public class Drawing 
    {
       //  Fields:

       private readonly List<Shape> _shapes; 
       private Color _background; 

        // Constructor: 
       
       public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }

        public Drawing() : this (Color.White) // Default constructor
        {
            // other steps could go here…
        }

       // Methods:

        public void AddShape (Shape shape) 
        {
            _shapes.Add(shape);
        }

        public void RemoveShape (Shape shape)
        {
            _shapes.Remove(shape);
        }

        public void Draw()
        {
            SplashKit.ClearScreen(_background);

            foreach (Shape shape in _shapes)
            {
                shape.Draw();
            }
        }

        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                if (s.IsAt(pt))
                {
                    s.Selected = true;
                }

                else
                {
                    s.Selected = false;
                }
            }
        }

        public void Save(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            writer.WriteColor(_background);
            writer.WriteLine(ShapeCount);

            foreach (Shape s in _shapes)
            {
                s.SaveTo(writer); 
            }

            writer.Close();
        }
        
        public void Load(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            Background = reader.ReadColor();
            int count = reader.ReadInteger();
            _shapes.Clear();

            try
            {
                for (int i = 0; i < count; i++)
                {
                    string kind = reader.ReadLine();
                    Shape s = null; 
                 
                    switch (kind)
                    {
                        case "Rectangle":
                            s = new MyRectangle();
                            break;
                        case "Circle":
                            s = new MyCircle();
                            break;
                        case "Line":
                            s = new MyLine(); 
                            break;
                        default:
                            throw new InvalidDataException("Unknown shape kind: " + kind);
                    }

                    s.LoadFrom(reader);
                    AddShape(s);
                }
            }
            finally
            {
                reader.Close();
            }
        }

        // Properties:

        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }

        public int ShapeCount
        {
            get { return _shapes.Count; }
        }

        public List<Shape>  SelectedShape
        {
            get
            {
                List<Shape> result = new List<Shape>();
                foreach (Shape s in _shapes)
                {
                    if(s.Selected)
                    {
                        result.Add(s);
                    }
                }
                return result;
            }
        }
    }
}
