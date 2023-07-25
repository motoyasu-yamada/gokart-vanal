using System;
using System.Windows.Forms;
using gokart_vanal.alfano6;

namespace gokart_vanal
{
  static class Program
  {
    public static UserSettings UserSettings { get; } = new UserSettings();

    /// <summary>
    /// アプリケーションのメイン エントリ ポイントです。
    /// </summary>
    [STAThread]
    static void Main()
    {
      MatLabXrkTest.Test();
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
    }
  }
}