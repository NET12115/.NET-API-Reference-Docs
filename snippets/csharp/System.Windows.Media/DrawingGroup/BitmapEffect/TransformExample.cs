// <SnippetDrawingGroupTransformExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SDKSample
{
    public class TransformExample : Page
    {

        public TransformExample()
        {

            //
            // Create a GeometryDrawing.
            //

            // Define the drawing's contents.
            PathFigure pLineFigure = new PathFigure();
            pLineFigure.StartPoint = new Point(25, 25);
            PolyLineSegment pLineSegment = new PolyLineSegment();
            pLineSegment.Points.Add(new Point(0, 50));
            pLineSegment.Points.Add(new Point(25, 75));
            pLineSegment.Points.Add(new Point(50, 50));
            pLineSegment.Points.Add(new Point(25, 25));
            pLineSegment.Points.Add(new Point(25, 0));
            pLineFigure.Segments.Add(pLineSegment);
            PathGeometry pGeometry = new PathGeometry();
            pGeometry.Figures.Add(pLineFigure);

            GeometryDrawing drawing1 = new GeometryDrawing(
                    Brushes.Lime,
                    new Pen(Brushes.Black, 10),
                    pGeometry
                );

            //
            // Create another GeometryDrawing.
            //
            GeometryDrawing drawing2 = new GeometryDrawing(
                    Brushes.Lime,
                    new Pen(Brushes.Black, 2),
                    new EllipseGeometry(new Point(10, 10), 5, 5)
                );

            // Create the DrawingGroup and add the
            // geometry drawings.
            DrawingGroup aDrawingGroup = new DrawingGroup();
            aDrawingGroup.Children.Add(drawing1);
            aDrawingGroup.Children.Add(drawing2);

            //
            // Create a RotateTransform and apply it to the
            // drawing group.
            //
            RotateTransform rotation = new RotateTransform(
                45, // Angle 
                50, // CenterX
                75  // CenterY
                );
            aDrawingGroup.Transform = rotation;

            // Use an Image control and a DrawingImage to
            // display the drawing.
            DrawingImage aDrawingImage = new DrawingImage(aDrawingGroup);

            // Freeze the DrawingImage for performance benefits.
            aDrawingImage.Freeze();

            Image anImage = new Image();
            anImage.Source = aDrawingImage;
            anImage.Stretch = Stretch.None;
            anImage.HorizontalAlignment = HorizontalAlignment.Left;

            // Create a border around the images and add it to the
            // page.
            Border imageBorder = new Border();
            imageBorder.BorderBrush = Brushes.Gray;
            imageBorder.BorderThickness = new Thickness(1);
            imageBorder.VerticalAlignment = VerticalAlignment.Top;
            imageBorder.HorizontalAlignment = HorizontalAlignment.Left;
            imageBorder.Margin = new Thickness(20);
            imageBorder.Child = anImage;

            this.Background = Brushes.White;
            this.Margin = new Thickness(20);
            this.Content = imageBorder;
        }
    }
}

// </SnippetDrawingGroupTransformExampleWholePage>
