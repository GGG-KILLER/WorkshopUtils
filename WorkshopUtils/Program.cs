using System;
using System.Windows.Forms;

namespace WorkshopUtils
{
    internal static class Program
    {
        internal static String APIKey;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main ( )
        {
            Application.EnableVisualStyles ( );
            Application.SetCompatibleTextRenderingDefault ( false );
            using ( var choiceForm = new UI.ChoiceForm ( ) )
                Application.Run ( choiceForm );
        }
    }
}

public static class ISynchronizeInvokeExtensions
{
    public static void InvokeEx<T> ( this T @this, Action<T> action )
        where T : System.ComponentModel.ISynchronizeInvoke
    {
        if ( @this.InvokeRequired )
            @this.Invoke ( action, new Object[] { @this } );
        else
            action?.Invoke ( @this );
    }
}
