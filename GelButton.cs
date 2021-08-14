using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace EVE_Mission_Counter
{
  internal class GelButton : Button
  {
    private Color gradientTop = Color.FromArgb((int) byte.MaxValue, 44, 85, 177);
    private Color gradientBottom = Color.FromArgb((int) byte.MaxValue, 153, 198, 241);
    private Color paintGradientTop;
    private Color paintGradientBottom;
    private Color paintForeColor;
    private Rectangle buttonRect;
    private Rectangle highlightRect;
    private int rectCornerRadius;
    private float rectOutlineWidth;
    private int highlightRectOffset;
    private int defaultHighlightOffset;
    private int highlightAlphaTop = (int) byte.MaxValue;
    private int highlightAlphaBottom;
    private Timer animateButtonHighlightedTimer = new Timer();
    private Timer animateResumeNormalTimer = new Timer();
    private bool increasingAlpha;

    [DefaultValue(typeof (Color), "0x2C55B1")]
    [Category("Appearance")]
    [Description("The color to use for the top portion of the gradient fill of the component.")]
    public Color GradientTop
    {
      get => this.gradientTop;
      set
      {
        this.gradientTop = value;
        this.SetPaintColors();
        this.Invalidate();
      }
    }

    [DefaultValue(typeof (Color), "0x99C6F1")]
    [Category("Appearance")]
    [Description("The color to use for the bottom portion of the gradient fill of the component.")]
    public Color GradientBottom
    {
      get => this.gradientBottom;
      set
      {
        this.gradientBottom = value;
        this.SetPaintColors();
        this.Invalidate();
      }
    }

    public override Color ForeColor
    {
      get => base.ForeColor;
      set
      {
        base.ForeColor = value;
        this.SetPaintColors();
        this.Invalidate();
      }
    }

    protected override void OnCreateControl()
    {
      this.SuspendLayout();
      this.SetControlSizes();
      this.SetPaintColors();
      this.InitializeTimers();
      base.OnCreateControl();
      this.ResumeLayout();
    }

    protected override void OnResize(EventArgs e)
    {
      this.SetControlSizes();
      this.Invalidate();
      base.OnResize(e);
    }

    private void SetControlSizes()
    {
      int num = Math.Min(this.ClientRectangle.Width, this.ClientRectangle.Height);
      this.buttonRect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);
      this.rectCornerRadius = Math.Max(1, num / 2);
      this.rectOutlineWidth = (float) Math.Max(1, num / 50);
      this.highlightRect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width - 1, (this.ClientRectangle.Height - 1) / 2);
      this.highlightRectOffset = Math.Max(1, num / 35);
      this.defaultHighlightOffset = Math.Max(1, num / 35);
    }

    private void SetControlSizes_old()
    {
      int num = Math.Min(this.ClientRectangle.Width, this.ClientRectangle.Height);
      this.buttonRect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);
      this.rectCornerRadius = Math.Max(1, num / 10);
      this.rectOutlineWidth = (float) Math.Max(1, num / 50);
      this.highlightRect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width - 1, (this.ClientRectangle.Height - 1) / 2);
      this.highlightRectOffset = Math.Max(1, num / 35);
      this.defaultHighlightOffset = Math.Max(1, num / 35);
    }

    protected override void OnEnabledChanged(EventArgs e)
    {
      if (!this.Enabled)
      {
        this.animateButtonHighlightedTimer.Stop();
        this.animateResumeNormalTimer.Stop();
      }
      this.SetPaintColors();
      this.Invalidate();
      base.OnEnabledChanged(e);
    }

    private void SetPaintColors()
    {
      if (this.Enabled)
      {
        if (SystemInformation.HighContrast)
        {
          this.paintGradientTop = Color.Black;
          this.paintGradientBottom = Color.Black;
          this.paintForeColor = Color.White;
        }
        else
        {
          this.paintGradientTop = this.gradientTop;
          this.paintGradientBottom = this.gradientBottom;
          this.paintForeColor = this.ForeColor;
        }
      }
      else if (SystemInformation.HighContrast)
      {
        this.paintGradientTop = Color.Gray;
        this.paintGradientBottom = Color.White;
        this.paintForeColor = Color.Black;
      }
      else
      {
        int num1 = (int) ((double) this.gradientTop.GetBrightness() * (double) byte.MaxValue);
        this.paintGradientTop = Color.FromArgb(num1, num1, num1);
        int num2 = (int) ((double) this.gradientBottom.GetBrightness() * (double) byte.MaxValue);
        this.paintGradientBottom = Color.FromArgb(num2, num2, num2);
        int num3 = (int) ((double) this.ForeColor.GetBrightness() * (double) byte.MaxValue);
        int num4 = num3 <= (int) sbyte.MaxValue ? num3 + 60 : num3 - 60;
        this.paintForeColor = Color.FromArgb(num4, num4, num4);
      }
    }

    private void InitializeTimers()
    {
      this.animateButtonHighlightedTimer.Interval = 20;
      this.animateButtonHighlightedTimer.Tick += new EventHandler(this.animateButtonHighlightedTimer_Tick);
      this.animateResumeNormalTimer.Interval = 5;
      this.animateResumeNormalTimer.Tick += new EventHandler(this.animateResumeNormalTimer_Tick);
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
      Graphics graphics = pevent.Graphics;
      graphics.SmoothingMode = SmoothingMode.AntiAlias;
      ButtonRenderer.DrawParentBackground(graphics, this.ClientRectangle, (Control) this);
      using (GraphicsPath path = GelButton.RoundedRectangle(this.buttonRect, this.rectCornerRadius, 0))
        graphics.SetClip(path, CombineMode.Replace);
      using (GraphicsPath path = GelButton.RoundedRectangle(this.buttonRect, this.rectCornerRadius, 0))
      {
        using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(this.buttonRect, this.paintGradientTop, this.paintGradientBottom, LinearGradientMode.Vertical))
          graphics.FillPath((Brush) linearGradientBrush, path);
        using (Pen pen = new Pen(this.paintGradientTop, this.rectOutlineWidth))
        {
          pen.Alignment = PenAlignment.Inset;
          graphics.DrawPath(pen, path);
        }
      }
      if (this.IsDefault)
      {
        using (GraphicsPath path = new GraphicsPath())
        {
          path.AddPath(GelButton.RoundedRectangle(this.buttonRect, this.rectCornerRadius, 0), false);
          path.AddPath(GelButton.RoundedRectangle(this.buttonRect, this.rectCornerRadius, this.defaultHighlightOffset), false);
          using (PathGradientBrush pathGradientBrush = new PathGradientBrush(path))
          {
            pathGradientBrush.CenterColor = Color.FromArgb(50, Color.White);
            pathGradientBrush.SurroundColors = new Color[1]
            {
              Color.FromArgb(100, Color.White)
            };
            graphics.FillPath((Brush) pathGradientBrush, path);
          }
        }
      }
      using (GraphicsPath path = GelButton.RoundedRectangle(this.highlightRect, this.rectCornerRadius, this.highlightRectOffset))
      {
        using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(this.highlightRect, Color.FromArgb(this.highlightAlphaTop, Color.White), Color.FromArgb(this.highlightAlphaBottom, Color.White), LinearGradientMode.Vertical))
          graphics.FillPath((Brush) linearGradientBrush, path);
      }
      TextRenderer.DrawText((IDeviceContext) graphics, this.Text, this.Font, this.buttonRect, this.paintForeColor, Color.Transparent, TextFormatFlags.EndEllipsis | TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }

    private static GraphicsPath RoundedRectangle(
      Rectangle boundingRect,
      int cornerRadius,
      int margin)
    {
      GraphicsPath graphicsPath = new GraphicsPath();
      graphicsPath.AddArc(boundingRect.X + margin, boundingRect.Y + margin, cornerRadius * 2, cornerRadius * 2, 180f, 90f);
      graphicsPath.AddArc(boundingRect.X + boundingRect.Width - margin - cornerRadius * 2, boundingRect.Y + margin, cornerRadius * 2, cornerRadius * 2, 270f, 90f);
      graphicsPath.AddArc(boundingRect.X + boundingRect.Width - margin - cornerRadius * 2, boundingRect.Y + boundingRect.Height - margin - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0.0f, 90f);
      graphicsPath.AddArc(boundingRect.X + margin, boundingRect.Y + boundingRect.Height - margin - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90f, 90f);
      graphicsPath.AddLine(boundingRect.X + margin, boundingRect.Y + boundingRect.Height - margin - cornerRadius * 2, boundingRect.X + margin, boundingRect.Y + margin + cornerRadius);
      graphicsPath.CloseFigure();
      return graphicsPath;
    }

    protected override void OnMouseEnter(EventArgs e)
    {
      this.HighlightButton();
      base.OnMouseEnter(e);
    }

    protected override void OnGotFocus(EventArgs e)
    {
      this.HighlightButton();
      base.OnGotFocus(e);
    }

    private void HighlightButton()
    {
      if (!this.Enabled)
        return;
      this.animateResumeNormalTimer.Stop();
      this.animateButtonHighlightedTimer.Start();
    }

    private void animateButtonHighlightedTimer_Tick(object sender, EventArgs e)
    {
      if (this.increasingAlpha)
      {
        if (100 <= this.highlightAlphaBottom)
          this.increasingAlpha = false;
        else
          this.highlightAlphaBottom += 5;
      }
      else if (0 >= this.highlightAlphaBottom)
        this.increasingAlpha = true;
      else
        this.highlightAlphaBottom -= 5;
      this.Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      this.ResumeNormalButton();
      base.OnMouseLeave(e);
    }

    protected override void OnLostFocus(EventArgs e)
    {
      this.ResumeNormalButton();
      base.OnLostFocus(e);
    }

    private void ResumeNormalButton()
    {
      if (!this.Enabled)
        return;
      this.animateButtonHighlightedTimer.Stop();
      this.animateResumeNormalTimer.Start();
    }

    private void animateResumeNormalTimer_Tick(object sender, EventArgs e)
    {
      bool flag = false;
      if (this.highlightAlphaBottom > 0)
      {
        this.highlightAlphaBottom -= 5;
        flag = true;
      }
      if (this.highlightAlphaTop < (int) byte.MaxValue)
      {
        this.highlightAlphaTop += 5;
        flag = true;
      }
      if (!flag)
        this.animateResumeNormalTimer.Stop();
      this.Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs mevent)
    {
      this.PressButton();
      base.OnMouseDown(mevent);
    }

    protected override void OnKeyDown(KeyEventArgs kevent)
    {
      if (kevent.KeyCode == Keys.Space || kevent.KeyCode == Keys.Return)
        this.PressButton();
      base.OnKeyDown(kevent);
    }

    private void PressButton()
    {
      if (!this.Enabled)
        return;
      this.animateButtonHighlightedTimer.Stop();
      this.animateResumeNormalTimer.Stop();
      this.highlightRect.Location = new Point(0, this.ClientRectangle.Height / 2);
      this.highlightAlphaTop = 0;
      this.highlightAlphaBottom = 200;
      this.Invalidate();
    }

    protected override void OnMouseUp(MouseEventArgs mevent)
    {
      this.ReleaseButton();
      if (this.DisplayRectangle.Contains(mevent.Location))
        this.HighlightButton();
      base.OnMouseUp(mevent);
    }

    protected override void OnKeyUp(KeyEventArgs kevent)
    {
      if (kevent.KeyCode == Keys.Space || kevent.KeyCode == Keys.Return)
      {
        this.ReleaseButton();
        if (this.IsDefault)
          this.HighlightButton();
      }
      base.OnKeyUp(kevent);
    }

    protected override void OnMouseMove(MouseEventArgs mevent)
    {
      if (this.Enabled && (mevent.Button & MouseButtons.Left) == MouseButtons.Left && !this.ClientRectangle.Contains(mevent.Location))
        this.ReleaseButton();
      base.OnMouseMove(mevent);
    }

    private void ReleaseButton()
    {
      if (!this.Enabled)
        return;
      this.highlightRect.Location = new Point(0, 0);
      this.highlightAlphaTop = (int) byte.MaxValue;
      this.highlightAlphaBottom = 0;
    }
  }
}
