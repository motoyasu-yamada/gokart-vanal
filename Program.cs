using System;
using System.Windows.Forms;

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
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new PlayerWindow());
    }
  }
}