using System;
using System.Windows.Forms;

namespace AffinTransformation
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AffinForm form = new AffinForm();
            Application.Run(form);
            
        }
    }
}
