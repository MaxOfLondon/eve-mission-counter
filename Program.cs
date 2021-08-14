using System;
using System.Windows.Forms;

namespace EVE_Mission_Counter
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new frmMain());
    }
  }
}
