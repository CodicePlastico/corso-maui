using System.Diagnostics;

namespace MauiShowcase.Pages.Views;

// https://github.com/SyncfusionExamples/Draw-Signature-using-GraphicsView-in-.NET-MAUI
public partial class CubeView : ContentView
{
    private readonly CubeDrawable drawable;
    public CubeView()
    {
        InitializeComponent();
        drawable = new CubeDrawable(this);
        Canvas.Drawable = drawable;

        var timer = Application.Current.Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromMilliseconds(16);
        timer.Tick += (s, e) => Canvas.Invalidate();
        timer.Start();
    }

    public class CubeDrawable : IDrawable
    {
        readonly VisualElement owner;
        readonly Stopwatch stopwatch = new Stopwatch();
        const double SPEED_X = 0.05; // rps
        const double SPEED_Y = 0.15; // rps
        const double SPEED_Z = 0.10; // rps
        Point3D[] vertices = new Point3D[0];

        int[][] edges = new int[][] {
            new[] { 0, 1 }, new[] { 1, 2 }, new[] { 2, 3 }, new[] { 3, 0 }, // back face
            new[] { 4, 5 }, new[] { 5, 6 }, new[] { 6, 7 }, new[] { 7, 4 }, // front face
            new[] { 0, 4 }, new[] { 1, 5 }, new[] { 2, 6 }, new[] { 3, 7 } // connecting sides
        };

        public CubeDrawable(VisualElement owner)
        {
            this.owner = owner;
            stopwatch.Start();
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            // Draw background
            canvas.FillColor = owner.BackgroundColor;
            canvas.FillRectangle(dirtyRect);
            canvas.StrokeColor = Colors.White;
            canvas.StrokeSize = 2;

            // calculate the time difference
            var timeDelta = stopwatch.ElapsedMilliseconds;
            stopwatch.Restart();

            double cx = dirtyRect.Width / 2;
            var cy = dirtyRect.Height / 2;
            var cz = 0;
            var size = dirtyRect.Height / 4;

            if (vertices.Length == 0)
            {
                vertices = new Point3D[] {
                    new Point3D(cx - size, cy - size, cz - size),
                    new Point3D(cx + size, cy - size, cz - size),
                    new Point3D(cx + size, cy + size, cz - size),
                    new Point3D(cx - size, cy + size, cz - size),
                    new Point3D(cx - size, cy - size, cz + size),
                    new Point3D(cx + size, cy - size, cz + size),
                    new Point3D(cx + size, cy + size, cz + size),
                    new Point3D(cx - size, cy + size, cz + size)
                };
            }

            // rotate the cube along the z axis
            var angle = timeDelta * 0.001 * SPEED_Z * Math.PI * 2;
            for (int i = 0; i < vertices.Length; i++)
            {
                var v = vertices[i];
                var dx = v.X - cx;
                var dy = v.Y - cy;
                var x = dx * Math.Cos(angle) - dy * Math.Sin(angle);
                var y = dx * Math.Sin(angle) + dy * Math.Cos(angle);
                vertices[i].X = x + cx;
                vertices[i].Y = y + cy;
            }

            // rotate the cube along the x axis
            angle = timeDelta * 0.001 * SPEED_X * Math.PI * 2;
            for (int i = 0; i < vertices.Length; i++)
            {
                var v = vertices[i];
                var dy = v.Y - cy;
                var dz = v.Z - cz;
                var y = dy * Math.Cos(angle) - dz * Math.Sin(angle);
                var z = dy * Math.Sin(angle) + dz * Math.Cos(angle);
                vertices[i].Y = y + cy;
                vertices[i].Z = z + cz;
            }

            // rotate the cube along the y axis
            angle = timeDelta * 0.001 * SPEED_Y * Math.PI * 2;
            for (int i = 0; i < vertices.Length; i++)
            {
                var v = vertices[i];
                var dx = v.X - cx;
                var dz = v.Z - cz;
                var x = dz * Math.Sin(angle) + dx * Math.Cos(angle);
                var z = dz * Math.Cos(angle) - dx * Math.Sin(angle);
                vertices[i].X = x + cx;
                vertices[i].Z = z + cz;
            }

            // draw each edge
            foreach (var edge in edges)
            {
                var x1 = Convert.ToSingle(vertices[edge[0]].X);
                var y1 = Convert.ToSingle(vertices[edge[0]].Y);
                var x2 = Convert.ToSingle(vertices[edge[1]].X);
                var y2 = Convert.ToSingle(vertices[edge[1]].Y);
                canvas.DrawLine(x1, y1, x2, y2);
            }
        }
    }

    public class Point3D
    {
        public Point3D(double x, double y, double z)
        {
            X = x; Y = y; Z = z;
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }

}