using IntegrationClient.WinForms.Forms;

namespace IntegrationClient.WinForms;

internal static class Program
{
    // [STAThread] é obrigatório em apps WinForms: componentes visuais do Windows
    // (drag-and-drop, clipboard, etc.) exigem que a thread principal rode em
    // modo "Single Threaded Apartment". Sem isso, algumas coisas quebram silenciosamente.
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // Run() abre o Form e mantém a aplicação viva até essa janela ser fechada.
        Application.Run(new MainForm());
    }
}
