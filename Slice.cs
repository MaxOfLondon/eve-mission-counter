using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace EVE_Mission_Counter
{
  public class Slice : IDisposable
  {
    private Pen borderPen;
    private PathGradientBrush fillBrush;
    private PointF sliceCenterPoint;
    private GraphicsPath path;
    private bool m_disposed;

    public Slice(
      Point center,
      int outerRadius,
      int innerRadius,
      float startAngle,
      float sweepAngle,
      float marginWidth,
      Color borderColor,
      Color fillColor1,
      Color fillColor2)
    {
      RectangleF rectangleF = new RectangleF((float) (outerRadius - center.X), (float) (outerRadius - center.Y), (float) outerRadius, (float) outerRadius);
      RectangleF innerRect = new RectangleF(0.0f, 0.0f, (float) innerRadius, (float) innerRadius);
      Slice.CenterRect(ref innerRect, rectangleF);
      startAngle += marginWidth / 2f;
      sweepAngle -= marginWidth;
      this.path = new GraphicsPath();
      this.path.StartFigure();
      this.path.AddArc(rectangleF, startAngle, sweepAngle);
      this.path.AddArc(innerRect, startAngle + sweepAngle, -sweepAngle);
      this.path.CloseFigure();
      RectangleF bounds = this.path.GetBounds();
      this.sliceCenterPoint = new PointF(bounds.X + bounds.Width / 2f, bounds.Y + bounds.Height / 2f);
      this.CreateFillBrush(fillColor1, fillColor2);
      this.borderPen = new Pen(borderColor);
    }

    ~Slice() => this.Dispose(true);

    public void Draw(Graphics g)
    {
      g.FillPath((Brush) this.fillBrush, this.path);
      g.DrawPath(this.borderPen, this.path);
    }

    private void CreateFillBrush(Color fillColor1, Color FillColor2)
    {
      if (this.fillBrush != null)
        this.fillBrush.Dispose();
      this.fillBrush = new PathGradientBrush(this.path);
      this.fillBrush.CenterPoint = this.sliceCenterPoint;
      this.fillBrush.CenterColor = fillColor1;
      this.fillBrush.SurroundColors = new Color[1]
      {
        FillColor2
      };
      this.fillBrush.SetSigmaBellShape(0.95f);
    }

    public void SetBorderColor(Color borderColor)
    {
      this.borderPen.Dispose();
      this.borderPen = new Pen(borderColor);
    }

    public void SetFillColors(Color centerColor, Color surroundColor) => this.CreateFillBrush(centerColor, surroundColor);

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (this.m_disposed)
        return;
      if (disposing)
      {
        this.fillBrush.Dispose();
        this.borderPen.Dispose();
        this.path.Dispose();
      }
      this.m_disposed = true;
    }

    private static PointF GetPointOnCircle(RectangleF bounds, float angleDeg)
    {
      double num1 = (double) angleDeg * Math.PI / 180.0;
      float num2 = bounds.X + bounds.Width / 2f;
      float num3 = bounds.Y + bounds.Height / 2f;
      return new PointF(num2 + bounds.Width / 2f * (float) Math.Cos(num1), num3 + bounds.Height / 2f * (float) Math.Sin(num1));
    }

    private static void CenterRect(ref RectangleF innerRect, RectangleF outerRect)
    {
      float num1 = outerRect.Width / 2f + outerRect.X;
      float num2 = outerRect.Height / 2f + outerRect.Y;
      innerRect.X = num1 - innerRect.Width / 2f;
      innerRect.Y = num2 - innerRect.Height / 2f;
    }
  }
}
