using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Mission_Counter
{
  public class frmAccount : Form
  {
    //private IContainer components;
    public TextBox txtXmlHidden;

    public frmAccount() => this.InitializeComponent();

    public string GetXmlSource() => this.txtXmlHidden.Text;

    protected override void Dispose(bool disposing)
    {
      //if (disposing && this.components != null)
      //  this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmAccount));
      this.txtXmlHidden = new TextBox();
      this.SuspendLayout();
      this.txtXmlHidden.Location = new Point(12, 217);
      this.txtXmlHidden.Multiline = true;
      this.txtXmlHidden.Name = "txtXmlHidden";
      this.txtXmlHidden.Size = new Size(444, 306);
      this.txtXmlHidden.TabIndex = 0;
      this.txtXmlHidden.Text = componentResourceManager.GetString("txtXmlHidden.Text");
      this.txtXmlHidden.Visible = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(876, 535);
      this.Controls.Add((Control) this.txtXmlHidden);
      this.Name = nameof (frmAccount);
      this.Text = "Manage Data Sets";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
