using Assignment1;
using System.Windows.Forms;

namespace Assignment1
{
    class Assignment1
    {
        // MAIN ENTRY POINT OF APPLICATION
        static void Main(string[] args)
        {
            string title = "Default", name = "Default";
            // Command Line Arguments
            if (args.Length > 0) title = args[0];
            if (args.Length > 1) name = args[1];

            MyForm form = new MyForm(title, name);
            Application.Run(form);

        }
    }
}


