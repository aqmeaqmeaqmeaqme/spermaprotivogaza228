using WinFormsApp2.Data;
using WinFormsApp2.Forms;

namespace WinFormsApp2;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        DatabaseInitializer.Initialize();
        Application.Run(new LoginForm());
    }
}
