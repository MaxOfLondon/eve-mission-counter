using System;
using System.Drawing;
using System.Windows.Forms;

namespace EVE_Mission_Counter
{
  public class InputBox
  {
    public static DialogResult Show(string title, string promptText, ref string value) => InputBox.Show(title, promptText, ref value, (InputBoxValidation) null);

    public static DialogResult Show(
      string title,
      string promptText,
      ref string value,
      InputBoxValidation validation)
    {
      Form form = new Form();
      Label label = new Label();
      TextBox textBox = new TextBox();
      Button button1 = new Button();
      Button button2 = new Button();
      form.Text = title;
      form.TopMost = true;
      label.Text = promptText;
      textBox.Text = value;
      button1.Text = "OK";
      button2.Text = "Cancel";
      button1.DialogResult = DialogResult.OK;
      button2.DialogResult = DialogResult.Cancel;
      label.SetBounds(9, 20, 372, 13);
      textBox.SetBounds(12, 36, 372, 20);
      button1.SetBounds(228, 72, 75, 23);
      button2.SetBounds(309, 72, 75, 23);
      label.AutoSize = true;
      textBox.Anchor |= AnchorStyles.Right;
      button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      form.ClientSize = new Size(396, 107);
      form.Controls.AddRange(new Control[4]
      {
        (Control) label,
        (Control) textBox,
        (Control) button1,
        (Control) button2
      });
      form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
      form.FormBorderStyle = FormBorderStyle.FixedDialog;
      form.StartPosition = FormStartPosition.CenterScreen;
      form.MinimizeBox = false;
      form.MaximizeBox = false;
      form.AcceptButton = (IButtonControl) button1;
      form.CancelButton = (IButtonControl) button2;
      if (validation != null)
        form.FormClosing += (FormClosingEventHandler) ((sender, e) =>
        {
          if (form.DialogResult != DialogResult.OK)
            return;
          string text = validation(textBox.Text);
          if (!(e.Cancel = text != ""))
            return;
          int num = (int) MessageBox.Show((IWin32Window) form, text, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          textBox.Focus();
        });
      DialogResult dialogResult = form.ShowDialog();
      value = textBox.Text;
      return dialogResult;
    }
  }
}
