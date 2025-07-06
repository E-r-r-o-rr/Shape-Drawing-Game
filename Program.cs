using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle, Circle, Line
        }

        public static void Main()
        {
            Drawing drawing = new Drawing();
            Window window = new Window("Shape Drawer", 800,600); 
            ShapeKind kindToAdd = ShapeKind.Circle;

            do
            {
                SplashKit.ProcessEvents(); // Processes pending events
                SplashKit.ClearScreen(); // Clears the screen 
                drawing.Draw();

                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }

                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;

                    if (kindToAdd == ShapeKind.Rectangle)
                    {
                        MyRectangle newRect = new MyRectangle();
                        newShape = newRect;
                    }

                    else if (kindToAdd == ShapeKind.Circle)
                    {
                        MyCircle newCircle = new MyCircle();
                        newShape = newCircle;   
                    }

                    else
                    {
                        MyLine newLine = new MyLine();
                        newShape = newLine;
                    }

                    newShape.X = SplashKit.MouseX();
                    newShape.Y = SplashKit.MouseY();
                    drawing.AddShape(newShape);
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    drawing.SelectShapesAt(SplashKit.MousePosition());
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    drawing.Background = SplashKit.RandomRGBColor(255);  
                }

                if (SplashKit.KeyTyped(KeyCode.BackspaceKey)|| SplashKit.KeyTyped(KeyCode.DeleteKey))
                {
                    foreach (Shape s in drawing.SelectedShape)
                    {
                        drawing.RemoveShape(s);
                    }
                }

                if (SplashKit.KeyTyped(KeyCode.SKey))
                {
                    drawing.Save("C:\\Users\\deyaa\\Downloads\\Bachelor of engineering\\2023\\Semester 2\\Object Oriented Programming\\Task 5.3C\\TestDrawing.txt");
                }


                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        drawing.Load("C:\\Users\\deyaa\\Downloads\\Bachelor of engineering\\2023\\Semester 2\\Object Oriented Programming\\Task 5.3C\\TestDrawing.txt");
                    } catch(Exception e)
                    {
                        Console.Error.WriteLine("Error loading file: {0}", e.Message);
                    }
                  
                }

                SplashKit.RefreshScreen(); //  Refreshes the screen
             
            }   while (!window.CloseRequested) ;
        }
    }
}
