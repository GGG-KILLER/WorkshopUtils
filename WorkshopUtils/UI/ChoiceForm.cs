using System;
using System.IO;
using System.Windows.Forms;

namespace WorkshopUtils.UI
{
    public partial class ChoiceForm : Form
    {
        public ChoiceForm ( )
        {
            InitializeComponent ( );
            var apiKey = new FileInfo ( Path.Combine (
                Path.GetDirectoryName ( this.GetType ( ).Assembly.Location ),
                "apikey"
            ) );

            if ( !apiKey.Exists )
            {
                MessageBox.Show ( this, "No 'apikey' file found with the Steam API Key.", "WorkshopUtils", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1 );
                Application.Exit ( );
            }

            using ( FileStream stream = apiKey.OpenRead ( ) )
            using ( var reader = new StreamReader ( stream, System.Text.Encoding.UTF8, false, 4096, true ) )
                Program.APIKey = reader.ReadToEnd ( ).Trim ( );
        }

        private void Button4_Click ( Object sender, EventArgs e )
        {
            using ( var f = new GMAParserForm ( ) )
            {
                f.ShowInTaskbar = false;
                f.ShowDialog ( this );
            }
        }

        private void Button5_Click ( Object sender, EventArgs e )
        {
            using ( var f = new WorkshopDLForm ( ) )
            {
                f.ShowInTaskbar = false;
                f.ShowDialog ( this );
            }
        }
    }
}
